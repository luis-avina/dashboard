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
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditPoliticalPartyViewModel:ViewModelBase
    {
        protected IMsftService PoliticalPartyService;

        public RelayCommand SavePoliticalPartyCommand { get; set; }

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;
        private bool isNewRecord = false;

        private ObservableCollection<PoliticalParty> _politicalPartyRef;

        private PoliticalParty _currentPoliticalParty = new PoliticalParty();
        public PoliticalParty CurrentPoliticalParty
        {
            get
            {
                return _currentPoliticalParty;
            }
            set
            {
                _currentPoliticalParty = value;
                RaisePropertyChanged("CurrentPoliticalParty");
            }
        }

        public AddEditPoliticalPartyViewModel(IMsftService msftService)
        {
            CurrentPoliticalParty = new PoliticalParty();
            PoliticalPartyService = msftService;
            RegisterMessages();
            RegisterCommands();
            
        }

        private void RegisterCommands()
        {
            SavePoliticalPartyCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (isNewRecord)
            {
                CurrentPoliticalParty.ColorIndex = 1;
                CurrentPoliticalParty.Color = "Aqua";
                PoliticalPartyService.SavePoliticalParty(SaveOperation,CurrentPoliticalParty);
            }
            else
            {
                PoliticalPartyService.UpdatePoliticalParty(UpdateOperation, CurrentPoliticalParty);
            }
        }

        private void UpdateOperation(SubmitOperation op)
        {
            if (op.HasError)
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_politicalPartyRef != null)
                {
                    _politicalPartyRef.Add(CurrentPoliticalParty);
                    CurrentPoliticalParty = new PoliticalParty();
                }
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<PoliticalPartyMessage>(this, OnEditPoliticalParty);

        }

        private void OnEditPoliticalParty(PoliticalPartyMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNewRecord = true;
                    _politicalPartyRef = msg.PoliticalPartyColl;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNewRecord = false;
                    CurrentPoliticalParty = msg.PoliticalParty;
                }
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
