using GalaSoft.MvvmLight;
using MsftDashboard;
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Models;
using MsftDashboard.Models;
using GalaSoft.MvvmLight.Command;
using System;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Pivot;

namespace MsftDashboard
{
    public class DashboardViewModel : ViewModelBase
    {

        private const string ROAD_MODE = "Road";
        private const string AERIAL_MODE = "Aerial";
        private const string LABELS_MODE = "AerialWithLabels";

        private const string STATE = "Estado";
        private const string SOURCE = "Area";
        private const string PROGRAM = "Programa";
        private const string TYPE = "Tipo";
        private const string TO = "To";
        private const string ROI = "ROI";
        private const string PROGRESS = "Progreso";
        private const string INVESTMENT = "Inversion";
        private const string OWNER = "Owner";
        private const string NUMBER = "Número";

        private const string SEARCH_PIVOT_MSFT = "PivotMsft";
        private const string SEARCH_PIVOT_STATE = "PivotState";
        private const string SEARCH_PIVOT_COMPETITION = "PivotCompetition";

        private const int DRAW_PIVOT_MSFT = 100;
        private const int DRAW_PIVOT_STATE = 200;
        private const int DRAW_PIVOT_COMPETITION = 300;

        private const string QUERY_PIVOT_MSFT_LIST = "QueryPivotMsft";
        private const string QUERY_PIVOT_STATE_LIST = "QueryPivotState";
        private const string QUERY_PIVOT_COMPETITION_LIST = "QueryPivotCompetition";

        private const string SHOW_MSFT_PIVOT= "SHOW_MSFT_PIVOT";

        private const string CLEAR_MAP_LAYERS = "CLEAR MAPLAYERS";
        private const string CLEAR_PIVOT_LAYERS = "CLEAR PIVOT LAYERS";

        private const int DRAW_MICROSOFT_PROGRAM_OPERATION = 1;
        private const int DRAW_STATE_PROGRAM_OPERATION = 1;
        private const int DRAW_COMPETITION_PROGRAM_OPERATION = 1;

        private const int UPDATE_MICROSOFT_PROGRAM = 4;
        private const int UPDATE_STATE_PROGRAM = 5;
        private const int UPDATE_COMPETITION_PROGRAM = 6;

        private const int SHOW_PIVOT_MSFT_INFO = 301;
        private const int SHOW_PIVOT_STATE_INFO = 302;
        private const int SHOW_PIVOT_COMPETITION_INFO = 303;

        private const int DRAW_ELEVEMOS_MEXICO_MARCO = 2;
        private const int DRAW_ELEVEMOS_MEXICO_ESPECIFICO = 3;

        private const int ID_OPERATION_CONVENIOS_ELEVEMOS_1 = 1;
        private const int ID_OPERATION_CONVENIOS_ELEVEMOS_2 = 2;
        private const int ID_OPERATION_CONVENIOS_ELEVEMOS_3 = 3;
        private const int ID_OPERATION_CONVENIOS_ELEVEMOS_4 = 4;

        private const int CHECK_ELEVEMOS_MARCO = 2;
        private const int UNCHECK_ELEVEMOS_MARCO = 3;

        private const int CHECK_ELEVEMOS_ESPECIFICO = 4;
        private const int UNCHECK_ELEVEMOS_ESPECIFICO = 5;

        private const int QUERY_ELEVEMOS_MEXICO = 1;

        private const int DRAW_POLITICAL_STATE_OPERATION = 1;
        private const int CHECKED_POLITICAL_STATE_OPERATION = 2;
        private const int UNCHECKED_POLITICAL_STATE_OPERATION = 3;

        private const int UPDATE_STATE_POLITICAL_INFO = 4;

        private const int UPDATE_ELEVEMOS_INFO = 7;

        protected IMsftService DashBoardService;

        private const string CHECK_ALL = "ALL";

        private Dictionary<string, ObservableCollection<PivotModel>> DictionaryPivotModels = new Dictionary<string, ObservableCollection<PivotModel>>();

        private bool _showCompetitionInfo = false;
        public bool ShowCompetitionInfo
        {
            get
            {
                return _showCompetitionInfo;
            }
            set
            {
                _showCompetitionInfo = value;
                RaisePropertyChanged("ShowCompetitionInfo");
            }
        }

        private ObservableCollection<PivotModel> _pivotModelInfoCollection = new ObservableCollection<PivotModel>();
        public ObservableCollection<PivotModel> PivotModelInfoCollection
        {
            get
            {
                return _pivotModelInfoCollection;
            }
            set
            {
                _pivotModelInfoCollection = value;
                RaisePropertyChanged("PivotModelInfoCollection");
            }
        }


        private bool _showPivotInfoState = false;
        public bool ShowPivotInfoState
        {
            get
            {
                return _showPivotInfoState;
            }
            set
            {
                _showPivotInfoState = value;
                RaisePropertyChanged("ShowPivotInfoState");
            }
        }

        private ObservableCollection<TypeModels> _typeCompetitionCollection = new ObservableCollection<TypeModels>();
        public ObservableCollection<TypeModels> TypeCompetitionCollection
        {
            get
            {
                return _typeCompetitionCollection;
            }
            set
            {
                _typeCompetitionCollection = value;
                RaisePropertyChanged("TypeCompetitionCollection");
            }
        }

        private DateTime _initialDateCompetition = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime InitialDateCompetition
        {
            get
            {
                return _initialDateCompetition;
            }
            set
            {
                _initialDateCompetition = value;
                RaisePropertyChanged("InitialDateCompetition");
            }
        }

        private DateTime _finalDateCompetition = DateTime.Now;
        public DateTime FinalDateCompetition
        {
            get
            {
                return _finalDateCompetition;
            }
            set
            {
                _finalDateCompetition = value;
                RaisePropertyChanged("FinalDateCompetition");
            }
        }


        private DateTime _initialDateState = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime InitialDateState
        {
            get
            {
                return _initialDateState;
            }
            set
            {
                _initialDateState = value;
                RaisePropertyChanged("InitialDateState");
            }
        }

        private DateTime _finalDateState = DateTime.Now;
        public DateTime FinalDateState
        {
            get
            {
                return _finalDateState;
            }
            set
            {
                _finalDateState = value;
                RaisePropertyChanged("FinalDateState");
            }
        }

        private DateTime _initialDate=new DateTime(DateTime.Now.Year-1,DateTime.Now.Month,DateTime.Now.Day);
        public DateTime InitialDate
        {
            get
            {
                return _initialDate;
            }
            set
            {
                _initialDate = value;
                RaisePropertyChanged("InitialDate");
            }
        }

        private DateTime _finalDate=DateTime.Now;
        public DateTime FinalDate
        {
            get
            {
                return _finalDate;
            }
            set
            {
                _finalDate = value;
                RaisePropertyChanged("FinalDate");
            }
        }

        private bool _showPivotMsft=false;
        public bool ShowPivotMsft
        {
            get
            {
                return _showPivotMsft;
            }
            set
            {
                _showPivotMsft = value;
                RaisePropertyChanged("ShowPivotMsft");
            }
        }

        private bool _showPivotState=false;
        public bool ShowPivotState
        {
            get
            {
                return _showPivotState;
            }
            set
            {
                _showPivotState = value;
                RaisePropertyChanged("ShowPivotState");
            }
        }

        private bool _showCompetitionPanel = false;
        public bool ShowCompetitionPanel
        {
            get
            {
                return _showCompetitionPanel;
            }
            set
            {
                _showCompetitionPanel = value;
                RaisePropertyChanged("ShowCompetitionPanel");
            }
        }

        private bool _showPivotCompetition=false;
        public bool ShowPivotCompetition
        {
            get
            {
                return _showPivotCompetition;
            }
            set
            {
                _showPivotCompetition = value;
                RaisePropertyChanged("ShowPivotCompetition");
            }
        }

        private bool _showDetailInvestmentPanel=false;
        public bool ShowDetailInvestmentPanel
        {
            get
            {
                return _showDetailInvestmentPanel;
            }
            set
            {
                _showDetailInvestmentPanel = value;
                RaisePropertyChanged("ShowDetailInvestmentPanel");
            }
        }

        private const string IS_ALL = "ALL";
        private double _totalInvestMent = 0;
        public double TotalInvestMent
        {
            get
            {
                return _totalInvestMent;
            }
            set
            {
                _totalInvestMent = value;
                RaisePropertyChanged("TotalInvestMent");
            }
        }

        private double _totalRoi = 0;
        public double TotalRoi
        {
            get
            {
                return _totalRoi;
            }
            set
            {
                _totalRoi = value;
                RaisePropertyChanged("TotalRoi");
            }
        }

        private ObservableCollection<PivotModel> _competitionPivot = new ObservableCollection<PivotModel>();
        private ObservableCollection<PivotModel> CompetitionPivot
        {
            get
            {
                return _competitionPivot;
            }
            set
            {
                _competitionPivot = value;
                RaisePropertyChanged("CompetitionPivot");
            }
        }

        private ObservableCollection<Competition> _competitionCollectionFilter = new ObservableCollection<Competition>();
        public ObservableCollection<Competition> CompetitionCollectionFilter
        {
            get
            {
                return _competitionCollectionFilter;
            }
            set
            {
                _competitionCollectionFilter = value;
                RaisePropertyChanged("CompetitionCollectionFilter");
            }
        }

        private ObservableCollection<Competition> _competitionCollection = new ObservableCollection<Competition>();
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

        private ObservableCollection<PivotModel> _statePivot = new ObservableCollection<PivotModel>();
        private ObservableCollection<PivotModel> StatePivot
        {
            get
            {
                return _statePivot;
            }
            set
            {
                _statePivot = value;
                RaisePropertyChanged("StatePivot");
            }
        }


        private ObservableCollection<PivotModel> _msftProgramPivot = new ObservableCollection<PivotModel>();
        private ObservableCollection<PivotModel> MsftProgramPivot
        {
            get
            {
                return _msftProgramPivot;
            }
            set
            {
                _msftProgramPivot = value;
                RaisePropertyChanged("MsftProgramPivot");
            }
        }

        private ObservableCollection<Competition> _competitionCollectionInfo = new ObservableCollection<Competition>();
        public ObservableCollection<Competition> CompetitionCollectionInfo
        {
            get
            {
                return _competitionCollection;
            }
            set
            {
                _competitionCollection = value;
                RaisePropertyChanged("CompetitionCollectionInfo");
            }
        }

        private ObservableCollection<MexicoAgreement> _mexicoStateAgreementCollection = new ObservableCollection<MexicoAgreement>();
        public ObservableCollection<MexicoAgreement> MexicoStateAgreementCollection
        {
            get
            {
                return _mexicoStateAgreementCollection;
            }
            set
            {
                _mexicoStateAgreementCollection = value;
                RaisePropertyChanged("MexicoStateAgreementCollection");
            }
        }

        private Dictionary<string, ObservableCollection<MexicoAgreement>> DictionaryMexicoAgreements = new Dictionary<string, ObservableCollection<MexicoAgreement>>();
        private Dictionary<string, ObservableCollection<MicrosoftProgramState>> DictionaryMsftProgram = new Dictionary<string, ObservableCollection<MicrosoftProgramState>>();
        private Dictionary<string, ObservableCollection<StateProgram>> DictionaryStateProgram = new Dictionary<string, ObservableCollection<StateProgram>>();
        private Dictionary<string, ObservableCollection<Competition>> DictionaryCompetitionState = new Dictionary<string, ObservableCollection<Competition>>();

        private ObservableCollection<MexicoAgreement> MarcoCollectionToDraw = new ObservableCollection<MexicoAgreement>();
        private ObservableCollection<MexicoAgreement> EspecificoCollectionToDraw = new ObservableCollection<MexicoAgreement>();

        private ObservableCollection<MexicoAgreement> _especificoCollection;
        public ObservableCollection<MexicoAgreement> EspecificoCollection
        {
            get
            {
                return _especificoCollection;
            }
            set
            {
                _especificoCollection = value;
                RaisePropertyChanged("EspecificoCollection");
            }
        }

        private ObservableCollection<MexicoAgreement> _marcoCollection;
        public ObservableCollection<MexicoAgreement> MarcoCollection
        {
            get
            {
                return _marcoCollection;
            }
            set
            {
                _marcoCollection = value;
                RaisePropertyChanged("MarcoCollection");
            }
        }

        private bool _showStateProgramInvestmentPanel;
        public bool ShowStateProgramInvestmentPanel
        {
            get
            {
                return _showStateProgramInvestmentPanel;
            }
            set
            {
                _showStateProgramInvestmentPanel = value;
                RaisePropertyChanged("ShowStateProgramInvestmentPanel");
            }
        }

        private bool _showStateProgramInfo=false;
        public bool ShowStateProgramInfo
        {
            get 
            {
                return _showStateProgramInfo;
            }
            set
            {
                _showStateProgramInfo = value;
                RaisePropertyChanged("ShowStateProgramInfo");
            }
        }

        private ObservableCollection<StateProgram> _stateProgamInfoCollection = new ObservableCollection<StateProgram>();
        public ObservableCollection<StateProgram> StateProgramInfoCollection
        {
            get
            {
                return _stateProgamInfoCollection;
            }
            set
            {
                _stateProgamInfoCollection = value;
                RaisePropertyChanged("StateProgramInfoCollection");
            }
        }
        
        private ObservableCollection<MicrosoftProgramState> _msftProgamInfoCollection= new ObservableCollection<MicrosoftProgramState>();
        public ObservableCollection<MicrosoftProgramState> MsftProgramInfoCollection
        {
            get
            {
                return _msftProgamInfoCollection;
            }
            set
            {
                _msftProgamInfoCollection = value;
                RaisePropertyChanged("MsftProgramInfoCollection");
            }
        }

        private ObservableCollection<AreaProgramModel> _areaProgramCollection = new ObservableCollection<AreaProgramModel>();
        public ObservableCollection<AreaProgramModel> AreaProgramCollection
        {
            get
            {
                return _areaProgramCollection;
            }
            set
            {
                _areaProgramCollection = value;
                RaisePropertyChanged("AreaProgramCollection");
            }
        }

        private bool _showMsftProgramInfo=false;
        public bool ShowMsftProgramInfo
        {
            get
            {
                return _showMsftProgramInfo;
            }
            set
            {
                _showMsftProgramInfo = value;
                RaisePropertyChanged("ShowMsftProgramInfo");
            }
        }

        private string _stateNameProgram;
        public string StateNameProgram
        {
            get
            {
                return _stateNameProgram;
            }
            set
            {
                _stateNameProgram = value;
                RaisePropertyChanged("StateNameProgram");
            }
        }

        private bool _showMsftInvestmentPanel=false;
        public bool ShowMsftInvestmentPanel
        {
            get
            {
                return _showMsftInvestmentPanel;
            }
            set
            {
                _showMsftInvestmentPanel = value;
                RaisePropertyChanged("ShowMsftInvestmentPanel");
            }
        }


        private ObservableCollection<PoliticalInformationState> ChangePoliticalInformationCollection= new ObservableCollection<PoliticalInformationState>();

        private ObservableCollection<StateProgram> _stateProgramCollection;
        public ObservableCollection<StateProgram> StateProgramCollection
        {
            get
            {
                return _stateProgramCollection;
            }
            set
            {
                _stateProgramCollection = value;
                RaisePropertyChanged("StateProgramCollection");
            }
        }

        private ObservableCollection<MicrosoftProgramState> _msftProgramCollection;
        public ObservableCollection<MicrosoftProgramState> MsftProgramCollection
        {
            get
            {
                return _msftProgramCollection;
            }
            set
            {
                _msftProgramCollection = value;
                RaisePropertyChanged("MsftProgramCollection");
            }
        }


        private ObservableCollection<MexicoAgreement> _elevemosCollection = new ObservableCollection<MexicoAgreement>();
        public ObservableCollection<MexicoAgreement> ElevemosCollection
        {
            get
            {
                return _elevemosCollection;
            }
            set 
            {
                _elevemosCollection = value;
                RaisePropertyChanged("ElevemosCollection");
            }
        }

        private string allCheck = CHECK_ALL;
        public string AllCheck
        {
            get
            {
                return allCheck;
            }
            set
            {
                allCheck = value;
                RaisePropertyChanged("AllCheck");
            }
        }

        private DateTime initialDate;
        private DateTime finalDate;

        public RelayCommand PoliticCommand { get; set; }
        public RelayCommand CheckAllPoliticalCommand { get; set; }
        public RelayCommand UnCheckAllPoliticalCommand { get; set; }
        public RelayCommand<string> CheckedPoliticalCommand { get; set; }
        public RelayCommand<string> UnCheckedPoliticalCommand { get; set; }
        
        public RelayCommand ElevemosCommand{get;set;}
        public RelayCommand<int> CheckMarcoCommand { get; set; }
        public RelayCommand<int> UnCheckMarcoCommand { get; set; }
        public RelayCommand<int> CheckEspecificoCommand { get; set; }
        public RelayCommand<int> UnCheckEspecificoCommand { get; set; }

        public RelayCommand InversionMsftCommand { get; set; }
        public RelayCommand InversionEstadoCommand { get; set; }
        public RelayCommand InversionCompetitionCommand { get; set; }
        public RelayCommand PivotMsftCommand { get; set; }
        public RelayCommand PivotStateCommand { get; set; }
        public RelayCommand PivotCompetitionCommand { get; set; }

        public RelayCommand CheckMarcoAllCommand    {get;set;}
        public RelayCommand UnCheckMarcoAllCommand  {get;set;}
        public RelayCommand CheckEspecificoAllCommand   {get;set;}
        public RelayCommand UnCheckEspecificoAllCommand {get;set;}

        public RelayCommand<string> CheckAllAreaMsftCommand { get; set; }
        public RelayCommand<string> UnCheckAllAreaMsftCommand { get; set; }
        public RelayCommand<string> CheckProgramMsftCommand { get; set; }
        public RelayCommand<string> UnCheckProgramMsftCommand { get; set; }

        public RelayCommand<string> CheckAllAreaStateProgramCommand { get; set; }
        public RelayCommand<string> UnCheckAllAreaStateProgramCommand { get; set; }
        public RelayCommand<string> CheckProgramStateCommand { get; set; }
        public RelayCommand<string> UnCheckProgramStateCommand { get; set; }


        public RelayCommand<string> CheckedTypeCompetitionCommand { get; set; }
        public RelayCommand<string> UnCheckedTypeCompetitionCommand { get; set; }


        public RelayCommand OkPivotMsftCommand { get; set; }
        public RelayCommand CancelPivotMsftCommand { get; set; }

        public RelayCommand OkPivotStateCommand { get; set; }
        public RelayCommand CancelPivotStateCommand { get; set; }

        public RelayCommand OkPivotCompetitionCommand { get; set; }
        public RelayCommand CancelPivotCompetitionCommand { get; set; }

        public RelayCommand SearchDateCommand { get; set; }
        public RelayCommand SearchDateStateCommand { get; set; }
        public RelayCommand SearchDateCompetitionCommand { get; set; }

        public RelayCommand DateCommand { get; set; }

        public RelayCommand CheckRoadMode { get; set; }
        public RelayCommand CheckAerialMode { get; set; }
        public RelayCommand CheckLabelsMode { get; set; }

        private ObservableCollection<MexicoAgreement> _especificoElevemosMexicoCollection;
        public ObservableCollection<MexicoAgreement> EspecificoElevemosMexicoCollection
        {
            get
            {
                return _especificoElevemosMexicoCollection;
            }
            set
            {
                _especificoElevemosMexicoCollection = value;
                RaisePropertyChanged("EspecificoElevemosMexicoCollection");
            }
        }

        private ObservableCollection<MexicoAgreement> _marcoElevemosMexicoCollection    ;
        public ObservableCollection<MexicoAgreement> MarcoElevemosMexicoCollection
        {
            get
            {
                return _marcoElevemosMexicoCollection;
            }
            set
            {
                _marcoElevemosMexicoCollection = value;
                RaisePropertyChanged("MarcoElevemosMexicoCollection");
            }
        }

        private ObservableCollection<MexicoAgreement> _elevemosMexicoCollection;
        public ObservableCollection<MexicoAgreement> ElevemosMexicoCollection
        {
            get
            {
                return _elevemosMexicoCollection;
            }
            set
            {
                _elevemosMexicoCollection = value;
                RaisePropertyChanged("ElevemosMexicoCollection");
            }
        }

        private List<string> ListColorAreas = new List<string>()
        {
            "#FFFF8600",
            "#FFFF1600",
            "#FF256F2E",
            "#FFF7FF00",
            "#FF00A2FF",
            "#FF8332BB",
            "#FF0A1954"
        };

        private List<string> ListColorsElevemosMexico = new List<string>()
        {
            "#FF2D830E",
            "#FFF2FF13",
            "#FFF31616",
            "#FF169DF3"
        };

        private List<string> ListColorsElevemosMexico2 = new List<string>()
        {
            "#902D830E",
            "#8EF2FF13",
            "#8EF31616",
            "#8E169DF3"
        };
        
        private int countcheckTimes; 
        private const bool IS_CHECKED = true;
        private const bool IS_UNCHECKED = false;

        private TypeAgreementsModel _marco;
        public TypeAgreementsModel Marco
        {
            get
            {
                return _marco;
            }
            set
            {
                _marco = value;
                RaisePropertyChanged("Marco");
            }
        }

        private TypeAgreementsModel _especifico;
        public TypeAgreementsModel Especifico
        {
            get
            {
                return _especifico;
            }
            set
            {
                _especifico = value;
                RaisePropertyChanged("Especifico");
            }
        }

        private ObservableCollection<TypeAgreementsModel> _typeAgreementsCollectionEspecifico = new ObservableCollection<TypeAgreementsModel>();
        public ObservableCollection<TypeAgreementsModel> TypeAgreementsCollectionEspecifico
        {
            get
            {
                return _typeAgreementsCollectionEspecifico;
            }
            set
            {
                _typeAgreementsCollectionEspecifico = value;
                RaisePropertyChanged("TypeAgreementsCollectionEspecifico");
            }
        }

        private ObservableCollection<TypeAgreementsModel> _typeAgreementsCollectionMarco= new ObservableCollection<TypeAgreementsModel>();
        public ObservableCollection<TypeAgreementsModel> TypeAgreementsCollectionMarco
        {
            get
            {
                return _typeAgreementsCollectionMarco;
            }
            set
            {
                _typeAgreementsCollectionMarco = value;
                RaisePropertyChanged("TypeAgreementsCollectionMarco");
            }
        }

        private string _stateNameElevemos;
        public string StateNameElevemos
        {
            get
            {
                return _stateNameElevemos;
            }
            set
            {
                _stateNameElevemos = value;
                RaisePropertyChanged("StateNameElevemos");
            }
        }

        private bool _showElevemosPanelInfo;
        public bool ShowElevemosPanelInfo
        {
            get
            {
                return _showElevemosPanelInfo;
            }
            set
            {
                _showElevemosPanelInfo = value;
                RaisePropertyChanged("ShowElevemosPanelInfo");
            }
        }

        private bool _showElevemosPanel;
        public bool ShowElevemosPanel
        {
            get
            {
                return _showElevemosPanel;
            }
            set
            {
                _showElevemosPanel = value;
                RaisePropertyChanged("ShowElevemosPanel");
            }
        }

        private bool _showInfoPoliticalState;
        public bool ShowInfoPoliticalState
        {
            get
            {
                return _showInfoPoliticalState;
            }
            set
            {
                _showInfoPoliticalState = value;
                RaisePropertyChanged("ShowInfoPoliticalState");
            }
        }

        private ObservableCollection<PoliticalInformationMunicipality> _politicMunicipalityInfoCollection;
        public ObservableCollection<PoliticalInformationMunicipality> PoliticMunicipalityInfoCollection
        {
            get
            {
                return _politicMunicipalityInfoCollection;
            }
            set
            {
                _politicMunicipalityInfoCollection = value;
                RaisePropertyChanged("PoliticMunicipalityInfoCollection");
            }
        }

        private PoliticalInformationState _selectedPoliticInfotmationState = new PoliticalInformationState();
        public PoliticalInformationState SelectedPoliticInfotmationState
        {
            get
            {
                return _selectedPoliticInfotmationState;
            }
            set
            {
                _selectedPoliticInfotmationState = value;
                RaisePropertyChanged("SelectedPoliticInfotmationState");
            }
        }
 
        private bool _isAllPoliticalPartyChecked=true;
        public bool IsAllPoliticalPartyChecked
        {
            get
            {
                return _isAllPoliticalPartyChecked;
            }
            set
            {
                _isAllPoliticalPartyChecked = value;
                RaisePropertyChanged("IsAllPoliticalPartyChecked");
            }
        }

        private ObservableCollection<PoliticalPartyModel> _politicalPartyModelCollection = new ObservableCollection<PoliticalPartyModel>();
        public ObservableCollection<PoliticalPartyModel> PoliticalPartyModelCollection
        {
            get
            {
                return _politicalPartyModelCollection;
            }
            set
            {
                _politicalPartyModelCollection = value;
                RaisePropertyChanged("PoliticalPartyModelCollection");
            }
        }

        private ObservableCollection<PoliticalParty> _politicalPartyCollection = new ObservableCollection<PoliticalParty>();
        public ObservableCollection<PoliticalParty> PoliticalPartyCollection
        {
            get
            {
                return _politicalPartyCollection;
            }
            set
            {
                _politicalPartyCollection = value;
                RaisePropertyChanged("PoliticalPartyCollection");
            }
        }

        private bool _showPoliticPartyPanel;
        public bool ShowPoliticPartyPanel
        {
            get
            {
                return _showPoliticPartyPanel;
            }
            set
            {
                _showPoliticPartyPanel = value;
                RaisePropertyChanged("ShowPoliticPartyPanel");
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        private bool _showDatePanel;
        public bool ShowDatePanel
        {
            get
            {
                return _showDatePanel;
            }
            set
            {
                _showDatePanel = value;
                RaisePropertyChanged("ShowDatePanel");
            }
        }

        private bool _showLoading;
        public bool ShowLoading
        {
            get
            {
                return _showLoading;
            }
            set
            {
                _showLoading = value;
                RaisePropertyChanged("ShowLoading");
            }
        }

        private ObservableCollection<PoliticalInformationState> _politicalInformationStateCollection;
        public ObservableCollection<PoliticalInformationState> PoliticalInformationStateCollection
        {
            get
            {
                return _politicalInformationStateCollection;
            }
            set
            {
                _politicalInformationStateCollection = value;
                RaisePropertyChanged("PoliticalInformationStateCollection"); 
            }
        }


        private Months _selectedInitialMonth;
        public Months SelectedInitialMonth
        {
            get
            {
                return _selectedInitialMonth;
            }
            set
            {
                _selectedInitialMonth = value;
                RaisePropertyChanged("SelectedInitialMonth");
            }
        }

        public ObservableCollection<Months> _initialMonth;
        public ObservableCollection<Months> InitialMonth
        {
            get
            {
                return _initialMonth;
            }
            set
            {
                _initialMonth = value;
                RaisePropertyChanged("InitialMonth");
            }
        }

        private Months _selectedFinalMonth;
        public Months SelectedFinalMonth
        {
            get
            {
                return _selectedFinalMonth;
            }
            set
            {
                _selectedFinalMonth = value;
                RaisePropertyChanged("SelectedFinalMonth");
            }
        }

        public ObservableCollection<Months> _finalMonth;
        public ObservableCollection<Months> FinalMonth
        {
            get
            {
                return _finalMonth;
            }
            set
            {
                _finalMonth = value;
                RaisePropertyChanged("FinalMonth");
            }
        }

        private Year _selectedInitialYear;
        public Year SelectedInitialYear
        {
            get
            {
                return _selectedInitialYear;
            }
            set
            {
                _selectedInitialYear = value;
                RaisePropertyChanged("SelectedInitialYear");
            }
        }

        public ObservableCollection<Year> _initialYear;
        public ObservableCollection<Year>InitialYear
        {
            get
            {
                return _initialYear;
            }
            set
            {
                _initialYear = value;
                RaisePropertyChanged("InitialYear");
            }
        }

        public Year _selectedFinalYear;
        public Year SelectedFinalYear
        {
            get
            {
                return _selectedFinalYear;
            }
            set
            {
                _selectedFinalYear = value;
                RaisePropertyChanged("SelectedFinalYear");
            }
        }

        public ObservableCollection<Year> _finalYear;
        public ObservableCollection<Year> FinalYear
        {
            get
            {
                return _finalYear;
            }
            set
            {
                _finalYear = value;
                RaisePropertyChanged("FinalYear");
            }
        }

        public DashboardViewModel(IMsftService msftService)
        {
            DashBoardService = msftService;
            RegisterCommands();
            RegisterMessages();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<CallBackPoliticalStateMessage>(this,OnRecieveInfoPoliticalStateMessage);
            Messenger.Default.Register<CallBackMexicoAgreementMessages>(this,OnReceiveMexicoAgreementMessage);
            Messenger.Default.Register<CallBackProgramsMessage>(this,OnReceivedProgramMessage);
            Messenger.Default.Register<CallBackCompetitionMessage>(this,OnReceivedCompetitionMessage);
            Messenger.Default.Register<PivotMessages>(this, OnReceivedPivotList);
        }

        private void OnReceivedPivotList(PivotMessages msg)
        {
            if (msg.Operation.Equals(QUERY_PIVOT_MSFT_LIST))
            {
                CreateMsftPivotStateList(msg.Pivot);
            }

            else if (msg.Operation.Equals(QUERY_PIVOT_STATE_LIST))
            {
                CreatePivotStateList(msg.Pivot);
            }
            else if (msg.Operation.Equals(QUERY_PIVOT_COMPETITION_LIST))
            {
                CreatePivotCompetitionList(msg.Pivot);
            }
        }


        private void OnRecieveInfoPoliticalStateMessage(CallBackPoliticalStateMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == UPDATE_STATE_POLITICAL_INFO)
                {
                    if(msg.PoliticaStateInfo!=null){
                    
                        SelectedPoliticInfotmationState = msg.PoliticaStateInfo;
                        IsBusy = true;
                        ShowLoading = true;
                        DashBoardService.GetPoliticalMunicipalityByIdPoliticalState
                        (OnLoadPoliticalInfoMunicipality, 
                        SelectedPoliticInfotmationState.IdPoliticalInformationState);
                    }
                }
            }
        }

        private void OnLoadPoliticalInfoMunicipality(ObservableCollection<PoliticalInformationMunicipality> munPolicCollection)
        {
            if(munPolicCollection!=null)
            {
                
                PoliticMunicipalityInfoCollection = munPolicCollection;
            }
            ShowInfoPoliticalState = true;
            IsBusy = false;
            ShowLoading = false;
        }

        private void OnReceiveMexicoAgreementMessage(CallBackMexicoAgreementMessages msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == UPDATE_ELEVEMOS_INFO)
                {
                    if(DictionaryMexicoAgreements.ContainsKey(msg.MexicoAgreement.State.Name))
                    {
                        StateNameElevemos = msg.MexicoAgreement.State.Name;
                        MexicoStateAgreementCollection = DictionaryMexicoAgreements[msg.MexicoAgreement.State.Name];
                        ShowElevemosPanelInfo = true;
                    }
                }
            }
        }

        private void OnReceivedProgramMessage(CallBackProgramsMessage msg)
        {
            if (msg.idOperation == UPDATE_MICROSOFT_PROGRAM)
            {
                if (msg.MicrosoftProgramStateCallBack != null)
                {
                    MsftProgramCollection.Clear();
                    StateNameProgram = msg.MicrosoftProgramStateCallBack.State.Name;

                    MsftProgramCollection = new ObservableCollection<MicrosoftProgramState>(DictionaryMsftProgram[msg.MicrosoftProgramStateCallBack.State.Name]);
                    ShowMsftProgramInfo = true;
                }
            }
            else if (msg.idOperation == UPDATE_STATE_PROGRAM)
            {
                if (msg.StateProgramCallBack != null)
                {
                    StateNameProgram = msg.StateProgramCallBack.State.Name;

                    if (StateProgramInfoCollection != null)
                    {
                        StateProgramInfoCollection.Clear();
                        StateProgramInfoCollection = new ObservableCollection<StateProgram>(DictionaryStateProgram[msg.StateProgramCallBack.State.Name]);
                    }
                    ShowStateProgramInfo = true;
                }
            }
            else if (msg.idOperation == UPDATE_COMPETITION_PROGRAM)
            {
                if (msg.CompetitonCallBack != null)
                {
                    StateNameProgram = msg.CompetitonCallBack.State.Name;

                    if (CompetitionCollectionInfo != null)
                    {
                        CompetitionCollectionInfo.Clear();
                        CompetitionCollectionInfo = new ObservableCollection<Competition>(DictionaryCompetitionState[msg.CompetitonCallBack.State.Name]);
                    }
                    ShowCompetitionInfo = true;
                }
                
            }
            else if (msg.idOperation == SHOW_PIVOT_MSFT_INFO)
            {
                if (DictionaryPivotModels.ContainsKey(msg.MsftPivotCallBack.State))
                {
                    StateNameProgram = msg.MsftPivotCallBack.State;
                    PivotModelInfoCollection = DictionaryPivotModels[msg.MsftPivotCallBack.State];
                    ShowPivotInfoState = true;
                }
            }
            else if (msg.idOperation == SHOW_PIVOT_STATE_INFO)
            {
                if (DictionaryPivotModels.ContainsKey(msg.StatePivotCallBack.State))
                {
                    StateNameProgram = msg.StatePivotCallBack.State;
                    ShowPivotInfoState = true;
                }
            }
            else if (msg.idOperation == SHOW_PIVOT_COMPETITION_INFO)
            {
                if (DictionaryPivotModels.ContainsKey(msg.CompetitionPivotCallBack.State))
                {
                    StateNameProgram = msg.CompetitionPivotCallBack.State;
                    ShowPivotInfoState = true;
                }

            }
        }

        private void OnReceivedCompetitionMessage(CallBackCompetitionMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == UPDATE_COMPETITION_PROGRAM)
                {
                    CompetitionCollectionInfo = new ObservableCollection<Competition>(DictionaryCompetitionState[msg.CompetitionState.State.Name]);

                }
            }
        }

        private void OnLoadMsftProgramStateInfoById(ObservableCollection<MicrosoftProgramState> msftProgramCollection)
        {
            if (msftProgramCollection != null)
            {

            }
        }

        private void OnLoadStateProgramInfoById(ObservableCollection<StateProgram> stateProgram)
        {
            
        }

        private void RegisterCommands()
        {
            DateCommand = new RelayCommand(OnDateSelected);

            PoliticCommand = new RelayCommand(OnPoliticSelected);
            CheckAllPoliticalCommand = new RelayCommand(OnCheckAllPoliticalState);
            UnCheckAllPoliticalCommand = new RelayCommand(OnUncheckAllPoliticalState);
            CheckedPoliticalCommand = new RelayCommand<string>(OnCheckBoxPoliticalState);
            UnCheckedPoliticalCommand = new RelayCommand<string>(OnUnCheckBoxPoliticalState);

            ElevemosCommand = new RelayCommand(OnElevemosSelected);

            CheckMarcoAllCommand = new RelayCommand(OnSelectCheckMarcoAll);
            UnCheckMarcoAllCommand = new RelayCommand(OnSelectUnCheckMarcoAll);
            CheckEspecificoAllCommand = new RelayCommand(OnSelectCheckEspecificoAll);
            UnCheckEspecificoAllCommand = new RelayCommand(OnSelectUnCheckEspecificoAll);
            
            CheckMarcoCommand = new RelayCommand<int>(OnCheckElevemosMarcoSelected);
            CheckEspecificoCommand = new RelayCommand<int>(OnCheckElevemosEspecificoSelected);
            UnCheckMarcoCommand = new RelayCommand<int>(OnUnCheckElevemosMarcoSelected);
            UnCheckEspecificoCommand = new RelayCommand<int>(OnUnCheckElevemosEspecificoSelected);

            InversionEstadoCommand = new RelayCommand(OnInversionEstadoSelected);
            InversionMsftCommand = new RelayCommand(OnInversionMsftSelected);
            InversionCompetitionCommand = new RelayCommand(OnInversionCompetitionSelected);

            CheckAllAreaMsftCommand = new RelayCommand<string>(OnCheckedAllAreasMsft);
            UnCheckAllAreaMsftCommand = new RelayCommand<string>(OnUnCheckedAllAreasMsft);
            CheckProgramMsftCommand = new RelayCommand<string>(OnCheckMsftProgramCommand);
            UnCheckProgramMsftCommand = new RelayCommand<string>(OnUnCheckMsftProgramCommand);

            CheckAllAreaStateProgramCommand = new RelayCommand<string>(OnCheckAllAreasState);
            UnCheckAllAreaStateProgramCommand = new RelayCommand<string>(OnUnCheckAllAreasState);
            CheckProgramStateCommand = new RelayCommand<string>(OnCheckStateProgramCommand);
            UnCheckProgramStateCommand = new RelayCommand<string>(OnUnCheckStateProgramCommand);

            PivotMsftCommand = new RelayCommand(OnPivotMsftSelected);
            PivotStateCommand = new RelayCommand(OnPivoStateSelected);
            PivotCompetitionCommand = new RelayCommand(OnPivotCompetitionSelected);

            SearchDateCommand = new RelayCommand(OnSearchDate);
            OkPivotMsftCommand = new RelayCommand(OnOkPivotMsft);
            CancelPivotMsftCommand = new RelayCommand(CancelPivotMsft);

            SearchDateStateCommand = new RelayCommand(OnSearchDateState);
            OkPivotStateCommand = new RelayCommand(OnOkPivotState);
            CancelPivotStateCommand = new RelayCommand(CancelPivotState);

            SearchDateCompetitionCommand = new RelayCommand(OnSearchDateCompetition);
            OkPivotCompetitionCommand = new RelayCommand(OnOkPivotCompetition);
            CancelPivotCompetitionCommand = new RelayCommand(CancelPivotCompetition);

            CheckedTypeCompetitionCommand = new RelayCommand<string>(OnCheckTypeCompetitionCommand);
            UnCheckedTypeCompetitionCommand = new RelayCommand<string>(OnUnChecktTypeCompetitionCommand);

            CheckRoadMode = new RelayCommand(OnCheckRoadMode);
            CheckAerialMode = new RelayCommand(OnCheckAerialMode);
            CheckLabelsMode = new RelayCommand(OnCheckLabelsMode);

        }

        private void OnCheckRoadMode()
        {
            //Messenger.Default.Send<string>(ROAD_MODE);  
        }

        private void OnCheckAerialMode()
        {
            Messenger.Default.Send<string>(AERIAL_MODE);  
        }

        private void OnCheckLabelsMode()
        {
            Messenger.Default.Send<string>(LABELS_MODE);  
        }


        private void OnCheckTypeCompetitionCommand(string type)
        {
            CheckUnCheckTypeCompetition(type, IS_CHECKED);
            Messenger.Default.Send<CompetitionMessage>(
               new CompetitionMessage()
               {
                   IdOperation = DRAW_COMPETITION_PROGRAM_OPERATION,
                   CompetitionCollection = this.CompetitionCollectionFilter
               });
        }

        private void OnUnChecktTypeCompetitionCommand(string type)
        {
            CheckUnCheckTypeCompetition(type, IS_UNCHECKED);
            Messenger.Default.Send<CompetitionMessage>(
               new CompetitionMessage()
               {
                   IdOperation = DRAW_COMPETITION_PROGRAM_OPERATION,
                   CompetitionCollection = this.CompetitionCollectionFilter
               });
        }

        private void CheckUnCheckTypeCompetition(string competitionName, bool isChecked)
        {
            TotalRoi = 0;
            TotalInvestMent = 0;
            CompetitionCollectionFilter.Clear();
            foreach (TypeModels typeCompetition in TypeCompetitionCollection)
            {
                if (typeCompetition.Name.ToLower().Trim().Equals(competitionName.ToLower().Trim()))
                {
                    typeCompetition.IsChecked = isChecked;
                }
                AddCompetitionToMap(typeCompetition.Name, typeCompetition.IsChecked);
            }
        }

        public void AddCompetitionToMap(string competitionName, bool isChecked)
        {

            foreach (Competition competition in CompetitionCollection)
            {
                if (competition.TypeSource.Name.Equals(competitionName)&& isChecked)
                {
                    TotalInvestMent += competition.Investment;
                    TotalRoi += competition.ROI;
                    CompetitionCollectionFilter.Add(competition);
                }
            }
        }

        private void OnSearchDate()
        {
            if (InitialDate != null && FinalDate != null)
            {

                StringBuilder queryCxml = new StringBuilder();
                queryCxml.Append("InitialDate=").Append(InitialDate.Ticks)
                    .Append("&").Append("FinalDate=").Append(FinalDate.Ticks);


                Dictionary<string, string> searchParameters = new Dictionary<string, string>();
                searchParameters.Add(SEARCH_PIVOT_MSFT, queryCxml.ToString());
                Messenger.Default.Send<Dictionary<string, string>>
                                    (searchParameters);
            }
        }

        private void OnOkPivotMsft()
        {
            Messenger.Default.Send<string>(QUERY_PIVOT_MSFT_LIST);
           
        }

        private void CancelPivotMsft()
        {
            ShowPivotMsft = false;
        }

        private void OnSearchDateState()
        {
            if (InitialDateState != null && FinalDateState != null)
            {

                StringBuilder queryCxml = new StringBuilder();
                queryCxml.Append("InitialDate=").Append(InitialDateState.Ticks)
                    .Append("&").Append("FinalDate=").Append(FinalDateState.Ticks);


                Dictionary<string, string> searchParameters = new Dictionary<string, string>();
                searchParameters.Add(SEARCH_PIVOT_STATE, queryCxml.ToString());
                Messenger.Default.Send<Dictionary<string, string>>
                                    (searchParameters);
            }
        }

        private void OnOkPivotState()
        {
            Messenger.Default.Send<string>(QUERY_PIVOT_STATE_LIST);

        }

        private void CancelPivotState()
        {
            ShowPivotState = false;
        }


        private void OnSearchDateCompetition()
        {
            if (InitialDateCompetition != null && FinalDateCompetition != null)
            {

                StringBuilder queryCxml = new StringBuilder();
                queryCxml.Append("InitialDate=").Append(InitialDateCompetition.Ticks)
                    .Append("&").Append("FinalDate=").Append(FinalDateCompetition.Ticks);


                Dictionary<string, string> searchParameters = new Dictionary<string, string>();
                searchParameters.Add(SEARCH_PIVOT_COMPETITION, queryCxml.ToString());
                Messenger.Default.Send<Dictionary<string, string>>
                                    (searchParameters);
            }
        }

        private void OnOkPivotCompetition()
        {
            Messenger.Default.Send<string>(QUERY_PIVOT_COMPETITION_LIST);

        }

        private void CancelPivotCompetition()
        {
            ShowPivotCompetition = false;
        }

        

        private void OnCheckMsftProgramCommand(string program)
        {
            UpdateAreaProgram(program,IS_CHECKED);
            CheckUnCheckProgram();
            

            Messenger.Default.Send<MsftProgramMessage>
                   (new MsftProgramMessage()
                   {
                       IdOperation = DRAW_MICROSOFT_PROGRAM_OPERATION,
                       MsftProgramCollection = this.MsftProgramCollectionFilter
                   }
                   );
        }

        private void OnUnCheckMsftProgramCommand(string program)
        {
            ShowMsftInvestmentPanel = false;
            
            UpdateAreaProgram(program, IS_UNCHECKED);
            CheckUnCheckProgram();


            Messenger.Default.Send<MsftProgramMessage>
                   (new MsftProgramMessage()
                   {
                       IdOperation = DRAW_MICROSOFT_PROGRAM_OPERATION,
                       MsftProgramCollection = this.MsftProgramCollectionFilter
                   }
                   );
        }

        private void OnCheckStateProgramCommand(string program)
        {
            UpdateAreaProgram(program, IS_CHECKED);
            CheckUnCheckProgramState();


            Messenger.Default.Send<StateProgramMessage>
                   (new StateProgramMessage()
                   {
                       IdOperation = DRAW_STATE_PROGRAM_OPERATION,
                       StateProgramCollection = this.StateProgramCollectionFilter
                   }
                   );
        }

        private void OnUnCheckStateProgramCommand(string program)
        {
            UpdateAreaProgram(program, IS_UNCHECKED);
            CheckUnCheckProgramState();


            Messenger.Default.Send<StateProgramMessage>
                   (new StateProgramMessage()
                   {
                       IdOperation = DRAW_STATE_PROGRAM_OPERATION,
                       StateProgramCollection = this.StateProgramCollectionFilter
                   }
                   );
        }

        private void UpdateAreaProgram(string name, bool isChecked)
        {
            foreach (AreaProgramModel area in AreaProgramCollection)
            {
                foreach (ProgramModel program in area.ProgramCollection)
                {
                    if (program.Name.Equals(name))
                    {
                        program.IsChecked = isChecked;
                    }
                }
            }
        }

        private void CheckUnCheckProgram()
        {
            if (MsftProgramCollectionFilter == null)
            {
                MsftProgramCollectionFilter = new ObservableCollection<MicrosoftProgramState>();
            }
            MsftProgramCollectionFilter.Clear();

            TotalInvestMent = 0;
            TotalRoi = 0;
            foreach (MicrosoftProgramState msft in MsftProgramCollection)
            {
                foreach (AreaProgramModel area in AreaProgramCollection)
                {
                    if (area.Name.Equals(msft.Source.Name))
                    {
                        foreach(ProgramModel program in area.ProgramCollection)
                        {
                            if (program.Name.Equals(msft.Program.Name) && program.IsChecked)
                            {
                                TotalInvestMent += (double)msft.Investment;
                                TotalRoi += (double)msft.ROI;
                                MsftProgramCollectionFilter.Add(msft);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void CheckUnCheckProgramState()
        {
            if (StateProgramCollectionFilter == null)
            {
                StateProgramCollectionFilter = new ObservableCollection<StateProgram>();
            }
            StateProgramCollectionFilter.Clear();

            TotalInvestMent = 0;
            TotalRoi = 0;
            foreach (StateProgram stateProgram in StateProgramCollection)
            {
                foreach (AreaProgramModel area in AreaProgramCollection)
                {
                    if (area.Name.Equals(stateProgram.Source.Name))
                    {
                        foreach (ProgramModel program in area.ProgramCollection)
                        {
                            if (program.Name.Equals(stateProgram.Program.Name) && program.IsChecked)
                            {
                                TotalInvestMent += (double)stateProgram.Investment;
                                TotalRoi += (double)stateProgram.ROI;
                                StateProgramCollectionFilter.Add(stateProgram);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private ObservableCollection<MicrosoftProgramState> MsftProgramCollectionFilter = new ObservableCollection<MicrosoftProgramState>();

        private void OnCheckedAllAreasMsft(string areaName)
        {
            
            ShowMsftInvestmentPanel = false;
            CheckUnCheckArea(areaName,IS_CHECKED);
            ObservableCollection<AreaProgramModel> auxAreaModel = new ObservableCollection<AreaProgramModel>(AreaProgramCollection);
            AreaProgramCollection = new ObservableCollection<AreaProgramModel>(auxAreaModel);

            Messenger.Default.Send<MsftProgramMessage>
                   (new MsftProgramMessage()
                   {
                       IdOperation = DRAW_MICROSOFT_PROGRAM_OPERATION,
                       MsftProgramCollection = this.MsftProgramCollectionFilter
                   }
                   );

        }

        private void OnUnCheckedAllAreasMsft(string areaName)
        {
            
            ShowMsftInvestmentPanel = false;
            CheckUnCheckArea(areaName, IS_UNCHECKED);
            ObservableCollection<AreaProgramModel> auxAreaModel = new ObservableCollection<AreaProgramModel>(AreaProgramCollection);
            AreaProgramCollection = new ObservableCollection<AreaProgramModel>(auxAreaModel);
            
            Messenger.Default.Send<MsftProgramMessage>
                  (new MsftProgramMessage()
                  {
                      IdOperation = DRAW_MICROSOFT_PROGRAM_OPERATION,
                      MsftProgramCollection = this.MsftProgramCollectionFilter
                  }
                  );
        }

        private void CheckUnCheckArea(string areaName, bool isChecked)
        {
            if (MsftProgramCollectionFilter == null)
            {
                MsftProgramCollectionFilter = new ObservableCollection<MicrosoftProgramState>();    
            }
            
            MsftProgramCollectionFilter.Clear();
            TotalInvestMent = 0;
            TotalRoi = 0;
            foreach (AreaProgramModel area in AreaProgramCollection)
            {
                if (area.Name.Equals(areaName))
                {
                    area.IsChecked = isChecked;
                    CheckUnCheckProgams(area.ProgramCollection,isChecked);
                }

                AddMsftProgramToDraw(area);
            }
        }

        private void AddMsftProgramToDraw(AreaProgramModel area)
        {
            foreach (MicrosoftProgramState msftProgram in MsftProgramCollection)
            {
                if (msftProgram.Source.Name.Equals(area.Name) && area.IsChecked)
                {
                    TotalInvestMent += (double)msftProgram.Investment;
                    TotalRoi += (double)msftProgram.ROI;
                    MsftProgramCollectionFilter.Add(msftProgram);
                }
                else
                {
                    foreach (ProgramModel pg in area.ProgramCollection)
                    {
                        if (pg.Name.Equals(msftProgram.Program.Name)&&pg.IsChecked)
                        {
                            TotalInvestMent += (double)msftProgram.Investment;
                            TotalRoi += (double)msftProgram.ROI;
                            MsftProgramCollectionFilter.Add(msftProgram);
                        }
                    }
                }
            }
        }

        private void AddStateProgramToDraw(AreaProgramModel area)
        {
            foreach (StateProgram stateProgram in StateProgramCollection)
            {
                if (stateProgram.Source.Name.Equals(area.Name) && area.IsChecked)
                {
                    TotalInvestMent += (double)stateProgram.Investment;
                    TotalRoi += (double)stateProgram.ROI;
                    StateProgramCollectionFilter.Add(stateProgram);
                }
                else
                {
                    foreach (ProgramModel pg in area.ProgramCollection)
                    {
                        if (pg.Name.Equals(stateProgram.Program.Name) && pg.IsChecked)
                        {
                            TotalInvestMent += (double)stateProgram.Investment;
                            TotalRoi += (double)stateProgram.ROI;
                            StateProgramCollectionFilter.Add(stateProgram);
                        }
                    }
                }
            }
        }
        private ObservableCollection<StateProgram> StateProgramCollectionFilter = new ObservableCollection<StateProgram>();

        private void OnCheckAllAreasState(string areaName)
        {

            CheckUnCheckAreaStateProgram(areaName, IS_CHECKED);
            ObservableCollection<AreaProgramModel> auxAreaModel = new ObservableCollection<AreaProgramModel>(AreaProgramCollection);
            AreaProgramCollection = new ObservableCollection<AreaProgramModel>(auxAreaModel);

            Messenger.Default.Send<StateProgramMessage>
                   (new StateProgramMessage()
                   {
                       IdOperation = DRAW_STATE_PROGRAM_OPERATION,
                       StateProgramCollection = this.StateProgramCollectionFilter
                   }
                   );
           
            
            
        }

        private void OnUnCheckAllAreasState(string areaName)
        {
            CheckUnCheckAreaStateProgram(areaName, IS_UNCHECKED);
            ObservableCollection<AreaProgramModel> auxAreaModel = new ObservableCollection<AreaProgramModel>(AreaProgramCollection);
            AreaProgramCollection = new ObservableCollection<AreaProgramModel>(auxAreaModel);

            Messenger.Default.Send<StateProgramMessage>
                   (new StateProgramMessage()
                   {
                       IdOperation = DRAW_STATE_PROGRAM_OPERATION,
                       StateProgramCollection = this.StateProgramCollectionFilter
                   }
                   );
        }

        private void CheckUnCheckAreaStateProgram(string areaName, bool isChecked)
        {
            if (StateProgramCollectionFilter == null)
            {
                StateProgramCollectionFilter = new ObservableCollection<StateProgram>();
            }

            StateProgramCollectionFilter.Clear();
            TotalInvestMent = 0;
            TotalRoi = 0;
            foreach (AreaProgramModel area in AreaProgramCollection)
            {
                if (area.Name.Equals(areaName))
                {
                    area.IsChecked = isChecked;
                    CheckUnCheckProgamsState(area.ProgramCollection, isChecked);
                }

                AddStateProgramToDraw(area);
            }
        }

        private void CheckUnCheckProgamsState(ObservableCollection<ProgramModel>programCollection,bool isChecked)
        {
            foreach (ProgramModel pg in programCollection)
            {
                pg.IsChecked = isChecked;
            }
        }

        private void CheckUnCheckProgams(ObservableCollection<ProgramModel> programs,bool isChecked)
        {
            foreach (ProgramModel pg in programs)
            {
                pg.IsChecked = isChecked;
            }
        }

        public void AddAreaToMap(int rangeOperation, bool isChecked)
        {

            foreach (MexicoAgreement marcoState in MarcoElevemosMexicoCollection)
            {
                int range = GetRangeByProgress(marcoState.Progress);
                if (range == rangeOperation && isChecked)
                {
                    MarcoCollectionToDraw.Add(marcoState);
                }
            }
        }

        private void OnSelectCheckMarcoAll()
        {
            if (TypeAgreementsCollectionMarco == null || TypeAgreementsCollectionMarco.Count <= 0)
            {
                return;
            }

            ChangeCheckUnCheckAllMarco(IS_CHECKED);
            ObservableCollection<TypeAgreementsModel> typesMarco = TypeAgreementsCollectionMarco;
            TypeAgreementsCollectionMarco = new ObservableCollection<TypeAgreementsModel>(typesMarco);
            Messenger.Default.Send<MexicoAgreementMessages>(
                   new MexicoAgreementMessages()
                   {
                       IdOperation = DRAW_ELEVEMOS_MEXICO_MARCO,
                       ElevemosMarcoCollection = MarcoElevemosMexicoCollection
                   });
        }

        private void OnSelectUnCheckMarcoAll()
        {
            if (TypeAgreementsCollectionMarco == null || TypeAgreementsCollectionMarco.Count <= 0)
            {
                return;
            }

            ChangeCheckUnCheckAllMarco(IS_UNCHECKED);
            ObservableCollection<TypeAgreementsModel> typesMarco = TypeAgreementsCollectionMarco;
            TypeAgreementsCollectionMarco = new ObservableCollection<TypeAgreementsModel>(typesMarco);
            Messenger.Default.Send<MexicoAgreementMessages>(
                  new MexicoAgreementMessages()
                  {
                      IdOperation = DRAW_ELEVEMOS_MEXICO_MARCO,
                      ElevemosMarcoCollection = new ObservableCollection<MexicoAgreement>()
                  });
        }

        private void ChangeCheckUnCheckAllMarco(bool isChecked)
        {
            foreach(TypeAgreementsModel typeAgreement in TypeAgreementsCollectionMarco)
            {
                if (typeAgreement.IsEnabled)
                {
                    typeAgreement.IsChecked = isChecked;
                }
            }
        }

        private void OnSelectCheckEspecificoAll()
        {
            if (TypeAgreementsCollectionEspecifico == null || TypeAgreementsCollectionEspecifico.Count <= 0)
            {
                return;
            }

            ChangeCheckUnCheckAllEspecifico(IS_CHECKED);
            ObservableCollection<TypeAgreementsModel> typesEspecifico = TypeAgreementsCollectionEspecifico;
            TypeAgreementsCollectionEspecifico = new ObservableCollection<TypeAgreementsModel>(typesEspecifico);
            Messenger.Default.Send<MexicoAgreementMessages>(
                  new MexicoAgreementMessages()
                  {
                      IdOperation = DRAW_ELEVEMOS_MEXICO_ESPECIFICO,
                      ElevemosEspecificoCollection = EspecificoElevemosMexicoCollection
                  });
        }

        private void OnSelectUnCheckEspecificoAll()
        {
            if (TypeAgreementsCollectionEspecifico == null || TypeAgreementsCollectionEspecifico.Count<=0)
            {
                return;
            }

            ChangeCheckUnCheckAllEspecifico(IS_UNCHECKED);
            ObservableCollection<TypeAgreementsModel> typesEspecifico = TypeAgreementsCollectionEspecifico;
            TypeAgreementsCollectionEspecifico = new ObservableCollection<TypeAgreementsModel>(typesEspecifico);
            Messenger.Default.Send<MexicoAgreementMessages>(
                  new MexicoAgreementMessages()
                  {
                      IdOperation = DRAW_ELEVEMOS_MEXICO_ESPECIFICO,
                      ElevemosEspecificoCollection = new ObservableCollection<MexicoAgreement>()
                  });
        }

        private void ChangeCheckUnCheckAllEspecifico(bool isChecked)
        {
            foreach (TypeAgreementsModel typeAgreement in TypeAgreementsCollectionEspecifico)
            {
                if (typeAgreement.IsEnabled)
                {
                    typeAgreement.IsChecked = isChecked;
                }
            }
        }

        private void OnInversionEstadoSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ClearPivotLayers();
            DictionaryStateProgram.Clear();
            if (SelectedFinalYear == null || SelectedFinalYear == null || SelectedInitialMonth == null
                || SelectedFinalMonth == null)
            {
                MessageBox.Show("Favor de selecionar un rango de fechas antes de consultar");
                return;
            }

            DateTime initialDate = new DateTime(SelectedInitialYear.Year1, SelectedInitialMonth.Id, 1);
            DateTime finalDate = new DateTime(SelectedFinalYear.Year1, SelectedFinalMonth.Id, 1);

            IsBusy = true;
            ShowLoading = true;
            DashBoardService.GetProgramStateByDate(OnLoadStateProgramInfo, initialDate, finalDate);
            
        }

        private void OnLoadStateProgramInfo(ObservableCollection<StateProgram> stateProgramCollecion)
        {
            if (stateProgramCollecion != null)
            {
                ShowStateProgramInvestmentPanel = true;
                StateProgramCollection = stateProgramCollecion;
                GroupAreaCheckBoxesState();
                ShowDetailInvestmentPanel = true;
                Messenger.Default.Send<StateProgramMessage>
                    (new StateProgramMessage()
                    {
                        IdOperation = DRAW_STATE_PROGRAM_OPERATION,
                        StateProgramCollection = this.StateProgramCollection
                    }
                    );
            }
            IsBusy = false;
            ShowLoading = false;
        }

        private void GroupAreaCheckBoxesState()
        {
            int exists = 0;
            AreaProgramCollection.Clear();
            DictionaryStateProgram.Clear();
            if (dicAreas == null)
            {
                dicAreas = new Dictionary<int, string>();
            }
            else
            {
                dicAreas.Clear();
            }

            foreach (StateProgram item in StateProgramCollection)
            {

                GroupStateProgramByStates(item);
                TotalInvestMent += (double)item.Investment;
                TotalRoi += (double)item.ROI;

                if (!dicAreas.ContainsKey(item.IdSource))
                {
                    string _toolTIp = String.Format("Inversión: {0:C}", item.Investment) + "\n" +
                                        String.Format("ROI: {0:C}", item.ROI);
                    dicAreas.Add(item.Source.IdSource, "");
                    AreaProgramCollection.Add(
                        new AreaProgramModel()
                        {
                            Name = item.Source.Name,
                            Color = ListColorAreas[item.IdSource - 1],
                            IsChecked = true,
                            TotalInvestment = (double)item.Investment,
                            TotalRoi = (double)item.ROI,
                            ToolTip = _toolTIp,
                            ProgramCollection = new ObservableCollection<ProgramModel>() { new ProgramModel() { Name = item.Program.Name, IsChecked = true, TotalInvestment = (double)item.Investment, TotalRoi = (double)item.ROI, ToolTip = _toolTIp } }
                        }
                        );
                }
                else
                {
                    foreach (AreaProgramModel areaModel in AreaProgramCollection)
                    {
                        if (areaModel.Name.Equals(item.Source.Name))
                        {
                            areaModel.TotalInvestment += (double)item.Investment;
                            areaModel.TotalRoi += (double)item.ROI;

                            string _toolTIp = String.Format("Inversión: {0:C}", areaModel.TotalInvestment) + "\n" +
                                       String.Format("ROI: {0:C}", areaModel.TotalRoi);
                            areaModel.ToolTip = _toolTIp;

                            foreach (ProgramModel pg in areaModel.ProgramCollection)
                            {

                                if (pg.Name.Equals(item.Program.Name))
                                {
                                    pg.TotalInvestment += (double)item.Investment;
                                    pg.TotalRoi += (double)item.ROI;
                                    pg.ToolTip = String.Format("Inversión: {0:C}", pg.TotalInvestment) + "\n" +
                                       String.Format("ROI: {0:C}", pg.TotalRoi);
                                    exists = 1;
                                    break;
                                }
                            }

                            if (exists > 0)
                            {
                                exists = 0;
                            }
                            else
                            {
                                _toolTIp = String.Format("Inversión: {0:C}", item.Investment) + "\n" +
                                        String.Format("ROI: {0:C}", item.ROI);
                                areaModel.ProgramCollection.Add(new ProgramModel() { Name = item.Program.Name, IsChecked = true, TotalRoi = (double)item.ROI, TotalInvestment = (double)item.Investment, ToolTip = _toolTIp });
                            }
                        }
                    }
                }
            }
        }

        private void OnInversionMsftSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ClearPivotLayers();
            dicAreas.Clear();
            DictionaryMexicoAgreements.Clear();

            if (SelectedFinalYear == null || SelectedFinalYear == null || SelectedInitialMonth == null
                || SelectedFinalMonth == null)
            {
                MessageBox.Show("Favor de selecionar un rango de fechas antes de consultar");
                return;
            }

            DateTime initialDate = new DateTime(SelectedInitialYear.Year1, SelectedInitialMonth.Id, 1);
            DateTime finalDate = new DateTime(SelectedFinalYear.Year1, SelectedFinalMonth.Id, 1);

            IsBusy = true;
            ShowLoading = true;
            DashBoardService.GetMicrosoftProgramStateByDate(OnLoadMsftProgramInfo, initialDate, finalDate);
        }

        private Dictionary<int, string> DicTypes = new Dictionary<int, string>(); 
        
        private void OnInversionCompetitionSelected()
        {  
            ClearMapLayers();
            ClearPanels();
            ClearPivotLayers();
            TypeCompetitionCollection.Clear();
            //DictionaryMexicoAgreements.Clear();

            if (SelectedFinalYear == null || SelectedFinalYear == null || SelectedInitialMonth == null
                || SelectedFinalMonth == null)
            {
                MessageBox.Show("Favor de selecionar un rango de fechas antes de consultar");
                return;
            }

            DateTime initialDate = new DateTime(SelectedInitialYear.Year1, SelectedInitialMonth.Id, 1);
            DateTime finalDate = new DateTime(SelectedFinalYear.Year1, SelectedFinalMonth.Id, 1);

            IsBusy = true;
            ShowLoading = true;
            DashBoardService.GetCompetitionByDate(OnLoadCompetition, initialDate, finalDate);

        }

        private void OnLoadCompetition(ObservableCollection<Competition> competitionCollection)
        {
            if (competitionCollection != null && competitionCollection.Count>0)
            {
                CompetitionCollection = competitionCollection;
                GenerateTypeCompetitionCollection(CompetitionCollection);
                ShowCompetitionPanel = true;
                ShowDetailInvestmentPanel = true;
                Messenger.Default.Send<CompetitionMessage>
                    (
                        new CompetitionMessage()
                        {
                            IdOperation=DRAW_COMPETITION_PROGRAM_OPERATION,
                            CompetitionCollection= this.CompetitionCollection
                        }
                    );

            }
            IsBusy = false;
            ShowLoading = false;
        }

        private void GenerateTypeCompetitionCollection(ObservableCollection<Competition> competitionCollection)
        {
            foreach (Competition competition in competitionCollection)
                {GroupCompetitionByState(competition);
                AddToTypeCompetitonCollection(competition);   
            }
        }

        private void AddToTypeCompetitonCollection(Competition competition)
        {

            
            TypeModels typeModel = new TypeModels();
            typeModel.Name = competition.TypeSource.Name;
            typeModel.IsChecked = true;

            if (TypeCompetitionCollection == null)
            {
                TypeCompetitionCollection = new ObservableCollection<TypeModels>();
            }

            if (TypeCompetitionCollection.Count <= 0)
            {
                TotalInvestMent += competition.Investment;
                TotalRoi += competition.ROI;
                typeModel.TotalInvestment += (double)competition.Investment;
                typeModel.TotalRoi += (double)competition.ROI;
                typeModel.ToolTip = String.Format("Inversión: {0:C}", typeModel.TotalInvestment) + "\n" +
                                        String.Format("ROI: {0:C}", typeModel.TotalRoi);
                typeModel.Color = ListColorAreas[competition.TypeSource.IdType-1];
                TypeCompetitionCollection.Add(typeModel);

            }
            else
            {
                bool isAlreadyInserted = false;
                foreach (TypeModels typeCompetiton in TypeCompetitionCollection)
                {
                    if (typeCompetiton.Name.Equals(typeModel.Name))
                    {

                        TotalInvestMent += competition.Investment;
                        TotalRoi += competition.ROI;
                        typeCompetiton.TotalInvestment += competition.Investment;
                        typeCompetiton.TotalRoi += competition.ROI;
                        typeCompetiton.ToolTip = String.Format("Inversión: {0:C}", typeCompetiton.TotalInvestment) + "\n" +
                                        String.Format("ROI: {0:C}", typeCompetiton.TotalRoi);
                        isAlreadyInserted = true;
                        break;
                    }
                }

                if (!isAlreadyInserted)
                {
                    TotalInvestMent += competition.Investment;
                    TotalRoi += competition.ROI;
                    typeModel.TotalInvestment += (double)competition.Investment;
                    typeModel.TotalRoi += (double)competition.ROI;
                    typeModel.ToolTip = String.Format("Inversión: {0:C}", typeModel.TotalInvestment) + "\n" +
                                            String.Format("ROI: {0:C}", typeModel.TotalRoi);
                    typeModel.Color = ListColorAreas[competition.TypeSource.IdType - 1];
                    TypeCompetitionCollection.Add(typeModel);
                }
            }

        }



        private void OnPivotMsftSelected()
        {
            ClearMapLayers();
            ClearPanels();

            ShowPivotMsft = true;

            //DateTime initialDate= new DateTime(SelectedInitialYear.Year1,SelectedInitialMonth.Id,1);
            //DateTime finalDate= new DateTime(SelectedFinalYear.Year1,SelectedFinalMonth.Id,1);
            //StringBuilder queryCxml = new StringBuilder();
            //queryCxml.Append("InitialDate=").Append(initialDate.Ticks)
            //    .Append("&").Append("FinalDate=").Append(finalDate.Ticks);
                
            
            //Messenger.Default.Send<string>(SHOW_MSFT_PIVOT);
        }

        private void OnPivoStateSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ShowPivotState = true;
        }

        private void OnPivotCompetitionSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ShowPivotCompetition = true;
        }

        private Dictionary<int, string> dicAreas = new Dictionary<int, string>();

        private void OnLoadMsftProgramInfo(ObservableCollection<MicrosoftProgramState> msftProgramCollection)
        {
            if (msftProgramCollection != null && msftProgramCollection.Count>0)
            {
                MsftProgramCollection = msftProgramCollection;
                GroupAreaCheckBoxes();
                
                
                Messenger.Default.Send<MsftProgramMessage>
                    (new MsftProgramMessage()
                        {
                            IdOperation=DRAW_MICROSOFT_PROGRAM_OPERATION,
                            MsftProgramCollection =this.MsftProgramCollection
                        }
                    );

                ShowDetailInvestmentPanel = true;
                ShowMsftInvestmentPanel = true;
            }
            IsBusy = false;
            ShowLoading = false;
        }

        private void GroupMsftProgramByStates(MicrosoftProgramState msftProgram)
        {
            if (!DictionaryMsftProgram.ContainsKey(msftProgram.State.Name))
            {
                ObservableCollection<MicrosoftProgramState> msftProgramColl = new ObservableCollection<MicrosoftProgramState>();
                msftProgramColl.Add(msftProgram);
                DictionaryMsftProgram.
                    Add(msftProgram.State.Name, msftProgramColl);
            }
            else
            {
                ((ObservableCollection<MicrosoftProgramState>)
                    DictionaryMsftProgram[msftProgram.State.Name]).Add(msftProgram);
            }

        }

        private void GroupStateProgramByStates(StateProgram stateProgram)
        {
            if (!DictionaryStateProgram.ContainsKey(stateProgram.State.Name))
            {
                ObservableCollection<StateProgram> stateProgramColl = new ObservableCollection<StateProgram>();
                stateProgramColl.Add(stateProgram);
                DictionaryStateProgram.
                    Add(stateProgram.State.Name, stateProgramColl);
            }
            else
            {
                ((ObservableCollection<StateProgram>)
                    DictionaryStateProgram[stateProgram.State.Name]).Add(stateProgram);
            }

        }

         private void GroupCompetitionByState(Competition competition)
         {
             if (!DictionaryCompetitionState.ContainsKey(competition.State.Name))
             {
                 ObservableCollection<Competition> competitionColl = new ObservableCollection<Competition>();
                 competitionColl.Add(competition);
                 DictionaryCompetitionState.
                     Add(competition.State.Name, competitionColl);
             }
             else
             {
                 ((ObservableCollection<Competition>)
                     DictionaryCompetitionState[competition.State.Name]).Add(competition);
             }
         }

        
        private void GroupAreaCheckBoxes()
        {
            int exists = 0;
            AreaProgramCollection.Clear();
            DictionaryMsftProgram.Clear();
            if (dicAreas == null)
            {
                dicAreas = new Dictionary<int, string>();
            }
            else
            {
                dicAreas.Clear();
            }

            foreach (MicrosoftProgramState item in MsftProgramCollection)
            {

                GroupMsftProgramByStates(item);
                TotalInvestMent += (double)item.Investment;
                TotalRoi += (double)item.ROI;

                if (!dicAreas.ContainsKey(item.IdSource))
                {
                    string _toolTIp = String.Format("Inversión: {0:C}", item.Investment) + "\n" +
                                        String.Format("ROI: {0:C}", item.ROI);
                    dicAreas.Add(item.Source.IdSource, "");
                    AreaProgramCollection.Add(
                        new AreaProgramModel()
                        {
                            Name = item.Source.Name,
                            Color = ListColorAreas[item.IdSource - 1],
                            IsChecked = true,
                            TotalInvestment=(double)item.Investment,
                            TotalRoi=(double)item.ROI,
                            ToolTip=_toolTIp,
                            ProgramCollection = new ObservableCollection<ProgramModel>() { new ProgramModel() { Name = item.Program.Name, IsChecked = true,TotalInvestment=(double)item.Investment,TotalRoi=(double)item.ROI,ToolTip=_toolTIp } }
                        }
                        );
                }
                else
                {
                    foreach (AreaProgramModel areaModel in AreaProgramCollection)
                    {
                        if (areaModel.Name.Equals(item.Source.Name))
                        {
                            areaModel.TotalInvestment += (double)item.Investment;
                            areaModel.TotalRoi += (double)item.ROI;

                            string _toolTIp = String.Format("Inversión: {0:C}", areaModel.TotalInvestment) + "\n" +
                                       String.Format("ROI: {0:C}", areaModel.TotalRoi);
                            areaModel.ToolTip = _toolTIp;

                            foreach (ProgramModel pg in areaModel.ProgramCollection)
                            {   
                                
                                if (pg.Name.Equals(item.Program.Name))
                                {
                                    pg.TotalInvestment += (double)item.Investment;
                                    pg.TotalRoi += (double)item.ROI;
                                    pg.ToolTip = String.Format("Inversión: {0:C}", pg.TotalInvestment) + "\n" +
                                       String.Format("ROI: {0:C}", pg.TotalRoi);
                                    exists = 1;
                                    break;
                                }
                            }

                            if (exists > 0)
                            {
                                exists = 0;
                            }
                            else
                            {
                                _toolTIp = String.Format("Inversión: {0:C}", item.Investment) + "\n" +
                                        String.Format("ROI: {0:C}", item.ROI);
                                areaModel.ProgramCollection.Add(new ProgramModel() {Name=item.Program.Name,IsChecked=true,TotalRoi=(double)item.ROI,TotalInvestment=(double)item.Investment,ToolTip=_toolTIp });
                            }
                        }
                    }
                }
            }
        }

        private void OnDateSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ShowDatePanel = true;
        }

        private void OnCheckElevemosMarcoSelected(int idOperation)
        {
            MarcoCollectionToDraw.Clear();

            CheckUnCheckMarco(idOperation, IS_CHECKED);

            Messenger.Default.Send<MexicoAgreementMessages>(
                new MexicoAgreementMessages()
                {
                    IdOperation = DRAW_ELEVEMOS_MEXICO_MARCO,
                    ElevemosMarcoCollection = MarcoCollectionToDraw
                });

        }

        private void OnUnCheckElevemosMarcoSelected(int idOperation)
        {
            MarcoCollectionToDraw.Clear();

            CheckUnCheckMarco(idOperation, IS_UNCHECKED);

            Messenger.Default.Send<MexicoAgreementMessages>(
                new MexicoAgreementMessages()
                {
                    IdOperation = DRAW_ELEVEMOS_MEXICO_MARCO,
                    ElevemosMarcoCollection = MarcoCollectionToDraw
                });
        }

        private void CheckUnCheckMarco(int idOperation, bool isChecked)
        {
            foreach (TypeAgreementsModel marco in TypeAgreementsCollectionMarco)
            {
                
                if (GetRangeElevemosMexico(marco.Id) == idOperation)
                {
                    marco.IsChecked = isChecked;
                }
                AddMarcoStateToMap(marco.Id, marco.IsChecked);
            }
        }

        public void AddMarcoStateToMap(int rangeOperation, bool isChecked)
        {

            foreach (MexicoAgreement marcoState in MarcoElevemosMexicoCollection)
            {
                int range = GetRangeByProgress(marcoState.Progress);
                if (range == rangeOperation && isChecked)
                {
                    MarcoCollectionToDraw.Add(marcoState);
                }
            }
        }

        private void OnCheckElevemosEspecificoSelected(int idOperation)
        {
            EspecificoCollectionToDraw.Clear();

            CheckUnCheckEspecifico(idOperation, IS_CHECKED);

            Messenger.Default.Send<MexicoAgreementMessages>(
                new MexicoAgreementMessages()
                {
                    IdOperation = DRAW_ELEVEMOS_MEXICO_ESPECIFICO,
                    ElevemosEspecificoCollection = EspecificoCollectionToDraw
                });
        }

        private void OnUnCheckElevemosEspecificoSelected(int idOperation)
        {
            EspecificoCollectionToDraw.Clear();

            CheckUnCheckEspecifico(idOperation, IS_UNCHECKED);

            Messenger.Default.Send<MexicoAgreementMessages>(
                new MexicoAgreementMessages()
                {
                    IdOperation = DRAW_ELEVEMOS_MEXICO_ESPECIFICO,
                    ElevemosEspecificoCollection = EspecificoCollectionToDraw
                });
            
        }

        private void CheckUnCheckEspecifico(int idOperation, bool isChecked)
        {
            foreach (TypeAgreementsModel especifico in TypeAgreementsCollectionEspecifico)
            {
                
                if (especifico.Id == idOperation)
                {
                    especifico.IsChecked = isChecked;
                }
                AddEspecificoStateToMap(especifico.Id, especifico.IsChecked);
            }
        }

        public void AddEspecificoStateToMap(int rangeOperation, bool isChecked)
        {

            foreach (MexicoAgreement especifico in EspecificoElevemosMexicoCollection)
            {
                int range = GetRangeByProgress(especifico.Progress);
                if (range == rangeOperation&& isChecked)
                {
                    EspecificoCollectionToDraw.Add(especifico);
                }
            }
        }


        private int GetRangeElevemosMexico(int idOperation)
        {
            int range = 0;
            if (idOperation == 1)
            {
                range = 1;
            }
            else if (idOperation == 2)
            {
                range = 2;
            }
            else if (idOperation == 3)
            {
                range = 3;
            }
            else if (idOperation == 4)
            {
                range = 4;
            }

            return range;
        }

        private int GetRangeByProgress(int p)
        {
            int range = 0;
            if (p >= 0 && p < 25)
            {
                range= 1;
            }
            else if (p >= 25 && p < 50)
            {
                range = 2;
            }

            else if (p >= 50 && p < 75)
            {
                range = 3;
            }

            else if (p >= 75 && p <= 100)
            {
                range = 4;
            }

            return range;
        }

        private void OnElevemosSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ClearPivotLayers();

            if (SelectedFinalYear == null || SelectedFinalYear == null || SelectedInitialMonth == null
                || SelectedFinalMonth == null)
            {
                MessageBox.Show("Favor de selecionar un rango de fechas antes de consultar");
                return;
            }
  
            initialDate = new DateTime(SelectedInitialYear.Year1,SelectedInitialMonth.Id,1);
            finalDate = new DateTime(SelectedFinalYear.Year1,SelectedFinalMonth.Id,1);

            IsBusy = true;
            ShowLoading = true;
            DashBoardService.GetTypeAgreement(OnLoadTypeAgreements);
        }

        private void OnLoadElevemosMexicoInfo(ObservableCollection<MexicoAgreement> elevemosCollection)
        {
            if (elevemosCollection != null)
            {
                ElevemosMexicoCollection = elevemosCollection;


                AgroupByTypeAgreement(ElevemosMexicoCollection);

                Messenger.Default.Send<MexicoAgreementMessages>(
                    new MexicoAgreementMessages() 
                    { IdOperation=QUERY_ELEVEMOS_MEXICO,
                        ElevemosEspecificoCollection=EspecificoElevemosMexicoCollection,
                        ElevemosMarcoCollection =MarcoElevemosMexicoCollection
                    });
                IsBusy = false;
                ShowLoading = false;
                ShowElevemosPanel = true;
            }
        }

        private void AgroupByTypeAgreement(ObservableCollection<MexicoAgreement> elevemosMexicoCollection)
        {
            foreach (MexicoAgreement mx in elevemosMexicoCollection)
            {
                GroupAgreementsByState(mx);

                int indexRange= GetRangeByProgress(mx.Progress);

                if (mx.TypeAgreement.IdTypeAgreement == 1)
                {
                    if(MarcoElevemosMexicoCollection==null)
                    {
                        MarcoElevemosMexicoCollection = new ObservableCollection<MexicoAgreement>();
                    }
                    MarcoElevemosMexicoCollection.Add(mx);
                    if (!TypeAgreementsCollectionMarco[indexRange - 1].IsChecked)
                    {
                        TypeAgreementsCollectionMarco[indexRange - 1].IsChecked = true;
                        TypeAgreementsCollectionMarco[indexRange - 1].IsEnabled = true;
                    }
                }
                else
                {
                    if (EspecificoElevemosMexicoCollection == null)
                    {
                        EspecificoElevemosMexicoCollection = new ObservableCollection<MexicoAgreement>();
                    }
                    EspecificoElevemosMexicoCollection.Add(mx);

                    if (!TypeAgreementsCollectionEspecifico[indexRange - 1].IsChecked)
                    {
                        TypeAgreementsCollectionEspecifico[indexRange - 1].IsChecked = true;
                        TypeAgreementsCollectionEspecifico[indexRange - 1].IsEnabled = true;
                    }
                }
            }
        }

        private void GroupAgreementsByState(MexicoAgreement stateAgreement)
        {
            if (!DictionaryMexicoAgreements.ContainsKey(stateAgreement.State.Name))
            {
                ObservableCollection<MexicoAgreement> agreementColl= new ObservableCollection<MexicoAgreement>();
                agreementColl.Add(stateAgreement);
                DictionaryMexicoAgreements.
                    Add(stateAgreement.State.Name,agreementColl);
            }
            else 
            {
                ((ObservableCollection<MexicoAgreement>)
                    DictionaryMexicoAgreements[stateAgreement.State.Name]).Add(stateAgreement);
            }
        }

        private void OnLoadTypeAgreements(ObservableCollection<TypeAgreement> typeAgreementsCollection)
        {
            if (TypeAgreementsCollectionMarco != null && TypeAgreementsCollectionMarco.Count > 0)
            {
                TypeAgreementsCollectionMarco = null;
            }

            if (TypeAgreementsCollectionEspecifico != null && TypeAgreementsCollectionEspecifico.Count > 0)
            {
                TypeAgreementsCollectionEspecifico = null;
            }

            if (typeAgreementsCollection != null)
            {
                GenerateParentsTypeAgreements();
                GenerateTypeAgreementCollection(typeAgreementsCollection);
                
            }
            DashBoardService.GetMexicoAgreementsByDate(OnLoadElevemosMexicoInfo, initialDate, finalDate);
            
        }

        private void GenerateParentsTypeAgreements()
        {
            Marco = new TypeAgreementsModel() { Id = 0,IsChecked=true,Name="Marco"};
            Especifico = new TypeAgreementsModel() { Id = 0, IsChecked = true, Name = "Especifico" };
        }

        private void GenerateTypeAgreementCollection(ObservableCollection<TypeAgreement> typeAgreementsCollection)
        {
            foreach (TypeAgreement typeAgreement in typeAgreementsCollection)
            {
                if(typeAgreement.Name.StartsWith("Marco"))
                {
                    GenerateTypeAgreementsMarco();
                }
                else
                {
                    GenerateTypeAgreementsEspecifico();   
                }
            }
        }

        public void GenerateTypeAgreementsMarco()
        {
            int inicialAdvance = 0;
            int finalAdvance = 25;

            if (TypeAgreementsCollectionMarco == null)
            {
                TypeAgreementsCollectionMarco = new ObservableCollection<TypeAgreementsModel>();
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {

                TypeAgreementsModel typeAgreement = new TypeAgreementsModel();
                typeAgreement.Id = i + 1;
                sb.Append("Avance ").Append(inicialAdvance).Append("-").Append(finalAdvance).Append("%");
                typeAgreement.Name = sb.ToString();
                typeAgreement.Color = ListColorsElevemosMexico[i];
                typeAgreement.IsChecked = false;
                typeAgreement.IsEnabled = false;
                TypeAgreementsCollectionMarco.Add(typeAgreement);

                inicialAdvance += 25;
                finalAdvance += 25;
                sb.Clear();
            }
            sb = null;
        }

        public void GenerateTypeAgreementsEspecifico()
        {   
            int inicialAdvance = 0;
            int finalAdvance = 25;

            if (TypeAgreementsCollectionEspecifico == null)
            {
                TypeAgreementsCollectionEspecifico = new ObservableCollection<TypeAgreementsModel>();
            }

            StringBuilder sb = new StringBuilder();
            for(int i=0; i < 4; i++)
            {
                
                TypeAgreementsModel typeAgreement = new TypeAgreementsModel();
                typeAgreement.Id = i + 1;
                sb.Append("Avance ").Append(inicialAdvance).Append("-").Append(finalAdvance).Append("%");
                typeAgreement.Name = sb.ToString();
                typeAgreement.Color = ListColorsElevemosMexico2[i];
                typeAgreement.IsChecked = false;
                typeAgreement.IsEnabled = false;
                TypeAgreementsCollectionEspecifico.Add(typeAgreement);
                
                inicialAdvance += 25;
                finalAdvance += 25;
                sb.Clear();
            }
            sb = null;
        }

        private void LoadData()
        {
            //DashBoardService.GetCurrentStateEconomicInfo(OnLoadStateInfo, 2);
            DashBoardService.GetCurrentEducationStateInfo(OnLoadEducationInfo, 1);

            
            LoadMonthsCombos();
            LoadYearsCombos();
        }

        private void OnLoadEducationInfo(EducationInformationState ed)
        {
            if (ed != null)
            {
            }
        }


        private void OnLoadStateInfo(StateEconomicInfo st)
        {
            if (st != null)
            {

            }
        }

        private void LoadYearsCombos()
        {
            InitialMonth = new ObservableCollection<Months>(App.MonthsCatalog);
            FinalMonth = new ObservableCollection<Months>(App.MonthsCatalog);
        }

        private void LoadMonthsCombos()
        {
            DashBoardService.GetYears(OnLoadYears);
        }



        #region operations

        private void OnLoadYears(ObservableCollection<Year> yearsCollection)
        {
            if (yearsCollection != null)
            {
                InitialYear = new ObservableCollection<Year>(yearsCollection);
                FinalYear = new ObservableCollection<Year>(yearsCollection);
            }
        }


        private void OnPoliticSelected()
        {
            ClearMapLayers();
            ClearPanels();
            ClearPivotLayers();
            if (PoliticalInformationStateCollection!=null && PoliticalInformationStateCollection.Count > 0)
            {
                PoliticalInformationStateCollection.Clear();
            }
            if (PoliticalPartyModelCollection!=null && PoliticalPartyModelCollection.Count > 0)
            {
                PoliticalPartyModelCollection.Clear();
            }
            DisplayBusyIndicator();
            DashBoardService.GetPoliticalStateInformationByDate(OnLoadPoliticStateInfo,DateTime.Now);
        }

        private void OnLoadPoliticStateInfo(ObservableCollection<PoliticalInformationState> politicalStateColl)
        {
            if (politicalStateColl != null)
            {
                PoliticalInformationStateCollection = politicalStateColl;
                GeneratePoliticalPartyCollection(PoliticalInformationStateCollection);
                ShowPoliticPartyPanel = true;
                ConvertToPoliticalPartyModelCollection();
                Messenger.Default.Send<PoliticalStateMessage>(
                    new PoliticalStateMessage()
                    {
                        IdOperation = DRAW_POLITICAL_STATE_OPERATION,
                    PoliticalStateCollection=this.PoliticalInformationStateCollection });
            }
            HideBusyIndicator();
        }

        private void ConvertToPoliticalPartyModelCollection()
        {
            foreach (PoliticalParty item in PoliticalPartyCollection)
            {
                PoliticalPartyModel ppm = new PoliticalPartyModel();
                ppm.IdPoliticalParty = item.IdPoliticalParty;
                ppm.Color = item.Color;
                ppm.ShortName = item.ShortName;
                ppm.IsChecked = true;
                
                PoliticalPartyModelCollection.Add(ppm);
            }

            countcheckTimes = PoliticalPartyCollection.Count;
        }

        private void GeneratePoliticalPartyCollection(ObservableCollection<PoliticalInformationState> PoliticalInformationStateCollection)
        {
            foreach (PoliticalInformationState politicState in PoliticalInformationStateCollection)
            {
                AddToPoliticalPartyCollection(politicState.PoliticalParty);   
            }
        }

        private PoliticalPartyModel ConterToPoliticalPartyModel(PoliticalParty politicalParty)
        {
            PoliticalPartyModel ppm = new PoliticalPartyModel();
            ppm.IdPoliticalParty = politicalParty.IdPoliticalParty;
            ppm.Color = politicalParty.Color;
            ppm.ShortName = politicalParty.ShortName;

            return ppm;
        }

        private void AddToPoliticalPartyCollection(PoliticalParty politicalParty)
        {
            if (PoliticalPartyCollection == null)
            {
                PoliticalPartyCollection = new ObservableCollection<PoliticalParty>();
            }

            if (PoliticalPartyCollection.Count <= 0)
            {   
                
                PoliticalPartyCollection.Add(politicalParty );
            }

            else
            {
                bool isAlreadyInserted = false;
                foreach(PoliticalParty politicParty in PoliticalPartyCollection)
                {
                    if (politicParty.IdPoliticalParty == politicalParty.IdPoliticalParty)
                    {
                        isAlreadyInserted = true;
                        break;
                    }
                }

                if (!isAlreadyInserted)
                {
                    PoliticalPartyCollection.Add(politicalParty);
                }
            }
           
        }

        private void OnCheckAllPoliticalState()
        {
            CheckUnCheckAllPoliticalParty(IS_CHECKED);
            ObservableCollection<PoliticalPartyModel> auxColl = new ObservableCollection<PoliticalPartyModel>(PoliticalPartyModelCollection);
            //PoliticalPartyModelCollection.Clear();
            PoliticalPartyModelCollection = new ObservableCollection<PoliticalPartyModel>(auxColl);
            RaisePropertyChanged("PoliticalPartyModelCollection");

            Messenger.Default.Send<PoliticalStateMessage>(
                new PoliticalStateMessage()
                { IdOperation = DRAW_POLITICAL_STATE_OPERATION,
                    PoliticalStateCollection = PoliticalInformationStateCollection }); 
        }

        private void OnUncheckAllPoliticalState()
        {
            CheckUnCheckAllPoliticalParty(IS_UNCHECKED);
            ObservableCollection<PoliticalPartyModel> auxColl = new ObservableCollection<PoliticalPartyModel>(PoliticalPartyModelCollection);
            //PoliticalPartyModelCollection.Clear();
            PoliticalPartyModelCollection = new ObservableCollection<PoliticalPartyModel>(auxColl);
           //countcheckTimes = 0;

            RaisePropertyChanged("PoliticalPartyModelCollection");
            Messenger.Default.Send<PoliticalStateMessage>(new PoliticalStateMessage() 
            { IdOperation = DRAW_POLITICAL_STATE_OPERATION,
                PoliticalPartyModel = this.PoliticalPartyModelCollection });
        }

        private void OnCheckBoxPoliticalState(string politicPartyName) 
        {
            countcheckTimes++;
            CheckUnCheckPoliticalParty(politicPartyName, IS_CHECKED);
            Messenger.Default.Send<PoliticalStateMessage>(
                new PoliticalStateMessage()
                {
                IdOperation = DRAW_POLITICAL_STATE_OPERATION,
                PoliticalStateCollection=this.ChangePoliticalInformationCollection });
            
        }

        private void OnUnCheckBoxPoliticalState(string politicPartyName)
        {
            countcheckTimes--;

            if (countcheckTimes == 0 && IsAllPoliticalPartyChecked)
            {
                IsAllPoliticalPartyChecked = false;
            }
            CheckUnCheckPoliticalParty(politicPartyName,IS_UNCHECKED);
            Messenger.Default.Send<PoliticalStateMessage>
                (new PoliticalStateMessage() {
                    IdOperation = DRAW_POLITICAL_STATE_OPERATION,
                    PoliticalStateCollection = this.ChangePoliticalInformationCollection
                });
        }

        private void CheckUnCheckAllPoliticalParty(bool isChecked)
        {
            if (PoliticalInformationStateCollection != null)
            {
            }

            foreach (PoliticalPartyModel politicParty in PoliticalPartyModelCollection)
            {
               politicParty.IsChecked = isChecked;
            }
        }

        private void CheckUnCheckPoliticalParty(string politicPartyName,bool isChecked)
        {

            ChangePoliticalInformationCollection.Clear();
            foreach (PoliticalPartyModel politicParty in PoliticalPartyModelCollection)
            {
                if (politicParty.ShortName.ToLower().Trim().Equals(politicPartyName.ToLower().Trim()))
                {
                    politicParty.IsChecked = isChecked;
                }
                AddPoliticStateToMap(politicParty, politicParty.IsChecked);
            }            
        }

        public void AddPoliticStateToMap(PoliticalPartyModel politicParty,bool isChecked)
        {
            
            foreach (PoliticalInformationState politicState in PoliticalInformationStateCollection)
            {
                if (politicState.PoliticalParty.IdPoliticalParty == politicParty.IdPoliticalParty
                    && isChecked)
                {
                    ChangePoliticalInformationCollection.Add(politicState);
                }
            }
        }

        public void RemovePoliticStateToMap(PoliticalPartyModel politicParty)
        {
            ChangePoliticalInformationCollection.Clear();

            foreach (PoliticalInformationState politicState in PoliticalInformationStateCollection)
            {
                if (politicState.PoliticalParty.IdPoliticalParty == politicParty.IdPoliticalParty)
                {
                    ChangePoliticalInformationCollection.Add(politicState);
                }
            }

        }


        #endregion

        

        private void CreateMsftPivotStateList(PivotViewer pivot)
        {
            MsftProgramPivot.Clear();
            foreach (string pivotId in pivot.InScopeItemIds)
            {
                PivotItem pivotItem = pivot.GetItem(pivotId);
                PivotModel msftStateProgram = new PivotModel();
                ConvertToPivotObj(pivotItem, msftStateProgram);
                MsftProgramPivot.Add(msftStateProgram);
                GroupDictionaryPivots(msftStateProgram);
            }

            Messenger.Default.Send<MsftProgramMessage>
                (
                    new MsftProgramMessage()
                    {   IdOperation = DRAW_PIVOT_MSFT,
                        MsftPivotCollection = this.MsftProgramPivot
                    }
                );

            ShowPivotMsft = false;
        }

        private void CreatePivotStateList(PivotViewer pivot)
        {
            StatePivot.Clear();
            foreach (string pivotId in pivot.InScopeItemIds)
            {
                PivotItem pivotItem = pivot.GetItem(pivotId);
                PivotModel stateProgram = new PivotModel();
                ConvertToPivotObj(pivotItem, stateProgram);
                GroupDictionaryPivots(stateProgram);
                StatePivot.Add(stateProgram);
            }

            Messenger.Default.Send<StateProgramMessage>
                (
                    new StateProgramMessage()
                    {
                        IdOperation = DRAW_PIVOT_STATE,
                        StatePivotCollection = this.StatePivot
                    }
                );

            ShowPivotState = false;
        }

        private void CreatePivotCompetitionList(PivotViewer pivot)
        {
            CompetitionPivot.Clear();
            foreach (string pivotId in pivot.InScopeItemIds)
            {
                PivotItem pivotItem = pivot.GetItem(pivotId);
                PivotModel competitionProgram = new PivotModel();
                ConvertToPivotObj(pivotItem, competitionProgram);
                GroupDictionaryPivots(competitionProgram);
                CompetitionPivot.Add(competitionProgram);
            }

            Messenger.Default.Send<CompetitionMessage>
                (
                    new CompetitionMessage()
                    {
                        IdOperation = DRAW_PIVOT_COMPETITION,
                        CompetitionPivotCollection = this.CompetitionPivot
                    }
                );

            ShowPivotCompetition = false;
        }



        private void ConvertToPivotObj(PivotItem pivotItem, PivotModel pivotObj)
        {
            foreach (KeyValuePair<string, IList<string>> kvp in pivotItem.Facets)
            {
                switch (kvp.Key)
                {
                    case SOURCE:
                        pivotObj.Source = kvp.Value[0];
                        break;
                    case PROGRAM:
                        pivotObj.Program = kvp.Value[0];
                        break;
                    case OWNER:
                        pivotObj.Owner = kvp.Value[0];
                        break;
                    case TYPE:
                        pivotObj.Type = kvp.Value[0];
                        break;
                    case INVESTMENT:
                        pivotObj.Investment = Double.Parse(kvp.Value[0]);
                        break;
                    case ROI:
                        pivotObj.ROI = Double.Parse(kvp.Value[0]);
                        break;
                    case PROGRESS:
                        pivotObj.Progress = Int32.Parse(kvp.Value[0]);
                        break;
                    case NUMBER:
                        pivotObj.Number = Int32.Parse(kvp.Value[0]);
                        break;
                    case STATE:
                        pivotObj.State = kvp.Value[0];
                        break;
                }
            }
        }

        private void GroupDictionaryPivots(PivotModel pivot)
        {
            if (!DictionaryPivotModels.ContainsKey(pivot.State))
            {
                ObservableCollection<PivotModel> pivotModelColl 
                    = new ObservableCollection<PivotModel>();
                pivotModelColl.Add(pivot);
                DictionaryPivotModels.Add(pivot.State,pivotModelColl);
            }
            else
            {
                ((ObservableCollection<PivotModel>)
                    DictionaryPivotModels[pivot.State]).Add(pivot);
            }
        }

        private void ClearMapLayers()
        {
            Messenger.Default.Send<string>(CLEAR_MAP_LAYERS);
        }

        private void ClearPivotLayers()
        {
            Messenger.Default.Send<string>(CLEAR_PIVOT_LAYERS);
        }
        
        private void ClearPanels()
        {
            ShowPoliticPartyPanel = false;
            ShowInfoPoliticalState = false;
            ShowElevemosPanel = false;
            ShowDatePanel = false;
            ShowMsftProgramInfo =false;
            ShowMsftInvestmentPanel = false;
            ShowStateProgramInfo = false;
            ShowStateProgramInvestmentPanel = false;
            ShowDetailInvestmentPanel = false;
            ShowPivotMsft = false;
            ShowPivotState = false;
            ShowPivotCompetition = false;
            ShowCompetitionInfo = false;
            ShowCompetitionPanel = false;
            ShowElevemosPanelInfo = false;
        }

        private void HideBusyIndicator()
        {
            ShowLoading = false;
            IsBusy = false;
        }

        private void DisplayBusyIndicator()
        {
            ShowLoading = true;
            IsBusy = true;
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
