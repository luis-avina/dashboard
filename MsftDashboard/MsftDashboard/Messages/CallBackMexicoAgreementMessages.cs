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
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;

namespace MsftDashboard.Messages
{
    internal class CallBackMexicoAgreementMessages : MessageBase
    {
        public int IdOperation { get; set; }
        public MexicoAgreement MexicoAgreement { get; set; }
        public ObservableCollection<MexicoAgreement> MexicoAgreementCollection { get; set; }
    }
}
