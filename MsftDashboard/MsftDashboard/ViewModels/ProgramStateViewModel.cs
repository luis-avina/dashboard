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
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight;
using MsftDashboard.Services;
using MsftDashboard.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace MsftDashboard
{
    public class ProgramStateViewModel:ViewModelBase
    {
private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        protected IMsftService MsftProgramService { get; set; }

        private StateProgram _previousProgramState;

        private bool isCatalogsAlreadyLoaded=false;

        private string _contactStateName;
        public string ContactStateName
        {
            get
            {
                return _contactStateName;
            }
            set
            {
                _contactStateName = value;
                RaisePropertyChanged("ContactStateName");
            }
        }

        private string _contactMsftName;
        public string ContactMsftName
        {
            get
            {
                return _contactMsftName;
            }
            set
            {
                _contactMsftName = value;
                RaisePropertyChanged("ContactMsftName");
            }
        }

        private bool _isAddOperation = false;
        public bool IsAddOperation
        {
            get
            {
                return _isAddOperation;
            }
            set
            {
                _isAddOperation = value;
                RaisePropertyChanged("IsAddOperation");
            }
        }

        private bool _isEditOperation = false;
        public bool IsEditOperation
        {
            get
            {
                return _isEditOperation;
            }
            set
            {
                _isEditOperation = value;
                RaisePropertyChanged("IsEditOperation");
            }
        }
        
        private bool isNewRecord = false;

        private bool _showProgramInfo = false;
        public bool ShowProgramInfo
        { 
            get 
            {
                return _showProgramInfo;
            }
            set
            {
                _showProgramInfo = value;
                RaisePropertyChanged("ShowProgramInfo");
            }
        }


        private bool _showProgramEdit = false;
        public bool ShowProgramEdit
        {
            get
            {
                return _showProgramEdit;
            }
            set
            {
                _showProgramEdit = value;
                RaisePropertyChanged("ShowProgramEdit");
            }
        }

        private bool _isShowGridDates = false;
        public bool IsShowGridDates
        {
            get
            {
                return _isShowGridDates;
            }
            set
            {
                _isShowGridDates = value;
                RaisePropertyChanged("IsShowGridDates");
            }
        }

        private bool _isEnableDataGridStates= true;
        public bool IsEnableDataGridStates
        {
            get
            {
                return _isEnableDataGridStates;
            }
            set
            {
                _isEnableDataGridStates = value;
                RaisePropertyChanged("IsEnableDataGridStates");
            }
        }

        private bool _isEnableDataGridDates = false;
        public bool IsEnableDataGridDates
        {
            get
            {
                return _isEnableDataGridDates;
            }
            set
            {
                _isEnableDataGridDates = value;
                RaisePropertyChanged("IsEnableDataGridDates");
            }
        }


        private Year _currentInitialYear;
        public Year CurrentInitialYear
        {
            get
            {
                return _currentInitialYear;
            }
            set
            {
                _currentInitialYear = value;
                RaisePropertyChanged("CurrentInitialYear");
            }
        }


        private Year _currentFinalYear;
        public Year CurrentFinalYear
        {
            get
            {
                return _currentFinalYear;
            }
            set
            {
                _currentFinalYear = value;
                RaisePropertyChanged("CurrentFinalYear");
            }
        }

        private Months _currentInitialMonth;
        public Months CurrentInitialMonth
        {
            get
            {
                return _currentInitialMonth;
            }
            set
            {
                _currentInitialMonth = value;
                RaisePropertyChanged("CurrentInitialMonth");
            }
        }

        private Months _currenFinalMonth;
        public Months CurrentFinalMonth
        {
            get
            {
                return _currenFinalMonth;
            }
            set
            {
                _currenFinalMonth = value;
                RaisePropertyChanged("CurrentFinalMonth");
            }
        }

        private State _selectedState;
        public State SelectedState
        {
            get
            {
                return _selectedState;
            }
            set
            {
                _selectedState = value;
                RaisePropertyChanged("SelectedState");
            }
        }

        private ObservableCollection<Months> _monthsInitialCollection;
        public ObservableCollection<Months> MonthsInitialCollection
        {
            get
            {
                return _monthsInitialCollection;
            }
            set
            {
                _monthsInitialCollection = value;
                RaisePropertyChanged("MonthsInitialCollection");
            }
        }

        private ObservableCollection<Months> _monthsFinalCollection;
        public ObservableCollection<Months> MonthsFinalCollection
        {
            get
            {
                return _monthsFinalCollection;
            }
            set
            {
                _monthsFinalCollection = value;
                RaisePropertyChanged("MonthsFinalCollection");
            }
        }

        private ObservableCollection<Year> _yearsInitialCollection;
        public ObservableCollection<Year> YearsInitialCollection
        {
            get
            {
                return _yearsInitialCollection;
            }
            set
            {
                _yearsInitialCollection = value;
                RaisePropertyChanged("YearsInitialCollection");
            }
        }

        private ObservableCollection<Year> _yearsFinalCollection;
        public ObservableCollection<Year> YearsFinalCollection
        {
            get
            {
                return _yearsFinalCollection;
            }
            set
            {
                _yearsFinalCollection = value;
                RaisePropertyChanged("YearsFinalCollection");
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

        private Partner _currentPartner;
        public Partner CurrentPartner
        {
            get
            {
                return _currentPartner;
            }
            set
            {
                _currentPartner = value;
                RaisePropertyChanged("CurrentPartner");
            }
        }

        private ObservableCollection<Partner> _partnerCollection;
        public ObservableCollection<Partner> PartnerCollection
        {
            get
            {
                return _partnerCollection;
            }
            set
            {
                _partnerCollection = value;
                RaisePropertyChanged("PartnerCollection");
            }
        }

        private ObservableCollection<StateProgram> _refPrograms;

        private Program _currentProgram;
        public Program CurrentProgram
        {
            get
            {
                return _currentProgram;
            }
            set
            {
                _currentProgram = value;
                RaisePropertyChanged("CurrentProgram");
            }
        }

        private ObservableCollection<Program> _programCollection;
        public ObservableCollection<Program> ProgramCollection
        {
            get
            {
                return _programCollection;
            }
            set
            {
                _programCollection = value;
                RaisePropertyChanged("ProgramCollection");
            }
        }

        private Source _currentSource;
        public Source CurrentSource
        {
            get
            {
                return _currentSource;
            }
            set
            {
                _currentSource = value;
                RaisePropertyChanged("CurrentSource");
            }
        }

        private ObservableCollection<Source> _sourceCollection;
        public ObservableCollection<Source> SourceCollection
        {
            get
            {
                return _sourceCollection;
            }
            set
            {
                _sourceCollection = value;
                RaisePropertyChanged("SourceCollection");
            }
        }

        private ObservableCollection<StateProgram> _programStateCollectionRef;

        private string msftFirstName=string.Empty;
        private string msftLastName=string.Empty;

        private Contact _contactMsft = new Contact();
        public Contact ContactMsft
        {
            get
            {
                return _contactMsft;
            }
            set
            {
                _contactMsft = value;
                if (_contactMsft != null)
                {
                  if(!String.IsNullOrEmpty(_contactMsft.FirstName)){
                      msftFirstName = _contactMsft.FirstName;
                  }
                  if(!String.IsNullOrEmpty(_contactMsft.LastName)){
                      msftLastName = _contactMsft.LastName;
                  }
                  ContactMsftName = msftFirstName + " " + msftLastName;
                }
                RaisePropertyChanged("ContactMsft");
            }
        }

        private string stateFirstName = string.Empty;
        private string stateLastName = string.Empty;

        private Contact _contactState = new Contact();
        public Contact ContactState
        {
            get
            {
                return _contactState;
            }
            set
            {
                _contactState = value;

                if (_contactState != null)
                {
                    if (!String.IsNullOrEmpty(_contactState.FirstName))
                    {
                        stateFirstName = _contactState.FirstName;
                    }
                    if (!String.IsNullOrEmpty(_contactState.LastName))
                    {
                        stateLastName = _contactState.LastName;
                    }
                    ContactStateName = stateFirstName +" "+ stateLastName;
                }

                RaisePropertyChanged("ContactState");
            }
        }

        private StateProgram _currentStateProgram = new StateProgram();
        public StateProgram CurrentStateProgram
        {
            get
            {
                return _currentStateProgram;
            }
            set
            {
                _currentStateProgram = value;
                RaisePropertyChanged("CurrentStateProgram");
            }
        }


        public RelayCommand AddProgramMsftCommand { get; set; }
        public RelayCommand EditProgramMsftCommand { get; set; }
        public RelayCommand SelectStateCommand { get; set; }
        public RelayCommand SelectProgramStateCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand AddContactStateCommand { get; set; }
        public RelayCommand AddContactMsftCommand { get; set; }


        private StateProgram _selectedStateProgram;
        public StateProgram SelectedStateProgram
        {
            get
            {
                return _selectedStateProgram;
            }
            set
            {
                _selectedStateProgram = value;
                RaisePropertyChanged("SelectedStateProgram");
            }
        }

        private ObservableCollection<StateProgram> _stateProgramCollection;
        public ObservableCollection<StateProgram> StateProgramCollection
        {
            get
            {
                return _stateProgramCollection;
            }
            set
            {
                _stateProgramCollection = value;
                RaisePropertyChanged("StateProgramCollection");
        
            }
        }

        public ProgramStateViewModel(IMsftService msftService)
        {
            MsftProgramService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            MsftProgramService.GetStates(OnLoadStates);
        }

        private void OnLoadStates(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        private void OnSelectState()
        {
            if (SelectedState != null)
            {
                ShowProgramInfo = false;
                ShowProgramEdit = false;
                IsShowGridDates = false;
                IsEnableDataGridDates = false;
                    
                MsftProgramService.GetProgramStateByState(OnLoadStateProgram, SelectedState.IdState);
            }
        }

        private void OnLoadStateProgram(ObservableCollection<StateProgram> msftCollection)
        {
            if (msftCollection != null)
            {
                
                StateProgramCollection = msftCollection;

                if (msftCollection.Count > 0)
                {

                    IsShowGridDates = true;
                    IsEnableDataGridDates = true;
                    
                }
                else
                {
                    LoadCatalogs();
                    IsAddOperation = true;
                    IsEditOperation = false;
                    IsEnableDataGridDates = false;
                    IsShowGridDates = false;
                    SelectedStateProgram = new StateProgram ();
                    isNewRecord = true;
                    ShowProgramStateEdit();
                }
            }
        }

        private void RegisterCommands()
        {
            AddProgramMsftCommand = new RelayCommand(AddMsftProgram);
            EditProgramMsftCommand = new RelayCommand(UpdateMsftProgram);
            SelectStateCommand = new RelayCommand(OnSelectState);
            SelectProgramStateCommand = new RelayCommand(OnSelectProgramMsft);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            AddContactMsftCommand = new RelayCommand(AddContactMsft);
            AddContactStateCommand = new RelayCommand(AddContactState);
        }

        private void AddContactMsft()
        {
            Messenger.Default.Send<LaunchEditContactMessage>(new LaunchEditContactMessage());
            Messenger.Default.Send<ContactMessage>(new ContactMessage() { Contact = this.ContactMsft });

        }

        private void AddContactState()
        {
            Messenger.Default.Send<LaunchEditContactMessage>(new LaunchEditContactMessage());
            Messenger.Default.Send<ContactMessage>(new ContactMessage() { Contact = this.ContactState });
        }

        private void Save()
        {
            if (isNewRecord)
            {
                _refPrograms = new ObservableCollection<StateProgram>(StateProgramCollection);
                SelectedStateProgram.State = SelectedState;
                SelectedStateProgram.DateFrom = new DateTime(CurrentInitialYear.Year1, CurrentInitialMonth.Id, 1);
                SelectedStateProgram.DateTo = new DateTime(CurrentFinalYear.Year1, CurrentFinalMonth.Id, 1);
                SelectedStateProgram.Program = CurrentProgram;
                SelectedStateProgram.Partner = CurrentPartner;
                SelectedStateProgram.Source = CurrentSource;
                SelectedStateProgram.IdContactMsft = ContactMsft.IdContact;
                SelectedStateProgram.IdContactState = ContactState.IdContact;
                MsftProgramService.SaveStateProgram(SaveOperation, SelectedStateProgram);
            }
            else
            {

                SelectedStateProgram.IdContactMsft = ContactMsft.IdContact;
                SelectedStateProgram.IdContactState = ContactState.IdContact;
                MsftProgramService.UpdateStateProgram(UpdateOperation, SelectedStateProgram);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                StateProgramCollection.Add(SelectedStateProgram);
                MsftProgramService.GetProgramStateById(OnSelectMsftProgram,SelectedStateProgram.IdStateProgram);
                IsShowGridDates = true;
                IsEnableDataGridDates = true;
                isCatalogsAlreadyLoaded = true;
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }
        private void OnSelectMsftProgram(ObservableCollection<StateProgram> programState)
        {
            if (programState != null)
            {
                SelectedStateProgram = programState[0];
                if (StateProgramCollection == null || StateProgramCollection.Count <= 0)
                {
                    StateProgramCollection = new ObservableCollection<StateProgram>(_refPrograms);
                }
                StateProgramCollection.Add(SelectedStateProgram);
                ShowProgramStateInfo();
                _refPrograms = null;
            }
        }


        private void UpdateOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                ShowProgramStateInfo();
                
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }
        private void Cancel()
        {
            if (IsShowGridDates)
            {
                ShowProgramStateInfo();
                if (isNewRecord)
                {
                    SelectedStateProgram = _previousProgramState;
                }
            }
            else
            {
                ContactMsft = new Contact();
                ContactState = new Contact();
                SelectedStateProgram = new StateProgram();
            }
        }

        private void OnSelectProgramMsft()
        {
            ShowProgramStateInfo();
        }

        private void AddMsftProgram()
        {
            if (!isCatalogsAlreadyLoaded)
            {
                LoadCatalogs();
            }
            else
            {
                PartnerCollection = new ObservableCollection<Partner>(_partnersCollection);
                ProgramCollection = new ObservableCollection<Program>(_programsCollection);
                SourceCollection = new ObservableCollection<Source>(_sourcesCollection);

                YearsFinalCollection = new ObservableCollection<Year>(_yearsCollection);
                YearsInitialCollection = new ObservableCollection<Year>(_yearsCollection);
                MonthsInitialCollection = new ObservableCollection<Months>(App.MonthsCatalog);
                MonthsFinalCollection = new ObservableCollection<Months>(App.MonthsCatalog);


            }
            ContactMsft = new Contact();
            ContactState = new Contact();
            ContactStateName = string.Empty;
            isNewRecord = true;
            IsAddOperation = true;
            IsEditOperation = false;
            _previousProgramState = SelectedStateProgram;

            CurrentSource = new Source();
            CurrentProgram = new Program();
            CurrentPartner = new Partner();
            
            CurrentInitialMonth = new Months();
            CurrentInitialYear = new Year();

            CurrentFinalYear = new Year();
            CurrentFinalMonth = new Months();

            SelectedStateProgram = new StateProgram();
            ShowProgramStateEdit();
            
        }
        
        private ObservableCollection<Year> _yearsCollection = new ObservableCollection<Year>();
        private ObservableCollection<Source> _sourcesCollection = new ObservableCollection<Source>();
        private ObservableCollection<Program> _programsCollection = new ObservableCollection<Program>();
        private ObservableCollection<Partner> _partnersCollection = new ObservableCollection<Partner>();

        private void LoadCatalogs()
        {
            MonthsInitialCollection = new ObservableCollection<Months>(App.MonthsCatalog);
            MonthsFinalCollection = new ObservableCollection<Months>(App.MonthsCatalog);
            MsftProgramService.GetYears(OnLoadYears);
            MsftProgramService.GetSources(OnLoadSources);
            MsftProgramService.GetPartners(OnLoadPartners);
            MsftProgramService.GetPrograms(OnLoadPrograms);
        }

        private void OnLoadSources(ObservableCollection<Source> sources)
        {
            if (sources != null)
            {
                SourceCollection = sources;
                _sourcesCollection = sources;
            }

        }

        private void OnLoadPrograms(ObservableCollection<Program>programs)
        {
            if (programs != null)
            {
                ProgramCollection = programs;
                _programsCollection = programs;
            }
        }

        private void OnLoadPartners(ObservableCollection<Partner> partners)
        {
            if (partners != null)
            {
                PartnerCollection = partners;
                _partnersCollection = partners;
            }
        }

        private void OnLoadYears(ObservableCollection<Year> years)
        {
            if (years != null)
            {
                YearsInitialCollection = new ObservableCollection<Year>(years);
                YearsFinalCollection = new ObservableCollection<Year>(years);
            }
        }

        private void UpdateMsftProgram()
        {
            this.ContactMsft = SelectedStateProgram.Contact;
            this.ContactState = SelectedStateProgram.Contact1;
            isNewRecord = false;
            IsEditOperation = true;
            IsAddOperation = false;
            ShowProgramStateEdit();
            //Messenger.Default.Send<LaunchMsftProgramMessage>(new LaunchMsftProgramMessage());
            //Messenger.Default.Send<MsftProgramMessage>(new MsftProgramMessage() { IdOperation = EDIT_OPERATION, MsftProgram = this.SelectedMicrosoftProgramState });
        }

        private void ShowProgramStateInfo()
        {
            ShowProgramEdit = false;
            ShowProgramInfo = true;
            
        }

        private void ShowProgramStateEdit()
        {
            ShowProgramInfo = false;
            ShowProgramEdit = true;
        }


        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}