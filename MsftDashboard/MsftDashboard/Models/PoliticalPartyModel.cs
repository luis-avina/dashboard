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
using System.ComponentModel;


namespace MsftDashboard.Models
{
    public class PoliticalPartyModel:Model
    {
        public int IdPoliticalParty { get; set; }
        public string ShortName { get; set; }
        public string Color { get; set; }

        private bool _isChecked = false;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }
    }
}
