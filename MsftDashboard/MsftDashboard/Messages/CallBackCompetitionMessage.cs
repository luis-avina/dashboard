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

namespace MsftDashboard.Messages
{
    public class CallBackCompetitionMessage
    {
        public int IdOperation { get; set; }
        public Competition CompetitionState { get; set; }
    }
}
