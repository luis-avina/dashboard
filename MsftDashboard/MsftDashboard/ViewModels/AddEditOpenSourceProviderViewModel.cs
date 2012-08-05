using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using MsftDashboard.Models;
using MsftDashboard.Web.Models;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System;

namespace MsftDashboard
{
    public class AddEditOpenSourceProviderViewModel:ViewModelBase
    {
        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        public RelayCommand SaveCommand { get; set; }

        protected IMsftService OpenSourceService { get; set; }

        public bool isNewRecord = false;

        private OpenSourceStateProvider _currentOpenSourceProvider=new OpenSourceStateProvider();
        public OpenSourceStateProvider CurrentOpenSourceProvider
        {
            get
            {
                return _currentOpenSourceProvider;
            }
            set
            {
                _currentOpenSourceProvider = value;
                RaisePropertyChanged("CurrentOpenSourceProvider");
            }
        }

        private ObservableCollection<OpenSourceStateProvider> _openSourceProviderCollectionRef;

        private Product _currentProduct;
        public Product CurrentProduct
        {
            get
            {
                return _currentProduct;
            }
            set
            {
                _currentProduct = value;
                RaisePropertyChanged("CurrentProduct");
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

        private ObservableCollection<Months> _monthCollection;
        public ObservableCollection<Months> MonthCollection
        {
            get
            {
                return _monthCollection;
            }
            set
            {
                _monthCollection = value;
                RaisePropertyChanged("MonthCollection");
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

        private ObservableCollection<Product> _productCollection;
        public ObservableCollection<Product> ProductCollection
        {
            get
            {
                return _productCollection;
            }
            set
            {
                _productCollection = value;
                RaisePropertyChanged("ProductCollection");
            }
        }

        public AddEditOpenSourceProviderViewModel(IMsftService msftService)
        {
            OpenSourceService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();

        }

        private void LoadData()
        {
            OpenSourceService.GetStates(OnLoadStates);
            OpenSourceService.GetYears(OnLoadYears);
            OpenSourceService.GetProduct(OnLoadProducts);
            MonthCollection = App.MonthsCatalog;
                        
        }

        private void OnLoadStates(ObservableCollection<State> statesCollection)
        {
            if (statesCollection != null)
            {
                StateCollection = statesCollection;
            }
        }

        private void OnLoadYears(ObservableCollection<Year> yearsCollection)
        {
            if (yearsCollection != null)
            {
                YearsCollection = yearsCollection;
            }
        }

        private void OnLoadProducts(ObservableCollection<Product> productsCollection)
        {
            if (productsCollection != null)
            {
                ProductCollection = productsCollection;
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<OpenSourceStateProviderMessage>(this,OnEditOpenSourceProvider);
        }

        private void OnEditOpenSourceProvider(OpenSourceStateProviderMessage msg)
        {
            if (msg!=null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNewRecord = true;
                    _openSourceProviderCollectionRef = msg.OpenSourceCollection;
                }
                else if (msg.IdOperation == EDIT_OPERATION)
                {
                    isNewRecord = false;
                    CurrentOpenSourceProvider = msg.OpenSourceProvider;
                }
            }
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (isNewRecord)
            {
                CurrentOpenSourceProvider.DateFrom = new DateTime(CurrentYear.Year1,CurrentMonth.Id,1);
                CurrentOpenSourceProvider.IdProduct = CurrentProduct.IdProduct;
                CurrentOpenSourceProvider.State = CurrentState;
                OpenSourceService.SaveOpenSourceProvider(SaveOperation,CurrentOpenSourceProvider);
            }
            else
            {
                OpenSourceService.UpdateOpenSourceProvider(UpdateOperation,CurrentOpenSourceProvider);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_openSourceProviderCollectionRef != null)
                {
                    _openSourceProviderCollectionRef.Add(CurrentOpenSourceProvider);
                }
            }
            else
            {
                MessageBox.Show(op.Error.Message);
                op.MarkErrorAsHandled();
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

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }

        
    }
}
