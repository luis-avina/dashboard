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
using System.Collections.ObjectModel;
using MsftDashboard.Models;

namespace MsftDashboard
{
    public partial class App : Application
    {
        public static ObservableCollection<Months> MonthsCatalog = new ObservableCollection<Months>();
        public static String MapMode = "AerialWithLabels";
        public App()
        {
            this.Startup += this.Application_Startup;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
            LoadMonthsCatalog();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.RootVisual = new MainPage();
        }

        private void LoadMonthsCatalog()
        {
            MonthsCatalog.Add(new Months() { Id = 1, Month = "Enero" });
            MonthsCatalog.Add(new Months() { Id = 2, Month = "Febrero" });
            MonthsCatalog.Add(new Months() { Id = 3, Month = "Marzo" });
            MonthsCatalog.Add(new Months() { Id = 4, Month = "Abril" });
            MonthsCatalog.Add(new Months() { Id = 5, Month = "Mayo" });
            MonthsCatalog.Add(new Months() { Id = 6, Month = "Junio" });
            MonthsCatalog.Add(new Months() { Id = 7, Month = "Julio" });
            MonthsCatalog.Add(new Months() { Id = 8, Month = "Agosto" });
            MonthsCatalog.Add(new Months() { Id = 9, Month = "Septiembre" });
            MonthsCatalog.Add(new Months() { Id = 10, Month = "Octubre" });
            MonthsCatalog.Add(new Months() { Id = 11, Month = "Noviembre" });
            MonthsCatalog.Add(new Months() { Id = 12, Month = "Diciembre" });
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // a ChildWindow control.
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                ChildWindow errorWin = new ErrorWindow(e.ExceptionObject);
                errorWin.Show();
            }
        }
    }
}