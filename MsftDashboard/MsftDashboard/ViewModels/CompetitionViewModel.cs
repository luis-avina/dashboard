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
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;

namespace MsftDashboard
{
    public class CompetitionViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;
        
        protected IMsftService CompetitionService { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        private ObservableCollection<Competition> _competitionCollection;
        public ObservableCollection<Competition> CompetitionCollection
        {
            get
            {
                return _competitionCollection;
            }
            set
            {
                _competitionCollection = value;
                RaisePropertyChanged("CompetitionCollection");
            }
        }

        private Competition _selectedCompetition;
        public Competition SelectedCompetition
        {
            get
            {
                return _selectedCompetition;
            }
            set
            {
                _selectedCompetition = value;
                RaisePropertyChanged("SelectedCompetition");
            }
        }

        public CompetitionViewModel(IMsftService msftService)
        {
            CompetitionService = msftService;
            RegisterCommands();
            RegisterMessages();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<CompetitionMessage>(this, OnCompetitionAdd);
        }

        private void OnCompetitionAdd(CompetitionMessage msg)
        {
            if (msg!=null && msg.CompetitionCollection!=null)
            {
                CompetitionCollection = msg.CompetitionCollection;
            }
        }

        private void RegisterCommands()
        {
            AddCommand = new RelayCommand(AddCompetition);
            UpdateCommand = new RelayCommand(UpdateCompetition);
        }

        private void AddCompetition()
        {
            Messenger.Default.Send<LaunchEditCompetitionMessage>(new LaunchEditCompetitionMessage());
            Messenger.Default.Send<CompetitionMessage>(new CompetitionMessage()
                {
                    IdOperation = ADD_OPERATION,
                    CompetitionCollection = CompetitionCollection
                });
        }

        private void UpdateCompetition()
        {
            Messenger.Default.Send<LaunchEditCompetitionMessage>(new LaunchEditCompetitionMessage());
            Messenger.Default.Send<CompetitionMessage>(new CompetitionMessage()
            {
                IdOperation = EDIT_OPERATION,
                CompetitionInfo = SelectedCompetition
            });
        }

        private void LoadData()
        {
            CompetitionCollection = null;
            CompetitionService.GetCompetitionInformation(GetCompetitionCallBack);
        }

        private void GetCompetitionCallBack(ObservableCollection<Competition>competition)
        {
            if (competition != null)
            {
                this.CompetitionCollection = competition;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
