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
using Microsoft.Pivot.Internal.ViewModels;

namespace MsftDashboard.Models
{
    public class PivotModel : Model
    {
        private string _source;
        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                RaisePropertyChanged("Source");
               
            }
        }

        private string _program;
        public string Program
        {
            get
            {
                return _program;
            }
            set
            {
                _program = value;
                RaisePropertyChanged("Program");

            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");

            }
        }

        private string _owner;
        public string Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
                RaisePropertyChanged("Owner");

            }
        }

        private string _state;
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                RaisePropertyChanged("State");

            }
        }

        private double _investment;
        public double Investment
        {
            get
            {
                return _investment;
            }
            set
            {
                _investment = value;
                RaisePropertyChanged("Investment");

            }
        }

        private double _roi;
        public double ROI
        {
            get
            {
                return _roi;
            }
            set
            {
                _roi = value;
                RaisePropertyChanged("ROI");

            }
        }

        private int _progress;
        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                RaisePropertyChanged("Progress");

            }
        }

        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                RaisePropertyChanged("Number");

            }
        }
    }
}
