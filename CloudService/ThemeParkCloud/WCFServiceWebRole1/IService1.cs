using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //get Theme Parks Data
        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Xml,
         BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "viewthemeparks?format=xml")]
        ThemeParkList[] viewThemeParksJson();

        //Upload a Picture to a Theme Park
        [OperationContract]
        string UploadImage(string FileName, byte[] sentImage);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ThemeParkList
    {
        [DataMember]
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        private string name;
        public string Name
        {
            get { return name;}
            set{ name = value;}
        }
    }
}
