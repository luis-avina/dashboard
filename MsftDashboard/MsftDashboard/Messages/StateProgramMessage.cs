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
    public class StateProgramMessage:MessageBase
    {
        public int IdOperation { get; set; }
        public StateProgram StateProgram { get; set; }
        public ObservableCollection<StateProgram> StateProgramCollection { get; set; }
        public ObservableCollection<PivotModel> StatePivotCollection { get; set; }
    }
}
