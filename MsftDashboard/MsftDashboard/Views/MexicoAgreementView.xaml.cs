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
    public partial class MexicoAgreementView : Page
    {
        public MexicoAgreementView()
        {
            InitializeComponent();
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditMexicoAgreementMessage>(this, OnEditMexicoAgreement);
        }

        private void OnEditMexicoAgreement(LaunchEditMexicoAgreementMessage msg)
        {
            if (msg != null)
            {
                AddEditMexicoAgreementWindow editMexico = new AddEditMexicoAgreementWindow();
                editMexico.Show();
            }
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister<LaunchEditMexicoAgreementMessage>(this);
            var dt = this.DataContext as MexicoAgreementViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
                base.OnNavigatingFrom(e);
            }
        }
    }
}
