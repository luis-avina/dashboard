using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Messages
{
    internal class OpenSourceStateProviderMessage:MessageBase
    {
        public int IdOperation { get; set; }
        public OpenSourceStateProvider OpenSourceProvider { get; set; }
        public ObservableCollection<OpenSourceStateProvider> OpenSourceCollection { get; set; }
    }
}
