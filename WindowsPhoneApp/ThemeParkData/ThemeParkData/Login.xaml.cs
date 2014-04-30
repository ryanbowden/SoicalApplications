using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using System.IO.IsolatedStorage;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ThemeParkData
{
    public partial class Login : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        // new instance of AMS authenticated user

        private MobileServiceUser user;
        public Login()
        {
            InitializeComponent();
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
                    string UserId = user.UserId;
                    //
                    message = string.Format("You are now logged in - {0}", user.UserId);
                    //Dont display unless testing!
                    //MessageBox.Show(message);
                    //use isolated storage/protectedclass to save useridtoken
                    var result = await App.MobileService.InvokeApiAsync("facebookname", HttpMethod.Get, null);
                    string json = result.ToString();
                    //parse the json
                    dynamic jsonParse = JObject.Parse(json);
                    string UserName = result["name"].ToString();
                    //export data for testing purposes.
                    //facebookdata.Text = "Name = " + UserName;
                    IsolatedStorageSettings.ApplicationSettings["UserID"] = UserId;
                    IsolatedStorageSettings.ApplicationSettings["UserName"] = UserName;
                }
                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                    MessageBox.Show(message);
                }
            }
            NavigationService.Navigate(new Uri("/ThemeParks.xaml", UriKind.Relative));
        }

        async private void but_Facebook(object sender, RoutedEventArgs e)
        {
            await Authenticate();
        }

        
    }
}