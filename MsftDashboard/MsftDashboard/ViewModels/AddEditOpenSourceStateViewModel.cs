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
using MsftDashboard.Web.Models;
using GalaSoft.MvvmLight;
using MsftDashboard.Services;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using MsftDashboard.Messages;
using GalaSoft.MvvmLight.Command;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard
{
    public class AddEditOpenSourceStateViewModel:ViewModelBase
    {
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand SelectTypeProductCommand { get; set; }

        protected IMsftService OpenSourceService { get; set; }

        private const int ADD_OPERATION = 1;
        private const int EDIT_OPERATION = 2;

        private bool isNewRecord = false;

        private Penetration _currentPenetration;
        public Penetration CurrentPenetration
        {
            get
            {
                return _currentPenetration;
            }
            set
            {
                _currentPenetration = value;
                RaisePropertyChanged("CurrentPenetration");
            }
        }

        private ObservableCollection<Penetration> _penetrationCollection;
        public ObservableCollection<Penetration> PenetrationCollection
        {
            get
            {
                return _penetrationCollection;
            }
            set
            {
                _penetrationCollection = value;
                RaisePropertyChanged("PenetrationCollection");
            }
        }

        private TypeProduct _currentTypeProduct;
        public TypeProduct CurrentTypeProduct
        {
            get
            {
                return _currentTypeProduct;
            }
            set
            {
                _currentTypeProduct = value;
                RaisePropertyChanged("CurrentTypeProduct");
            }
        }

        private ObservableCollection<TypeProduct> _typeProductCollection;
        public ObservableCollection<TypeProduct> TypeProductCollection
        {
            get
            {
                return _typeProductCollection;
            }
            set
            {
                _typeProductCollection = value;
                RaisePropertyChanged("TypeProductCollection");
            }
        }

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

        private ObservableCollection<OpenSourceState> _openSourceCollectionRef;

        private OpenSourceState _currentOpenSourceState = new OpenSourceState();
        public OpenSourceState CurrentOpenSourceState
        {
            get
            {
                return _currentOpenSourceState;
            }
            set
            {
                _currentOpenSourceState = value;
                RaisePropertyChanged("CurrentOpenSourceState");
            }
        }

        public AddEditOpenSourceStateViewModel(IMsftService msftService)
        {
            OpenSourceService = msftService;
            RegisterMessages();
            RegisterCommands();
            LoadData();
        }

        private void RegisterCommands()
        {
            SaveCommand = new RelayCommand(Save);
            SelectTypeProductCommand = new RelayCommand(OnSelectTypeProduct);
            
        }

        private void OnSelectTypeProduct()
        {
            if(CurrentTypeProduct!=null)
            {
                OpenSourceService.GetProductByIdTypeProduct(OnLoadProducts,CurrentTypeProduct.IdTypeProduct);
            }
        }

        private void Save()
        {
            if (isNewRecord)
            {
                CurrentOpenSourceState.State = CurrentState;
                CurrentOpenSourceState.TypeProduct = CurrentTypeProduct;
                CurrentOpenSourceState.Product = CurrentProduct;
                CurrentOpenSourceState.Penetration = CurrentPenetration;
                CurrentOpenSourceState.Year = CurrentYear.Year1;
                OpenSourceService.SaveOpenSourceState(SaveOperation,CurrentOpenSourceState);
            }
            else
            {

                CurrentOpenSourceState.Penetration = CurrentPenetration;
                OpenSourceService.UpdateOpenSourceState(UpdateOperation,CurrentOpenSourceState);
            }
        }

        private void SaveOperation(SubmitOperation op)
        {
            if (!op.HasError)
            {
                if (_openSourceCollectionRef != null)
                {
                    _openSourceCollectionRef.Add(CurrentOpenSourceState);
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
            
        private void OnEditOpenSourceState(OpenSourceStateMessage msg)
        {
            if (msg != null)
            {
                if (msg.IdOperation == ADD_OPERATION)
                {
                    isNewRecord = true;
                    _openSourceCollectionRef = msg.OpenSourceCollection;
                }
                else if(msg.IdOperation==EDIT_OPERATION)
                {
                    isNewRecord = false;
                    CurrentOpenSourceState = msg.OpenSourceState;
                }
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<OpenSourceStateMessage>(this, OnEditOpenSourceState);
        }


        private void LoadData()
        {
            OpenSourceService.GetStates(OnLoadStates);
            OpenSourceService.GetYears(OnLoadYears);
            OpenSourceService.GetTypeProduct(OnLoadTypeProducts);
            OpenSourceService.GetPenetration(OnLoadPenetration);
            
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

        private void OnLoadTypeProducts(ObservableCollection<TypeProduct> typeProductsCollection)
        {
            if (typeProductsCollection != null)
            {
                TypeProductCollection = typeProductsCollection;
            }
        }

        private void OnLoadProducts(ObservableCollection<Product> productsCollection)
        {
            if (productsCollection != null)
            {
                ProductCollection = productsCollection;
            }
        }

        private void OnLoadPenetration(ObservableCollection<Penetration> penetrationCollection)
        {
            if (penetrationCollection != null)
            {
                PenetrationCollection = penetrationCollection;
            }
        }
        
    }
}
