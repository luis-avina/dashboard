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
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Services;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class MexicoAgreementViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        private ObservableCollection<MexicoAgreement> _mexicoAgreementCollection;
        public ObservableCollection<MexicoAgreement> MexicoAgreementCollection
        {
            get
            {
                return _mexicoAgreementCollection;
            }
            set
            {
                _mexicoAgreementCollection = value;
                RaisePropertyChanged("MexicoAgreementCollection");
            }
        }

        private MexicoAgreement _selectedMexicoAgreement;
        public MexicoAgreement SelectedMexicoAgreement 
        {
            get
            {
                return _selectedMexicoAgreement;
            }
            set
            {
                _selectedMexicoAgreement = value;
                RaisePropertyChanged("SelectedMexicoAgreement");
            }
        }

        protected IMsftService MexicoAgreementService { get; set; }

        public MexicoAgreementViewModel(IMsftService msftService)
        {
            MexicoAgreementService = msftService;
            RegisterCommands();
            LoadData();

        }

        private void LoadData()
        {
            MexicoAgreementService.GetMexicoAgreements(OnLoadMexicoAgreementCollections);
        }

        private void OnLoadMexicoAgreementCollections(ObservableCollection<MexicoAgreement> mexicoAgreements)
        {
            if (mexicoAgreements != null)
            {
                MexicoAgreementCollection = mexicoAgreements;
            }
        }

        private void OnAddMexicoAgreement(MexicoAgreementMessages msg)
        {
            if (msg != null)
            {
                MexicoAgreementCollection = msg.MexicoAgreementCollection;
            }
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(OnAddMexicoAgreement);
            UpdateCommand = new RelayCommand(OnUpdateMexicoAgreement);
        }

        private void OnAddMexicoAgreement()
        {
            Messenger.Default.Send<LaunchEditMexicoAgreementMessage>(new LaunchEditMexicoAgreementMessage());
            Messenger.Default.Send<MexicoAgreementMessages>(new MexicoAgreementMessages() { IdOperation=ADD_OPERATION,MexicoAgreementCollection=MexicoAgreementCollection});
        }

        private void OnUpdateMexicoAgreement()
        {
            Messenger.Default.Send<LaunchEditMexicoAgreementMessage>(new LaunchEditMexicoAgreementMessage());
            Messenger.Default.Send<MexicoAgreementMessages>(new MexicoAgreementMessages() { IdOperation = EDIT_OPERATION, MexicoAgreement = SelectedMexicoAgreement });
        }
        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
