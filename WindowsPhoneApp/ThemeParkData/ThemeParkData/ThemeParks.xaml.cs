using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Xml.Linq;

namespace ThemeParkData
{
    public partial class ThemeParks : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public ThemeParks()
        {
            InitializeComponent();
            //Get user Settings
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            //First set up the Strings to get User details
            string UserID;
            string UserName;
            // add logic here to check isolated storage/protected class contains valid for userid/token
            //This will check to see if the person has logged in before
            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue("UserID", out UserID) && IsolatedStorageSettings.ApplicationSettings.TryGetValue("UserName", out UserName))
            {
                //Add this to the page to personaise the page for them
                PersonName.Text = "Welcome " + UserName;
            }
            else
            {
                //Should not be here!
                //Proberly should send uers back to log in screen?
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //get the Theme park Data
            try
            {
                WebClient ThemeParksNames = new WebClient();
                ThemeParksNames.DownloadStringCompleted += ThemeParksNames_DownloadStringCompleted;
                ThemeParksNames.DownloadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/viewthemeparks?format=xml"));
            }
            catch
            {
                MessageBox.Show("Network Failure");
            }
        }

        void ThemeParksNames_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //Now need to get that data and display it on the page
            //check for errors
            if (e.Error == null)
            {
                try
                {
                    //No errors have been passed now need to take this file and parse it 
                    //Its in XML format
                    XDocument xdox = XDocument.Parse(e.Result);
                    //need a list for them to be put in to
                    List<ThemeParksClass> ParkList = new List<ThemeParksClass>();
                    XNamespace ns = "http://schemas.datacontract.org/2004/07/WCFServiceWebRole1";
                    //Now need to get every element and add it to the list
                    foreach (XElement item in xdox.Descendants(ns + "ThemeParkList"))
                    {
                        ThemeParksClass content = new ThemeParksClass();
                        content.ID = Convert.ToInt32(item.Element(ns+"id").Value);
                        content.ThemeParkName = item.Element(ns+"name").Value.ToString();
                        ParkList.Add(content);
                    }

                    parkList.ItemsSource = ParkList.ToList();
                }
                catch (Exception ex)
                {
                    txtBlockErrors.Text = ex.Message;
                }
            }
            else
            {
                //There an Error
            }
        }

        private void ThemeParkClick(object sender, SelectionChangedEventArgs e)
        {
            //Send to the Page of photos
            //check is selcted item is null!
            if (parkList.SelectedItem == null)
            {
                //message box removed as everytiem someone came back to this page this fires. so message box would get annoying. 
                //MessageBox.Show("Error");
                return;
            }
            //we need to get the park ID and Name
            int parkID = (parkList.SelectedItem as ThemeParksClass).ID;
            string parkName = (parkList.SelectedItem as ThemeParksClass).ThemeParkName;
            NavigationService.Navigate(new Uri("/photos.xaml?pID=" + parkID + "&pName=" + parkName, UriKind.Relative));
        }
    }
}