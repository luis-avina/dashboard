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
    public class MsftModel
    {
        public string Source { get; set; }

        public string Owner { get; set; }

        public string Program { get; set; }

        public string Type { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public double ROI { get; set; }

        public int Progress { get; set; }

        public double Investment { get; set; }

        public string State { get; set; }
    }
}
