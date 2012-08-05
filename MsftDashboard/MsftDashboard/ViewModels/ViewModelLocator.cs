using MsftDashboard;
using Microsoft.Practices.Unity;
using MsftDashboard.Services;

namespace MsftDashboard
{
    public class ViewModelLocator 
    {
        
        private static Bootstrapper _bootStrapper;
        

        public ViewModelLocator()
        {
            if (_bootStrapper == null)
                _bootStrapper = new Bootstrapper();

        }

        public ContactsViewModel Contact
        {
            get{ return _bootStrapper.Container.Resolve<ContactsViewModel>();}
        }

        public EconomyViewModel Economy
        {
            get { return _bootStrapper.Container.Resolve<EconomyViewModel>(); }
        }

        public PoliticViewModel Politic
        {
            get { return _bootStrapper.Container.Resolve<PoliticViewModel>(); }
        }

        public PoliticalPartyViewModel PoliticalParty
        {
            get { return _bootStrapper.Container.Resolve<PoliticalPartyViewModel>(); }
        }

        public AddEditPoliticalPartyStateViewModel PoliticStateChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditPoliticalPartyStateViewModel>(); }

        }

        public AddEditPoliticalPartyViewModel PoliticalPartyChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditPoliticalPartyViewModel>(); }
        }

        public CompetitionViewModel Competition
        {
            get { return _bootStrapper.Container.Resolve<CompetitionViewModel>(); }
        }

        public AddEditContactViewModel ContactChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditContactViewModel>(); }
        }

        public AddEditEconomyViewModel EconomyChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditEconomyViewModel>(); }
        }

        public AddEditCompetitionViewModel CompetitionChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditCompetitionViewModel>(); }
        }

        public PopulationViewModel Population
        {
            get { return _bootStrapper.Container.Resolve<PopulationViewModel>(); }
        }

        public MexicoAgreementViewModel MexicoAgreementState
        {
            get { return _bootStrapper.Container.Resolve<MexicoAgreementViewModel>(); }
        }

        public AddEditMexicoAgreementViewModel MexicoAgreementChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditMexicoAgreementViewModel>(); }
        }

        public SocialOrganizationsInfoViewModel SocialOrganization
        {
            get { return _bootStrapper.Container.Resolve<SocialOrganizationsInfoViewModel>(); }
        }
        public AddEditSocialOrganizationViewModel SocialOrganizationChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditSocialOrganizationViewModel>(); }
        }

        public CapacitationCenterViewModel CapacitationCenter
        {
            get { return _bootStrapper.Container.Resolve<CapacitationCenterViewModel>(); }
        }

        public AddEditCapacitationCenterViewModel CapacitationCenterChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditCapacitationCenterViewModel>(); }
        }

        public ProgramsMsftStateViewModel MsftProgram
        {
            get { return _bootStrapper.Container.Resolve<ProgramsMsftStateViewModel>(); }
        }

        public AddEditMsftProgramViewModel MsftProgramChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditMsftProgramViewModel>(); }
        }

        public OpenSourceViewModel OpenSource
        {
            get { return _bootStrapper.Container.Resolve<OpenSourceViewModel>(); }
        }

        public AddEditOpenSourceStateViewModel OpenSourceChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditOpenSourceStateViewModel>(); }
        }

        public OpenSourceProviderViewModel OpenSourceProvider
        {
            get { return _bootStrapper.Container.Resolve<OpenSourceProviderViewModel>(); }
        }

        public OpenSourceCommunityViewModel OpenSourceCommunity
        {
            get { return _bootStrapper.Container.Resolve<OpenSourceCommunityViewModel>();}
        }

        public AddEditOpenSourceProviderViewModel OpenSourceProviderChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditOpenSourceProviderViewModel>(); }
        }

        public AddEditOpenSourceCommunityViewModel OpenSourceCommunityChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditOpenSourceCommunityViewModel>(); }
        }

        public EducationViewModel EducationState
        {
            get { return _bootStrapper.Container.Resolve<EducationViewModel>(); }
        }

        public AddEditEducationStateViewModel EducationStateChild
        {
            get { return _bootStrapper.Container.Resolve<AddEditEducationStateViewModel>(); }
        }

        public EducationEnlaceViewModel EducationEnlace
        {
            get { return _bootStrapper.Container.Resolve<EducationEnlaceViewModel>(); }
        }

        public EducationSepProjectsViewModel EducationSep
        {
            get { return _bootStrapper.Container.Resolve<EducationSepProjectsViewModel>(); }
        }

        public EducationUniversitiesViewModel EducationUniversities
        {
            get { return _bootStrapper.Container.Resolve<EducationUniversitiesViewModel>(); }
        }

        public SchoolsViewModel Schools
        {
            get { return _bootStrapper.Container.Resolve<SchoolsViewModel>(); }
        }

        public ProgramStateViewModel ProgramState
        {
            get { return _bootStrapper.Container.Resolve<ProgramStateViewModel>(); }
        }

        public DashboardViewModel Dashboard
        {
            get { return _bootStrapper.Container.Resolve<DashboardViewModel>(); }

        }
    }
}