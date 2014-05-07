using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Xna.Framework.Media;
using ThemeParkData.ThemeParkPhoto_Service;
using System.Xml.Linq;

namespace ThemeParkData
{
    public partial class TakePhoto : PhoneApplicationPage
    {
        int parkID = 0;
        int UserID;
        string parkName = string.Empty;
        CameraCaptureTask cameraCaptureTask;
        private byte[] imageBytes;
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public TakePhoto()
        {
            InitializeComponent();
            cameraCaptureTask = new CameraCaptureTask();
            cameraCaptureTask.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);


            string UserId = IsolatedStorageSettings.ApplicationSettings["UserID"].ToString();
            WebClient userProfiles = new WebClient();
            userProfiles.DownloadStringCompleted += userProfiles_DownloadStringCompleted;
            userProfiles.DownloadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/viewusers?format=xml&sid=" + UserId));
        }

        private void userProfiles_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                XDocument xdoc = XDocument.Parse(e.Result);
                // Create new list for string items in TwitterItem class
                List<Users> contentList = new List<Users>();
                // For each user profile  'User' read in downloaded xml file add it to list
                // Use linq query to find each status in xml file
                // remove namespace from xml response, yours may be different!
                XNamespace ns = "http://schemas.datacontract.org/2004/07/WCFServiceWebRole1";

                foreach (XElement item in xdoc.Descendants(ns + "Users"))
                {
                    UserID = Convert.ToInt32(item.Element(ns + "Id").Value);
                }
            }
            catch
            {
                //somethign went wrong.
            }
        }

        private void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            // set captured photo to image control
            BitmapImage bitmap = new BitmapImage();
            bitmap.SetSource(e.ChosenPhoto);
            imgTakenPicture.Source = bitmap;

            // enable save/upload buttons,'add to hub' checkbox and filename textbox
            btnSavePicture.IsEnabled = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //This is to get the data that was passed from the home screen to which song to use!
            base.OnNavigatedTo(e);

            if ((NavigationContext.QueryString["pID"] == string.Empty) || (NavigationContext.QueryString["pName"] == string.Empty))
            {
                //if not show message box. 
                MessageBox.Show("Empty Vaules have been sent, Please got back and try again");
            }
            else
            {
                parkID = Convert.ToInt32(NavigationContext.QueryString["pID"]);
                parkName = NavigationContext.QueryString["pName"].ToString();
                ParkDetails.Text = "Park you are adding a Photo to is - "  + parkName;
            }
        }

        private void capturePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            // Launch photo capture task
            cameraCaptureTask.Show();
        }

        private void choosePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooserTask;
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            photoChooserTask.Show();
        }

        private void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage ChosenImage;
                ChosenImage = new System.Windows.Media.Imaging.BitmapImage();
                ChosenImage.SetSource(e.ChosenPhoto);
                imgTakenPicture.Source = ChosenImage;

                btnSavePicture.IsEnabled = true;

            }
        }

        private void savePhotoButton_click(object sender, RoutedEventArgs e)
        {
            //First disable all the buttons
            btnSavePicture.IsEnabled = false;
            capturePhotoButton.IsEnabled = false;
            choosePhotoButton.IsEnabled = false;
            //Show progress bar so users know something happening
            progressbar.Visibility = System.Windows.Visibility.Visible;

            try
            {
                // create new writeable image and set it's value to our image on screen
                WriteableBitmap bmp = new WriteableBitmap((BitmapSource)imgTakenPicture.Source);

                // create new byte array and read our image soure into it;
                byte[] byteArray = new byte[4096];

                using (MemoryStream stream = new MemoryStream())
                {
                    bmp.SaveJpeg(stream, bmp.PixelWidth, bmp.PixelHeight, 0, 80);
                    byteArray = stream.ToArray();
                }
                //Need to make a filename for this image
                Guid guid = Guid.NewGuid();
                //Done ;)
                string filename = guid + "-" + parkID;

                Service1Client svc = new Service1Client();
                svc.UploadImageCompleted += svc_UploadImageCompleted;
                svc.UploadImageAsync(filename, byteArray);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        // code to launch when image data has been uploaded to server, can return error so handle it
        private void svc_UploadImageCompleted(object sender, UploadImageCompletedEventArgs e)
        {
            //check if uploaded 
            if (e.Error == null)
            {
                //It Worked :D
                //Now need to add the photo to the database and save it.

                //MessageBox.Show(e.Result.ToString(), "Success", MessageBoxButton.OK);
                //Need the URl the picture is located at
                string URL = e.Result.ToString();
                //now the theme park ID
                int ThemeParkID = parkID;
                //Now need the User ID that will be added to the system.
                WebClient addPhoto = new WebClient();
                addPhoto.UploadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/photoadd?uid=" + UserID + "&tpid=" + ThemeParkID + "&photourl=" + URL), "POST");
                addPhoto.UploadStringCompleted += addPhoto_UploadStringCompleted;
            }
            else
            {
                //It Failed :'(
                MessageBox.Show(e.Error.Message, "Unsuccessful", MessageBoxButton.OK);
            }
        }

        private void addPhoto_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Photo added!", "Success", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/photos.xaml?pID=" + parkID + "&pName=" + parkName, UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Issues With Adding to Database", "Unsuccessful", MessageBoxButton.OK);
                //Enable all the buttons
                btnSavePicture.IsEnabled = true;
                capturePhotoButton.IsEnabled = true;
                choosePhotoButton.IsEnabled = true;
                //Show progress bar so users know something happening
                progressbar.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

  


    }
}