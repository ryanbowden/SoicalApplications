﻿#pragma checksum "C:\Users\Ryan\Documents\GitHub\SoicalApplications\WindowsPhoneApp\ThemeParkData\ThemeParkData\TakePhoto.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "268609D703D167582FD7E5FC9D3CED94"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ThemeParkData {
    
    
    public partial class TakePhoto : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button capturePhotoButton;
        
        internal System.Windows.Controls.Image imgTakenPicture;
        
        internal System.Windows.Controls.Button choosePhotoButton;
        
        internal System.Windows.Controls.Button btnSavePicture;
        
        internal System.Windows.Controls.TextBlock ParkDetails;
        
        internal System.Windows.Controls.ProgressBar progressbar;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ThemeParkData;component/TakePhoto.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.capturePhotoButton = ((System.Windows.Controls.Button)(this.FindName("capturePhotoButton")));
            this.imgTakenPicture = ((System.Windows.Controls.Image)(this.FindName("imgTakenPicture")));
            this.choosePhotoButton = ((System.Windows.Controls.Button)(this.FindName("choosePhotoButton")));
            this.btnSavePicture = ((System.Windows.Controls.Button)(this.FindName("btnSavePicture")));
            this.ParkDetails = ((System.Windows.Controls.TextBlock)(this.FindName("ParkDetails")));
            this.progressbar = ((System.Windows.Controls.ProgressBar)(this.FindName("progressbar")));
        }
    }
}

