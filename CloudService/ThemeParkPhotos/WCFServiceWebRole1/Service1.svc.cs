using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
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
            catch (Exception ex)
            {
                return "Failed: " + ex.Message + "| Full Message: " + ex.ToString();
            }
            return bloburl;
        }
    }
}
