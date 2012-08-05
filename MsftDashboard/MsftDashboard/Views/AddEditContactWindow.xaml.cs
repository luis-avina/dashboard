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

namespace MsftDashboard
{
    public partial class AddEditContactWindow:ChildWindow
    {
        public AddEditContactWindow()
        {
            InitializeComponent();
            this.Unloaded += new RoutedEventHandler(AddEditContactWindow_Unloaded);
        }

        void AddEditContactWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister(this);

            var dt = DataContext as AddEditContactViewModel;

            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
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
    }
}

