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
    public partial class EconomyView : Page
    {
        public EconomyView()
        {
            InitializeComponent();
            RegisterMessages();

        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditEconomyMessage>(this, OnLaunchEditEconomy);
        }

        private void OnLaunchEditEconomy(LaunchEditEconomyMessage msg)
        {
            var editEconomy = new AddEditEconomyWindow();
            editEconomy.Show();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister<LaunchEditEconomyMessage>(this);
            var dt = this.DataContext as ContactsViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
                base.OnNavigatingFrom(e);
            }
        }
    }
}
