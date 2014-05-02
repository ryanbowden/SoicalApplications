using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //This is to get the data that was passed from the home screen to which song to use!
            base.OnNavigatedTo(e);

            //get/clean these strings
            int parkID = 0;
            string parkName = string.Empty;

            if ((NavigationContext.QueryString["pID"] == string.Empty) || (NavigationContext.QueryString["pName"] == string.Empty))
            {
                //if not show message box. 
                MessageBox.Show("Empty Vaules have been sent, Please got back and try again");
            }
            else
            {
                parkID = Convert.ToInt32(NavigationContext.QueryString["pID"]);
                parkName = NavigationContext.QueryString["pName"].ToString();
                PageName.Text = parkID.ToString()+" : " + parkName;
            }
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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //need to send them to add a photo page with details.

            NavigationService.Navigate(new Uri("/TakePhoto.xaml?pID=" + parkID + "&pName=" + parkName, UriKind.Relative));

  
        }
    }
}