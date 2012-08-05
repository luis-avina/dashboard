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
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Models;

namespace MsftDashboard.Messages
{
    internal class CallBackPoliticalStateMessage:MessageBase
    {
        public int IdOperation { get; set; }
        public PoliticalInformationState PoliticaStateInfo { get; set; }
        public ObservableCollection<PoliticalInformationState> PoliticalStateCollection { get; set; }
        public ObservableCollection<PoliticalPartyModel> PoliticalPartyModel { get; set; }
    }
}
