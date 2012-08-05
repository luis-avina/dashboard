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

namespace MsftDashboard.Models
{
    public class StatePivotShape:Microsoft.Maps.MapControl.MapPolygon
    {
        public int IdState { get; set; }
        public string StateName { get; set; }
        public MsftModel MsftModelObj { get; set; }
    }
}
