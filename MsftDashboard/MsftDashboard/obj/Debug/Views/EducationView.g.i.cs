﻿#pragma checksum "C:\Users\Administrator\Documents\MsftDashboard\MsftDashboard\Views\EducationView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "731A22AA79382675234010A364F9AC35"
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


namespace MsftDashboard.Views {
    
    
    public partial class EducationView : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button btnUpdate;
        
        internal System.Windows.Controls.Button btnEliminar;
        
        internal System.Windows.Controls.DataGrid dataGridEducation;
        
        internal System.Windows.Controls.Button btnNew;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MsftDashboard;component/Views/EducationView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.btnUpdate = ((System.Windows.Controls.Button)(this.FindName("btnUpdate")));
            this.btnEliminar = ((System.Windows.Controls.Button)(this.FindName("btnEliminar")));
            this.dataGridEducation = ((System.Windows.Controls.DataGrid)(this.FindName("dataGridEducation")));
            this.btnNew = ((System.Windows.Controls.Button)(this.FindName("btnNew")));
        }
    }
}

