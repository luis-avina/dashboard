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
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace MsftDashboard
{
    public partial class OpenSourceView : Page
    {
        public OpenSourceView()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditOpenSourceStateMessage>(this,OnEditOpenSourceState);
        }

        private void OnEditOpenSourceState(LaunchEditOpenSourceStateMessage msg)
        {
            if (msg != null)
            {
                AddEditOpenSourceWindow editOpenSource = new AddEditOpenSourceWindow();
                editOpenSource.Show();
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister<LaunchEditOpenSourceStateMessage>(this);
            var dt = this.DataContext as OpenSourceViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
                base.OnNavigatingFrom(e);
            }
        }
    }
}
