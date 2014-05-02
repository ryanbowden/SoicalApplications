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
using System.Configuration;
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

        public string UploadImage(string FileName, byte[] sentImage)
        {
            //Get the Image and add it to the blog.
            //Need a string to keep the url to sent back
            String bloburl;
            try
            {
                //Get the Image and add it to the blog.
                //Receive image as a stream
                Stream imageStream = new MemoryStream(sentImage);

                //Now connect the cloud storage
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("AzureStorage"));

                //Create a new instance of the blob storage client
                CloudBlobClient bloblClient = storageAccount.CreateCloudBlobClient();

                //Container for photos
                CloudBlobContainer container = bloblClient.GetContainerReference("themeparks");
                //if it does not excist create it
                container.CreateIfNotExists();

                // Set the permissions for your blob container
                BlobContainerPermissions containerPermissions = new BlobContainerPermissions();
                // Set the access permission of your container to 'public' - if you want to use advanced shared access keys for security then you need to do this in your own time, it's worth extra marks!
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(containerPermissions);

                // Retrieve a blobname reference for the new image you want to upload, we create a directory called /images in our blob container
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(string.Format("{0}/{1}", "images", FileName + ".jpg"));

                // Create or overwrite the blob with the image data
                blockBlob.UploadFromStream(imageStream);
                bloburl = blockBlob.Uri.ToString();
            }
            catch(Exception ex)
            {
                return "Failed"+ ex.Message;
            }
            return bloburl;
        }
       
    }
}
