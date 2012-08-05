using System;
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Web.Services;
using Microsoft.Windows.Data.DomainServices;

namespace MsftDashboard.Services
{
    public class ContactService : IContactService
    {
        private LoadOperation<Contact> _contactsLoadOperation;
        private Action<ObservableCollection<Contact>> _getContactsCallBack;
        public DBContext Context { get; set; }
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;

        public ContactService()
        {
            Context = new DBContext();
            Context.PropertyChanged += ContextPropertyChanged;
        }

        private void ContextPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (NotifyHasChanges != null)
            {
                NotifyHasChanges(this, new HasChangesEventArgs() { HasChanges = Context.HasChanges });
            }
        }


        public void GetContacts(Action<ObservableCollection<Contact>> getContactsCallBack)
        {
            _getContactsCallBack = getContactsCallBack;
            Context.Contacts.Clear();
            _contactsLoadOperation = Context.Load<Contact>(Context.GetContactsQuery());
            _contactsLoadOperation.Completed += OnLoadContactsCompleted;

        }

        void OnLoadContactsCompleted(object sender, EventArgs e)
        {
            _contactsLoadOperation.Completed -= OnLoadContactsCompleted;
            var contacts = new EntityList<Contact>(Context.Contacts, _contactsLoadOperation.Entities);
            _getContactsCallBack(contacts);
        }
    }
}
