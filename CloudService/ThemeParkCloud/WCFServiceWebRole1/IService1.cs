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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "viewthemeparks?format=xml")]
        ThemeParkList[] viewThemeParksJson();

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,UriTemplate = "users?sid={sid}&name={Name}")]
        bool addProfile(string sid, string name);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,BodyStyle = WebMessageBodyStyle.Bare,UriTemplate = "viewusers?format=xml&sid={sid}")]
        Users[] viewProfilesXML(string sid);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "photoadd?uid={uid}&tpid={tpid}&photourl={photourl}")]
        bool addPhoto(int uid, int tpid, string photourl);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "viewphotos?format=xml&themeparkid={themeparkid}")]
        Photos[] viewThemeParkPhotosXML(string themeparkid);
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

    public class Users
    {
        [DataMember]
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        private string serviceid;
        public string ServiceID
        {
            get { return serviceid; }
            set { serviceid = value; }
        }

        [DataMember]
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }

    public class Photos
    {
        [DataMember]
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        private int userid;
        public int UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        [DataMember]
        private int themeparkid;
        public int ThemeParkID
        {
            get { return themeparkid; }
            set { themeparkid = value; }
        }

        [DataMember]
        private string photourl;
        public string PhotoURL
        {
            get { return photourl; }
            set { photourl = value; }
        }
    }
}
