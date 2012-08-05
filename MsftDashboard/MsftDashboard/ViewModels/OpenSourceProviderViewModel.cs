using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class OpenSourceProviderViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        protected IMsftService OpenSourceService { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private OpenSourceStateProvider _selectedOpenSourceProvider;
        public OpenSourceStateProvider SelectedOpenSourceProvider
        {
            get
            {
                return _selectedOpenSourceProvider;
            }
            set
            {
                _selectedOpenSourceProvider = value;
                RaisePropertyChanged("SelectedOpenSourceProvider");
            }
        }

        private ObservableCollection<OpenSourceStateProvider> _openSourceProviderCollection;
        public ObservableCollection<OpenSourceStateProvider> OpenSourceProviderCollection
        {
            get
            {
                return _openSourceProviderCollection;
            }
            set
            {
                _openSourceProviderCollection = value;
                RaisePropertyChanged("OpenSourceProviderCollection");
            }
        }

        public OpenSourceProviderViewModel(IMsftService msftService)
        {
            OpenSourceService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            OpenSourceService.GetOpenSourceStateProvider(OnLoadOpenSourceProvider);
        }

        private void OnLoadOpenSourceProvider(ObservableCollection<OpenSourceStateProvider>openSourceProvider)
        {
            if (openSourceProvider != null)
            {
                OpenSourceProviderCollection = openSourceProvider;
            }

        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddOperation);
            UpdateCommand = new RelayCommand(UpdateOperation);
        }

        private void AddOperation()
        {
            Messenger.Default.Send<LaunchEditOpenSourceProviderMessage>(new LaunchEditOpenSourceProviderMessage());
            Messenger.Default.Send<OpenSourceStateProviderMessage>(new OpenSourceStateProviderMessage() { IdOperation = ADD_OPERATION, OpenSourceCollection = this.OpenSourceProviderCollection });
        }

        private void UpdateOperation()
        {
            Messenger.Default.Send<LaunchEditOpenSourceProviderMessage>(new LaunchEditOpenSourceProviderMessage());
            Messenger.Default.Send<OpenSourceStateProviderMessage>(new OpenSourceStateProviderMessage() { IdOperation = EDIT_OPERATION, OpenSourceProvider = this.SelectedOpenSourceProvider });
        }


        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
