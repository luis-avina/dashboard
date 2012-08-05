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
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Models;
using MsftDashboard.Messages;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditCompetitionViewModel:ViewModelBase
    {
        private const string TITLE_COMPETITION_ADD = "Agregar Información de Competencia en el Estado";
        private const string TITLE_COMPETITION_EDIT = "Editar Información de Competencia en el Estado";

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        private bool isNew;

        public RelayCommand SaveCommand { get; set; }

        private bool _isError;
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
                RaisePropertyChanged("IsError");
            }
        }

        private bool _isSuccess;
        public bool IsSuccess
        {
            get
            {
                return _isSuccess;
            }
            set
            {
                _isSuccess = value;
                RaisePropertyChanged("IsSuccess");
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        private Year _currentYear;
        public Year CurrentYear
        {
            get
            {
                return _currentYear;
            }
            set
            {
                _currentYear = value;
                RaisePropertyChanged("CurrentYear");
            }
        }

        private Months _currentMonth;
        public Months CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                RaisePropertyChanged("CurrentMonth");
            }
        }

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

        private ObservableCollection<Months> _monthsCollection;
        public ObservableCollection<Months> MonthsCollection
        {
            get
            {
                return _monthsCollection;
            }
            set
            {
                _monthsCollection = value;
                RaisePropertyChanged("MonthsCollection");
            }
        }

        private ObservableCollection<Year> _yearsCollection;
        public ObservableCollection<Year> YearsCollection
        {
            get
            {
                return _yearsCollection;
            }
            set
            {
                _yearsCollection = value;
                RaisePropertyChanged("YearsCollection");
            }
        }

        private Competition _competitionInfo = new Competition();
        public Competition CompetitionInfo 
        {
            get
            {
                return _competitionInfo;
            }
            set
            {
                _competitionInfo = value;
                RaisePropertyChanged("CompetitionInfo");
            }
        }

        private ObservableCollection<Competition> _competitionCollectionRef;

        private string _titleCompetitionWindow;
        public string TitleCompetitionWindow
        {
            get
            {
                return _titleCompetitionWindow;
            }
            set
            {
                _titleCompetitionWindow = value;
                RaisePropertyChanged("TitleCompetitionWindow");
            }
        }

        private Competitor _currentCompetitor;
        public Competitor CurrentCompetitor
        {
            get
            {
                return _currentCompetitor;
            }
            set
            {
                _currentCompetitor = value;
                RaisePropertyChanged("CurrentCompetitor");
            }
        }

        private ObservableCollection<Competitor> _competitorCollection;
        public ObservableCollection<Competitor> CompetitorCollection
        {
            get
            {
                return _competitorCollection;
            }
            set
            {
                _competitorCollection = value;
                RaisePropertyChanged("CompetitorCollection");
            }
        }

        public IMsftService CompetitionService { get; set; }

        public AddEditCompetitionViewModel(IMsftService msftService)
        {
            MonthsCollection = App.MonthsCatalog;
            CompetitionService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void LoadData()
        {
            CompetitionService.GetStates(GetStatesCallBack);
            CompetitionService.GetYears(GetYearsCallBack);
            CompetitionService.GetCompetitor(GetCompetitorCallBack);
        }

        private void GetStatesCallBack(ObservableCollection<State> states)
        {
            if (states != null)
            {
                StateCollection = states;
            }
        }

        private void GetYearsCallBack(ObservableCollection<Year> years)
        {
            if (years != null)
            {
                YearsCollection = years;
            }
        }

        private void GetCompetitorCallBack(ObservableCollection<Competitor> competitor)
        {
            if (competitor != null)
            {
                CompetitorCollection = competitor;
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(SaveCompetition);
        }

        private void SaveCompetition()
        {
            if (isNew)
            {
                CompetitionInfo.Competitor = CurrentCompetitor;
                CompetitionInfo.State = CurrentState;
                CompetitionInfo.DateFrom = new DateTime(CurrentYear.Year1,CurrentMonth.Id,1);
                CompetitionService.SaveCompetition(AddCompetitionOperation, CompetitionInfo);
            }
            else
            {
                CompetitionService.UpdateCompetition(UpdateCompetitionOperations,CompetitionInfo);
            }
        }

        private void AddCompetitionOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                IsSuccess = true;
                if (_competitionCollectionRef != null)
                {
                    _competitionCollectionRef.Add(CompetitionInfo);
                    Messenger.Default.Send(new CompetitionMessage()
                    {
                        CompetitionCollection = _competitionCollectionRef
                    });
                }
                CompetitionInfo = new Competition();
            }
            else
            {
                IsError = true;
                ErrorMessage = op.Error.Message;
                op.MarkErrorAsHandled();
            }
        }

        private void UpdateCompetitionOperations(SubmitOperation op)
        {
            if (!op.HasError)
            {
                IsSuccess = true;
            }
            else
            {
                IsError = true;
                ErrorMessage = op.Error.Message;
                op.MarkErrorAsHandled();
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<CompetitionMessage>(this,OnEditCompetition);
        }

        private void OnEditCompetition(CompetitionMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNew = true;
                    TitleCompetitionWindow = TITLE_COMPETITION_ADD;
                    _competitionCollectionRef = msg.CompetitionCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNew = false;
                    TitleCompetitionWindow = TITLE_COMPETITION_EDIT;
                    CompetitionInfo = msg.CompetitionInfo;
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
