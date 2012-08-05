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
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public partial class CorporativeView : Page
    {
        public CorporativeView()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditSocialOrgInfoMessage>(this,OnLaunchEditSocOrg);
        }

        private void OnLaunchEditSocOrg(LaunchEditSocialOrgInfoMessage msg)
        {
            if (msg != null)
            {
                AddEditSocialOrgInfoWindow socInfoWindow = new AddEditSocialOrgInfoWindow();
                socInfoWindow.Show();
            }

        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
