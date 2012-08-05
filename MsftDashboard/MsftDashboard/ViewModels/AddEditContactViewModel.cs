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
using MsftDashboard.Common;
using MsftDashboard.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Web.Models;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;

namespace MsftDashboard
{
    public class AddEditContactViewModel:ViewModelBase
    {
        private const string  ADD_CONTACT_TITLE = "Agregar Contacto";
        private const string EDIT_CONTACT_TITLE="Editar Contacto";

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;
        private bool isNewRecord = false;

        private ObservableCollection<Contact> _contacsReferences;

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

        public RelayCommand SaveCommand { get; set; }

        protected IMsftService ContactChildService { get; set; }

        private Contact _contact=new Contact();
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                RaisePropertyChanged("Contact");
                RemoveMessages();
            }
        }

        private string _titleContactWindow;
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

        public AddEditContactViewModel(IMsftService msftService)
        {
            RegisterMessages();
            RegisterCommands();

            ContactChildService = msftService;
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        { 
            if (isNewRecord)
            {
                Contact.Status = true;
                ContactChildService.SaveContact(SaveContactCallback, Contact);
                if (_contacsReferences != null)
                {
                    _contacsReferences.Add(Contact);
                    Messenger.Default.Send<ContactsMessageBackOp>(new ContactsMessageBackOp()
                                         {
                                             ContactCollection = _contacsReferences
                                         });
                                
                }
            }
            else
            {
               ContactChildService.UpdateContact(UpdateContactCallBack, Contact);
            }
           

        }

        private void SaveContactCallback(SubmitOperation op)
        {
            if (!op.HasError)
            {

                Contact = new Contact();
                IsSuccess = true;


            }
            else
            {
                ErrorMessage = op.Error.Message;
                IsError = true;
                op.MarkErrorAsHandled();
            }
        }

        private void UpdateContactCallBack(SubmitOperation op)
        {

            if (!op.HasError)
            {

                Contact = new Contact();
                IsSuccess = true;

            }
            else
            {
                ErrorMessage = op.Error.Message;
                IsError = true;
                op.MarkErrorAsHandled();
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<ContactMessage>(this, OnLaunchEditContact);
        }

        private void OnLaunchEditContact(ContactMessage msgContact)
        {
            if(msgContact.idOperation == ADD_OPERATION)
            {
                isNewRecord = true;
                TitleContactWindow = ADD_CONTACT_TITLE;
                _contacsReferences = msgContact.ContactCollection;
            }
            else if(msgContact.idOperation == EDIT_OPERATION)
            {
                TitleContactWindow = EDIT_CONTACT_TITLE;
                Contact = msgContact.Contact;
                _contacsReferences = msgContact.ContactCollection;
            }
            
        }

        private void RemoveMessages()
        {
            if (IsError)
            {
                IsError = false;
            }
            if (IsSuccess)
            {
                IsSuccess = false;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
