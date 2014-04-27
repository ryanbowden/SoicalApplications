using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ThemeParkData.Resources;
using Microsoft.WindowsAzure.MobileServices;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Security.Cryptography;


namespace ThemeParkData
{
    public partial class MainPage : PhoneApplicationPage
    {
        // new instance of AMS authenticated user

        private MobileServiceUser user;

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // add logic here to check isolated storage/protected class contains valid for userid/token
            await Authenticate();
            // navigate to secure area in your app when authenticated
            NavigationService.Navigate(new Uri("/views/success.xaml", UriKind.Relative));
        }

        // Constructor

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private async System.Threading.Tasks.Task Authenticate()
        {
            // authentic user
            while (user == null)
            {
                string message;
                try
                {
                    user = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                    message =
                        string.Format("You are now logged in - {0}", user.UserId);
                    // use isolated storage/protectedclass to save userid/token
                    //Now to add it to isolated storage

                }

                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                }

                MessageBox.Show(message);
            }
        }
    }
}