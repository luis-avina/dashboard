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

namespace MsftDashboard.Helpers
{
    public class GetMapMode
    {
        public static AerialMode AerialMode()
        {
            return new AerialMode();
        }

        public static AerialMode AerialModeWithLabels()
        {
            return new AerialMode(true);
        }

        public static RoadMode RoadMode()
        {
            return new RoadMode();
        }

        
    }
}
