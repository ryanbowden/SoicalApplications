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
            string UserID;
            string UserName;
            // add logic here to check isolated storage/protected class contains valid for userid/token
            //This will check to see if the person has logged in before
            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue("UserID", out UserID) && IsolatedStorageSettings.ApplicationSettings.TryGetValue("UserName", out UserName))
            {
                txtblock_name.Text = "Welcome " + UserName;
            }
            else
            {
                //Should not get here!
            }
        }

    }
}