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
    public partial class AddEditEducationStateWindow : ChildWindow
    {
        private const int SCHOOLS_INFORMATION = 1;
        private const int UNIVERSITIES_INFORMATION = 2;
        private const int ENLACE_INFORMATION = 3;
        private const int SEP_INFORMATION = 4;

        public AddEditEducationStateWindow()
        {
            InitializeComponent();
            //RegisterMessages();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<LaunchEditEducationStateMessage>(this, OnEdit);
        }

        private void OnEdit(LaunchEditEducationStateMessage msg)
        {
            if (msg != null)
            {
                switch(msg.IdOperation)
                {
                    case SCHOOLS_INFORMATION:
                        EducationSchoolView educationSchool = new EducationSchoolView();
                        educationSchool.Show();
                        break;

                    case UNIVERSITIES_INFORMATION:
                        EducationUniversitiesView educationUniversities = new EducationUniversitiesView();
                        educationUniversities.Show();
                        break;
                    case ENLACE_INFORMATION:
                        EducationEnlaceView educationEnlace = new EducationEnlaceView();
                        educationEnlace.Show();
                        break;
                    case SEP_INFORMATION:
                        EducationSepProjectsView educationSep = new EducationSepProjectsView();
                        educationSep.Show();
                        break;
                }
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
            Messenger.Default.Unregister(this);
            var dt = DataContext as AddEditEducationStateViewModel;

            if (dt != null)
            {
                dt.Cleanup();
            }
            
            base.OnClosed(e);
        }
    }
}

