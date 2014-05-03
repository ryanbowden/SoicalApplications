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
    }
}
