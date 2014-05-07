using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;

namespace ThemeParkData
{
    public partial class photos : PhoneApplicationPage
    {
        //get/clean these strings
        int parkID = 0;
        string parkName = string.Empty;

        public photos()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }


        private void ThemeParkPhotos_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    //No errors have been passed now need to take this file and parse it 
                    //Its in XML format
                    XDocument xdox = XDocument.Parse(e.Result);
                    //need a list for them to be put in to
                    List<Photos> themeparkPhoto = new List<Photos>();
                    themeparkPhoto.Clear();
                    XNamespace ns = "http://schemas.datacontract.org/2004/07/WCFServiceWebRole1";
                    //Now need to get every element and add it to the list
                    foreach (XElement item in xdox.Descendants(ns + "Photos"))
                    {
                        Photos content = new Photos();
                        content.ID = Convert.ToInt32(item.Element(ns + "ID").Value);
                        content.PhotoURL = Convert.ToString(item.Element(ns + "PhotoURL").Value);
                        //content.ID = Convert.ToInt32(item.Element(ns + "id").Value);
                        //content.ThemeParkName = item.Element(ns + "name").Value.ToString();
                        themeparkPhoto.Add(content);
                    }
                    ThemeParkPhoto.ItemsSource = null;
                    ThemeParkPhoto.ItemsSource = themeparkPhoto.ToList();
                    //Delete all the stuff
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //There an Error
            }
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
                PageName.Text = parkName;
                GetThemeParkPhotos();
            }
        }


        public void GetThemeParkPhotos()
        {

            WebClient ThemeParkPhotos = new WebClient();
            ThemeParkPhotos.DownloadStringCompleted += ThemeParkPhotos_DownloadStringCompleted;
            ThemeParkPhotos.DownloadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/viewphotos?format=xml&themeparkid=" + parkID));
            //MessageBox.Show("Test if this works"+parkID);
        }

        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBarIconButton AddButton = new ApplicationBarIconButton();
            AddButton.IconUri = new Uri("/Images/add.png", UriKind.Relative);
            AddButton.Text = "Add Photo";
            ApplicationBar.Buttons.Add(AddButton);
            AddButton.Click +=AddButton_Click;
            //Dont add refresh button as it does not work at this time :(
            /*ApplicationBarIconButton RefreshButton = new ApplicationBarIconButton();
            RefreshButton.IconUri = new Uri("/Images/refresh.png", UriKind.Relative);
            RefreshButton.Text = "Refresh";
            ApplicationBar.Buttons.Add(RefreshButton);
            RefreshButton.Click += RefreshButton_Click;*/
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GetThemeParkPhotos();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //need to send them to add a photo page with details.

            NavigationService.Navigate(new Uri("/TakePhoto.xaml?pID=" + parkID + "&pName=" + parkName, UriKind.Relative));

  
        }
    }
}