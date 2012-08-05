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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Services;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Models;

namespace MsftDashboard
{
    public class EducationEnlaceViewModel:ViewModelBase
    {
        protected IMsftService EducationService { get; set; }

        public RelayCommand SaveCommand { get; set; }

        private int _numberOfTests;
        public int NumberOfTests
        {
            get
            {
                return _numberOfTests;
            }
            set
            {
                _numberOfTests = value;
                RaisePropertyChanged("NumberOfTests");
            }
        }

        private EnlaceTest _currentEnlaceTest= new EnlaceTest();
        public EnlaceTest CurrentEnlaceTest
        {
            get
            {
                return _currentEnlaceTest;
            }
            set
            {
                _currentEnlaceTest = value;
                RaisePropertyChanged("CurrentEnlaceTest");
            }
        }

        private SchoolGrade _currentSchoolGrade=new SchoolGrade();
        public SchoolGrade CurrentSchoolGrade
        {
            get
            {
                return _currentSchoolGrade;
            }
            set
            {
                _currentSchoolGrade = value;
                RaisePropertyChanged("CurrentSchoolGrade");
            }
        }

        private ObservableCollection<SchoolGrade> _schoolGradeCollection;
        public ObservableCollection<SchoolGrade> SchoolGradeCollection
        {
            get
            {
                return _schoolGradeCollection;
            }
            set
            {
                _schoolGradeCollection = value;
                RaisePropertyChanged("SchoolGradeCollection");
            }
        }

        private ObservableCollection<EnlaceTest> _enlaceTestCollectionRef;
        private State _stateRef;

        public ObservableCollection<EnlaceInfo> _enlaceTestCollection = new ObservableCollection<EnlaceInfo>();
        public ObservableCollection<EnlaceInfo> EnlaceTestCollection
        {
            get
            {
                return _enlaceTestCollection;
            }
            set
            {
                _enlaceTestCollection = value;
                RaisePropertyChanged("EnlaceTestCollection");
            }
        }

        public EducationEnlaceViewModel(IMsftService msftService)
        {
            EducationService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            EducationService.GetSchoolGrade(OnLoadSchoolGrade);
        }

        private void OnLoadSchoolGrade(ObservableCollection<SchoolGrade> schoolGrade)
        {
            if (schoolGrade != null)
            {
                SchoolGradeCollection = schoolGrade;
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<EducationInformationStateMessage>(this, OnEditEnlace);
        }

        private void OnEditEnlace(EducationInformationStateMessage msg)
        {
            if (msg != null)
            {
                _stateRef = msg.State;
                _enlaceTestCollectionRef = msg.EnlaceTests;
                
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            AddToGrid();
        }

        private void AddToGrid()
        {
            EnlaceInfo enlace = new EnlaceInfo();
            enlace.IdShcoolLevel = CurrentSchoolGrade.IdSchoolGrade;
            enlace.SchoolLevel = CurrentSchoolGrade.Name;
            enlace.NumberOfTest = NumberOfTests;
            enlace.StateName = _stateRef.Name;

            EnlaceTestCollection.Add(enlace);

            CurrentEnlaceTest.IdSchoolGrade = CurrentSchoolGrade.IdSchoolGrade;
            CurrentEnlaceTest.Number = NumberOfTests;

            _enlaceTestCollectionRef.Add(CurrentEnlaceTest);

            NumberOfTests = 0;
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
