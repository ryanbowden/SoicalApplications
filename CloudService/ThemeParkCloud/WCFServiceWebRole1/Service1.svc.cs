using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core;
using System.IO;
using System.Collections.Specialized;


namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public ThemeParkList[] viewThemeParksJson()
        {
            //Need to get list of Theme parks and return it in Json.
            // get the connections string stored in the web.config file as a string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            // create  new sql connections using the connection string
            SqlConnection thisConnection = new SqlConnection(connectionString);
            //Create a temp List to hold the data
            List<ThemeParkList> themeparks = new List<ThemeParkList>();
            
            try
            {
                //Sql Command
                SqlCommand getThemeParks = thisConnection.CreateCommand();
                //Open SQL Command
                thisConnection.Open();
                string sql = "SELECT ID,Name FROM ThemeParks";

                getThemeParks.CommandText = sql;

                //Create a SQL data adapter 
                SqlDataAdapter da = new SqlDataAdapter(getThemeParks);
                //Create a new Dataset 
                DataSet ds = new DataSet();
                da.Fill(ds, "ThemeParks");

                //Now get every row and 

                foreach (DataRow dr in ds.Tables["ThemeParks"].Rows)
                {
                    themeparks.Add(new ThemeParkList()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr[1])
                    });
                }
            }
            catch(Exception)
            {
                
            }
            finally
            {
                thisConnection.Close();
            }

            return themeparks.ToArray();
        }

        public bool addProfile(string sid, string name)
        {

            // code to add a new user profile to SQL database
            // creates a new instance of our database objects (user table in this case)

            using (var context = new ThemeParkData_Entities())
            {
                // add a new object (or row) to our user profile table
                context.Users.Add(new User()
               // bind each database column to the parameters we pass in our method
               // guid, firstname, surname, and email
                {
                    ServiceID = sid,
                    Name = name,
                });

                // commit changes to the user profile table
                context.SaveChanges();
                return true;
            }
        }

        public Users[] viewProfilesXML(string sid)
        {
            // get the connections string stored in the web.config file as a string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            // create  new sql connections using the connection string
            SqlConnection thisConnection = new SqlConnection(connectionString);
            // create a new sql command called getUsers
            SqlCommand getUsers = thisConnection.CreateCommand();
            // create a temp list to store the rows of users returned from the database
            List<Users> users = new List<Users>();
            // open the sql connection and construct the select query
            thisConnection.Open();
            string sql = "select * from Users where ServiceID=@sid";
            // paramertise your query to stop sql injections!
            getUsers.Parameters.AddWithValue("@sid", sid);
            getUsers.CommandText = sql;
            // create an sql data adapter using the getUsers query
            SqlDataAdapter da = new SqlDataAdapter(getUsers);
            // create a new dataset containing the rows returned from the user_profile table
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            // for every row returned call our DataContract in IService1.cs
            foreach (DataRow dr in ds.Tables["Users"].Rows)
            {
                users.Add(new Users()
                {
                    Id = Convert.ToInt32(dr[0]),
                    ServiceID = Convert.ToString(dr[1]),
                    Name = Convert.ToString(dr[2]),
                });
            }

            //Return data for XML output
            thisConnection.Close();
            return users.ToArray();
        }

        public Photos[] viewThemeParkPhotosXML(string themeparkid)
        {
            // get the connections string stored in the web.config file as a string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            // create  new sql connections using the connection string
            SqlConnection thisConnection = new SqlConnection(connectionString);
            // create a new sql command called getUsers
            SqlCommand getUsers = thisConnection.CreateCommand();
            // create a temp list to store the rows of users returned from the database
            List<Photos> Photo = new List<Photos>();
            // open the sql connection and construct the select query
            thisConnection.Open();
            string sql = "select * from Photos where ThemeParkID=@themeparkid";
            // paramertise your query to stop sql injections!
            getUsers.Parameters.AddWithValue("@themeparkid", themeparkid);
            getUsers.CommandText = sql;
            // create an sql data adapter using the getUsers query
            SqlDataAdapter da = new SqlDataAdapter(getUsers);
            // create a new dataset containing the rows returned from the user_profile table
            DataSet ds = new DataSet();
            da.Fill(ds, "Photos");
            // for every row returned call our DataContract in IService1.cs
            foreach (DataRow dr in ds.Tables["Photos"].Rows)
            {
                Photo.Add(new Photos()
                {
                    ID = Convert.ToInt32(dr[0]),
                    UserID = Convert.ToInt32(dr[1]),
                    ThemeParkID = Convert.ToInt32(dr[2]),
                    PhotoURL = Convert.ToString(dr[3])
                });
            }
            //Return data for XML output
            thisConnection.Close();
            return Photo.ToArray();
        }

        public bool addPhoto(int uid, int tpid, string photourl)
        {
            // code to add a new user profile to SQL database
            // creates a new instance of our database objects (user table in this case)
            using (var context = new ThemeParkData_Entities())
            {
                // add a new object (or row) to our user profile table
                context.Photos.Add(new Photo()
                // bind each database column to the parameters we pass in our method
                // guid, firstname, surname, and email
                {
                    UserID = Convert.ToInt32(uid),
                    ThemeParkID = Convert.ToInt32(tpid),
                    PhotoURL = photourl
                });

                // commit changes to the user profile table
                context.SaveChanges();
                return true;
            }
        }
    }
}
