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
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace MsftDashboard.Messages
{
    internal class EconomyMessage:MessageBase
    {
        public int IdOperation { get; set; }
        public StateEconomicInfo EconomyInfo { get; set; }
        public ObservableCollection<StateEconomicInfo> EconomyInfoCollection { get; set; }

    }
}
