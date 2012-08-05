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
using MsftDashboard.Models;

namespace MsftDashboard.Messages
{
    public class CallBackProgramsMessage
    {
        public int idOperation
        {
            get;
            set;
        }
        public MicrosoftProgramState MicrosoftProgramStateCallBack
        {
            get;
            set;
        }

        public StateProgram StateProgramCallBack
        {
            get;
            set;
        }

        public Competition CompetitonCallBack
        {
            get;
            set;
        }

        public PivotModel MsftPivotCallBack
        {
            get;
            set;
        }
        public PivotModel StatePivotCallBack
        {
            get;
            set;
        }

        public PivotModel CompetitionPivotCallBack
        {
            get;
            set;
        }
    }
}
