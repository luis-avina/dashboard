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
    public class ProgramModel:Model
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private double _totalInvestment;
        public double TotalInvestment
        {
            get
            {
                return _totalInvestment;
            }
            set
            {
                _totalInvestment = value;
                RaisePropertyChanged("TotalInvestment");
            }
        }

        private double _totalRoi;
        public double TotalRoi
        {
            get
            {
                return _totalRoi;
            }
            set
            {
                _totalRoi = value;
                RaisePropertyChanged("TotalRoi");
            }
        }

        private string _toolTip;
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                _toolTip = value;
                RaisePropertyChanged("ToolTip");
            }
        }
    }
}
