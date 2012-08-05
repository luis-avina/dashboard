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
using MsftDashboard.Helpers;

namespace MsftDashboard
{
    public partial class AdministrationView : Page
    {
        public AdministrationView()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void tilePoblacion_Click(object sender, RoutedEventArgs e)
        {
            LinkOpener.OpenURL(new Uri("http://localhost:1120/MsftDashboardTestPage.aspx#/PopulationView"));
        }
    }
}