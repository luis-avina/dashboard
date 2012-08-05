using GalaSoft.MvvmLight;

namespace MsftDashboard
{
    public class AdministrationViewModel:ViewModelBase
    {
        protected IPageConductor PageConductor { get; set; }

        public AdministrationViewModel(IPageConductor pageConductor)
        {
            PageConductor = pageConductor;
        }

    }
}
