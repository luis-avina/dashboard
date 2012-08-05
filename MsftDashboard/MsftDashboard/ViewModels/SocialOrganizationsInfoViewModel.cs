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
    public class SocialOrganizationsInfoViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        protected IMsftService SocialOrgService { get; set; }

        private SocialOrganizationInformation _selectedSocialOrg;
        public SocialOrganizationInformation SelectedSocialOrg
        {
            get
            {
                return _selectedSocialOrg;
            }
            set
            {
                _selectedSocialOrg = value;
                RaisePropertyChanged("SelectedSocialOrg");
            }
        }

        private ObservableCollection<SocialOrganizationInformation> _socialOrgCollection;
        public ObservableCollection<SocialOrganizationInformation> SocialOrgCollection
        {
            get
            {
                return _socialOrgCollection;
            }
            set
            {
                _socialOrgCollection = value;
                RaisePropertyChanged("SocialOrgCollection");
            }
        }

        public SocialOrganizationsInfoViewModel(IMsftService msftService)
        {
            SocialOrgService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddSocOrgInfo);
            UpdateCommand = new RelayCommand(UpdateSocOrgInfo);
            
        }

        private void AddSocOrgInfo()
        {
            Messenger.Default.Send<LaunchEditSocialOrgInfoMessage>(new LaunchEditSocialOrgInfoMessage());
            Messenger.Default.Send<SocialOrgInfoMessage>(new SocialOrgInfoMessage() { IdOperation=ADD_OPERATION,SocOrgInfoCollection=SocialOrgCollection });

        }

        private void UpdateSocOrgInfo()
        {
            Messenger.Default.Send<LaunchEditSocialOrgInfoMessage>(new LaunchEditSocialOrgInfoMessage());
            Messenger.Default.Send<SocialOrgInfoMessage>(new SocialOrgInfoMessage() { IdOperation = EDIT_OPERATION, SocOrgInfo = SelectedSocialOrg });
        }

        private void LoadData()
        {
            SocialOrgService.GetSocialOrganizationInformation(OnLoadSocOrgInfo);
        }

        private void OnLoadSocOrgInfo(ObservableCollection<SocialOrganizationInformation> socInfo)
        {
            if (socInfo!=null)
            {
                SocialOrgCollection = socInfo;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
