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
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using System.ServiceModel.DomainServices.Client;
using MsftDashboard.Models;

namespace MsftDashboard
{
    public class AddEditSocialOrganizationViewModel:ViewModelBase
    {
        protected IMsftService SocialOrgService { get; set; }

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        private bool isNew = false;

        public RelayCommand SaveCommand{get;set;}

        private ObservableCollection<SocialOrganizationInformation> _socOrgInfoCollectionRef;

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

        private SocialOrganizationInformation _currentSocialOgInfo= new SocialOrganizationInformation();
        public SocialOrganizationInformation CurrentSocialOgInfo
        {
            get
            {
                return _currentSocialOgInfo;
            }
            set
            {
                _currentSocialOgInfo = value;
                RaisePropertyChanged("CurrentSocialOgInfo");
            }
        }


        public AddEditSocialOrganizationViewModel(IMsftService msftService)
        {
            SocialOrgService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (isNew)
            {
                CurrentSocialOgInfo.PopulationAttended = CurrentPopulationAttended;
                CurrentSocialOgInfo.SocialCause = CurrentSocialCause;
                CurrentSocialOgInfo.State = CurrentState;
                SocialOrgService.SaveSocialOrganizationInformation(AddOperation,CurrentSocialOgInfo);
            }
            else
            {
                SocialOrgService.UpdateSocialOrganizationInformation(UpdateOperation, CurrentSocialOgInfo);
            }
        }

        private void AddOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_socOrgInfoCollectionRef != null)
                {
                    _socOrgInfoCollectionRef.Add(CurrentSocialOgInfo);
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
            Messenger.Default.Register<SocialOrgInfoMessage>(this,OnEditSocialOrg);
        }

        private void OnEditSocialOrg(SocialOrgInfoMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNew = true;
                    _socOrgInfoCollectionRef = msg.SocOrgInfoCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNew = false;
                    CurrentSocialOgInfo = msg.SocOrgInfo;
                    CurrentState = CurrentSocialOgInfo.State;
                    CurrentSocialCause = CurrentSocialOgInfo.SocialCause;
                    CurrentPopulationAttended = CurrentSocialOgInfo.PopulationAttended;
                }
            }

        }

        private void LoadData()
        {
            SocialOrgService.GetSocialCause(OnLoadSocialCause);
            SocialOrgService.GetPopulationAttended(OnLoadPopulationAttended);
            SocialOrgService.GetStates(OnLoadStates);

        }

        private void OnLoadSocialCause(ObservableCollection<SocialCause>socCause)
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
