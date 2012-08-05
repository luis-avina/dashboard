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
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class CapacitationCenterViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        protected IMsftService CapacitationCenterService { get; set; }

        private CapacitationCenterInformation _selectedCapacitationCenter;
        public CapacitationCenterInformation SelectedCapacitationCenter
        {
            get
            {
                return _selectedCapacitationCenter;
            }
            set
            {
                _selectedCapacitationCenter = value;
                RaisePropertyChanged("SelectedCapacitationCenter");
            }

        }

        private ObservableCollection<CapacitationCenterInformation> _capacitationCenterCollection;
        public ObservableCollection<CapacitationCenterInformation> CapacitationCenterCollection
        {
            get
            {
                return _capacitationCenterCollection;
            }
            set
            {
                _capacitationCenterCollection = value;
                RaisePropertyChanged("CapacitationCenterCollection");
            }
        }


        public CapacitationCenterViewModel(IMsftService msftService)
        {
            CapacitationCenterService = msftService;
            RegisterCommands();
            LoadData();

        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddCapacitationCenter);
            UpdateCommand = new RelayCommand(EditCapacitationCenter);
        }

        private void AddCapacitationCenter()
        {
            Messenger.Default.Send <LaunchEditCapacitationCenterMessage>(new LaunchEditCapacitationCenterMessage());
            Messenger.Default.Send<CapacitationCenterMessage>(new CapacitationCenterMessage() { IdOperation = ADD_OPERATION,CapCenterInfoCollection = CapacitationCenterCollection});
        }

        private void EditCapacitationCenter()
        {
            Messenger.Default.Send<LaunchEditCapacitationCenterMessage>(new LaunchEditCapacitationCenterMessage());
            Messenger.Default.Send<CapacitationCenterMessage>(new CapacitationCenterMessage() { IdOperation = EDIT_OPERATION, CapCenterInfo = SelectedCapacitationCenter });
        }

        private void LoadData()
        {
            CapacitationCenterService.GetCapacitationCenter(OnLoadCapacitationCenter);
        }

        private void OnLoadCapacitationCenter(ObservableCollection<CapacitationCenterInformation> capCenterCollection)
        {
            if (capCenterCollection != null)
            {
                CapacitationCenterCollection = capCenterCollection;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
