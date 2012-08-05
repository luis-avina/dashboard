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

namespace MsftDashboard.Views
{
    public partial class PoliticView : Page
    {
        public PoliticView()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchPoliticalStateMessage>(this, OnEditPoliticalState);
        }

        private void OnEditPoliticalState(LaunchPoliticalStateMessage msg)
        {
            if (msg != null)
            {
                AddEditPoliticalStateWindow editPoliticalState = new AddEditPoliticalStateWindow();
                editPoliticalState.Show();
            }
        }
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister<LaunchPoliticalStateMessage>(this);
            var dt = this.DataContext as PoliticViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
                base.OnNavigatingFrom(e);
            }
        }

    }
}
