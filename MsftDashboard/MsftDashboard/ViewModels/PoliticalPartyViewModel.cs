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
using GalaSoft.MvvmLight;
using MsftDashboard.Services;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class PoliticalPartyViewModel:ViewModelBase
    {
        protected IMsftService PoliticalPartyService;
        
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddPoliticalPartyCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        private PoliticalParty _selectedPoliticalParty;
        public PoliticalParty SelectedPoliticalParty
        {
            get
            {
                return _selectedPoliticalParty;
            }
            set
            {
                _selectedPoliticalParty = value;
                RaisePropertyChanged("SelectedPoliticalParty");
            }
        }

        private ObservableCollection<PoliticalParty> _politicalPartyCollection;
        public ObservableCollection<PoliticalParty> PoliticalPartyCollection
        {
            get
            {
                return _politicalPartyCollection;
            }
            set
            {
                _politicalPartyCollection = value;
                RaisePropertyChanged("PoliticalPartyCollection");
            }
        }

        public PoliticalPartyViewModel(IMsftService msftService)
        {
            PoliticalPartyService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            AddPoliticalPartyCommand = new RelayCommand(AddPoliticalParty);
            UpdateCommand = new RelayCommand(EditPoliticalParty);
           
        }

        private void AddPoliticalParty()
        {
            Messenger.Default.Send<LaunchEditPoliticalPartyMessage>(new LaunchEditPoliticalPartyMessage());
            Messenger.Default.Send<PoliticalPartyMessage>(new PoliticalPartyMessage() { IdOperation = ADD_OPERATION, PoliticalPartyColl = this.PoliticalPartyCollection });
        }

        private void EditPoliticalParty()
        {
            Messenger.Default.Send<LaunchEditPoliticalPartyMessage>(new LaunchEditPoliticalPartyMessage());
            Messenger.Default.Send<PoliticalPartyMessage>(new PoliticalPartyMessage() { IdOperation = EDIT_OPERATION, PoliticalParty = SelectedPoliticalParty });
        }

        private void LoadData()
        {
            PoliticalPartyService.GetPoliticalParty(OnLoadPoliticalParty);
        }

        private void OnLoadPoliticalParty(ObservableCollection<PoliticalParty> politicalParty)
        {
            if (politicalParty != null)
            {
                PoliticalPartyCollection = politicalParty;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }

    }
}
