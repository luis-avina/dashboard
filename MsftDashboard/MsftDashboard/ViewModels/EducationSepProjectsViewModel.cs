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
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using MsftDashboard.Services;
using MsftDashboard.Models;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Messages;

namespace MsftDashboard
{
    public class EducationSepProjectsViewModel:ViewModelBase
    {
        protected IMsftService EducationService { get; set; }

        public RelayCommand SaveCommand{get;set;}


        private State _stateRef;
        private ObservableCollection<SEPProjectState> _sepProjectStateCollectionRef;

        private int _progress;
        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                RaisePropertyChanged("Progress");
            }
        }

        private TypeSepProject _currentTypeSepProject;
        public TypeSepProject CurrentTypeSepProject
        {
            get
            {
                return _currentTypeSepProject;
            }
            set
            {
                _currentTypeSepProject = value;
                RaisePropertyChanged("CurrentTypeSepProject");
            }
        }

        private ObservableCollection<TypeSepProject> _typeSepProjectCollection;
        public ObservableCollection<TypeSepProject> TypeSepProjectCollection
        {
            get
            {
                return _typeSepProjectCollection;
            }
            set
            {
                _typeSepProjectCollection = value;
                RaisePropertyChanged("TypeSepProjectCollection");
            }
        }

        private SepProjectInfo _currentSepProjectinfo;
        public SepProjectInfo CurrentSepProjectinfo
        {
            get
            {
                return _currentSepProjectinfo;
            }
            set
            {
                _currentSepProjectinfo = value;
                RaisePropertyChanged("CurrentSepProjectinfo");
            }
        }

        private ObservableCollection<SepProjectInfo> _sepProjectCollection;
        public ObservableCollection<SepProjectInfo> SepProjectCollection 
        {
            get
            {
                return _sepProjectCollection;
            }
            set
            {
                _sepProjectCollection = value;
                RaisePropertyChanged("SepProjectCollection");
            }
        }

        public EducationSepProjectsViewModel(IMsftService msftService)
        {
            SepProjectCollection = new ObservableCollection<SepProjectInfo>();
            EducationService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<EducationInformationStateMessage>(this, OnEditSep);
        }

        private void OnEditSep(EducationInformationStateMessage msg)
        {
            if (msg != null)
            {
                _stateRef = msg.State;
                _sepProjectStateCollectionRef = msg.SEPProjectStates;
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            CurrentSepProjectinfo = new SepProjectInfo();
            CurrentSepProjectinfo.IdTypeSepProject = CurrentTypeSepProject.IdTypeSepProject;
            CurrentSepProjectinfo.StateName = _stateRef.Name;
            CurrentSepProjectinfo.Percentage = Progress;
            CurrentSepProjectinfo.SepProjectName = CurrentTypeSepProject.Name;
            SepProjectCollection.Add(CurrentSepProjectinfo);

            if (_sepProjectStateCollectionRef != null)
            {
                SEPProjectState sep = new SEPProjectState();
                sep.IdTypeSepProject = CurrentTypeSepProject.IdTypeSepProject;
                sep.Percentage = Progress;
                _sepProjectStateCollectionRef.Add(sep);
            }

            Progress = 0;
        }

        public void LoadData()
        {
            EducationService.GetTypeSepProject(OnLoadTypeSepProject);
        }

        private void OnLoadTypeSepProject(ObservableCollection<TypeSepProject> typeSepProject)
        {
            if (typeSepProject != null)
            {
                TypeSepProjectCollection = typeSepProject;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}
