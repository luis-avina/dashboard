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
    public class PoliticViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }


        protected IPageConductor PageConductor { get; set; }

        protected IMsftService PoliticService { get; set; }

        private PoliticalInformationState _selectedPoliticalState;
        public PoliticalInformationState SelectedPoliticalState
        {
            get
            {
                return _selectedPoliticalState;
            }
            set
            {
                _selectedPoliticalState = value;
                RaisePropertyChanged("SelectedPoliticalState");
            }
        }

        private ObservableCollection<PoliticalInformationState> _politicStateCollection;
        public ObservableCollection<PoliticalInformationState> PoliticStateCollection
        {
            get
            {
                return _politicStateCollection;
            }
            set
            {
                _politicStateCollection = value;
                RaisePropertyChanged("PoliticStateCollection");
            }
        }

        public PoliticViewModel(IPageConductor pageConductor, IMsftService msftService)
        {
            PageConductor = pageConductor;
            PoliticService = msftService;
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(OnAddPoliticalState);
            UpdateCommand = new RelayCommand(OnUpdatePoliticalState);
        }

        private void OnAddPoliticalState()
        {
            Messenger.Default.Send<LaunchPoliticalStateMessage>(new LaunchPoliticalStateMessage() );
            Messenger.Default.Send<PoliticalStateMessage>(new PoliticalStateMessage() { IdOperation = ADD_OPERATION, PoliticalStateCollection = PoliticStateCollection });
        }

        private void OnUpdatePoliticalState()
        {
            Messenger.Default.Send<LaunchPoliticalStateMessage>(new LaunchPoliticalStateMessage());
            Messenger.Default.Send<PoliticalStateMessage>(new PoliticalStateMessage() { IdOperation = EDIT_OPERATION, PoliticaStateInfo = SelectedPoliticalState });
        }

        private void LoadData()
        {
            PoliticService.GetPoliticInformation(GetPoliticalStateCallBack);
        }

        private void GetPoliticalStateCallBack(ObservableCollection<PoliticalInformationState> politicState)
        {
            if (politicState != null)
            {
                this.PoliticStateCollection = politicState;
            }
        }
    }
}
