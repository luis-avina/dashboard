﻿#pragma checksum "C:\Users\Administrator\Documents\MsftDashboard\MsftDashboard\Views\AddEditOpenSourceProviderWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "40FC1DF06E7E300106BC4D6580514D4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MsftDashboard {
    
    
    public partial class AddEditOpenSourceProviderWindow : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ComboBox cmbState;
        
        internal System.Windows.Controls.ComboBox cmbProduct;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.ComboBox cmbMonth;
        
        internal System.Windows.Controls.ComboBox cmbYear_Copy;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MsftDashboard;component/Views/AddEditOpenSourceProviderWindow.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.cmbState = ((System.Windows.Controls.ComboBox)(this.FindName("cmbState")));
            this.cmbProduct = ((System.Windows.Controls.ComboBox)(this.FindName("cmbProduct")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.cmbMonth = ((System.Windows.Controls.ComboBox)(this.FindName("cmbMonth")));
            this.cmbYear_Copy = ((System.Windows.Controls.ComboBox)(this.FindName("cmbYear_Copy")));
        }
    }
}

