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
    public partial class AddEditProgramsMsft : ChildWindow
    {
        public AddEditProgramsMsft()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditContactMessage>(this,OnShowContactModal);
        }

        private void OnShowContactModal(LaunchEditContactMessage msg)
        {
            if (msg != null)
            {
                ContactViewWindow contactWindow = new ContactViewWindow();
                contactWindow.Show();
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        protected override void OnClosed(EventArgs e)
        { 
            Messenger.Default.Unregister<LaunchEditContactMessage>(this);
            var dt = this.DataContext as AddEditMsftProgramViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
            }

            base.OnClosed(e);
        }
    }
}

