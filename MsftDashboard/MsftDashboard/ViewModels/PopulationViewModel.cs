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
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Services;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class PopulationViewModel:ViewModelBase
    {
        private bool _hasChanges;
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                _hasChanges = value;
                RaisePropertyChanged("HasChanges");
            }
        }

        public IMsftService PopulationService { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand SelectStateCommand { get; set; }

        private State _currentState;
        public State CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
                RaisePropertyChanged("CurrentState");
            }
        }

        private ObservableCollection<Municipality> _municipalityCollection;
        public ObservableCollection<Municipality> MunicipalityCollection
        {
            get
            {
                return _municipalityCollection;
            }
            set
            {
                _municipalityCollection = value;
                RaisePropertyChanged("MunicipalityCollection");
            }
        }

        private ObservableCollection<State> _stateCollection;
        public ObservableCollection<State> StateCollection
        {
            get
            {
                return _stateCollection;
            }
            set
            {
                _stateCollection = value;
                RaisePropertyChanged("StateCollection");
            }
        }

        public PopulationViewModel(IMsftService msftService)
        {
            PopulationService = msftService;
            RegisterCommands();
            LoadData();

            PopulationService.NotifyHasChanges += PopulationService_NotifyHasChanges;
        }

        private void PopulationService_NotifyHasChanges(Object sender, HasChangesEventArgs e)
        {
            HasChanges = e.HasChanges;
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void LoadData()
        {
            PopulationService.GetStates(GetStatesCallBack);
        }

        private void GetStatesCallBack(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save,() => HasChanges);
            SelectStateCommand = new RelayCommand(OnSelectState);
        }

        private void Save()
        {
            PopulationService.SaveMunicipality(SaveOperation,null);
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                MessageBox.Show("Cambios Exitosos");
            }
            else
            {
                MessageBox.Show("Ocurrio un error" + op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void LoadMunicipalities()
        {
            PopulationService.GetMunicipalities(GetMunicipalitiesCallBack,CurrentState.IdState);
        }

        private void GetMunicipalitiesCallBack(ObservableCollection<Municipality> municipalities)
        {
            if (municipalities != null)
            {
                MunicipalityCollection = municipalities;
            }
        }

        private void OnSelectState()
        {
            if (CurrentState != null)
            {
                LoadMunicipalities();
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            
            base.Cleanup();
        }
    }
}
