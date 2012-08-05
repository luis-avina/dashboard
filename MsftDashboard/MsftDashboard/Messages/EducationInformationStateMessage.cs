using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Messages
{
    internal class EducationInformationStateMessage:MessageBase
    {
        public int IdOperation { get; set; }
        public State State { get; set; }
        public EducationInformationState EducationState { get; set; }
        public ObservableCollection<EducationInformationState> EducationStateCollection { get; set; }
        public ObservableCollection<SchoolsInformation> SchoolsInformations { get; set; }
        public ObservableCollection<SEPProjectState> SEPProjectStates { get; set; }
        public ObservableCollection<StudentsInformation> StudentsInformations { get; set; }
        public ObservableCollection<EnlaceTest> EnlaceTests { get; set; }
        public ObservableCollection<TeachersInformation> TeachersInformations { get; set; }
        public ObservableCollection<MainUniversity> UniversitiesCollection { get; set; }
    }
}
