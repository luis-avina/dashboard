﻿#pragma checksum "C:\Users\Administrator\Documents\MsftDashboard\MsftDashboard\Views\AddEditEconomyWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D8672638DA0893CBA498A3D379AF87D8"
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
    
    
    public partial class AddEditEconomyWindow : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ComboBox cmbMonth;
        
        internal System.Windows.Controls.ComboBox cmbYear;
        
        internal System.Windows.Controls.ComboBox cmbState;
        
        internal System.Windows.Controls.Canvas cnvSuccess;
        
        internal System.Windows.Controls.TextBlock txtSuccess;
        
        internal System.Windows.Controls.Canvas cnvNotSuccess;
        
        internal System.Windows.Controls.TextBlock txtNotSuccess;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.Button CancelButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MsftDashboard;component/Views/AddEditEconomyWindow.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.cmbMonth = ((System.Windows.Controls.ComboBox)(this.FindName("cmbMonth")));
            this.cmbYear = ((System.Windows.Controls.ComboBox)(this.FindName("cmbYear")));
            this.cmbState = ((System.Windows.Controls.ComboBox)(this.FindName("cmbState")));
            this.cnvSuccess = ((System.Windows.Controls.Canvas)(this.FindName("cnvSuccess")));
            this.txtSuccess = ((System.Windows.Controls.TextBlock)(this.FindName("txtSuccess")));
            this.cnvNotSuccess = ((System.Windows.Controls.Canvas)(this.FindName("cnvNotSuccess")));
            this.txtNotSuccess = ((System.Windows.Controls.TextBlock)(this.FindName("txtNotSuccess")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
        }
    }
}

