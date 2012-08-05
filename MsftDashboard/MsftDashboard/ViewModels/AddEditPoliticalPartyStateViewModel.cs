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
using MsftDashboard.Models;
using MsftDashboard.Web.Models;
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class AddEditPoliticalPartyStateViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand SaveCommand { get; set; }

        private bool isNew = false;

        private ObservableCollection<PoliticalInformationState> _politicalStateRef;

        protected IMsftService PoliticalService { get; set; }

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

        private PoliticalParty _currentPoliticalParty;
        public PoliticalParty CurrentPoliticalParty
        {
            get
            {
                return _currentPoliticalParty;
            }
            set
            {
                _currentPoliticalParty = value;
                RaisePropertyChanged("CurrentPoliticalParty");
            }
        }

        private ObservableCollection<PoliticalParty> _politicalPartyCollection;
        public ObservableCollection<PoliticalParty> PoliticalPartyCollection
        {
            get
            {
                return _politicalPartyCollection;
            }
            set
            {
                _politicalPartyCollection = value;
                RaisePropertyChanged("PoliticalPartyCollection");
            }
        }

        private PoliticalInformationState _currentPoliticalState=new PoliticalInformationState();
        public PoliticalInformationState CurrentPoliticalState
        {
            get
            {
                return _currentPoliticalState;
            }
            set
            {
                _currentPoliticalState = value;
                RaisePropertyChanged("CurrentPoliticalState");
            }
        }


        public AddEditPoliticalPartyStateViewModel(IMsftService msftService)
        {
            PoliticalService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<PoliticalStateMessage>(this,OnEditPoliticalState);
        }

        private void OnEditPoliticalState(PoliticalStateMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNew = true;
                    _politicalStateRef = msg.PoliticalStateCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNew = false;
                    CurrentPoliticalState = msg.PoliticaStateInfo;
                }
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (isNew)
            {
                CurrentPoliticalState.State = CurrentState;
                CurrentPoliticalState.PoliticalParty = CurrentPoliticalParty;
                CurrentPoliticalState.DateFrom = new DateTime(CurrentInitialYear.Year1, CurrentInitialMonth.Id, 1);
                CurrentPoliticalState.DateTo = new DateTime(CurrentFinalYear.Year1, CurrentFinalMonth.Id, 1);

                PoliticalService.SavePoliticalState(SaveOperation, CurrentPoliticalState);
            }
            else
            {
                PoliticalService.UpdatePoliticalState(UpdateOperation, CurrentPoliticalState);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                _politicalStateRef.Add(CurrentPoliticalState);
                CurrentPoliticalState = new PoliticalInformationState();
            }
            else
            {
                MessageBox.Show("Ocurrio un error" + op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void UpdateOperation(SubmitOperation op)
        {
            if (op.HasError)
            {
                MessageBox.Show("Ocurrio un error" + op.Error.Message);
                op.MarkErrorAsHandled();
            }

        }

        private void LoadData()
        {
            LoadMonths();
            PoliticalService.GetYears(OnGetYearsCallBack);
            PoliticalService.GetStates(OnGetStatesCallBack);
            PoliticalService.GetPoliticalParty(OnGetPoliticalPartyCallBack);

        }

        private void OnGetPoliticalPartyCallBack(ObservableCollection<PoliticalParty> politicalParties)
        {
            if (politicalParties != null)
            {
                PoliticalPartyCollection = politicalParties;
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
    }
}
