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
using Microsoft.Maps.MapControl;
using MsftDashboard.Web.Models;

namespace MsftDashboard.DrawMapHelpers
{
    public class StateShapePolitical:MapPolygon
    {
        public int IdState { get; set; }
        public string StateName { get; set; }
        public string Operation { get; set; }
        public PoliticalInformationState PoliticState { get; set; }
    }
}
