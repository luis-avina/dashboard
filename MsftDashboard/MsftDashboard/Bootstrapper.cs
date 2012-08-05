using Microsoft.Practices.Unity;
using MsftDashboard.Services;


namespace MsftDashboard
{
    public class Bootstrapper
    {
        public IUnityContainer Container { get; set; }

        public Bootstrapper()
        {
            Container = new UnityContainer();

            ConfigureContainer();
        }

        /// <summary>
        /// We register here every service / interface / viewmodel.
        /// </summary>
        private void ConfigureContainer()
        {
            //Services
            Container.RegisterInstance<IPageConductor>(new PageConductor());
            Container.RegisterInstance<IMsftService>(new MsftService());

            ////View Models
            Container.RegisterType<ContactsViewModel>();
            Container.RegisterType<EconomyViewModel>();
            Container.RegisterType<PoliticViewModel>();
            Container.RegisterType<AddEditContactViewModel>();
            Container.RegisterType<AddEditEconomyViewModel>();
            Container.RegisterType<AddEditCompetitionViewModel>();
            Container.RegisterType<PopulationViewModel>();
            Container.RegisterType<MexicoAgreementViewModel>();
            Container.RegisterType<AddEditMexicoAgreementViewModel>();
            Container.RegisterType<AddEditPoliticalPartyStateViewModel>();
            Container.RegisterType<PoliticalPartyViewModel>();
            Container.RegisterType<AddEditPoliticalPartyViewModel>();
            Container.RegisterType<SocialOrganizationsInfoViewModel>();
            Container.RegisterType<CapacitationCenterViewModel>();
            Container.RegisterType<AddEditCapacitationCenterViewModel>();
            Container.RegisterType<ProgramsMsftStateViewModel>();
            Container.RegisterType<OpenSourceViewModel>();
            Container.RegisterType<AddEditOpenSourceStateViewModel>();
            Container.RegisterType<OpenSourceProviderViewModel>();
            Container.RegisterType<OpenSourceCommunityViewModel>();
            Container.RegisterType<AddEditOpenSourceProviderViewModel>();
            Container.RegisterType<AddEditOpenSourceCommunityViewModel>();
            Container.RegisterType<EducationViewModel>();
            Container.RegisterType<AddEditEducationStateViewModel>();
            Container.RegisterType<EducationEnlaceViewModel>();
            Container.RegisterType<SchoolsViewModel>();
            Container.RegisterType<EducationSepProjectsViewModel>();
            Container.RegisterType<EducationUniversitiesViewModel>();
            Container.RegisterType<ProgramStateViewModel>();
            Container.RegisterType<DashboardViewModel>();
        }
    }
}
