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
using MsftDashboard.Models;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditMexicoAgreementViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        private bool isNew = false;

        protected IMsftService MexicoAgreementService{get;set;}

        public RelayCommand SaveCommand { get; set; }

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

        private TypeAgreement _currentTypeAgreement;
        public TypeAgreement CurrentTypeAgreement
        {
            get
            {
                return _currentTypeAgreement;
            }
            set
            {
                _currentTypeAgreement = value;
                RaisePropertyChanged("CurrentTypeAgreement");
            }
        }
        private ObservableCollection<TypeAgreement> _typeAgreementCollection;
        public ObservableCollection<TypeAgreement> TypeAgreementCollection
        {
            get
            {
                return _typeAgreementCollection;
            }
            set
            {
                _typeAgreementCollection = value;
                RaisePropertyChanged("TypeAgreementCollection");
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

        private MexicoAgreement _currentMexicoAgreement = new MexicoAgreement();
        public MexicoAgreement CurrentMexicoAgreement
        {
            get
            {
                return _currentMexicoAgreement;
            }
            set
            {
                _currentMexicoAgreement = value;
                RaisePropertyChanged("CurrentMexicoAgreement");
            }
        }

        private ObservableCollection<MexicoAgreement> _mexicoAgreementRefCollection;

        public AddEditMexicoAgreementViewModel(IMsftService msftService)
        {
            MexicoAgreementService = msftService;
            RegisterCommands();
            RegisterMessages();
            LoadData();
        }

        private void LoadData()
        {
            LoadMonths();
            MexicoAgreementService.GetYears(OnGetYearsCallBack);
            MexicoAgreementService.GetStates(OnGetStatesCallBack);
            MexicoAgreementService.GetTypeAgreement(OnGetTypeAgreementCallBack);

        }

        private void LoadMonths()
        {
            MonthsInitialCollection = new ObservableCollection<Months>(App.MonthsCatalog);
            MonthsFinalCollection = new ObservableCollection<Months>(App.MonthsCatalog);
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

        private void OnGetTypeAgreementCallBack(ObservableCollection<TypeAgreement> typeAgreements)
        {
            if (typeAgreements != null)
            {
                TypeAgreementCollection = typeAgreements;
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<MexicoAgreementMessages>(this,OnEditMexicoAgreement);
        }

        private void OnEditMexicoAgreement(MexicoAgreementMessages msg)
        {
            if (msg!= null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNew = true;
                    _mexicoAgreementRefCollection = msg.MexicoAgreementCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNew = false;
                    CurrentMexicoAgreement = msg.MexicoAgreement;
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
                CurrentMexicoAgreement.State = CurrentState;
                CurrentMexicoAgreement.TypeAgreement = CurrentTypeAgreement;
                CurrentMexicoAgreement.DateFrom = new DateTime(CurrentInitialYear.Year1,CurrentInitialMonth.Id,1);
                CurrentMexicoAgreement.DateTo = new DateTime(CurrentFinalYear.Year1, CurrentFinalMonth.Id, 1);

                MexicoAgreementService.SaveMexicoAgreement(SaveOperation,CurrentMexicoAgreement);
            }
            else
            {
                MexicoAgreementService.UpdateMexicoAgreement(UpdateOperation,CurrentMexicoAgreement);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                _mexicoAgreementRefCollection.Add(CurrentMexicoAgreement);
                CurrentMexicoAgreement = new MexicoAgreement();
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

    }
}
