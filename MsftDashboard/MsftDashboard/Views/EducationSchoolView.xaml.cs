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
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace MsftDashboard
{
    public partial class EducationSchoolView : ChildWindow
    {
        public EducationSchoolView()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            Messenger.Default.Unregister<EducationInformationStateMessage>(this);

            var dt = DataContext as SchoolsViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
            }

            base.OnClosed(e);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

