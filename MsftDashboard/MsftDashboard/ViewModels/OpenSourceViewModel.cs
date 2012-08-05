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
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class OpenSourceViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        protected IMsftService OpenSourceService { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private OpenSourceState _selectedOpenSourceState;
        public OpenSourceState SelectedOpenSourceState
        {
            get
            {
                return _selectedOpenSourceState;
            }
            set
            {
                _selectedOpenSourceState = value;
                RaisePropertyChanged("SelectedOpenSourceState");
            }
        }

        private ObservableCollection<OpenSourceState> _openSourceStateCollection;
        public ObservableCollection<OpenSourceState> OpenSourceStateCollection
        {
            get
            {
                return _openSourceStateCollection;
            }
            set
            {
                _openSourceStateCollection = value;
                RaisePropertyChanged("OpenSourceStateCollection");
            }
        }

        public OpenSourceViewModel(IMsftService msftService)
        {
            OpenSourceService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddOperation);
            UpdateCommand = new RelayCommand(UpdateOperation);
        }

        private void AddOperation()
        {
            Messenger.Default.Send<LaunchEditOpenSourceStateMessage>(new LaunchEditOpenSourceStateMessage());
            Messenger.Default.Send<OpenSourceStateMessage>(new OpenSourceStateMessage() { IdOperation = ADD_OPERATION, OpenSourceCollection = this.OpenSourceStateCollection });
        }

        private void UpdateOperation()
        {
            Messenger.Default.Send<LaunchEditOpenSourceStateMessage>(new LaunchEditOpenSourceStateMessage());
            Messenger.Default.Send<OpenSourceStateMessage>(new OpenSourceStateMessage() { IdOperation = EDIT_OPERATION,OpenSourceState = this.SelectedOpenSourceState });
        }

        private void LoadData()
        {
            OpenSourceService.GetOpenSourceStateInformation(OnLoadOpenSource);
        }

        private void OnLoadOpenSource(ObservableCollection<OpenSourceState> openSourceCollection)
        {
            if (openSourceCollection != null)
            {
                OpenSourceStateCollection = openSourceCollection;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }

    }
}
