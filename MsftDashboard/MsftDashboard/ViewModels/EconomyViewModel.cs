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
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using System.ServiceModel.DomainServices.Client;
using MsftDashboard.Models;

namespace MsftDashboard
{
    public class EconomyViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        private string _stateName;
        public string StateName
        {
            get
            {
                return _stateName;
            }
            set
            {
                _stateName = value;
                RaisePropertyChanged("StateName");
            }
        }

        private bool isCatalogsAlreadyLoaded = false;

        private bool _isCombosEnabled=false;
        public bool IsCombosEnabled
        {
            get
            {
                return _isCombosEnabled;
            }
            set
            {
                _isCombosEnabled = value;
                RaisePropertyChanged("IsCombosEnabled");
            }
        }

        private bool _isNewRecord = false;
        public bool IsNewRecord
        {
            get
            {
                return _isNewRecord;
            }
            set
            {
                _isNewRecord = value;
                RaisePropertyChanged("IsNewRecord");
            }
        }
        private StateEconomicInfo _previousStateEcomicInfo;
        

        protected IMsftService EconomyService { get; set; }

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


        private bool _showEconomicInfo = false;
        public bool ShowEconomicInfo
        {
             get
             {
                 return _showEconomicInfo;
             }
             set
             {
                 _showEconomicInfo = value;
                 RaisePropertyChanged("ShowEconomicInfo");
             }
         }
         
        private bool _showEdictEconomicInfo=false;
        public bool ShowEdictEconomicInfo
        {
            get
            {
                return _showEdictEconomicInfo;
            }
            set
            {
                _showEdictEconomicInfo = value;
                RaisePropertyChanged("ShowEdictEconomicInfo");
            }
        }

        private bool _isEnableDataGridStates = true;
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

        private bool _showEconomyStateInfo = false;
        public bool ShowEconomyStateInfo
        {
            get
            {
                return _showEconomyStateInfo;
            }
            set
            {
                _showEconomyStateInfo = value;
                RaisePropertyChanged("ShowEconomyStateInfo");
            }
        }

        private bool _isShowListEconomicStater=false;
        public bool IsShowListEconomicState
        {
            get
            {
                return _isShowListEconomicStater;
            }
            set
            {
                _isShowListEconomicStater = value;
                RaisePropertyChanged("IsShowListEconomicState");
            }
        }

        private StateEconomicInfo _selectedEconomicState;
        public StateEconomicInfo SelectedEconomicState
        {
            get
            {
                return _selectedEconomicState;
            }
            set
            {
                _selectedEconomicState = value;
                RaisePropertyChanged("SelectedEconomicState");
            }
        }

        private ObservableCollection<StateEconomicInfo> _stateEconomicInfoCollection;
        public ObservableCollection<StateEconomicInfo> StateEconomicInfoCollection
        {
            get
            {
                return _stateEconomicInfoCollection;
            }
            set
            {
                _stateEconomicInfoCollection = value;
                RaisePropertyChanged("StateEconomicInfoCollection");
            }
        }

        private State _selectedStateEdit;
        public State SelectedStateEdit
        {
            get
            {
                return _selectedStateEdit;
            }
            set
            {
                _selectedStateEdit = value;
                RaisePropertyChanged("SelectedStateEdit");
            }
        }

        private ObservableCollection<State> _stateCollectionEdit;
        public ObservableCollection<State> StateCollectionEdit
        {
            get
            {
                return _stateCollectionEdit;
            }
            set
            {
                _stateCollectionEdit = value;
                RaisePropertyChanged("StateCollectionEdit");
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


        public RelayCommand AddEconomictStateCommand { get; set; }
        public RelayCommand EditEconomicStateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SelectStateCommand { get; set; }
        public RelayCommand SelectEconomicStateCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public EconomyViewModel(IMsftService msftService)
        {
            EconomyService = msftService;

            RegisterCommands();
           
            LoadInfo();
        }


        private void OnGetEconomyCollection(EconomyMessage msg)
        {
            if (msg != null && msg.EconomyInfoCollection != null)
            {
                StateEconomicInfoCollection = msg.EconomyInfoCollection;
            }

        }

        private void RegisterCommands()
        {
            AddEconomictStateCommand = new RelayCommand(AddEconomyChild);
            EditEconomicStateCommand = new RelayCommand(EditEconomyChild);
            SelectStateCommand = new RelayCommand(OnSelectState);
            SelectEconomicStateCommand = new RelayCommand(OnSelectEconomicState);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddEconomyChild()
        {
            if (!isCatalogsAlreadyLoaded)
            {
                LoadCatalogs();
                isCatalogsAlreadyLoaded = true;
            }
            IsCombosEnabled = false;
            StateName = SelectedState.Name;
            IsNewRecord = true;
            _previousStateEcomicInfo = SelectedEconomicState;
            SelectedEconomicState = new StateEconomicInfo();
            ShowEditEconomic();
        }

        private void LoadCatalogs()
        {
            MonthsCollection = App.MonthsCatalog;
            EconomyService.GetYears(OnLoadYears);
            
        }

        private void OnLoadYears(ObservableCollection<Year> years)
        {
            if (years != null)
            {
                YearsCollection = years;
                isCatalogsAlreadyLoaded = true;
            }

        }

        private void EditEconomyChild()
        {
            IsCombosEnabled = true;
            IsNewRecord = false;
            ShowEditEconomic(); 
        }

        private void OnSelectState()
        {
            if (SelectedState.Name != null)
            {
                EconomyService.GetEconomyStateInformationByState(OnLoadEconomyStateCollection,SelectedState.IdState);
                IsEnableDataGridDates = true;
            }
        }

        private void OnSelectEconomicState()
        {
            if (SelectedEconomicState != null)
            {
                ShowEconomicInfo = true;
            }
        }

        private void Save()
        {
            if (IsNewRecord)
            {
                SelectedEconomicState.IdState = SelectedState.IdState;
                SelectedEconomicState.FromDate = new DateTime(CurrentYear.Year1, CurrentMonth.Id, 1);
                EconomyService.SaveEconomyState(SaveOperation, SelectedEconomicState);
            }
            else
            {
                EconomyService.UpdateStateEconomyInfo(UpdateOperation, SelectedEconomicState);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                IsShowListEconomicState = true;
                StateEconomicInfoCollection.Add(SelectedEconomicState);
                
                _previousStateEcomicInfo = null;
                
                ShowEconomy();
                
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void UpdateOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                ShowEconomy();   
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }


        private void Cancel()
        {
            if (IsShowListEconomicState)
            {
                ShowEconomy();
                if (IsNewRecord)
                {
                    SelectedEconomicState = _previousStateEcomicInfo;
                }
            }
            else
            {
                SelectedEconomicState = new StateEconomicInfo();
            }
            
        }

        private void OnLoadEconomyStateCollection(ObservableCollection<StateEconomicInfo> economyStateCollection)
        {
            if (economyStateCollection != null)
            {
                StateEconomicInfoCollection = economyStateCollection;
                if (economyStateCollection.Count > 0)
                {
                    IsShowListEconomicState = true;
                }
                else
                {
                    IsShowListEconomicState = false;
                    SelectedEconomicState = new StateEconomicInfo();
                    IsNewRecord = true;
                    LoadCatalogs();
                    ShowEditEconomic();
                }
            }
            
        }


        private void LoadInfo()
        {
            StateEconomicInfoCollection = null;
            EconomyService.GetStates(GetStatesCallBack);
        }

        private void GetStatesCallBack(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        private void GetEconomyCallBack(ObservableCollection<StateEconomicInfo> economy)
        {
            if (economy != null)
            {
                //foreach (var bookOfDay in booksOfDay)
                //{
                //    BooksOfTheDay.Add(bookOfDay);
                //}
                this.StateEconomicInfoCollection = economy;
            }
        }

        private void ShowEconomy()
        {
            ShowEconomicInfo = true;
            ShowEdictEconomicInfo = false;
            IsEnableDataGridDates = true;
            IsEnableDataGridStates = true;
        }

        private void ShowEditEconomic()
        {
            ShowEconomicInfo = false;
            ShowEdictEconomicInfo = true;
            IsEnableDataGridDates = false;
            IsEnableDataGridStates= false;
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
