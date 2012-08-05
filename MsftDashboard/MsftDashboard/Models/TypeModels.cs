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
    public class TypeModels:Model
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

        private string _color;
        public String Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                RaisePropertyChanged("Color");
            }
        }

        private double _totalInvesment;
        public double TotalInvestment
        {
            get
            {
                return _totalInvesment;
            }
            set
            {
                _totalInvesment = value;
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
        private string _toolTIp = string.Empty;
        public string ToolTip
        {
            get
            {
                return _toolTIp;
            }

            set
            {
                _toolTIp = value;
                RaisePropertyChanged("ToolTip");
            }
        }
    }
}
