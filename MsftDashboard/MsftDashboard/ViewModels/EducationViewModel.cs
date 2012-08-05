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
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;

namespace MsftDashboard
{
    public class EducationViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }

        protected IMsftService EducationService { get; set; }

        private EducationInformationState _selectedEducationInformationState;
        public EducationInformationState SelectedEducationInformationState
        {
            get
            {
                return _selectedEducationInformationState;
            }
            set
            {
                _selectedEducationInformationState = value;
                RaisePropertyChanged("SelectedEducationInformationState");
            }
        }

        private ObservableCollection<EducationInformationState> _educationInformationStateCollection=new ObservableCollection<EducationInformationState>();
        public ObservableCollection<EducationInformationState> EducationInformationStateCollection
        {
            get
            {
                return _educationInformationStateCollection;
            }
            set
            {
                _educationInformationStateCollection = value;
                RaisePropertyChanged("EducationInformationStateCollection");
            }
        }

        public EducationViewModel(IMsftService msftService)
        {
            EducationService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            EducationService.GetEducationStateInformation(OnLoadEducationInformationState);
        }

        private void OnLoadEducationInformationState(ObservableCollection<EducationInformationState> educationInfoState)
        {
            if (educationInfoState != null)
            {
                EducationInformationStateCollection = educationInfoState;
            }
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddEducationStateInformation);
            EditCommand = new RelayCommand(EditEducationStateInformation);
        }

        private void AddEducationStateInformation()
        {
            Messenger.Default.Send<LaunchEditEducationStateMessage>(new LaunchEditEducationStateMessage());
            Messenger.Default.Send<EducationInformationStateMessage>(new EducationInformationStateMessage() {IdOperation=ADD_OPERATION,EducationStateCollection = this.EducationInformationStateCollection });
        }

        private void EditEducationStateInformation()
        {
            Messenger.Default.Send<LaunchEditEducationStateMessage>(new LaunchEditEducationStateMessage());
            Messenger.Default.Send<EducationInformationStateMessage>(new EducationInformationStateMessage() {IdOperation=EDIT_OPERATION,EducationState = this.SelectedEducationInformationState });
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
