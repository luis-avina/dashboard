using GalaSoft.MvvmLight;
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using System.ServiceModel.DomainServices.Client;
using System.Windows;

namespace MsftDashboard
{
    public class ContactsViewModel:ViewModelBase
    {
        protected IMsftService ContactService { get; set; }

        private bool _showContactsGrid = false;
        public bool ShowContactsGrid
        {
            get
            {
                return _showContactsGrid;
            }
            set
            {
                _showContactsGrid = value;
                RaisePropertyChanged("ShowContactsGrid");
            }
        }
    

        private const int ADD_CONTACT = 1;
        private const int EDIT_CONTACT = 2;

        private Contact _previousContact ;

        private bool _isEnabledGrid=true;
        public bool IsEnableDataGrid
        {
            get
            {
                return _isEnabledGrid;
            }
            set
            {
                _isEnabledGrid = value;
                RaisePropertyChanged("IsEnableDataGrid");
            }
        }

        private bool isNewRecord = false;

        private Contact _contactProgramsRef;

        private bool _showContactInfo = false;
        public bool ShowContactInfo
        {
            get
            {
                return _showContactInfo;
            }
            set
            {
                _showContactInfo = value;
                RaisePropertyChanged("ShowContactInfo");
            }

        }

        private bool _showAddEditContact=false;
        public bool ShowAddEditContact
        {
            get
            {
                return _showAddEditContact;
            }
            set
            {
                _showAddEditContact = value;
                RaisePropertyChanged("ShowAddEditContact");
            }
        }

        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand EditContactCommand { get; set; }
        public RelayCommand SelectContactCommand { get; set;}
        public RelayCommand SelectedContactGridCommand{get;set;}
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }


        private string _titleContactWindow = string.Empty;
        public string TitleContactWindow
        {
            get
            {
                return _titleContactWindow;
            }
            set
            {
                _titleContactWindow = value;
                RaisePropertyChanged("TitleContactWindow");
            }
        }

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                RaisePropertyChanged("Contacts");
            }
        }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                RaisePropertyChanged("SelectedContact");
            }
        }

        private string _titleContactEditWindow;
        public string TitleContactEditWindow
        {
            get
            {
                return _titleContactEditWindow;
            }
            set
            {
                _titleContactEditWindow = value;
                RaisePropertyChanged("TitleContactEditWindow");
            }
        }

        public ContactsViewModel(IMsftService contactService)
        {
            ContactService = contactService;
            RegisterMessages();
            RegisterCommands();
            LoadContacts();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<ContactMessage>(this, OnSelectedContact);
        }

        private void OnSelectedContact(ContactMessage msg)
        {
            if (msg != null)
            {
                _contactProgramsRef = msg.Contact;
            }
        }

        private void RegisterCommands()
        {
            AddContactCommand = new RelayCommand(OnAddCommand);
            EditContactCommand = new RelayCommand(OnEditCommand);
            SelectedContactGridCommand = new RelayCommand(OnSelectCommand);
            SelectContactCommand = new RelayCommand(OnSelectContactCommand);
            SaveCommand = new RelayCommand(OnSaveCommand);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        private void OnAddCommand()
        {
            _previousContact = SelectedContact;
            SelectedContact = new Contact();
            ShowEdictContact();
            isNewRecord = true;
            IsEnableDataGrid = false;
        }

        private void OnEditCommand()
        {
            ShowEdictContact();
            isNewRecord = false;
        }

        private void OnSelectCommand()
        {
           ShowContact();
        }

        private void OnSelectContactCommand()
        {
            _contactProgramsRef.IdContact = SelectedContact.IdContact;
            _contactProgramsRef.FirstName = SelectedContact.FirstName;
            _contactProgramsRef.LastName = SelectedContact.LastName;
            _contactProgramsRef.Email = SelectedContact.Email;
            _contactProgramsRef.CellPhone = SelectedContact.CellPhone;
            _contactProgramsRef.Telephone = SelectedContact.Telephone;
        }

        private void OnSaveCommand()
        {
            if (isNewRecord)
            {
                ContactService.SaveContact(SaveOperation, SelectedContact);
            }
            else
            {
                ContactService.UpdateContact(UpdateOperation, SelectedContact); 
            }
        }

        private void OnCancelCommand()
        {
            if (ShowContactsGrid)
            {

                if (isNewRecord)
                {
                    SelectedContact = _previousContact;
                }
                ShowContact();
            }
            else
            {
                SelectedContact = new Contact();
            }
        }

        private void LoadContacts()
        {
            Contacts = null;
            ContactService.GetContacts(GetContactsCallBack);
        }

        private void GetContactsCallBack(ObservableCollection<Contact> contacts)
        {
            if (contacts != null)
            {
                
                this.Contacts = contacts;
                if (Contacts.Count > 0)
                {
                    ShowContactsGrid = true;
                    isNewRecord = true;
                }
                else
                {
                    SelectedContact = new Contact();
                    isNewRecord = true;
                    ShowContactsGrid = false;
                    ShowEdictContact();
                }
            }
            
        }

        private void ShowContact()
        {
            ShowAddEditContact = false;
            ShowContactInfo = true;
            IsEnableDataGrid = true;
        }

        private void ShowEdictContact()
        {
           ShowAddEditContact = true;
           ShowContactInfo = false;
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                _previousContact = null;
                Contacts.Add(SelectedContact);
                ShowContactsGrid = true;
                ShowContact();

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
                ShowContact();
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
            
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
