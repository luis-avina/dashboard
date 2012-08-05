using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using MsftDashboard.Views;
using MsftDashboard.DrawMapHelpers;
using Microsoft.Maps.MapControl;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MsftDashboard.Services;
using Microsoft.Practices.Unity;
using MsftDashboard.Web.Models;
using MsftDashboard.Models;
using System.Reflection;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using System.Windows.Pivot;
using System.Windows.Browser;
using MsftDashboard.Helpers;
using System.Text;
using Microsoft.Maps.MapControl.Navigation;

namespace MsftDashboard
{
    public partial class DashboardView : Page
    {

        private List<SolidColorBrush> ListColorAreas = new List<SolidColorBrush>()
        {
            new SolidColorBrush(Color.FromArgb(255,255,134,0)),
            new SolidColorBrush(Color.FromArgb(255,255,22,0)),
            new SolidColorBrush(Color.FromArgb(255,37,111,16)),
            new SolidColorBrush(Color.FromArgb(255,247,255,0)),
            new SolidColorBrush(Color.FromArgb(255,0,162,255)),
            new SolidColorBrush(Color.FromArgb(255,131,50,187)),
            new SolidColorBrush(Color.FromArgb(255,10,25,84))
        };

        private const int SHOW_PIVOT_MSFT_INFO = 301;
        private const int SHOW_PIVOT_STATE_INFO = 302;
        private const int SHOW_PIVOT_COMPETITION_INFO = 303;

        private const string ROAD_MODE = "Road";
        private const string AERIAL_MODE = "Aerial";
        private const string LABELS_MODE = "AerialWithLabels";


        private const string QUERY_PIVOT_MSFT_LIST = "QueryPivotMsft";
        private const string QUERY_PIVOT_STATE_LIST = "QueryPivotState";
        private const string QUERY_PIVOT_COMPETITION_LIST = "QueryPivotCompetition";


        private const string SEARCH_PIVOT_MSFT = "PivotMsft";
        private const string SEARCH_PIVOT_STATE = "PivotState";
        private const string SEARCH_PIVOT_COMPETITION = "PivotCompetition";

        private const string SHOW_MSFT_PIVOT = "SHOW_MSFT_PIVOT";

        private const string CLEAR_MAP_LAYERS = "CLEAR MAPLAYERS";
        private const string CLEAR_PIVOT_LAYERS = "CLEAR PIVOT LAYERS";
        public const int VISIBLE_OPACITY = 1;
        public const int HIDE_OPACITY = 0;

        private const int QUERY_ELEVEMOS_MEXICO = 1;
        private const int DRAW_ELEVEMOS_MEXICO_MARCO = 2;
        private const int DRAW_ELEVEMOS_MEXICO_ESPECIFICO = 3;

        private const int DRAW_MICROSOFT_PROGRAM_OPERATION = 1;
        private const int DRAW_PIVOT_MSFT = 100;
        private const int DRAW_PIVOT_STATE = 200;

        private const int DRAW_COMPETITION_PROGRAM_OPERATION = 1;
        private const int DRAW_PIVOT_COMPETITION = 300;


        private const int DRAW_STATE_PROGRAM_OPERATION = 1;

        private const int UPDATE_MICROSOFT_PROGRAM = 4;
        private const int UPDATE_STATE_PROGRAM = 5;
        private const int UPDATE_COMPETITION_PROGRAM = 6;

        private const int DRAW_POLITICAL_STATE_OPERATION = 1;
        private const int CHECKED_POLITICAL_STATE_OPERATION = 2;
        private const int UNCHECKED_POLITICAL_STATE_OPERATION = 3;
        private const int UPDATE_STATE_POLITICAL_INFO = 4;

        private const int CHECK_ELEVEMOS_MARCO = 2;
        private const int UNCHECK_ELEVEMOS_MARCO = 3;

        private const int CHECK_ELEVEMOS_ESPECIFICO = 4;
        private const int UNCHECK_ELEVEMOS_ESPECIFICO = 5;

        private const int UPDATE_ELEVEMOS_INFO = 7;

        private string _politicalStateTitle;

        private MapLayer mapLayer = new MapLayer();
        private MapLayer mapEspecifico = new MapLayer();
        private MapLayer mapMarco = new MapLayer();
        private MapLayer mapPoliticState = new MapLayer();
        private MapLayer mapMsftProgram = new MapLayer();
        private MapLayer mapStateProgram = new MapLayer();
        private MapLayer mapCompetitionState = new MapLayer();

        private MapLayer mapPivotMsft = new MapLayer();
        private MapLayer mapPivotState = new MapLayer();
        private MapLayer mapPivotCompetition= new MapLayer();
        
        private const string CXML_NAME_MSFT = "MsftDashBoardSource.cxml";
        private const string CXML_NAME_STATE = "DataSourceState.cxml";
        private const string CXML_NAME_COMPETITION = "DataSourceCompetition.cxml";



        private string Query=string.Empty;

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

        public DashboardView()
        {
            InitializeComponent();
            //MapDashboard.MapForeground.TemplateApplied+=
            //     (s, ev) =>
            //    {
            //        MapDashboard.MapForeground.NavigationBar.TemplateApplied += (se, evn) =>
            //        {
            //            NavigationBar navControl = MapDashboard.MapForeground.NavigationBar;
            //            navControl.HorizontalPanel.Children.Clear();
            //            navControl.HorizontalPanel.Visibility = Visibility.Collapsed;

            //            navControl.Compass.Visibility = Visibility.Collapsed;
            //            navControl.MaxWidth = 25;
            //            navControl.Margin = new Thickness(0, -85, 0, 0);
            //        };
            //    };
            SelectDefaultMapMode();
            MapDashboard.NavigationVisibility = Visibility.Collapsed;
            MapDashboard.ModeChanged+=new EventHandler<MapEventArgs>(MapDashboard_ModeChanged);
            MapDashboard.Children.Add(mapLayer);
            MapDashboard.Children.Add(mapPoliticState);
            MapDashboard.Children.Add(mapEspecifico);
            MapDashboard.Children.Add(mapMarco);
            MapDashboard.Children.Add(mapMsftProgram);
            MapDashboard.Children.Add(mapStateProgram);
            MapDashboard.Children.Add(mapPivotMsft);
            MapDashboard.Children.Add(mapPivotState);
            MapDashboard.Children.Add(mapPivotCompetition);
            MapDashboard.Children.Add(mapCompetitionState);
            RegisterMessages();
            //LoadCollection(CXML_NAME, "");
        }

        private void SelectDefaultMapMode()
        {   

            if (App.MapMode.Equals("AerialWithLabels"))
            {
                RadLabels.IsChecked = true;
                RadLabels.Opacity = 1;
                MapDashboard.Mode = GetMapMode.AerialModeWithLabels();
            }
            else if (App.MapMode.Equals("Aerial"))
            {
                RadAerial.IsChecked = true;
                RadAerial.Opacity = 1;
                MapDashboard.Mode = GetMapMode.AerialMode();
            }
            else if (App.MapMode.Equals("Road"))
            {
                RadRoad.IsChecked = true;
                RadRoad.Opacity = 1;
                MapDashboard.Mode = GetMapMode.RoadMode();
            }
        }

        [ScriptableMember]
        private void LoadCollectionMsft(string cxmlName,string query)
        {
            string pageUrl = HtmlPage.Document.DocumentUri.AbsoluteUri;
            
            string rootUrl = pageUrl.Substring(0, pageUrl.LastIndexOf('/') + 1);
            string url = rootUrl.Substring(0, rootUrl.LastIndexOf('/') + 1);
            //Local 

            string collectionUrl = "http://localhost:1103/" + cxmlName+ "?" + query;
            //string collectionUrl = "http://msftdashboard.dyndns-work.com/" + cxmlName + "?" + query;

            PivotViewerMsft.CollectionLoadingCompleted += new EventHandler(PivotViewerMsft_CollectionLoadingCompleted);
            PivotViewerMsft.LoadCollection(collectionUrl, string.Empty);
            
            
        }

        [ScriptableMember]
        private void LoadCollectionState(string cxmlName, string query)
        {
            string pageUrl = HtmlPage.Document.DocumentUri.AbsoluteUri;

            string rootUrl = pageUrl.Substring(0, pageUrl.LastIndexOf('/') + 1);
            string url = rootUrl.Substring(0, rootUrl.LastIndexOf('/') + 1);
            //Local 

            string collectionUrl = "http://localhost:1103/" + cxmlName + "?" + query;
            //string collectionUrl = "http://msftdashboard.dyndns-work.com/" + cxmlName + "?" + query;

            PivotViewerState.CollectionLoadingCompleted += new EventHandler(PivotViewerState_CollectionLoadingCompleted);
            PivotViewerState.LoadCollection(collectionUrl, string.Empty);


        }

        void PivotViewerState_CollectionLoadingCompleted(object sender, EventArgs e)
        {
            btnSearchState.IsEnabled = true;
        }

        [ScriptableMember]
        private void LoadCollectionCompetition(string cxmlName, string query)
        {
            string pageUrl = HtmlPage.Document.DocumentUri.AbsoluteUri;

            string rootUrl = pageUrl.Substring(0, pageUrl.LastIndexOf('/') + 1);
            string url = rootUrl.Substring(0, rootUrl.LastIndexOf('/') + 1);
            //Local 

            string collectionUrl = "http://localhost:1103/" + cxmlName + "?" + query;
            //string collectionUrl = "http://msftdashboard.dyndns-work.com/" + cxmlName + "?" + query;

            PivotViewerCompetition.CollectionLoadingCompleted += new EventHandler(PivotViewerCompetition_CollectionLoadingCompleted);
            PivotViewerCompetition.LoadCollection(collectionUrl, string.Empty);


        }

        void PivotViewerCompetition_CollectionLoadingCompleted(object sender, EventArgs e)
        {
            btnSearchDateCompetition.IsEnabled = true;
            PivotViewerCompetition.UpdateLayout();
        }

        void PivotViewerMsft_CollectionLoadingCompleted(object sender, EventArgs e)
        {
            btnSearch.IsEnabled = true;
            PivotViewerState.UpdateLayout();
        }

        
        private void RegisterMessages()
        {
            Messenger.Default.Register<PoliticalStateMessage>(this,OnPoliticLayer);
            Messenger.Default.Register<string>(this, OnReceivedStringMessages);
            Messenger.Default.Register<Dictionary<string, string>>(this,OnReceivedPivotParameters);
            
            Messenger.Default.Register<MexicoAgreementMessages>(this,OnElevemosLayer);
            Messenger.Default.Register<MsftProgramMessage>(this,OnMicrosoftProgramLayer);
            Messenger.Default.Register<StateProgramMessage>(this,OnStateProgramLayer);
            Messenger.Default.Register<CompetitionMessage>(this, OnCompetitionLayer);
        }

        private void OnReceivedStringMessages(string msg)
        {
            if (msg.Equals(CLEAR_MAP_LAYERS))
            {
                ClearMapLayers();
            }
            else if (msg.Equals(CLEAR_PIVOT_LAYERS))
            {
                ClearMapPivotLayers();
            }
            else if (msg.Equals(QUERY_PIVOT_MSFT_LIST))
            {
                SendPivotMsftList();
            }
            else if (msg.Equals(QUERY_PIVOT_STATE_LIST))
            {
                SendPivotStateList();
            }
            else if (msg.Equals(QUERY_PIVOT_COMPETITION_LIST))
            {
                SendPivotCompetitionList();
            }
            else if (msg.Equals(ROAD_MODE))
            {
                ChangeMapMode(msg);
            }
            else if (msg.Equals(AERIAL_MODE))
            {
                ChangeMapMode(msg);
            }
            else if (msg.Equals(LABELS_MODE))
            {
                ChangeMapMode(msg);
            }
        }

        private void OnReceivedPivotParameters(Dictionary<string,string> msg)
        {
            if (msg != null)
            {
                if (msg.ContainsKey(SEARCH_PIVOT_MSFT))
                {
                    PivotViewerMsft.Visibility = Visibility.Visible;
                    btnSearch.IsEnabled = false;
                    string query = msg[SEARCH_PIVOT_MSFT];
                    LoadCollectionMsft(CXML_NAME_MSFT,query);
                }
                else if (msg.ContainsKey(SEARCH_PIVOT_STATE))
                {
                    PivotViewerState.Visibility = Visibility.Visible;
                    btnSearchState.IsEnabled = false;
                    string query = msg[SEARCH_PIVOT_STATE];
                    LoadCollectionState(CXML_NAME_STATE, query);
                }
                else if (msg.ContainsKey(SEARCH_PIVOT_COMPETITION))
                {
                    PivotViewerCompetition.Visibility = Visibility.Visible;
                    btnSearchDateCompetition.IsEnabled = false;
                    string query = msg[SEARCH_PIVOT_COMPETITION];
                    LoadCollectionCompetition(CXML_NAME_COMPETITION, query);
                }
            }
        }

        private void ClearMapLayers()
        {
            mapLayer.Children.Clear();
            mapMsftProgram.Children.Clear();
            mapStateProgram.Children.Clear();
            mapMarco.Children.Clear();
            mapEspecifico.Children.Clear();
            mapPoliticState.Children.Clear();
            
        }

        private void ClearMapPivotLayers()
        {
            mapPivotMsft.Children.Clear();
            mapPivotState.Children.Clear();
            mapPivotCompetition.Children.Clear();
        }

        private void OnPoliticLayer(PoliticalStateMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == DRAW_POLITICAL_STATE_OPERATION)
                {
                    _politicalStateTitle = msg.PoliticalStateTitle;
                    DrawPoliticLayer(msg.PoliticalStateCollection);
                }
            }
        }

        private void OnMicrosoftProgramLayer(MsftProgramMessage msg)
        {
            if (msg.IdOperation == DRAW_MICROSOFT_PROGRAM_OPERATION)
            {
                DrawMsftProgramLayer(msg.MsftProgramCollection);
            }

            else if (msg.IdOperation == DRAW_PIVOT_MSFT)
            {
                DrawMsftPivotLayer(msg.MsftPivotCollection);
            }

        }

        private void OnStateProgramLayer(StateProgramMessage msg)
        {
            if (msg.IdOperation == DRAW_STATE_PROGRAM_OPERATION)
            {
                DrawStateProgramLayer(msg.StateProgramCollection);
            }
            else if (msg.IdOperation == DRAW_PIVOT_STATE)
            {
                DrawStatePivotLayer(msg.StatePivotCollection);
            }
        }

        private void OnCompetitionLayer(CompetitionMessage msg)
        {
            if (msg.IdOperation == DRAW_COMPETITION_PROGRAM_OPERATION)
            {
                DrawCompetitionLayer(msg.CompetitionCollection);
            }
            else if (msg.IdOperation == DRAW_PIVOT_COMPETITION)
            {
                DrawCompetitionPivotLayer(msg.CompetitionPivotCollection);
            }
        }

        private void DrawPoliticLayer(ObservableCollection<PoliticalInformationState> politicStateCollection)
        {
            mapPoliticState.Children.Clear();

            if (politicStateCollection != null)
            {
                foreach (PoliticalInformationState politicStateItem in politicStateCollection)
                {
                    StateShape statePoliticalShape =
                        MapPolygonGenerator.GetStatePolygon(politicStateItem.State.Name);
                    statePoliticalShape.PoliticState = politicStateItem;
                    statePoliticalShape.Fill =
                        new SolidColorBrush(ColorReflector.GetThisColor(politicStateItem.PoliticalParty.Color));
                    statePoliticalShape.Fill.Opacity = 0.75;
                    statePoliticalShape.MouseLeftButtonDown += statePolitical_MouseLeftButtonDown;
                    AddToolTipToState(statePoliticalShape);
                    mapPoliticState.Children.Add(statePoliticalShape);
                }
            }
        }

        private void AddToolTipToState(StateShape stateShape)
        {
            var tooltipObject = new StackPanel();

            var title = new TextBlock();
            title.FontWeight = FontWeights.Bold;
            title.Text = stateShape.StateName;
            title.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            tooltipObject.Children.Add(title);
            var description = new TextBlock();
            description.Text = stateShape.StateName;
            ToolTipService.SetToolTip(stateShape, tooltipObject);
        }
       
        void statePolitical_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            StateShape st = sender as StateShape;

            Messenger.Default.Send<CallBackPoliticalStateMessage>
                (new CallBackPoliticalStateMessage()
                {
                    IdOperation = UPDATE_STATE_POLITICAL_INFO,
                    PoliticaStateInfo = st.PoliticState
                });
        }


        private void OnElevemosLayer(MexicoAgreementMessages msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == QUERY_ELEVEMOS_MEXICO)
                {
                    DrawElevemosMexico(msg.ElevemosMarcoCollection, mapMarco);
                    DrawElevemosMexico(msg.ElevemosEspecificoCollection, mapEspecifico);
                }
                else if (msg.IdOperation == DRAW_ELEVEMOS_MEXICO_MARCO)
                {
                    DrawElevemosMexico(msg.ElevemosMarcoCollection, mapMarco);
                }
                else if (msg.IdOperation == DRAW_ELEVEMOS_MEXICO_ESPECIFICO)
                {
                    DrawElevemosMexico(msg.ElevemosEspecificoCollection, mapEspecifico);
                }
            }
        }

        private void DrawElevemosMexico(ObservableCollection<MexicoAgreement> especificoCollection,MapLayer mapLayer)
        {
            mapLayer.Children.Clear();
            if (especificoCollection != null)
            {
                foreach (MexicoAgreement stateElevemos in especificoCollection)
                {
                    StateShape stateElevemosShape =
                          MapPolygonGenerator.GetStatePolygon(stateElevemos.State.Name);
                    stateElevemosShape.MexicoAgreementState = stateElevemos;
                    stateElevemosShape.Fill =
                            GetColorByRangeProgress(stateElevemos.Progress,stateElevemos.TypeAgreement.Name);
                    stateElevemosShape.MouseLeftButtonDown += new MouseButtonEventHandler(stateElevemosShape_MouseLeftButtonDown);
                    AddToolTipToState(stateElevemosShape);
                    mapLayer.Children.Add(stateElevemosShape);
                }
            }
        }

        private void DrawMsftProgramLayer(ObservableCollection<MicrosoftProgramState> msftProgram)
        {
            mapMsftProgram.Children.Clear();

            if (msftProgram != null)
            {
                foreach (MicrosoftProgramState msftProgramItem in msftProgram)
                {
                    StateShape stateMsftProgramShape =
                        MapPolygonGenerator.GetStatePolygon(msftProgramItem.State.Name);
                    stateMsftProgramShape.MsftProgram = msftProgramItem;
                    stateMsftProgramShape.Fill = ListColorAreas[msftProgramItem.IdSource - 1];
                    stateMsftProgramShape.Fill.Opacity = 0.75;
                    stateMsftProgramShape.MouseLeftButtonDown += new MouseButtonEventHandler(stateMsftProgramShape_MouseLeftButtonDown);
                    AddToolTipToState(stateMsftProgramShape);
                    mapMsftProgram.Children.Add(stateMsftProgramShape);
                }
            }
        }

        void stateMsftProgramShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StateShape st = sender as StateShape;
            Messenger.Default.Send<CallBackProgramsMessage>(
                new CallBackProgramsMessage()
                {
                    idOperation=UPDATE_MICROSOFT_PROGRAM,
                    MicrosoftProgramStateCallBack=st.MsftProgram
                }
            );
        }

        private void DrawStateProgramLayer(ObservableCollection<StateProgram> stateProgram)
        {
            mapStateProgram.Children.Clear();

            if (stateProgram != null)
            {
                foreach (StateProgram stateProgramItem in stateProgram)
                {
                    StateShape stateProgramShape =
                        MapPolygonGenerator.GetStatePolygon(stateProgramItem.State.Name);
                    stateProgramShape.StateProgram = stateProgramItem;
                    stateProgramShape.Fill = ListColorAreas[stateProgramItem.IdSource - 1];
                    stateProgramShape.Fill.Opacity = 0.75;
                    stateProgramShape.MouseLeftButtonDown += new MouseButtonEventHandler(stateProgramShape_MouseLeftButtonDown);
                    AddToolTipToState(stateProgramShape);
                    mapStateProgram.Children.Add(stateProgramShape);
                }
            }
        }

        void stateProgramShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            StateShape st = sender as StateShape;
            Messenger.Default.Send<CallBackProgramsMessage>
               (new CallBackProgramsMessage()
               {
                   idOperation = UPDATE_STATE_PROGRAM,
                   StateProgramCallBack = st.StateProgram
               });
        }


        private void DrawCompetitionLayer(ObservableCollection<Competition> competitionCollection)
        {
            mapCompetitionState.Children.Clear();

            if (competitionCollection != null)
            {
                foreach (Competition competitionItem in competitionCollection)
                {
                    StateShape stateCompetitionShape =
                        MapPolygonGenerator.GetStatePolygon(competitionItem.State.Name);
                    stateCompetitionShape.CompetitionState = competitionItem;
                    stateCompetitionShape.Fill = ListColorAreas[competitionItem.IdType - 1];
                    stateCompetitionShape.Fill.Opacity = 0.75;
                    stateCompetitionShape.MouseLeftButtonDown += new MouseButtonEventHandler(stateCompetitionShape_MouseLeftButtonDown);
                    AddToolTipToState(stateCompetitionShape);
                    mapCompetitionState.Children.Add(stateCompetitionShape);
                }
            }
        }

        void stateCompetitionShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StateShape competitionShape = sender as StateShape;
            Messenger.Default.Send<CallBackProgramsMessage>(
                new CallBackProgramsMessage()
                {
                    idOperation = UPDATE_COMPETITION_PROGRAM,
                    CompetitonCallBack = competitionShape.CompetitionState
                }
                );
        }


        private void stateElevemosShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StateShape st = sender as StateShape;
            Messenger.Default.Send<CallBackMexicoAgreementMessages>
               (new CallBackMexicoAgreementMessages()
               {
                   IdOperation = UPDATE_ELEVEMOS_INFO,
                   MexicoAgreement = st.MexicoAgreementState
               });
        }

        private void DrawMarcoLayer(ObservableCollection<MexicoAgreement> marcoCollection)
        {
            //ObservableCollection<StateShapeElevemosMexico> stateShapeList = MapPolygonGenerator.GetStateElevemosMap();

            //foreach (StateShapeElevemosMexico st in stateShapeList)
            //{
            //    foreach (MexicoAgreement mx in marcoCollection)
            //    {
            //        if(st.StateName.ToLower().Trim().StartsWith(mx.State.Name.ToLower().Trim()))
            //        {
            //            st.MexicoAgreementState = mx;
            //            st.Fill = GetColorByRangeProgress(mx.Progress);
            //            st.Range = GetRangeProgress(mx.Progress);
            //            st.Opacity = 1;
            //            st.MouseLeftButtonDown += new MouseButtonEventHandler(st_MouseLeftButtonDown);
            //            break;
            //        }
            //    }
            //}
            //AddMarcoLayer(stateShapeList);
        }

        private int GetRangeProgress(int p)
        {
            if (p >= 0 && p < 25)
            {
                return 1;
            }
            else if (p >= 25 && p < 50)
            {
                return 2;
            }

            else if (p >= 50 && p < 75)
            {
                return 3;
            }

            else if (p >= 75 && p <= 100)
            {
                return 4;
            }
            return 0;
        }

        private Brush GetColorByRangeProgress(int p,string typeAgreement)
        {
            if (p>=0 && p < 25)
            {
                if(typeAgreement.ToLower().StartsWith("marco"))
                {
                    return new SolidColorBrush(Color.FromArgb(255, 105, 177, 48));
                }
                else
                {
                    return new SolidColorBrush(Color.FromArgb(150, 105, 177, 48));
                }
            }
            else if(p>=25 && p<50)
            {
                if (typeAgreement.ToLower().StartsWith("marco"))
                {
                    return new SolidColorBrush(Color.FromArgb(255, 241, 251, 10));
                }
                else
                {
                    return new SolidColorBrush(Color.FromArgb(100, 241, 251, 10));
                }
                
            }

            else if (p>=50 && p < 75)
            {

                if (typeAgreement.ToLower().StartsWith("marco"))
                {
                    return new SolidColorBrush(Color.FromArgb(255, 251, 10, 10));
                }
                else
                {
                    return new SolidColorBrush(Color.FromArgb(100, 251, 10, 10));
                }
                
            }

            else if (p>=75 && p <= 100)
            {

                if (typeAgreement.ToLower().StartsWith("marco"))
                {
                    return new SolidColorBrush(Color.FromArgb(255, 0, 197, 255));
                }
                else
                {
                    return new SolidColorBrush(Color.FromArgb(100, 0, 197, 255));
                }
               
            }
            return new SolidColorBrush();

        }

        void st_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Widgets_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard widgetMouseEnter = (Storyboard)FindName("WidgetsStory");
            widgetMouseEnter.Begin();
            VisibleRadioButtons();
        }

        private void Widgets_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard widgetMouseLeave = (Storyboard)FindName("WidgetMouseLeave");
            widgetMouseLeave.Begin();
            HideRadioButtons();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            var dt = this.DataContext as DashboardViewModel;
            if (dt != null)
            {
                dt.Cleanup();
                dt = null;
                base.OnNavigatingFrom(e);
            }
        }

        private void btnPivot_Click(object sender, RoutedEventArgs e)
        {
            PivotAnimationAppear.Completed += new EventHandler(PivotAnimationAppear_Completed);
            PivotAnimationAppear.Begin();
            
        }

        void PivotAnimationAppear_Completed(object sender, EventArgs e)
        {
            MapDashboard.Visibility = Visibility.Collapsed;
            Widgets.Visibility = Visibility.Collapsed;
            //LoadCollection(CXML_NAME_M,Query);
        }

        private ObservableCollection<MsftModel> msftCollection = new ObservableCollection<MsftModel>();

        public void DrawMsftPivotLayer(ObservableCollection<PivotModel> msftProgram)
        {
            mapPivotMsft.Children.Clear();

            if (msftProgram != null)
            {
                foreach (PivotModel msftProgramItem in msftProgram)
                {
                    StateShape statePivotMsftProgramShape =
                        MapPolygonGenerator.GetStatePolygon(msftProgramItem.State);
                    statePivotMsftProgramShape.PivotStateModel = msftProgramItem;
                    statePivotMsftProgramShape.Fill = ListColorAreas[0];
                    statePivotMsftProgramShape.Fill.Opacity = 0.75;
                    statePivotMsftProgramShape.MouseLeftButtonDown += new MouseButtonEventHandler(statePivotMsftProgramShape_MouseLeftButtonDown);
                    AddToolTipToState(statePivotMsftProgramShape);
                    mapPivotMsft.Children.Add(statePivotMsftProgramShape);
                }
            }
        }

        void statePivotMsftProgramShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StateShape msftProgram = sender as StateShape;
            if (msftProgram != null)
            {
                Messenger.Default.Send<CallBackProgramsMessage>(
                   new CallBackProgramsMessage()
                   {
                       idOperation = SHOW_PIVOT_MSFT_INFO,
                       MsftPivotCallBack = msftProgram.PivotStateModel
                   }
               );
            }
        }

        private void DrawStatePivotLayer(ObservableCollection<PivotModel> stateCollection)
        {
            mapPivotState.Children.Clear();

            if (stateCollection != null)
            {
                foreach (PivotModel stateItem in stateCollection)
                {
                    StateShape statePivotShape =
                        MapPolygonGenerator.GetStatePolygon(stateItem.State);
                    statePivotShape.PivotStateModel = stateItem;
                    statePivotShape.Fill = ListColorAreas[1];
                    statePivotShape.Fill.Opacity = 0.75;
                    statePivotShape.MouseLeftButtonDown += new MouseButtonEventHandler(statePivotShape_MouseLeftButtonDown);
                    AddToolTipToState(statePivotShape);
                    mapPivotState.Children.Add(statePivotShape);
                }
            }
        }

        void statePivotShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StateShape stateProgram = sender as StateShape;

            if (stateProgram != null)
            {
                Messenger.Default.Send<CallBackProgramsMessage>(
                    new CallBackProgramsMessage()
                    {
                        idOperation=SHOW_PIVOT_STATE_INFO,
                        StatePivotCallBack= stateProgram.PivotStateModel
                    }
                );
            }
        }

        private void DrawCompetitionPivotLayer(ObservableCollection<PivotModel> competitionCollection)
        {
            mapPivotCompetition.Children.Clear();

            if (competitionCollection != null)
            {
                foreach (PivotModel competitonItem in competitionCollection)
                {
                    StateShape competitionPivotShape =
                        MapPolygonGenerator.GetStatePolygon(competitonItem.State);
                    competitionPivotShape.PivotStateModel = competitonItem;
                    competitionPivotShape.Fill = ListColorAreas[3];
                    competitionPivotShape.Fill.Opacity = 0.75;
                    competitionPivotShape.MouseLeftButtonDown += new MouseButtonEventHandler(competitionPivotShape_MouseLeftButtonDown);
                    AddToolTipToState(competitionPivotShape);
                    mapPivotCompetition.Children.Add(competitionPivotShape);
                }
            }
        }

        void competitionPivotShape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StateShape competitionState = sender as StateShape;

            if (competitionState != null)
            {
                Messenger.Default.Send<CallBackProgramsMessage>(
                    new CallBackProgramsMessage()
                    {
                        idOperation = SHOW_PIVOT_COMPETITION_INFO,
                        CompetitionPivotCallBack = competitionState.PivotStateModel
                    }
                );
            }
        }


        private void ChangeMapMode(string MapMode)
        {
            App.MapMode = MapMode;
            if (MapMode.Equals(ROAD_MODE))
            {
                MapDashboard.Mode = new RoadMode();
            }
            else if (MapMode.Equals(AERIAL_MODE))
            {
                MapDashboard.Mode = new AerialMode();
            }
            else if (MapMode.Equals(LABELS_MODE))
            {
                MapDashboard.Mode = new AerialMode(true);
            }

        }

        private void MapDashboard_ModeChanged(object sender, MapEventArgs map)
        {
            string mode ="";
            if (MapDashboard.Mode is RoadMode)
            {
                mode = "Road";
            }
            else if (MapDashboard.Mode is AerialMode)
            {
                AerialMode mapMode = (AerialMode)MapDashboard.Mode;

                mode = "Aerial";

                if (mapMode.Labels)
                {
                    mode = "AerialWithLabels";
                }
            }

            App.MapMode = mode;
            
        }

        private void SendPivotMsftList()
        {
            PivotMessages pivotMsg = new PivotMessages();
            pivotMsg.Operation = QUERY_PIVOT_MSFT_LIST;
            pivotMsg.Pivot = PivotViewerMsft;

            Messenger.Default.Send<PivotMessages>(pivotMsg);
        }

        private void SendPivotStateList()
        {
            PivotMessages pivotMsg = new PivotMessages();
            pivotMsg.Operation = QUERY_PIVOT_STATE_LIST;
            pivotMsg.Pivot = PivotViewerState;

            Messenger.Default.Send<PivotMessages>(pivotMsg);
        }

        private void SendPivotCompetitionList()
        {
            PivotMessages pivotMsg = new PivotMessages();
            pivotMsg.Operation = QUERY_PIVOT_COMPETITION_LIST;
            pivotMsg.Pivot = PivotViewerCompetition;

            Messenger.Default.Send<PivotMessages>(pivotMsg);
        }

        private void VisibleRadioButtons()
        {
            foreach(UIElement uiItem in Widgets.Children)
            {
                if (uiItem is RadioButton)
                {
                    RadioButton rad = uiItem as RadioButton;
                    if (rad.IsChecked == false)
                    {
                        rad.Opacity = 1;
                    }
                }
            }

            foreach (UIElement uiItem in MapModesBar.Children)
            {
                if (uiItem is RadioButton)
                {
                    RadioButton rad = uiItem as RadioButton;
                    if (rad.IsChecked == false)
                    {
                        rad.Opacity = 1;
                    }
                }
            }
        }

        private void HideRadioButtons()
        {
            foreach (UIElement uiItem in Widgets.Children)
            {
                if (uiItem is RadioButton)
                {
                    RadioButton rad = uiItem as RadioButton;
                    if (rad.IsChecked == false)
                    {
                        rad.Opacity = 0.25;
                    }
                }
            }

            foreach (UIElement uiItem in MapModesBar.Children)
            {
                if (uiItem is RadioButton)
                {
                    RadioButton rad = uiItem as RadioButton;
                    if (rad.IsChecked == false)
                    {
                        rad.Opacity = 0.25;
                    }
                }
            }
        }
       
        private void btnCenterMap_Click(object sender, RoutedEventArgs e)
        {
            MapDashboard.Center = new Location(24.085598897064752, -92.65625000000001);
            MapDashboard.ZoomLevel = 5;
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            MapDashboard.ZoomLevel += 1;
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if(MapDashboard.ZoomLevel>0)
            MapDashboard.ZoomLevel -= 1;
        }

        private void RadRoad_Checked(object sender, RoutedEventArgs e)
        {
            ChangeMapMode(ROAD_MODE);
        }

        private void RadAerial_Checked(object sender, RoutedEventArgs e)
        {
            ChangeMapMode(AERIAL_MODE);
        }

        private void RadLabels_Checked(object sender, RoutedEventArgs e)
        {
            ChangeMapMode(LABELS_MODE);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard1.Begin();   
        }
    }
}