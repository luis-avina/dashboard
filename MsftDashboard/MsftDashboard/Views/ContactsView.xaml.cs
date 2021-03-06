﻿using System;
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
using MsftDashboard.Views;
using Microsoft.Practices.Unity;

namespace MsftDashboard
{
    public partial class ContactsView : Page
    {
        public ContactsView()
        {
            
            InitializeComponent();
            RegisterMessages();
           
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditContactMessage>(this, OnLaunchEditContact);
        }

        private void OnLaunchEditContact(LaunchEditContactMessage msg)
        {
            var editContact = new AddEditContactWindow();
            editContact.Show();
        }


        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister<LaunchEditContactMessage>(this);
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
