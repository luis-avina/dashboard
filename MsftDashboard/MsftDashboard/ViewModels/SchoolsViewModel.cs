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
using MsftDashboard.Services;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Messages;
using MsftDashboard.Models;

namespace MsftDashboard
{
    public class SchoolsViewModel:ViewModelBase
    {

        protected IMsftService EducationService { get; set; }

        public RelayCommand SaveCommand { get; set; }

        private int _numberSchools;
        public int NumberSchools
        {
            get
            {
                return _numberSchools;
            }
            set
            {
                _numberSchools = value;
                RaisePropertyChanged("NumberSchools");
            }
        }

        private int _numberTeachers;
        public int NumberTeachers
        {
            get
            {
                return _numberTeachers;
            }
            set
            {
                _numberTeachers = value;
                RaisePropertyChanged("NumberTeachers");
            }
        }

        private int _numberStudents;
        public int NumberStudents 
        {
            get
            {
                return _numberStudents;
            }
            set
            {
                _numberStudents = value;
                RaisePropertyChanged("NumberStudents");
            }
        }

        private ObservableCollection<SchoolsInformation> _schoolsInfoCollectionRef;
        private ObservableCollection<TeachersInformation> _teachersnfoCollectionRef;
        private ObservableCollection<StudentsInformation> _studentsInfoCollectionRef;
        private State _stateRef;

        private ObservableCollection<EducationInformation> _educationInformationCollection;
        public ObservableCollection<EducationInformation> EducationInformationCollection
        {
            get
            {
                return _educationInformationCollection;
            }
            set
            {
                _educationInformationCollection = value;
                RaisePropertyChanged("EducationInformationCollection");
            }
        }

        private TeachersInformation _currentTeacherInfo= new TeachersInformation();
        public TeachersInformation CurrentTeacherInfo
        {
            get
            {
                return _currentTeacherInfo;
            }
            set
            {
                _currentTeacherInfo = value;
                RaisePropertyChanged("CurrentTeacherInfo");
            }
        }

        private SchoolsInformation _currentSchoolsInfo=new SchoolsInformation();
        public SchoolsInformation CurrentSchoolsInfo
        {
            get
            {
                return _currentSchoolsInfo;
            }
            set
            {
                _currentSchoolsInfo = value;
                RaisePropertyChanged("CurrentSchoolsInfo");
            }
        }

        private StudentsInformation _currentStudentsInfo = new StudentsInformation();
        public StudentsInformation CurrentStudentsInfo
        {
            get
            {
                return _currentStudentsInfo;
            }
            set
            {
                _currentStudentsInfo = value;
                RaisePropertyChanged("CurrentStudentsInfo");
            }
        }

        private SchoolLevel _currentSchoolLevel = new SchoolLevel();
        public SchoolLevel CurrentSchoolLevel
        {
            get
            {
                return _currentSchoolLevel;
            }
            set
            {
                _currentSchoolLevel = value;
                RaisePropertyChanged("CurrentSchoolLevel");
            }
        }

        private SchoolType _currentSchoolType=new SchoolType();
        public SchoolType CurrentSchoolType
        {
            get
            {
                return _currentSchoolType;
            }
            set
            {
                _currentSchoolType = value;
                RaisePropertyChanged("CurrentSchoolType");
            }
        }

        private ObservableCollection<SchoolType> _schoolTypeCollection;
        public ObservableCollection<SchoolType> SchoolTypeCollection
        {
            get
            {
                return _schoolTypeCollection;
            }
            set
            {
                _schoolTypeCollection = value;
                RaisePropertyChanged("SchoolTypeCollection");
            }
        }

        private ObservableCollection<SchoolLevel> _schoolLevelCollection;
        public ObservableCollection<SchoolLevel> SchoolLevelCollection
        {
            get
            {
                return _schoolLevelCollection;
            }
            set
            {
                _schoolLevelCollection = value;
                RaisePropertyChanged("SchoolLevelCollection");
            }
        }

        public SchoolsViewModel(IMsftService msftService)
        {
            EducationService = msftService;
            EducationInformationCollection= new ObservableCollection<EducationInformation>();
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<EducationInformationStateMessage>(this,OnEditSchools);
        }

        private void OnEditSchools(EducationInformationStateMessage msg)
        {
            if (msg != null) 
            {
                _stateRef = msg.State;
                _schoolsInfoCollectionRef = msg.SchoolsInformations;
                _teachersnfoCollectionRef = msg.TeachersInformations;
                _studentsInfoCollectionRef = msg.StudentsInformations;
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            AddToDataGrid();
            AddToStudentsCollection();
            AddToTeachersCollection();
            AddToSchoolsCollection();
            NumberSchools = 0;
            NumberStudents = 0;
            NumberTeachers = 0;
        }

        private void AddToSchoolsCollection()
        {
            if (_schoolsInfoCollectionRef != null)
            {
                CurrentSchoolsInfo.IdSchoolLevel = CurrentSchoolLevel.IdSchoolLevel;
                CurrentSchoolsInfo.IdSchoolType = CurrentSchoolType.IdSchoolType;
                CurrentSchoolsInfo.Number = NumberSchools;
                _schoolsInfoCollectionRef.Add(CurrentSchoolsInfo);
                CurrentSchoolsInfo = new SchoolsInformation();
            }
        }

        private void AddToTeachersCollection()
        {

            if (_teachersnfoCollectionRef != null)
            {
                CurrentTeacherInfo.IdSchoolLevel = CurrentSchoolLevel.IdSchoolLevel;
                CurrentTeacherInfo.IdSchoolType = CurrentSchoolType.IdSchoolType;
                CurrentTeacherInfo.Number = NumberSchools;
                _teachersnfoCollectionRef.Add(CurrentTeacherInfo);
                CurrentTeacherInfo = new TeachersInformation();
            }
        }

        private void AddToStudentsCollection()
        {
            if (_studentsInfoCollectionRef != null)
            {
                CurrentStudentsInfo.IdSchoolLevel = CurrentSchoolLevel.IdSchoolLevel;
                CurrentStudentsInfo.IdSchoolType = CurrentSchoolType.IdSchoolType;
                CurrentStudentsInfo.Number = NumberSchools;
                _studentsInfoCollectionRef.Add(CurrentStudentsInfo);
                CurrentStudentsInfo = new StudentsInformation();
            }
        }

        private void AddToDataGrid()
        {
            EducationInformation educInfo = new EducationInformation();
            educInfo.StateName = _stateRef.Name;
            educInfo.IdSchoolLevel = CurrentSchoolLevel.IdSchoolLevel;
            educInfo.SchoolLevelName = CurrentSchoolLevel.Name;
            educInfo.IdSchoolType = CurrentSchoolType.IdSchoolType;
            educInfo.SchoolTypeName = CurrentSchoolType.Name;
            educInfo.NumberSchools = NumberSchools;
            educInfo.NumberStudents = NumberStudents;
            educInfo.NumberTeachers = NumberTeachers;
            EducationInformationCollection.Add(educInfo);
        }

        private void LoadData()
        {
            EducationService.GetSchoolType(OnLoadSchoolType);
            EducationService.GetSchoolLevels(OnLoadSchoolLevel);
        }

        private void OnLoadSchoolType(ObservableCollection<SchoolType> schoolType)
        {
            if (schoolType != null)
            {
                SchoolTypeCollection = schoolType;
            }
        }

        private void OnLoadSchoolLevel(ObservableCollection<SchoolLevel> schoolLevel)
        {
            if (schoolLevel != null)
            {
                SchoolLevelCollection = schoolLevel;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
