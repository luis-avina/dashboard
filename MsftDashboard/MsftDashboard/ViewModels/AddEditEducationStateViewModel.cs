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
using MsftDashboard.Web.Models;
using MsftDashboard.Models;
using System.Collections.ObjectModel;
using MsftDashboard.Services;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class AddEditEducationStateViewModel:ViewModelBase
    {
        private const int SCHOOLS_INFORMATION = 1;
        private const int UNIVERSITIES_INFORMATION = 2;
        private const int ENLACE_INFORMATION = 3;
        private const int SEP_INFORMATION = 4;

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public IMsftService EducationService { get; set; }

        private bool isNew;

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand EducationSchoolCommand { get; set; }
        public RelayCommand UniversitieCommand { get; set; }
        public RelayCommand EnlaceCommand { get; set; }
        public RelayCommand SEPCommand { get; set; }


        private ObservableCollection<SEPProjectState> _sepProjectCollection = new ObservableCollection<SEPProjectState>();
        public ObservableCollection<SEPProjectState> SepProjectCollection
        {
            get
            {
                return _sepProjectCollection;
            }
            set
            {
                _sepProjectCollection = value;
                RaisePropertyChanged("SepProjectCollection");
            }
        }

        private ObservableCollection<MainUniversity> _mainUniversitieCollection = new ObservableCollection<MainUniversity>();
        public ObservableCollection<MainUniversity> MainUniversitieCollection
        {
            get
            {
                return _mainUniversitieCollection;
            }
            set
            {
                _mainUniversitieCollection = value;
                RaisePropertyChanged("MainUniversitieCollection");
            }
        }

        private ObservableCollection<EnlaceTest> _enlaceInformationCollection = new ObservableCollection<EnlaceTest>();
        public ObservableCollection<EnlaceTest> EnlaceInformationCollection
        {
            get
            {
                return _enlaceInformationCollection;
            }
            set
            {
                _enlaceInformationCollection = value;
                RaisePropertyChanged("EnlaceInformationCollection");
            }
        }

        private ObservableCollection<StudentsInformation> _studentsInformationCollection= new ObservableCollection<StudentsInformation>();
        public ObservableCollection<StudentsInformation> StudentsInformationCollection
        {
            get
            {
                return _studentsInformationCollection;
            }
            set
            {
                _studentsInformationCollection = value;
                RaisePropertyChanged("StudentsInformation");
            }
        }

        private ObservableCollection<TeachersInformation> _teachersInformationCollection=new ObservableCollection<TeachersInformation>();
        public ObservableCollection<TeachersInformation> TeachersInformationCollection
        {
            get
            {
                return _teachersInformationCollection;
            }
            set
            {
                _teachersInformationCollection = value;
                RaisePropertyChanged("TeachersInformationCollection");
            }
        }

        private ObservableCollection<SchoolsInformation> _schoolsInformationCollection=new ObservableCollection<SchoolsInformation>();
        public ObservableCollection<SchoolsInformation> SchoolsInformationCollection
        {
            get
            {
                return _schoolsInformationCollection;
            }
            set
            {
                _schoolsInformationCollection = value;
                RaisePropertyChanged("SchoolsInformationCollection");
            }
        }

        private EducationInformationState _currentEducationInfoState = new EducationInformationState();
        public EducationInformationState CurrentEducationInfoState
        {
            get
            {
                return _currentEducationInfoState;
            }
            set
            {
                _currentEducationInfoState = value;
                RaisePropertyChanged("CurrentEducationInfoState");
            }
        }

        private ObservableCollection<EducationInformationState> _educationStateCollectionRef;

        private Year _currentYear;
        public Year CurrentYear
        {
            get
            {
                return _currentYear;
            }
            set
            {
                _currentYear = value;
                RaisePropertyChanged("CurrentYear");
            }
        }


        private State _currentState;
        public State CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
                RaisePropertyChanged("CurrentState");
            }
        }

        private ObservableCollection<State> _stateCollection;
        public ObservableCollection<State> StateCollection
        {
            get
            {
                return _stateCollection;
            }
            set
            {
                _stateCollection = value;
                RaisePropertyChanged("StateCollection");
            }
        }


        private ObservableCollection<Year> _yearsCollection;
        public ObservableCollection<Year> YearsCollection
        {
            get
            {
                return _yearsCollection;
            }
            set
            {
                _yearsCollection = value;
                RaisePropertyChanged("YearsCollection");
            }
        }

        public AddEditEducationStateViewModel(IMsftService msftService)
        {
            EducationService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            EducationService.GetStates(OnLoadStates);
            EducationService.GetYears(OnLoadYears);
        }

        private void OnLoadStates(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        private void OnLoadYears(ObservableCollection<Year> years)
        {
            if(years!=null)
            {
                YearsCollection = years;
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
            EducationSchoolCommand = new RelayCommand(EditEducationSchool);
            UniversitieCommand = new RelayCommand(EditUniversities);
            EnlaceCommand = new RelayCommand(EditEnlace);
            SEPCommand = new RelayCommand(EditSep);
        }

        private void Save()
        {
            if (isNew)
            {
                CurrentEducationInfoState.IdState = CurrentState.IdState;
                CurrentEducationInfoState.Year = CurrentYear.Year1;
                LoadStudentsCollection();
                LoadTeachersCollection();
                LoadSchoolsCollection();
                LoadEnlaceCollection();
                LoadMainUniversitiesCollection();
                //LoadSepProjectCollection();
                EducationService.SaveEducationInformationState(SaveOperation, CurrentEducationInfoState);
                
            }
            else
            {
                EducationService.UpdateEducationInformationState(UpdateOperation,CurrentEducationInfoState);
            }
        }

        private void LoadMainUniversitiesCollection()
        {
            if (MainUniversitieCollection != null)
            {
                foreach (MainUniversity item in MainUniversitieCollection)
                {
                    CurrentEducationInfoState.MainUniversities.Add(item);
                }
            }
        }

        //private void LoadSepProjectCollection()
        //{
        //}

        private void LoadEnlaceCollection()
        {
            if (EnlaceInformationCollection != null)
            {
                foreach (EnlaceTest item in EnlaceInformationCollection)
                {
                    CurrentEducationInfoState.EnlaceTests.Add(item);
                }
            }
        }

        private void LoadSchoolsCollection()
        {
            
            
            if (SchoolsInformationCollection != null)
            {
                foreach (SchoolsInformation item in SchoolsInformationCollection)
                {
                    CurrentEducationInfoState.SchoolsInformations.Add(item);
                }
            }
        }

        private void LoadTeachersCollection()
        {
            if (TeachersInformationCollection != null)
            {
                foreach (TeachersInformation item in TeachersInformationCollection)
                {
                    CurrentEducationInfoState.TeachersInformations.Add(item);
                }
            }
        }

        private void LoadStudentsCollection()
        {
            if (StudentsInformationCollection != null)
            {
                foreach (StudentsInformation item in StudentsInformationCollection)
                {
                    CurrentEducationInfoState.StudentsInformations.Add(item);
                }
            }
        }

        private void EditEducationSchool()
        {
            EducationSchoolView educationSchool = new EducationSchoolView();
            educationSchool.Show();
            Messenger.Default.Send<EducationInformationStateMessage>(new EducationInformationStateMessage() { IdOperation = SCHOOLS_INFORMATION,State=CurrentState,SchoolsInformations=SchoolsInformationCollection,TeachersInformations=TeachersInformationCollection,StudentsInformations = StudentsInformationCollection});
        }

        private void EditUniversities()
        {
            EducationUniversitiesView educationUniversities = new EducationUniversitiesView();
            educationUniversities.Show();
            Messenger.Default.Send<EducationInformationStateMessage>(new EducationInformationStateMessage() {  State = this.CurrentState,UniversitiesCollection =this.MainUniversitieCollection });   
        }

        private void EditEnlace()
        {
            EducationEnlaceView educationEnlace = new EducationEnlaceView();
            educationEnlace.Show();
            Messenger.Default.Send<EducationInformationStateMessage>(new EducationInformationStateMessage() { IdOperation = ENLACE_INFORMATION, State=this.CurrentState, EnlaceTests = EnlaceInformationCollection });
            
        }

        private void EditSep()
        {
            EducationSepProjectsView educationSep = new EducationSepProjectsView();
            educationSep.Show();
            Messenger.Default.Send<EducationInformationStateMessage>(new EducationInformationStateMessage() { IdOperation = SEP_INFORMATION, State = this.CurrentState, SEPProjectStates = this.SepProjectCollection });
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                AddKeySepProject();
                EducationService.SaveSepProject(SaveSepProjectOperation,SepProjectCollection);
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void AddKeySepProject()
        {

            if (SepProjectCollection != null)
            {
                foreach (SEPProjectState item in SepProjectCollection)
                {
                    item.IdEducationInformationState = CurrentEducationInfoState.IdEducationInformationState;
                }
            }
        }


        private void SaveSepProjectOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_educationStateCollectionRef != null)
                {


                    _educationStateCollectionRef.Add(CurrentEducationInfoState);
                    CurrentEducationInfoState = new EducationInformationState();
                }
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void UpdateOperation(SubmitOperation op)
        {
            if (op.HasError)
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }


        private void RegisterMessages()
        {
            Messenger.Default.Register<EducationInformationStateMessage>(this,OnEditEducationState);
        }

        private void OnEditEducationState(EducationInformationStateMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNew = true;
                    if (msg.EducationStateCollection != null)
                    {
                        _educationStateCollectionRef = msg.EducationStateCollection;
                    }
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNew = false;
                    CurrentEducationInfoState = msg.EducationState;
                }
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }

    }
}
