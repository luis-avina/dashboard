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
using MsftDashboard.Models;
using MsftDashboard.Services;
using MsftDashboard.Web.Models;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditEconomyViewModel:ViewModelBase
    {
        protected IMsftService EconomyService { get; set; }

        private bool isNewRecord = false;

        public RelayCommand SaveCommand { get; set; }

        private const string TITLE_ECONOMY_ADD = "Agregar Información Economica del Estado";
        private const string TITLE_ECONOMY_EDIT = "Editar Información Economica del Estado";

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;
       
        private ObservableCollection<StateEconomicInfo> _stateEconomicInfoRef;

        
        private string _titleEconomyWindow;
        public string TitleEconomyWindow
        {
            get
            {
                return _titleEconomyWindow;
            }
            set
            {
                _titleEconomyWindow = value;
                RaisePropertyChanged("TitleEconomyWindow");
            }
        }

        private bool _isError;
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
                RaisePropertyChanged("IsError");
            }
        }

        private bool _isSuccess;
        public bool IsSuccess
        {
            get
            {
                return _isSuccess;
            }
            set
            {
                _isSuccess = value;
                RaisePropertyChanged("IsSuccess");
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

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

        private Months _currentMonth;
        public Months CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                RaisePropertyChanged("CurrentMonth");
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
        private ObservableCollection<Months> _monthsCollection;
        public ObservableCollection<Months> MonthsCollection
        {
            get
            {
                return _monthsCollection;
            }
            set
            {
                _monthsCollection = value;
                RaisePropertyChanged("MonthsCollection");
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

        private StateEconomicInfo _economyState= new StateEconomicInfo();
        public StateEconomicInfo EconomyState 
        {
            get
            {
                return _economyState;
            }
            set
            {
                _economyState = value;
                RaisePropertyChanged("EconomyState");
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

        public AddEditEconomyViewModel(IMsftService msftService)
        {
            EconomyState = new StateEconomicInfo();
            EconomyService = msftService;
            MonthsCollection = new ObservableCollection<Months>(App.MonthsCatalog);
            RegisterMessages();
            RegisterCommands();
            LoadData();

        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(SaveEconomicStateInfo);
        }

        private void SaveEconomicStateInfo()
        {
            if(isNewRecord)
            {
                EconomyState.State = CurrentState;
                EconomyState.FromDate = new DateTime(CurrentYear.Year1, CurrentMonth.Id, 1);

                EconomyService.SaveEconomyState(SaveEconomyOperation,EconomyState);
            }
            else
            {
                EconomyService.UpdateStateEconomyInfo(UpdateEconomyOperation,EconomyState);
            }
        }

        private void SaveEconomyOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                IsSuccess = true;
                if(_stateEconomicInfoRef!=null)
                {
                    _stateEconomicInfoRef.Add(EconomyState);
                    Messenger.Default.Send<EconomyMessage>(new EconomyMessage()
                    {
                        EconomyInfoCollection = _stateEconomicInfoRef
                    });        
                }
            }
            else
            {
                IsError = true;
                ErrorMessage = op.Error.Message;
                op.MarkErrorAsHandled();
            }
        }

        private void UpdateEconomyOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                IsSuccess = true;
            }
            else
            {
                IsError = true;
                ErrorMessage = op.Error.Message;
                op.MarkErrorAsHandled();
            }
        }


        private void RegisterMessages()
        {
            Messenger.Default.Register<EconomyMessage>(this,OnReceiveEconomyInfo);
        }

        private void OnReceiveEconomyInfo(EconomyMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNewRecord = true;
                    TitleEconomyWindow = TITLE_ECONOMY_ADD;
                    _stateEconomicInfoRef = msg.EconomyInfoCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNewRecord = false;
                    TitleEconomyWindow = TITLE_ECONOMY_EDIT;
                    EconomyState = msg.EconomyInfo;
                }
            }
        }

        private void LoadData()
        {
            EconomyService.GetStates(GetStatesCallBack);
            EconomyService.GetYears(GetYearsCallBack);
        }

        private void GetStatesCallBack(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        private void GetYearsCallBack(ObservableCollection<Year> years)
        {
            if (years != null)
            {
                YearsCollection = years;
            }
        }
        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
