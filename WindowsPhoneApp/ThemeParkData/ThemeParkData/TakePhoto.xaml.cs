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

namespace ThemeParkData
{
    public partial class TakePhoto : PhoneApplicationPage
    {
        int parkID = 0;
        string parkName = string.Empty;
        CameraCaptureTask cameraCaptureTask;
        private byte[] imageBytes;

        public TakePhoto()
        {
            InitializeComponent();
            cameraCaptureTask = new CameraCaptureTask();
            cameraCaptureTask.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);  
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

        }

        private void savePhotoButton_click(object sender, RoutedEventArgs e)
        {
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
                MessageBox.Show(e.Result.ToString(), "Success", MessageBoxButton.OK);
            }
            else
            {
                //It Failed :'(
                MessageBox.Show("Problem uploading photo, please try again", "Unsuccessful", MessageBoxButton.OK);
            }

        }

        
  


    }
}