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
using MsftDashboard.Services;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Messages;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Models;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditCapacitationCenterViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        protected IMsftService CapCenterService { get; set; }
        
        private bool isNewRecord = false;
        public RelayCommand SaveCommand { get; set; }

        private ObservableCollection<PopulationAttended> _populationAttendedCollection;
        public ObservableCollection<PopulationAttended> PopulationAttendedCollection
        {
            get
            {
                return _populationAttendedCollection;
            }
            set
            {
                _populationAttendedCollection = value;
                RaisePropertyChanged("PopulationAttendedCollection");
            }
        }

        private SocialCause _currentSocialCause;
        public SocialCause CurrentSocialCause
        {
            get
            {
                return _currentSocialCause;
            }
            set
            {
                _currentSocialCause = value;
                RaisePropertyChanged("CurrentSocialCause");
            }
        }

        private PopulationAttended _currentPopulationAttended;
        public PopulationAttended CurrentPopulationAttended
        {
            get
            {
                return _currentPopulationAttended;
            }
            set
            {
                _currentPopulationAttended = value;
                RaisePropertyChanged("CurrentPopulationAttended");
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

        private ObservableCollection<SocialCause> _socialCauseCollection;
        public ObservableCollection<SocialCause> SocialCauseCollection
        {
            get
            {
                return _socialCauseCollection;
            }
            set
            {
                _socialCauseCollection = value;
                RaisePropertyChanged("SocialCauseCollection");
            }
        }

        private SocialOrganization _currentSocialOrganization;
        public SocialOrganization CurrentSocialOrganization
        {
            get
            {
                return _currentSocialOrganization;
            }
            set
            {
                _currentSocialOrganization = value;
                RaisePropertyChanged("CurrentSocialOrganization");
            }
        }

        private ObservableCollection<SocialOrganization> _socialOrganizationCollection;
        public ObservableCollection<SocialOrganization> SocialOrganizationCollection
        {
            get
            {
                return _socialOrganizationCollection;
            }
            set
            {
                _socialOrganizationCollection = value;
                RaisePropertyChanged("SocialOrganizationCollection");
            }
        }

        private Conectivity _currentConectivity;
        public Conectivity CurrentConectivity
        {
            get
            {
                return _currentConectivity;
            }
            set
            {
                _currentConectivity = value;
                RaisePropertyChanged("CurrentConectivity");
            }
        }

        private ObservableCollection<Conectivity> _conectivityCollection;
        public ObservableCollection<Conectivity> ConectivityCollection
        {
            get
            {
                return _conectivityCollection;
            }
            set
            {
                _conectivityCollection = value;
                RaisePropertyChanged("ConectivityCollection");
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

        private CapacitationCenterInformation _currentCapCenterInfo = new CapacitationCenterInformation();
        public CapacitationCenterInformation CurrentCapCenterInfo
        {
            get
            {
                return _currentCapCenterInfo;
            }
            set
            {
                _currentCapCenterInfo = value;
                RaisePropertyChanged("CurrentCapCenterInfo");
            }
        }

        private ObservableCollection<CapacitationCenterInformation> _capCenterRefColl;

        public AddEditCapacitationCenterViewModel(IMsftService msftService)
        {
            CapCenterService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<CapacitationCenterMessage>(this, OnEditCapacitationCenter);
        }

        private void OnEditCapacitationCenter(CapacitationCenterMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNewRecord = true;
                    _capCenterRefColl = msg.CapCenterInfoCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNewRecord = false;
                    CurrentCapCenterInfo = msg.CapCenterInfo;
                }
            }
            
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if(isNewRecord)
            {
                CurrentCapCenterInfo.Conectivity = CurrentConectivity;
                CurrentCapCenterInfo.SocialCause = CurrentSocialCause;
                CurrentCapCenterInfo.SocialOrganization = CurrentSocialOrganization;
                CurrentCapCenterInfo.PopulationAttended = CurrentPopulationAttended;
                CurrentCapCenterInfo.State = CurrentState;
                CurrentCapCenterInfo.DateFrom = new DateTime(CurrentYear.Year1,CurrentMonth.Id,1);

                CapCenterService.SaveCapacitationCenter(SaveOperation,CurrentCapCenterInfo);
            }
            else
            {
                CapCenterService.UpdateCapacitationCenter(UpdateOperation,CurrentCapCenterInfo);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_capCenterRefColl != null)
                {
                    _capCenterRefColl.Add(CurrentCapCenterInfo);
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

        private void LoadData()
        {
            CapCenterService.GetSocialCause(OnLoadSocialCause);
            CapCenterService.GetPopulationAttended(OnLoadPopulationAttended);
            CapCenterService.GetStates(OnLoadStates);
            CapCenterService.GetYears(OnLoadYears);
            CapCenterService.GetSocialOrganization(OnLoadSocialOrganization);
            CapCenterService.GetConectivity(OnLoadConectivity);
            MonthsCollection = new ObservableCollection<Months>(App.MonthsCatalog);
        }

        private void OnLoadConectivity(ObservableCollection<Conectivity> conectivityCollection)
        {
            if (conectivityCollection != null)
            {
                ConectivityCollection = conectivityCollection;
            }

        }

        private void OnLoadYears(ObservableCollection<Year> years)
        {
            if (years != null)
            {
                YearsCollection = years;
            }
        }

        private void OnLoadSocialOrganization(ObservableCollection<SocialOrganization> socialOrg)
        {
            if (socialOrg != null)
            {
                SocialOrganizationCollection = socialOrg;
            }
        }

        private void OnLoadSocialCause(ObservableCollection<SocialCause> socCause)
        {
            if (socCause != null)
            {
                SocialCauseCollection = socCause;
            }
        }

        private void OnLoadPopulationAttended(ObservableCollection<PopulationAttended> popAttended)
        {
            if (popAttended != null)
            {
                PopulationAttendedCollection = popAttended;
            }
        }

        private void OnLoadStates(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
