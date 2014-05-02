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

namespace ThemeParkData
{
    public partial class TakePhoto : PhoneApplicationPage
    {
        int parkID = 0;
        string parkName = string.Empty;
        public TakePhoto()
        {
            InitializeComponent();
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

        }

        private void choosePhotoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void savePhotoButton_click(object sender, RoutedEventArgs e)
        {

        }


    }
}