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
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using MsftDashboard.Messages;
using MsftDashboard.Models;

namespace MsftDashboard
{
    public class EducationUniversitiesViewModel:ViewModelBase
    {
        protected IMsftService EducationService { get; set; }

        public RelayCommand SaveCommand { get; set; }

        private int _penetration;
        public int Penetration
        {
            get
            {
                return _penetration;
            }
            set
            {
                _penetration = value;
                RaisePropertyChanged("Penetration");
            }
        }

        private State _stateRef;
        private ObservableCollection<MainUniversity> _mainUniverCollectionRef;

        private UniversitieInfo _currentUniversitieInfo=new UniversitieInfo();
        public UniversitieInfo CurrentUniversitieInfo
        {
            get
            {
                return _currentUniversitieInfo;
            }
            set 
            {
                _currentUniversitieInfo = value;
                RaisePropertyChanged("CurrentUniversitieInfo");
            }
        }

        private ObservableCollection<UniversitieInfo> _universitieInfoCollection= new ObservableCollection<UniversitieInfo>();
        public ObservableCollection<UniversitieInfo> UniversitieInfoCollection 
        {
            get
            {
                return _universitieInfoCollection;
            }
            set
            {
                _universitieInfoCollection = value;
                RaisePropertyChanged("UniversitieInfoCollection");
            }
        }

        private University _currentUniversitie= new University();
        public University CurrentUniversitie
        {
            get
            {
                return _currentUniversitie;
            }
            set
            {
                _currentUniversitie = value;
                RaisePropertyChanged("CurrentUniversitie");
            }
        }

        private ObservableCollection<University>_universitieCollection;
        public ObservableCollection<University> UniversitieCollection
        {
            get
            {
                return _universitieCollection;
            }
            set
            {
                _universitieCollection = value;
                RaisePropertyChanged("UniversitieCollection");
            }
        }

        public EducationUniversitiesViewModel(IMsftService msftService)
        {
            EducationService = msftService;
            UniversitieInfoCollection = new ObservableCollection<UniversitieInfo>();
            RegisterMessages();
            RegisterCommands();
            
            
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
                _mainUniverCollectionRef = msg.UniversitiesCollection;
                LoadData();
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        public void Save()
        {
            CurrentUniversitieInfo.IdUniversity = CurrentUniversitie.IdUniversity;
            CurrentUniversitieInfo.StateName = _stateRef.Name;
            CurrentUniversitieInfo.UnversityName = CurrentUniversitie.Name;
            CurrentUniversitieInfo.Penetration = Penetration;

            UniversitieInfoCollection.Add(CurrentUniversitieInfo);


            MainUniversity mainUniver = new MainUniversity();
            mainUniver.IdUniversity = CurrentUniversitie.IdUniversity;
            mainUniver.Penetration = Penetration;

            if (_mainUniverCollectionRef != null)
            {
                _mainUniverCollectionRef.Add(mainUniver);
            }

            Penetration = 0;
        }

        public void LoadData()
        {
            if(_stateRef!=null)
            {
                EducationService.GetUniversitiesByState(OnLoadUniversities, _stateRef.IdState);
            }   
            
        }

        private void OnLoadUniversities(ObservableCollection<University> universities)
        {
            if(universities!=null)
            {
                UniversitieCollection = universities;
            }
        }

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);

            base.Cleanup();
        }
    }
}
