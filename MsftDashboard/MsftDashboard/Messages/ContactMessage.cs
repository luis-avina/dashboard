using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Messages
{
    internal class ContactMessage:MessageBase
    {
        public int idOperation { get; set; }
        public Contact Contact { get; set; }
        public ObservableCollection<Contact> ContactCollection { get; set; }
    }
}
