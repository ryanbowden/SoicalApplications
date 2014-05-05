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
using System.Xml.Linq;

namespace ThemeParkData
{
    public partial class Login : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        // new instance of AMS authenticated user
        string UserId;
        string UserName;

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
                    UserId = user.UserId;
                    //
                    message = string.Format("You are now logged in - {0}", user.UserId);
                    //Dont display unless testing!
                    //MessageBox.Show(message);
                    //use isolated storage/protectedclass to save useridtoken
                    var result = await App.MobileService.InvokeApiAsync("facebookname", HttpMethod.Get, null);
                    string json = result.ToString();
                    //parse the json
                    dynamic jsonParse = JObject.Parse(json);
                    UserName = result["name"].ToString();
                    //export data for testing purposes.
                    //facebookdata.Text = "Name = " + UserName;
                    IsolatedStorageSettings.ApplicationSettings["UserID"] = UserId;
                    IsolatedStorageSettings.ApplicationSettings["UserName"] = UserName;

                    //Need to check whether a user already added and if not add
                    WebClient userProfiles = new WebClient();
                    userProfiles.DownloadStringCompleted += userProfiles_DownloadStringCompleted;
                    userProfiles.DownloadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/viewusers?format=xml&sid=" + UserId));
                }
                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                    MessageBox.Show(message);
                }
            }
            NavigationService.Navigate(new Uri("/ThemeParks.xaml", UriKind.Relative));
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
                int users = 0;
                foreach (XElement item in xdoc.Descendants(ns + "Users"))
                {
                    //Should not run at all!
                    //unless their is a user already has an account.
                    users = users+1;

                }

                if (users > 0)
                {
                    //user Account already saved
                    //Do not want to add the account again.
                }
                else
                {
                    //user account not already added
                    //Add user details to the database
                    WebClient addProfile = new WebClient();
                    addProfile.UploadStringAsync(new Uri("http://themeparkcloud.cloudapp.net/Service1.svc/users?sid=" + UserId + "&name=" + UserName), "POST");
                    addProfile.UploadStringCompleted += addProfile_UploadStringCompleted;
                }
            }
            // display message in case of network error
            catch (Exception error)
            {
                MessageBox.Show("A network error has occured, please try again!");
                Console.WriteLine("An error occured:" + error);
            }
        }

        private void addProfile_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            //Check whether it worked or not. 
            if (e.Error == null)
            {
                MessageBox.Show("Profile added!", "Success", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Problem adding profile", "Unsuccessful", MessageBoxButton.OK);
                Console.WriteLine("An error occured:" + e.Error);
            }
        }

        async private void but_Facebook(object sender, RoutedEventArgs e)
        {
            await Authenticate();
        }

        
    }
}