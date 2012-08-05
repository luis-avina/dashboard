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
using MsftDashboard.Models;
using MsftDashboard.Services;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditMsftProgramViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddContactStateCommand { get; set; }
        public RelayCommand AddContactMsftCommand { get; set; }

        private bool isNew = false;

        protected IMsftService MsftProgramService{get;set;}

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

        private ObservableCollection<MicrosoftProgramState> _programMsftCollectionRef;

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
                RaisePropertyChanged("ContactMsft");
            }
        }

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
                RaisePropertyChanged("ContactState");
            }
        }

        private MicrosoftProgramState _currentMsftProgram = new MicrosoftProgramState();
        public MicrosoftProgramState CurrentMsftProgram
        {
            get
            {
                return _currentMsftProgram;
            }
            set
            {
                _currentMsftProgram = value;
                RaisePropertyChanged("CurrentMsftProgram");
            }
        }

        public AddEditMsftProgramViewModel(IMsftService msftService)
        {
            MsftProgramService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            AddContactMsftCommand = new RelayCommand(AddContactMsft);
            AddContactStateCommand = new RelayCommand(AddContactState);
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (isNew)
            {
                CurrentMsftProgram.Program = CurrentProgram;
                CurrentMsftProgram.Partner = CurrentPartner;
                CurrentMsftProgram.IdContactState = ContactState.IdContact;
                CurrentMsftProgram.IdContactMsft = ContactMsft.IdContact;
                CurrentMsftProgram.Source = CurrentSource;
                CurrentMsftProgram.State = CurrentState;
                CurrentMsftProgram.DateFrom = new DateTime(CurrentInitialYear.Year1,CurrentInitialMonth.Id,1);
                CurrentMsftProgram.DateTo = new DateTime(CurrentFinalYear.Year1, CurrentFinalYear.Id, 1);
                MsftProgramService.SaveProgramMsft(SaveOperation, CurrentMsftProgram);
            }
            else
            {
                MsftProgramService.UpdateProgramMsft(UpdateOperation,CurrentMsftProgram);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_programMsftCollectionRef != null)
                {
                    _programMsftCollectionRef.Add(CurrentMsftProgram);
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

        private void AddContactMsft()
        {
            Messenger.Default.Send<LaunchEditContactMessage>(new LaunchEditContactMessage());
            Messenger.Default.Send<ContactMessage>(new ContactMessage(){Contact=this.ContactMsft});

        }

        private void AddContactState()
        {
            Messenger.Default.Send<LaunchEditContactMessage>(new LaunchEditContactMessage());
            Messenger.Default.Send<ContactMessage>(new ContactMessage(){Contact=this.ContactState});
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<MsftProgramMessage>(this,OnEditMsftProgram);
        }

        private void OnEditMsftProgram(MsftProgramMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNew = true;
                    _programMsftCollectionRef = msg.MsftProgramCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNew = false;
                    CurrentMsftProgram = msg.MsftProgram;
                }
            }
        }

        private void LoadData()
        {
            LoadMonths();
            MsftProgramService.GetYears(OnGetYearsCallBack);
            MsftProgramService.GetStates(OnGetStatesCallBack);
            MsftProgramService.GetSources(OnGetSourceCallBack);
            MsftProgramService.GetPartners(OnGetPartnerCallBack);
            MsftProgramService.GetPrograms(OnGetProgramCallBack);

        }

        private void OnGetProgramCallBack(ObservableCollection<Program> programCollection)
        {
            if (programCollection != null)
            {
                ProgramCollection = programCollection;
            }
        }

        private void OnGetPartnerCallBack(ObservableCollection<Partner> partnerCollection)
        {
            if (partnerCollection != null)
            {
                PartnerCollection = partnerCollection;
            }
        }

        private void OnGetSourceCallBack(ObservableCollection<Source> sourceCollection)
        {
            if (sourceCollection != null)
            {
                SourceCollection = sourceCollection;
            }
        }

        private void OnGetYearsCallBack(ObservableCollection<Year> yearsCollection)
        {
            YearsInitialCollection = new ObservableCollection<Year>(yearsCollection);
            YearsFinalCollection = new ObservableCollection<Year>(yearsCollection);
        }

        private void OnGetStatesCallBack(ObservableCollection<State> stateCollection)
        {
            if (stateCollection != null)
            {
                StateCollection = stateCollection;
            }
        }
        private void LoadMonths()
        {
            MonthsInitialCollection = new ObservableCollection<Months>(App.MonthsCatalog);
            MonthsFinalCollection = new ObservableCollection<Months>(App.MonthsCatalog);
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
