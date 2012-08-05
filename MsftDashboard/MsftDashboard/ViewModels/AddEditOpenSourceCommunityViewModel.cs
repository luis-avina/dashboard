using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Services;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;
using System.Windows;

namespace MsftDashboard
{
    public class AddEditOpenSourceCommunityViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        protected IMsftService OpenSourceService { get; set; }

        private bool isNewRecord = false;

        private Contact _contactCommunity=new Contact();
        public Contact ContactCommunity
        {
            get
            {
                return _contactCommunity;
            }
            set
            {
                _contactCommunity = value;
                RaisePropertyChanged("ContactCommunity");
            }
        }


        private OpenSourceStateCommunity _currentOpenSourceCommunity = new OpenSourceStateCommunity();
        public OpenSourceStateCommunity CurrentOpenSourceCommunity
        {
            get
            {
                return _currentOpenSourceCommunity;
            }
            set
            {
                _currentOpenSourceCommunity = value;
                RaisePropertyChanged("CurrentOpenSourceCommunity");
            }
        }

        private ObservableCollection<OpenSourceStateCommunity> _openSourceCommunityCollectionRef;

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

        public AddEditOpenSourceCommunityViewModel(IMsftService msftService)
        {
            OpenSourceService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<OpenSourceCommunityMessage>(this,OnEditOpenSourceCommunity);
        }

        private void OnEditOpenSourceCommunity(OpenSourceCommunityMessage msg)
        {
            if (msg != null)
            {
                if(msg.IdOperation==ADD_OPERATION)
                {
                    isNewRecord = true;
                    _openSourceCommunityCollectionRef = msg.OpenSourceCommunityCollection;
                }
                else if(msg.IdOperation ==EDIT_OPERATION)
                {
                    isNewRecord = false;
                    CurrentOpenSourceCommunity = msg.OpenSourceCommunity;
                }
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
            AddContactCommand = new RelayCommand(AddContact);
        }

        private void Save()
        {
            if (isNewRecord)
            {   

                CurrentOpenSourceCommunity.IdContact = ContactCommunity.IdContact;
                CurrentOpenSourceCommunity.State = CurrentState;
                OpenSourceService.SaveOpenSourceCommunity(SaveOperation,CurrentOpenSourceCommunity);
            }
            else
            {
                if (ContactCommunity!=null && CurrentOpenSourceCommunity.IdContact != ContactCommunity.IdContact)
                {
                    CurrentOpenSourceCommunity.IdContact = ContactCommunity.IdContact;
                }

                OpenSourceService.UpdateOpenSourceCommunity(UpdateOperation,CurrentOpenSourceCommunity);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_openSourceCommunityCollectionRef != null)
                {
                    _openSourceCommunityCollectionRef.Add(CurrentOpenSourceCommunity);
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

           
        private void AddContact()
        {
            Messenger.Default.Send<LaunchEditContactMessage>(new LaunchEditContactMessage());
            Messenger.Default.Send<ContactMessage>(new ContactMessage(){Contact=this.ContactCommunity});
        }

        private void LoadData()
        {
            OpenSourceService.GetStates(OnLoadStates);
        }

        private void OnLoadStates(ObservableCollection<State> statesCollection)
        {
            if (statesCollection != null)
            {
                StateCollection = statesCollection;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
