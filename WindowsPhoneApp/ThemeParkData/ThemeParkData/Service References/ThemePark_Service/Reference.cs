﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace ThemeParkData.ThemePark_Service {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ThemeParkList", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1")]
    public partial class ThemeParkList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ThemePark_Service.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/viewThemeParksJson", ReplyAction="http://tempuri.org/IService1/viewThemeParksJsonResponse")]
        System.IAsyncResult BeginviewThemeParksJson(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList> EndviewThemeParksJson(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/UploadImage", ReplyAction="http://tempuri.org/IService1/UploadImageResponse")]
        System.IAsyncResult BeginUploadImage(string FileName, byte[] sentImage, System.AsyncCallback callback, object asyncState);
        
        string EndUploadImage(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ThemeParkData.ThemePark_Service.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class viewThemeParksJsonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public viewThemeParksJsonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UploadImageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UploadImageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ThemeParkData.ThemePark_Service.IService1>, ThemeParkData.ThemePark_Service.IService1 {
        
        private BeginOperationDelegate onBeginviewThemeParksJsonDelegate;
        
        private EndOperationDelegate onEndviewThemeParksJsonDelegate;
        
        private System.Threading.SendOrPostCallback onviewThemeParksJsonCompletedDelegate;
        
        private BeginOperationDelegate onBeginUploadImageDelegate;
        
        private EndOperationDelegate onEndUploadImageDelegate;
        
        private System.Threading.SendOrPostCallback onUploadImageCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<viewThemeParksJsonCompletedEventArgs> viewThemeParksJsonCompleted;
        
        public event System.EventHandler<UploadImageCompletedEventArgs> UploadImageCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ThemeParkData.ThemePark_Service.IService1.BeginviewThemeParksJson(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginviewThemeParksJson(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList> ThemeParkData.ThemePark_Service.IService1.EndviewThemeParksJson(System.IAsyncResult result) {
            return base.Channel.EndviewThemeParksJson(result);
        }
        
        private System.IAsyncResult OnBeginviewThemeParksJson(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((ThemeParkData.ThemePark_Service.IService1)(this)).BeginviewThemeParksJson(callback, asyncState);
        }
        
        private object[] OnEndviewThemeParksJson(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList> retVal = ((ThemeParkData.ThemePark_Service.IService1)(this)).EndviewThemeParksJson(result);
            return new object[] {
                    retVal};
        }
        
        private void OnviewThemeParksJsonCompleted(object state) {
            if ((this.viewThemeParksJsonCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.viewThemeParksJsonCompleted(this, new viewThemeParksJsonCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void viewThemeParksJsonAsync() {
            this.viewThemeParksJsonAsync(null);
        }
        
        public void viewThemeParksJsonAsync(object userState) {
            if ((this.onBeginviewThemeParksJsonDelegate == null)) {
                this.onBeginviewThemeParksJsonDelegate = new BeginOperationDelegate(this.OnBeginviewThemeParksJson);
            }
            if ((this.onEndviewThemeParksJsonDelegate == null)) {
                this.onEndviewThemeParksJsonDelegate = new EndOperationDelegate(this.OnEndviewThemeParksJson);
            }
            if ((this.onviewThemeParksJsonCompletedDelegate == null)) {
                this.onviewThemeParksJsonCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnviewThemeParksJsonCompleted);
            }
            base.InvokeAsync(this.onBeginviewThemeParksJsonDelegate, null, this.onEndviewThemeParksJsonDelegate, this.onviewThemeParksJsonCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult ThemeParkData.ThemePark_Service.IService1.BeginUploadImage(string FileName, byte[] sentImage, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUploadImage(FileName, sentImage, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string ThemeParkData.ThemePark_Service.IService1.EndUploadImage(System.IAsyncResult result) {
            return base.Channel.EndUploadImage(result);
        }
        
        private System.IAsyncResult OnBeginUploadImage(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string FileName = ((string)(inValues[0]));
            byte[] sentImage = ((byte[])(inValues[1]));
            return ((ThemeParkData.ThemePark_Service.IService1)(this)).BeginUploadImage(FileName, sentImage, callback, asyncState);
        }
        
        private object[] OnEndUploadImage(System.IAsyncResult result) {
            string retVal = ((ThemeParkData.ThemePark_Service.IService1)(this)).EndUploadImage(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUploadImageCompleted(object state) {
            if ((this.UploadImageCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UploadImageCompleted(this, new UploadImageCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UploadImageAsync(string FileName, byte[] sentImage) {
            this.UploadImageAsync(FileName, sentImage, null);
        }
        
        public void UploadImageAsync(string FileName, byte[] sentImage, object userState) {
            if ((this.onBeginUploadImageDelegate == null)) {
                this.onBeginUploadImageDelegate = new BeginOperationDelegate(this.OnBeginUploadImage);
            }
            if ((this.onEndUploadImageDelegate == null)) {
                this.onEndUploadImageDelegate = new EndOperationDelegate(this.OnEndUploadImage);
            }
            if ((this.onUploadImageCompletedDelegate == null)) {
                this.onUploadImageCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUploadImageCompleted);
            }
            base.InvokeAsync(this.onBeginUploadImageDelegate, new object[] {
                        FileName,
                        sentImage}, this.onEndUploadImageDelegate, this.onUploadImageCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override ThemeParkData.ThemePark_Service.IService1 CreateChannel() {
            return new Service1ClientChannel(this);
        }
        
        private class Service1ClientChannel : ChannelBase<ThemeParkData.ThemePark_Service.IService1>, ThemeParkData.ThemePark_Service.IService1 {
            
            public Service1ClientChannel(System.ServiceModel.ClientBase<ThemeParkData.ThemePark_Service.IService1> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginviewThemeParksJson(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("viewThemeParksJson", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList> EndviewThemeParksJson(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList> _result = ((System.Collections.ObjectModel.ObservableCollection<ThemeParkData.ThemePark_Service.ThemeParkList>)(base.EndInvoke("viewThemeParksJson", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUploadImage(string FileName, byte[] sentImage, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = FileName;
                _args[1] = sentImage;
                System.IAsyncResult _result = base.BeginInvoke("UploadImage", _args, callback, asyncState);
                return _result;
            }
            
            public string EndUploadImage(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("UploadImage", _args, result)));
                return _result;
            }
        }
    }
}
