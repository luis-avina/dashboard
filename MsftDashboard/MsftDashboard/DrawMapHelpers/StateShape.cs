using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maps.MapControl;
using MsftDashboard.Web.Models;
using MsftDashboard.Models;


namespace MsftDashboard.DrawMapHelpers
{
    public class StateShape:MapPolygon
    {
        public int IdState { get; set; }
        public string StateName { get; set; }
        public string Operation { get; set; }
        public MicrosoftProgramState MsftProgram { get; set; }
        public StateProgram StateProgram { get; set; }
        public PoliticalInformationState PoliticState { get; set; }
        public MexicoAgreement MexicoAgreementState { get; set; }
        public Competition CompetitionState { get; set; }
        public PivotModel PivotStateModel { get; set; }
    }
}
