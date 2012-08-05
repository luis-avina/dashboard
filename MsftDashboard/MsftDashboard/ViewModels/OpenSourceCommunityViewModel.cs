using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Services;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class OpenSourceCommunityViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        protected IMsftService OpenSourceService { get; set; }

        private OpenSourceStateCommunity _selectedOpenSourceCommunity;
        public OpenSourceStateCommunity SelectedOpenSourceCommunity
        {
            get
            {
                return _selectedOpenSourceCommunity;
            }
            set
            {
                _selectedOpenSourceCommunity = value;
                RaisePropertyChanged("SelectedOpenSourceCommunity");
            }
        }

        private ObservableCollection<OpenSourceStateCommunity> _openSourceCommunityCollection;
        public ObservableCollection<OpenSourceStateCommunity> OpenSourceCommunityCollection
        {
            get
            {
                return _openSourceCommunityCollection;
            }
            set
            {
                _openSourceCommunityCollection = value;
                RaisePropertyChanged("OpenSourceCommunityCollection");
            }

        }

        public OpenSourceCommunityViewModel(IMsftService msftService)
        {
            OpenSourceService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            OpenSourceService.GetOpenSourceStateCommunity(OnLoadOpenSourceStateCommunity);
        }

        private void OnLoadOpenSourceStateCommunity(ObservableCollection<OpenSourceStateCommunity>openSourceCommunity)
        {
            if (openSourceCommunity != null)
            {
                OpenSourceCommunityCollection = openSourceCommunity;
            }
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddOperation);
            UpdateCommand = new RelayCommand(UpdateOperation);
        }

        private void AddOperation()
        {
            Messenger.Default.Send<LaunchEditOpenSourceCommunityMessage>(new LaunchEditOpenSourceCommunityMessage());
            Messenger.Default.Send<OpenSourceCommunityMessage>(new OpenSourceCommunityMessage() { IdOperation = ADD_OPERATION, OpenSourceCommunityCollection = this.OpenSourceCommunityCollection });
        }

        private void UpdateOperation()
        {
            Messenger.Default.Send<LaunchEditOpenSourceCommunityMessage>(new LaunchEditOpenSourceCommunityMessage());
            Messenger.Default.Send<OpenSourceCommunityMessage>(new OpenSourceCommunityMessage() { IdOperation = EDIT_OPERATION, OpenSourceCommunity = this.SelectedOpenSourceCommunity });
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
