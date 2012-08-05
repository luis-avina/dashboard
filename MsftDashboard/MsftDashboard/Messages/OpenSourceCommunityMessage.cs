using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;

namespace MsftDashboard.Messages
{
    internal class OpenSourceCommunityMessage:MessageBase
    {
        public int IdOperation { get; set; }
        public OpenSourceStateCommunity OpenSourceCommunity { get; set; }
        public ObservableCollection<OpenSourceStateCommunity> OpenSourceCommunityCollection { get; set; }
    }
}
