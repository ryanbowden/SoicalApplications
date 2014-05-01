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
            //Get theme Park Names
        }

        private void InitializeSettings()
        {
            string UserID;
            string UserName;
            // add logic here to check isolated storage/protected class contains valid for userid/token
            //This will check to see if the person has logged in before
            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue("UserID", out UserID) && IsolatedStorageSettings.ApplicationSettings.TryGetValue("UserName", out UserName))
            {
                PersonName.Text = "Welcome " + UserName;
            }
            else
            {
                //Should not get here!
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //get the Theme park Data
            WebClient ThemeParksNames = new WebClient();
            ThemeParksNames.DownloadStringCompleted +=ThemeParksNames_DownloadStringCompleted;
            ThemeParksNames.DownloadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/viewthemeparks?format=xml"));

        }

        void ThemeParksNames_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //Now need to get that data and display it on the page
            //check for errors
            if (e.Error == null)
            {
                //No errors have been passed now need to take this file and parse it 
                //Its in XML format
                XDocument xdox = XDocument.Parse(e.Result);

            }
            else
            {
                //There an Error
            }
        }



    }
}