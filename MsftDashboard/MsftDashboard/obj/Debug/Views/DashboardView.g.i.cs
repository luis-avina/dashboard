﻿#pragma checksum "C:\Users\Administrator\Documents\MsftDashboard\MsftDashboard\Views\DashboardView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1D2A79E9BCA93263C244DC0567425710"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Pivot;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MsftDashboard {
    
    
    public partial class DashboardView : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Page DashBoardPage;
        
        internal System.Windows.Media.Animation.Storyboard WidgetsStory;
        
        internal System.Windows.Media.Animation.Storyboard WidgetMouseLeave;
        
        internal System.Windows.Media.Animation.Storyboard PivotAnimationAppear;
        
        internal System.Windows.Media.Animation.Storyboard PivotAnimationGone;
        
        internal System.Windows.Media.Animation.Storyboard ShowPivot;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard1;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.VisualStateGroup CentrePanelStates;
        
        internal System.Windows.VisualState Open;
        
        internal System.Windows.VisualState Closed;
        
        internal Microsoft.Maps.MapControl.Map MapDashboard;
        
        internal System.Windows.Controls.Button btnCenterMap;
        
        internal System.Windows.Controls.Button btnZoomIn;
        
        internal System.Windows.Controls.Button btnZoomOut;
        
        internal System.Windows.Controls.Grid Widgets;
        
        internal System.Windows.Controls.Grid WidgetsBar;
        
        internal System.Windows.Controls.Button btnPolitic;
        
        internal System.Windows.Controls.Button btnElevemos;
        
        internal System.Windows.Controls.Button btnInversionEstado;
        
        internal System.Windows.Controls.Button btnDate;
        
        internal System.Windows.Controls.Button btnInversionMsft;
        
        internal System.Windows.Controls.Button btnPivotCompetencia;
        
        internal System.Windows.Controls.Button btnPivotEstado;
        
        internal System.Windows.Controls.Button btnCompetencia;
        
        internal System.Windows.VisualStateGroup CommonStates1;
        
        internal System.Windows.VisualState Normal1;
        
        internal System.Windows.VisualState MouseOver1;
        
        internal System.Windows.VisualState Pressed1;
        
        internal System.Windows.VisualState Disabled1;
        
        internal System.Windows.Shapes.Ellipse ellipse1;
        
        internal System.Windows.Shapes.Path path1;
        
        internal System.Windows.VisualStateGroup CommonStates;
        
        internal System.Windows.VisualState Normal;
        
        internal System.Windows.VisualState MouseOver;
        
        internal System.Windows.VisualState Pressed;
        
        internal System.Windows.VisualState Disabled;
        
        internal System.Windows.Shapes.Ellipse ellipse;
        
        internal System.Windows.Shapes.Path path;
        
        internal System.Windows.VisualStateGroup CommonStates2;
        
        internal System.Windows.VisualState Normal2;
        
        internal System.Windows.VisualState MouseOver2;
        
        internal System.Windows.VisualState Pressed2;
        
        internal System.Windows.VisualState Disabled2;
        
        internal System.Windows.Shapes.Ellipse ellipse2;
        
        internal System.Windows.VisualStateGroup CommonStates3;
        
        internal System.Windows.VisualState Normal3;
        
        internal System.Windows.VisualState MouseOver3;
        
        internal System.Windows.VisualState Pressed3;
        
        internal System.Windows.VisualState Disabled3;
        
        internal System.Windows.Shapes.Ellipse ellipse3;
        
        internal System.Windows.Shapes.Path path2;
        
        internal System.Windows.VisualStateGroup CommonStates4;
        
        internal System.Windows.VisualState Normal4;
        
        internal System.Windows.VisualState MouseOver4;
        
        internal System.Windows.VisualState Pressed4;
        
        internal System.Windows.VisualState Disabled4;
        
        internal System.Windows.Shapes.Ellipse ellipse4;
        
        internal System.Windows.Shapes.Path path3;
        
        internal System.Windows.VisualStateGroup CommonStates7;
        
        internal System.Windows.VisualState Normal7;
        
        internal System.Windows.VisualState MouseOver7;
        
        internal System.Windows.VisualState Pressed7;
        
        internal System.Windows.VisualState Disabled7;
        
        internal System.Windows.Shapes.Ellipse ellipse7;
        
        internal System.Windows.Controls.Canvas DateUncheck_Copy;
        
        internal System.Windows.VisualStateGroup CommonStates8;
        
        internal System.Windows.VisualState Normal8;
        
        internal System.Windows.VisualState MouseOver8;
        
        internal System.Windows.VisualState Pressed8;
        
        internal System.Windows.VisualState Disabled8;
        
        internal System.Windows.Controls.RadioButton RadDate;
        
        internal System.Windows.Controls.RadioButton RadPolitic;
        
        internal System.Windows.Controls.RadioButton RadElevemos;
        
        internal System.Windows.Controls.RadioButton RadInvMsft;
        
        internal System.Windows.Controls.RadioButton RadInvState;
        
        internal System.Windows.Controls.RadioButton RadCompetition;
        
        internal System.Windows.Controls.RadioButton RadPivotMsft;
        
        internal System.Windows.Controls.RadioButton RadPivotState;
        
        internal System.Windows.Controls.RadioButton RadPivotCompetition;
        
        internal System.Windows.Controls.Grid MapModesBar;
        
        internal System.Windows.Controls.RadioButton RadRoad;
        
        internal System.Windows.Controls.RadioButton RadAerial;
        
        internal System.Windows.Controls.RadioButton RadLabels;
        
        internal System.Windows.Controls.Grid GridPivotMsft;
        
        internal System.Windows.Pivot.PivotViewer PivotViewerMsft;
        
        internal System.Windows.Controls.Button btnSearch;
        
        internal System.Windows.Controls.Button btnOk;
        
        internal System.Windows.Controls.Button btnCancel;
        
        internal System.Windows.Controls.Grid GridPivotState;
        
        internal System.Windows.Pivot.PivotViewer PivotViewerState;
        
        internal System.Windows.Controls.Button btnSearchState;
        
        internal System.Windows.Controls.Button btnOk1;
        
        internal System.Windows.Controls.Button btnCancel1;
        
        internal System.Windows.Controls.Grid GridPivotCompetition;
        
        internal System.Windows.Pivot.PivotViewer PivotViewerCompetition;
        
        internal System.Windows.Controls.Button btnSearchDateCompetition;
        
        internal System.Windows.Controls.Button btnOk2;
        
        internal System.Windows.Controls.Button btnCancel2;
        
        internal System.Windows.Controls.StackPanel stackDatePanel;
        
        internal System.Windows.Controls.ComboBox InitialMonth;
        
        internal System.Windows.Controls.ComboBox InitialYear;
        
        internal System.Windows.Controls.ComboBox FinalMonth;
        
        internal System.Windows.Controls.ComboBox FinalYear;
        
        internal System.Windows.Controls.StackPanel stackInversionMSFT;
        
        internal System.Windows.Controls.ScrollViewer FlyoutRightPanel2;
        
        internal System.Windows.Controls.StackPanel stackInversionEstado;
        
        internal System.Windows.Controls.ScrollViewer FlyoutRightPanel3;
        
        internal System.Windows.Controls.StackPanel stackPoliticPanel;
        
        internal System.Windows.Controls.CheckBox chkPartidos;
        
        internal System.Windows.Controls.StackPanel stkPoliticalParties;
        
        internal System.Windows.Controls.ItemsControl lstPoliticalPARTY;
        
        internal System.Windows.Controls.StackPanel stackElevemosPanel;
        
        internal System.Windows.Controls.StackPanel stkElevemosCheckBoxes;
        
        internal System.Windows.Controls.ItemsControl lstMarco;
        
        internal System.Windows.Controls.CheckBox chkElevemosMexico;
        
        internal System.Windows.Controls.StackPanel stkElevemosCheckBoxes_Copy;
        
        internal System.Windows.Controls.ItemsControl lstEspecifico;
        
        internal System.Windows.Controls.CheckBox chkElevemosMexico1;
        
        internal System.Windows.Controls.StackPanel stackCompetitionPanel;
        
        internal System.Windows.Controls.CheckBox chkTypesAll;
        
        internal System.Windows.Controls.StackPanel stkTypesCompetition;
        
        internal System.Windows.Controls.ItemsControl lstTypesCompetition;
        
        internal System.Windows.Controls.StackPanel stkDetailsInvestment;
        
        internal System.Windows.Controls.TextBlock lblInversion;
        
        internal System.Windows.Controls.ScrollViewer FlyoutRightPanel1;
        
        internal System.Windows.Controls.TextBlock lblTotals;
        
        internal System.Windows.Controls.TextBlock lblTotals_Copy;
        
        internal System.Windows.Controls.Grid GridPolitic;
        
        internal System.Windows.Controls.Grid GritTittle;
        
        internal System.Windows.Shapes.Rectangle PoliticRectangle;
        
        internal System.Windows.Controls.TextBlock StateTitle;
        
        internal System.Windows.Controls.TextBlock DateFrom;
        
        internal System.Windows.Controls.TextBlock PoliticalPartyTitle;
        
        internal System.Windows.Controls.TextBlock DateTo;
        
        internal System.Windows.Controls.Grid GridElevemos;
        
        internal System.Windows.Controls.Grid GritTittleElevemos;
        
        internal System.Windows.Shapes.Rectangle TileElevemos;
        
        internal System.Windows.Controls.TextBlock StateTitleElevemos;
        
        internal System.Windows.Controls.TextBlock ApplicationNameTextBlock_Copy3;
        
        internal System.Windows.Controls.Grid GridInversionMicrosoft;
        
        internal System.Windows.Controls.Grid GritTittleInversionMicrosoft;
        
        internal System.Windows.Controls.TextBlock StateInversionMicrosoftTitle;
        
        internal System.Windows.Controls.TextBlock InversionTitle;
        
        internal System.Windows.Controls.Grid GridInversionEstado;
        
        internal System.Windows.Controls.Grid GritTittleInversionEstado1;
        
        internal System.Windows.Controls.TextBlock StateInversionMicrosoftTitle2;
        
        internal System.Windows.Controls.TextBlock InversionTitle2;
        
        internal System.Windows.Controls.Grid GridInversionCompetencia;
        
        internal System.Windows.Controls.Grid GritTittleInversionEstado3;
        
        internal System.Windows.Controls.TextBlock StateInversionMicrosoftTitle1;
        
        internal System.Windows.Controls.TextBlock InversionTitle1;
        
        internal System.Windows.Controls.Grid GridPivotInfoState;
        
        internal System.Windows.Controls.Grid GritTittleInversionEstado2;
        
        internal System.Windows.Controls.TextBlock StateInversionMicrosoftTitle3;
        
        internal System.Windows.Controls.TextBlock InversionTitle3;
        
        internal System.Windows.Controls.BusyIndicator Loading;
        
        internal System.Windows.Controls.Grid grid;
        
        internal System.Windows.Controls.Grid CentrePanel;
        
        internal System.Windows.Controls.Grid grid1;
        
        internal System.Windows.Controls.RadioButton Rad1;
        
        internal System.Windows.Controls.RadioButton Rad2;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MsftDashboard;component/Views/DashboardView.xaml", System.UriKind.Relative));
            this.DashBoardPage = ((System.Windows.Controls.Page)(this.FindName("DashBoardPage")));
            this.WidgetsStory = ((System.Windows.Media.Animation.Storyboard)(this.FindName("WidgetsStory")));
            this.WidgetMouseLeave = ((System.Windows.Media.Animation.Storyboard)(this.FindName("WidgetMouseLeave")));
            this.PivotAnimationAppear = ((System.Windows.Media.Animation.Storyboard)(this.FindName("PivotAnimationAppear")));
            this.PivotAnimationGone = ((System.Windows.Media.Animation.Storyboard)(this.FindName("PivotAnimationGone")));
            this.ShowPivot = ((System.Windows.Media.Animation.Storyboard)(this.FindName("ShowPivot")));
            this.Storyboard1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard1")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CentrePanelStates = ((System.Windows.VisualStateGroup)(this.FindName("CentrePanelStates")));
            this.Open = ((System.Windows.VisualState)(this.FindName("Open")));
            this.Closed = ((System.Windows.VisualState)(this.FindName("Closed")));
            this.MapDashboard = ((Microsoft.Maps.MapControl.Map)(this.FindName("MapDashboard")));
            this.btnCenterMap = ((System.Windows.Controls.Button)(this.FindName("btnCenterMap")));
            this.btnZoomIn = ((System.Windows.Controls.Button)(this.FindName("btnZoomIn")));
            this.btnZoomOut = ((System.Windows.Controls.Button)(this.FindName("btnZoomOut")));
            this.Widgets = ((System.Windows.Controls.Grid)(this.FindName("Widgets")));
            this.WidgetsBar = ((System.Windows.Controls.Grid)(this.FindName("WidgetsBar")));
            this.btnPolitic = ((System.Windows.Controls.Button)(this.FindName("btnPolitic")));
            this.btnElevemos = ((System.Windows.Controls.Button)(this.FindName("btnElevemos")));
            this.btnInversionEstado = ((System.Windows.Controls.Button)(this.FindName("btnInversionEstado")));
            this.btnDate = ((System.Windows.Controls.Button)(this.FindName("btnDate")));
            this.btnInversionMsft = ((System.Windows.Controls.Button)(this.FindName("btnInversionMsft")));
            this.btnPivotCompetencia = ((System.Windows.Controls.Button)(this.FindName("btnPivotCompetencia")));
            this.btnPivotEstado = ((System.Windows.Controls.Button)(this.FindName("btnPivotEstado")));
            this.btnCompetencia = ((System.Windows.Controls.Button)(this.FindName("btnCompetencia")));
            this.CommonStates1 = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates1")));
            this.Normal1 = ((System.Windows.VisualState)(this.FindName("Normal1")));
            this.MouseOver1 = ((System.Windows.VisualState)(this.FindName("MouseOver1")));
            this.Pressed1 = ((System.Windows.VisualState)(this.FindName("Pressed1")));
            this.Disabled1 = ((System.Windows.VisualState)(this.FindName("Disabled1")));
            this.ellipse1 = ((System.Windows.Shapes.Ellipse)(this.FindName("ellipse1")));
            this.path1 = ((System.Windows.Shapes.Path)(this.FindName("path1")));
            this.CommonStates = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates")));
            this.Normal = ((System.Windows.VisualState)(this.FindName("Normal")));
            this.MouseOver = ((System.Windows.VisualState)(this.FindName("MouseOver")));
            this.Pressed = ((System.Windows.VisualState)(this.FindName("Pressed")));
            this.Disabled = ((System.Windows.VisualState)(this.FindName("Disabled")));
            this.ellipse = ((System.Windows.Shapes.Ellipse)(this.FindName("ellipse")));
            this.path = ((System.Windows.Shapes.Path)(this.FindName("path")));
            this.CommonStates2 = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates2")));
            this.Normal2 = ((System.Windows.VisualState)(this.FindName("Normal2")));
            this.MouseOver2 = ((System.Windows.VisualState)(this.FindName("MouseOver2")));
            this.Pressed2 = ((System.Windows.VisualState)(this.FindName("Pressed2")));
            this.Disabled2 = ((System.Windows.VisualState)(this.FindName("Disabled2")));
            this.ellipse2 = ((System.Windows.Shapes.Ellipse)(this.FindName("ellipse2")));
            this.CommonStates3 = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates3")));
            this.Normal3 = ((System.Windows.VisualState)(this.FindName("Normal3")));
            this.MouseOver3 = ((System.Windows.VisualState)(this.FindName("MouseOver3")));
            this.Pressed3 = ((System.Windows.VisualState)(this.FindName("Pressed3")));
            this.Disabled3 = ((System.Windows.VisualState)(this.FindName("Disabled3")));
            this.ellipse3 = ((System.Windows.Shapes.Ellipse)(this.FindName("ellipse3")));
            this.path2 = ((System.Windows.Shapes.Path)(this.FindName("path2")));
            this.CommonStates4 = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates4")));
            this.Normal4 = ((System.Windows.VisualState)(this.FindName("Normal4")));
            this.MouseOver4 = ((System.Windows.VisualState)(this.FindName("MouseOver4")));
            this.Pressed4 = ((System.Windows.VisualState)(this.FindName("Pressed4")));
            this.Disabled4 = ((System.Windows.VisualState)(this.FindName("Disabled4")));
            this.ellipse4 = ((System.Windows.Shapes.Ellipse)(this.FindName("ellipse4")));
            this.path3 = ((System.Windows.Shapes.Path)(this.FindName("path3")));
            this.CommonStates7 = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates7")));
            this.Normal7 = ((System.Windows.VisualState)(this.FindName("Normal7")));
            this.MouseOver7 = ((System.Windows.VisualState)(this.FindName("MouseOver7")));
            this.Pressed7 = ((System.Windows.VisualState)(this.FindName("Pressed7")));
            this.Disabled7 = ((System.Windows.VisualState)(this.FindName("Disabled7")));
            this.ellipse7 = ((System.Windows.Shapes.Ellipse)(this.FindName("ellipse7")));
            this.DateUncheck_Copy = ((System.Windows.Controls.Canvas)(this.FindName("DateUncheck_Copy")));
            this.CommonStates8 = ((System.Windows.VisualStateGroup)(this.FindName("CommonStates8")));
            this.Normal8 = ((System.Windows.VisualState)(this.FindName("Normal8")));
            this.MouseOver8 = ((System.Windows.VisualState)(this.FindName("MouseOver8")));
            this.Pressed8 = ((System.Windows.VisualState)(this.FindName("Pressed8")));
            this.Disabled8 = ((System.Windows.VisualState)(this.FindName("Disabled8")));
            this.RadDate = ((System.Windows.Controls.RadioButton)(this.FindName("RadDate")));
            this.RadPolitic = ((System.Windows.Controls.RadioButton)(this.FindName("RadPolitic")));
            this.RadElevemos = ((System.Windows.Controls.RadioButton)(this.FindName("RadElevemos")));
            this.RadInvMsft = ((System.Windows.Controls.RadioButton)(this.FindName("RadInvMsft")));
            this.RadInvState = ((System.Windows.Controls.RadioButton)(this.FindName("RadInvState")));
            this.RadCompetition = ((System.Windows.Controls.RadioButton)(this.FindName("RadCompetition")));
            this.RadPivotMsft = ((System.Windows.Controls.RadioButton)(this.FindName("RadPivotMsft")));
            this.RadPivotState = ((System.Windows.Controls.RadioButton)(this.FindName("RadPivotState")));
            this.RadPivotCompetition = ((System.Windows.Controls.RadioButton)(this.FindName("RadPivotCompetition")));
            this.MapModesBar = ((System.Windows.Controls.Grid)(this.FindName("MapModesBar")));
            this.RadRoad = ((System.Windows.Controls.RadioButton)(this.FindName("RadRoad")));
            this.RadAerial = ((System.Windows.Controls.RadioButton)(this.FindName("RadAerial")));
            this.RadLabels = ((System.Windows.Controls.RadioButton)(this.FindName("RadLabels")));
            this.GridPivotMsft = ((System.Windows.Controls.Grid)(this.FindName("GridPivotMsft")));
            this.PivotViewerMsft = ((System.Windows.Pivot.PivotViewer)(this.FindName("PivotViewerMsft")));
            this.btnSearch = ((System.Windows.Controls.Button)(this.FindName("btnSearch")));
            this.btnOk = ((System.Windows.Controls.Button)(this.FindName("btnOk")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
            this.GridPivotState = ((System.Windows.Controls.Grid)(this.FindName("GridPivotState")));
            this.PivotViewerState = ((System.Windows.Pivot.PivotViewer)(this.FindName("PivotViewerState")));
            this.btnSearchState = ((System.Windows.Controls.Button)(this.FindName("btnSearchState")));
            this.btnOk1 = ((System.Windows.Controls.Button)(this.FindName("btnOk1")));
            this.btnCancel1 = ((System.Windows.Controls.Button)(this.FindName("btnCancel1")));
            this.GridPivotCompetition = ((System.Windows.Controls.Grid)(this.FindName("GridPivotCompetition")));
            this.PivotViewerCompetition = ((System.Windows.Pivot.PivotViewer)(this.FindName("PivotViewerCompetition")));
            this.btnSearchDateCompetition = ((System.Windows.Controls.Button)(this.FindName("btnSearchDateCompetition")));
            this.btnOk2 = ((System.Windows.Controls.Button)(this.FindName("btnOk2")));
            this.btnCancel2 = ((System.Windows.Controls.Button)(this.FindName("btnCancel2")));
            this.stackDatePanel = ((System.Windows.Controls.StackPanel)(this.FindName("stackDatePanel")));
            this.InitialMonth = ((System.Windows.Controls.ComboBox)(this.FindName("InitialMonth")));
            this.InitialYear = ((System.Windows.Controls.ComboBox)(this.FindName("InitialYear")));
            this.FinalMonth = ((System.Windows.Controls.ComboBox)(this.FindName("FinalMonth")));
            this.FinalYear = ((System.Windows.Controls.ComboBox)(this.FindName("FinalYear")));
            this.stackInversionMSFT = ((System.Windows.Controls.StackPanel)(this.FindName("stackInversionMSFT")));
            this.FlyoutRightPanel2 = ((System.Windows.Controls.ScrollViewer)(this.FindName("FlyoutRightPanel2")));
            this.stackInversionEstado = ((System.Windows.Controls.StackPanel)(this.FindName("stackInversionEstado")));
            this.FlyoutRightPanel3 = ((System.Windows.Controls.ScrollViewer)(this.FindName("FlyoutRightPanel3")));
            this.stackPoliticPanel = ((System.Windows.Controls.StackPanel)(this.FindName("stackPoliticPanel")));
            this.chkPartidos = ((System.Windows.Controls.CheckBox)(this.FindName("chkPartidos")));
            this.stkPoliticalParties = ((System.Windows.Controls.StackPanel)(this.FindName("stkPoliticalParties")));
            this.lstPoliticalPARTY = ((System.Windows.Controls.ItemsControl)(this.FindName("lstPoliticalPARTY")));
            this.stackElevemosPanel = ((System.Windows.Controls.StackPanel)(this.FindName("stackElevemosPanel")));
            this.stkElevemosCheckBoxes = ((System.Windows.Controls.StackPanel)(this.FindName("stkElevemosCheckBoxes")));
            this.lstMarco = ((System.Windows.Controls.ItemsControl)(this.FindName("lstMarco")));
            this.chkElevemosMexico = ((System.Windows.Controls.CheckBox)(this.FindName("chkElevemosMexico")));
            this.stkElevemosCheckBoxes_Copy = ((System.Windows.Controls.StackPanel)(this.FindName("stkElevemosCheckBoxes_Copy")));
            this.lstEspecifico = ((System.Windows.Controls.ItemsControl)(this.FindName("lstEspecifico")));
            this.chkElevemosMexico1 = ((System.Windows.Controls.CheckBox)(this.FindName("chkElevemosMexico1")));
            this.stackCompetitionPanel = ((System.Windows.Controls.StackPanel)(this.FindName("stackCompetitionPanel")));
            this.chkTypesAll = ((System.Windows.Controls.CheckBox)(this.FindName("chkTypesAll")));
            this.stkTypesCompetition = ((System.Windows.Controls.StackPanel)(this.FindName("stkTypesCompetition")));
            this.lstTypesCompetition = ((System.Windows.Controls.ItemsControl)(this.FindName("lstTypesCompetition")));
            this.stkDetailsInvestment = ((System.Windows.Controls.StackPanel)(this.FindName("stkDetailsInvestment")));
            this.lblInversion = ((System.Windows.Controls.TextBlock)(this.FindName("lblInversion")));
            this.FlyoutRightPanel1 = ((System.Windows.Controls.ScrollViewer)(this.FindName("FlyoutRightPanel1")));
            this.lblTotals = ((System.Windows.Controls.TextBlock)(this.FindName("lblTotals")));
            this.lblTotals_Copy = ((System.Windows.Controls.TextBlock)(this.FindName("lblTotals_Copy")));
            this.GridPolitic = ((System.Windows.Controls.Grid)(this.FindName("GridPolitic")));
            this.GritTittle = ((System.Windows.Controls.Grid)(this.FindName("GritTittle")));
            this.PoliticRectangle = ((System.Windows.Shapes.Rectangle)(this.FindName("PoliticRectangle")));
            this.StateTitle = ((System.Windows.Controls.TextBlock)(this.FindName("StateTitle")));
            this.DateFrom = ((System.Windows.Controls.TextBlock)(this.FindName("DateFrom")));
            this.PoliticalPartyTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PoliticalPartyTitle")));
            this.DateTo = ((System.Windows.Controls.TextBlock)(this.FindName("DateTo")));
            this.GridElevemos = ((System.Windows.Controls.Grid)(this.FindName("GridElevemos")));
            this.GritTittleElevemos = ((System.Windows.Controls.Grid)(this.FindName("GritTittleElevemos")));
            this.TileElevemos = ((System.Windows.Shapes.Rectangle)(this.FindName("TileElevemos")));
            this.StateTitleElevemos = ((System.Windows.Controls.TextBlock)(this.FindName("StateTitleElevemos")));
            this.ApplicationNameTextBlock_Copy3 = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationNameTextBlock_Copy3")));
            this.GridInversionMicrosoft = ((System.Windows.Controls.Grid)(this.FindName("GridInversionMicrosoft")));
            this.GritTittleInversionMicrosoft = ((System.Windows.Controls.Grid)(this.FindName("GritTittleInversionMicrosoft")));
            this.StateInversionMicrosoftTitle = ((System.Windows.Controls.TextBlock)(this.FindName("StateInversionMicrosoftTitle")));
            this.InversionTitle = ((System.Windows.Controls.TextBlock)(this.FindName("InversionTitle")));
            this.GridInversionEstado = ((System.Windows.Controls.Grid)(this.FindName("GridInversionEstado")));
            this.GritTittleInversionEstado1 = ((System.Windows.Controls.Grid)(this.FindName("GritTittleInversionEstado1")));
            this.StateInversionMicrosoftTitle2 = ((System.Windows.Controls.TextBlock)(this.FindName("StateInversionMicrosoftTitle2")));
            this.InversionTitle2 = ((System.Windows.Controls.TextBlock)(this.FindName("InversionTitle2")));
            this.GridInversionCompetencia = ((System.Windows.Controls.Grid)(this.FindName("GridInversionCompetencia")));
            this.GritTittleInversionEstado3 = ((System.Windows.Controls.Grid)(this.FindName("GritTittleInversionEstado3")));
            this.StateInversionMicrosoftTitle1 = ((System.Windows.Controls.TextBlock)(this.FindName("StateInversionMicrosoftTitle1")));
            this.InversionTitle1 = ((System.Windows.Controls.TextBlock)(this.FindName("InversionTitle1")));
            this.GridPivotInfoState = ((System.Windows.Controls.Grid)(this.FindName("GridPivotInfoState")));
            this.GritTittleInversionEstado2 = ((System.Windows.Controls.Grid)(this.FindName("GritTittleInversionEstado2")));
            this.StateInversionMicrosoftTitle3 = ((System.Windows.Controls.TextBlock)(this.FindName("StateInversionMicrosoftTitle3")));
            this.InversionTitle3 = ((System.Windows.Controls.TextBlock)(this.FindName("InversionTitle3")));
            this.Loading = ((System.Windows.Controls.BusyIndicator)(this.FindName("Loading")));
            this.grid = ((System.Windows.Controls.Grid)(this.FindName("grid")));
            this.CentrePanel = ((System.Windows.Controls.Grid)(this.FindName("CentrePanel")));
            this.grid1 = ((System.Windows.Controls.Grid)(this.FindName("grid1")));
            this.Rad1 = ((System.Windows.Controls.RadioButton)(this.FindName("Rad1")));
            this.Rad2 = ((System.Windows.Controls.RadioButton)(this.FindName("Rad2")));
        }
    }
}

