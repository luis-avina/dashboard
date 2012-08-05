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
using MsftDashboard.Models;

namespace MsftDashboard.Messages
{
    internal class MsftProgramMessage : MessageBase
    {
        public int IdOperation { get; set; }
        public MicrosoftProgramState MsftProgram { get; set; }
        public ObservableCollection<MicrosoftProgramState> MsftProgramCollection {get;set;}
        public ObservableCollection<PivotModel> MsftPivotCollection { get; set; }
    }
}
