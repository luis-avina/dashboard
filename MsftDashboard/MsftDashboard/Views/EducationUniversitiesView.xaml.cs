using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public partial class EducationUniversitiesView : ChildWindow
    {
        public EducationUniversitiesView()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            //Messenger.Default.Unregister<EducationInformationStateMessage>(this);

            //var dt = DataContext as EducationUniversitiesViewModel;
            //if(dt!=null)
            //{
            //    dt.Cleanup();
            //    dt =null;
            //}

            base.OnClosed(e);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

