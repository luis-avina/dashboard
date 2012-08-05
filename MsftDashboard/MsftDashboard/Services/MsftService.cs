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
using System.ServiceModel.DomainServices.Client;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using MsftDashboard.Web.Services;
using Microsoft.Windows.Data.DomainServices;
using System.Linq;
using System.ComponentModel;

namespace MsftDashboard.Services
{
    public class MsftService:IMsftService
    {
        private Action<SubmitOperation> _updateCompetitionCallBack;
        private Action<SubmitOperation> _updateContactCallBack;
        private Action<SubmitOperation> _updateStateEconomicCallBack;
        private Action<SubmitOperation> _updateMexicoAgreementCallBack;
        private Action<SubmitOperation> _updatePoliticalStateCallBack;
        private Action<SubmitOperation> _updatePoliticalPartyCallBack;
        private Action<SubmitOperation> _updateSocialOrganizationCallBack;
        private Action<SubmitOperation> _updateCapacitationCenterCallBack;
        private Action<SubmitOperation> _updateMsftProgramCallBack;
        private Action<SubmitOperation> _updateOpenSourceState;
        private Action<SubmitOperation> _updateOpenSourceProvider;
        private Action<SubmitOperation> _updateOpenSourceCommunity;
        private Action<SubmitOperation> _updateEducationInformationState;
        private Action<SubmitOperation> _updateStateProgram;
        
        

        private Contact _contact;
        private StateEconomicInfo _stateEconomicInfo;
        private Competition _competition;
        private MexicoAgreement _mexicoAgreement;
        private PoliticalInformationState _politicalState;
        private PoliticalParty _politicalParty;
        private SocialOrganizationInformation _socOrgInfo;
        private CapacitationCenterInformation _capacitationCenter;
        private MicrosoftProgramState _msftProgram;
        private OpenSourceState _openSourceState;
        private OpenSourceStateCommunity _openSourceCommunity;
        private OpenSourceStateProvider _openSourceProvider;
        private EducationInformationState _educationInformationState;
        private StateProgram _stateProgram;

        private LoadOperation<Contact> _contactsLoadOperation;
        private Action<ObservableCollection<Contact>> _getContactsCallBack;
        
        private LoadOperation<StateEconomicInfo> _stateEconomyLoadOperation;
        private Action<ObservableCollection<StateEconomicInfo>> _getEconomyStateCallBack;
        
        private LoadOperation<PoliticalInformationState> _politicStateLoadOperation;
        private Action<ObservableCollection<PoliticalInformationState>> _getPoliticStateCallBack;
        
        private LoadOperation<Competition> _competitionLoadOperation;
        private Action<ObservableCollection<Competition>> _getCompetitionStateCallBack;
        
        private Action<ObservableCollection<Competitor>> _getCompetitorStateCallBack;
        private Action<ObservableCollection<State>> _getStatesCallBack;
        
        private LoadOperation<State> _stateLoadOperation;
        private Action<ObservableCollection<Year>> _getYearCallBack;
        
        private LoadOperation<Year> _yearLoadOperations;
        private LoadOperation<Competitor> _competitorLoadOperations;
        
        private Action<ObservableCollection<Municipality>> _getMunicipalityCallBack;
        private LoadOperation<Municipality> _municipalityLoadOperations;
        
        private Action<ObservableCollection<MexicoAgreement>> _getMexicoAgreementCallBack;
        private LoadOperation<MexicoAgreement> _mexicoAgreementOperation;

        private Action<ObservableCollection<EducationInformationState>> _getEducationStateCallBack;
        private LoadOperation<EducationInformationState> _educationStateOperation;

        private Action<ObservableCollection<OpenSourceState>> _getOpenSourceStateCallBack;
        private LoadOperation<OpenSourceState> _openSourceOperation;

        private Action<ObservableCollection<MicrosoftProgramState>> _getProgramMsftCallBack;
        private LoadOperation<MicrosoftProgramState> _programMsftOperation;

        private Action<ObservableCollection<TypeAgreement>> _getTypeAgreementCallBack;
        private LoadOperation<TypeAgreement> _typeAgreementOperation;

        private Action<ObservableCollection<PoliticalParty>> _getPoliticalPartyCallBack;
        private LoadOperation<PoliticalParty> _politicalPartyOperation;

        private Action<ObservableCollection<PopulationAttended>> _getPopulationAttendedCallBack;
        private LoadOperation<PopulationAttended> _populationAttendedOperation;

        private Action<ObservableCollection<SocialCause>> _getSocialCauseCallBack;
        private LoadOperation<SocialCause> _socialCauseOperation;

        private Action<ObservableCollection<SocialOrganizationInformation>> _getSocialInfoCallBack;
        private LoadOperation<SocialOrganizationInformation> _socialOrgOperation;

        private Action<ObservableCollection<CapacitationCenterInformation>> _getCapacitationCenterCallBack;
        private LoadOperation<CapacitationCenterInformation> _capacitationCenterOperation;

        private Action<ObservableCollection<SocialOrganization>> _getSocialOrganizationCallBack;
        private LoadOperation<SocialOrganization> _socialOrganizationOperation;

        private Action<ObservableCollection<Conectivity>> _getConectivityCallBack;
        private LoadOperation<Conectivity> _conectivityOperation;

        private Action<ObservableCollection<MicrosoftProgramState>> _getMsftProgramCallBack;
        private LoadOperation<MicrosoftProgramState> _msftOperation;

        private Action<ObservableCollection<Partner>> _getPartnersCallBack;
        private LoadOperation<Partner> _partnerOperation;

        private Action<ObservableCollection<Program>> _getProgramsCallBack;
        private LoadOperation<Program> _programOperation;

        private Action<ObservableCollection<Source>> _getSourcesCallBack;
        private LoadOperation<Source> _sourceOperation;

        private Action<ObservableCollection<TypeProduct>> _getTypeProductCallBack;
        private LoadOperation<TypeProduct> _typeProductOperation;

        private Action<ObservableCollection<Product>> _getProductCallBack;
        private LoadOperation<Product> _productOperation;

        private Action<ObservableCollection<Penetration>> _getPenetrationCallBack;
        private LoadOperation<Penetration> _penetrationOperation;

        private Action<ObservableCollection<OpenSourceStateProvider>> _getOpenSourceProviderCallBack;
        private LoadOperation<OpenSourceStateProvider> _openSourceProviderOperation;

        private Action<ObservableCollection<OpenSourceStateCommunity>> _getOpenSourceCommunityCallBack;
        private LoadOperation<OpenSourceStateCommunity> _openSourceCommunityOperation;

        private Action<ObservableCollection<EducationInformationState>> _getEducationInformationCallBack;
        private LoadOperation<EducationInformationState> _educationStateInformationOperation;

        private Action<ObservableCollection<SchoolLevel>> _getSchoolLevelsCallBack;
        private LoadOperation<SchoolLevel> _schoolLevelOperation;

        private Action<ObservableCollection<SchoolGrade>> _getSchoolGradeCallBack;
        private LoadOperation<SchoolGrade> _schoolGradeOperation;

        private Action<ObservableCollection<SchoolType>> _getSchoolTypeCallBack;
        private LoadOperation<SchoolType> _schoolTypeOperation;

        private Action<ObservableCollection<TypeSepProject>> _getTypeSepProjectCallBack;
        private LoadOperation<TypeSepProject> _schoolTypeSepProjectOperation;

        private Action<ObservableCollection<University>> _getUniversitiesCallBack;
        private LoadOperation<University> _universityOperation;

        private Action<ObservableCollection<StateProgram>> _getStateProgramCallBack;
        private LoadOperation<StateProgram> _stateProgramOperation;

        private Action<ObservableCollection<DateTime>> _getTimeCallBack;

        private Action<ObservableCollection<PoliticalInformationMunicipality>> _getPoliticalMunicipalityCallBack;
        private LoadOperation<PoliticalInformationMunicipality> municipalityPoliticOperation;

        private Action<StateEconomicInfo> _getCurrentStateEconomicInfo;
        private LoadOperation<StateEconomicInfo> currentStateEconomicInfo;

        private Action<EducationInformationState> _getCurrentEducationStateInfo;
        private LoadOperation<EducationInformationState> currentEducationStateInfo;


        public DBContext Context { get; set; }
        public event EventHandler<HasChangesEventArgs> NotifyHasChanges;

        public MsftService()
        {
            Context = new DBContext();
            Context.PropertyChanged += ContextPropertyChanged;
        }

        private void ContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (NotifyHasChanges != null)
            {
                NotifyHasChanges(this, new HasChangesEventArgs() { HasChanges = Context.HasChanges });
            }
        }


        #region insert
        public void SaveContact(Action<SubmitOperation> submitCallback, Contact contact)
        {
            if (contact!=null)
            {
                Context.Contacts.Add(contact);
                Context.SubmitChanges(submitCallback, null);
            }
        }

        public void SaveEconomyState(Action<SubmitOperation> submitCallback, StateEconomicInfo stateEconomy)
        {
            if (stateEconomy != null)
            {
                Context.StateEconomicInfos.Add(stateEconomy);
                Context.SubmitChanges(submitCallback, null);
            }
        }

        public void SaveCompetition(Action<SubmitOperation> submitCallback, Competition competition)
        {
            if (competition != null)
            {
                Context.Competitions.Add(competition);
                Context.SubmitChanges(submitCallback, null);
            }
        }

        public void SaveMunicipality(Action<SubmitOperation> submitCallback, object state)
        {
            if (Context.HasChanges)
            {
                Context.SubmitChanges(submitCallback,null);
            }
        }

        public void SaveMexicoAgreement(Action<SubmitOperation> submitCallBack, MexicoAgreement mexicoAgreement)
        {
            if (mexicoAgreement != null)
            {
                Context.MexicoAgreements.Add(mexicoAgreement);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SavePoliticalState(Action<SubmitOperation> submitCallBack, PoliticalInformationState politicalState)
        {
            if (politicalState != null)
            {
                Context.PoliticalInformationStates.Add(politicalState);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SavePoliticalParty(Action<SubmitOperation> submitCallBack, PoliticalParty politicalParty)
        {
            if (politicalParty != null)
            {
                Context.PoliticalParties.Add(politicalParty);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveSocialOrganizationInformation(Action<SubmitOperation> submitCallBack, SocialOrganizationInformation socOrgInfo)
        {
            if (socOrgInfo != null)
            {
                Context.SocialOrganizationInformations.Add(socOrgInfo);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveCapacitationCenter(Action<SubmitOperation> submitCallBack, CapacitationCenterInformation capCenter)
        {
            if (capCenter != null)
            {
                Context.CapacitationCenterInformations.Add(capCenter);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveProgramMsft(Action<SubmitOperation> submitCallBack, MicrosoftProgramState programMsft)
        {
            if (programMsft != null)
            {
                Context.MicrosoftProgramStates.Add(programMsft);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveOpenSourceState(Action<SubmitOperation> submitCallBack, OpenSourceState openSourceState)
        {
            if (openSourceState != null)
            {
                Context.OpenSourceStates.Add(openSourceState);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveOpenSourceCommunity(Action<SubmitOperation> submitCallBack, OpenSourceStateCommunity openSourceCommunity)
        {
            if (openSourceCommunity != null)
            {
                Context.OpenSourceStateCommunities.Add(openSourceCommunity);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveOpenSourceProvider(Action<SubmitOperation> submitCallBack, OpenSourceStateProvider openSourceProvider)
        {
            if (openSourceProvider != null)
            {
                Context.OpenSourceStateProviders.Add(openSourceProvider);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveEducationInformationState(Action<SubmitOperation> submitCallBack, EducationInformationState educationInformationState)
        {
            if (educationInformationState != null)
            {
                Context.EducationInformationStates.Add(educationInformationState);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        public void SaveSepProject(Action<SubmitOperation>submitCallBack,ObservableCollection<SEPProjectState>sepProjectCollection)
        {
            if (sepProjectCollection != null)
            {
                foreach (SEPProjectState item in sepProjectCollection)
                {
                    Context.SEPProjectStates.Add(item);
                   
                }

                Context.SubmitChanges(submitCallBack, null);
            }
        }

        public void SaveStateProgram(Action<SubmitOperation> submitCallBack, StateProgram stateProgram)
        {
            if (stateProgram != null)
            {
                Context.StatePrograms.Add(stateProgram);
                Context.SubmitChanges(submitCallBack,null);
            }
        }

        #endregion

        #region select

        public void GetCurrentStateEconomicInfo(Action<StateEconomicInfo> getCurrentStateEconomicInfo, int idState)
        {
            _getCurrentStateEconomicInfo = getCurrentStateEconomicInfo;
            Context.StateEconomicInfos.Clear();
            currentStateEconomicInfo = Context.Load<StateEconomicInfo>(Context.GetCurrentStateEconomicInfoByIdStateQuery(idState));
            currentStateEconomicInfo.Completed += OnLoadCurrentStateEconomicInfo;
        }

        private void OnLoadCurrentStateEconomicInfo(object sender, EventArgs e)
        {
            currentStateEconomicInfo.Completed -= OnLoadCurrentStateEconomicInfo;
            var current = currentStateEconomicInfo.Entities.FirstOrDefault();
            _getCurrentStateEconomicInfo(current);
        }

        public void GetCurrentEducationStateInfo(Action<EducationInformationState> getCurrentEducationInfo, int IdState)
        {
            _getCurrentEducationStateInfo = getCurrentEducationInfo;
            currentEducationStateInfo = Context.Load<EducationInformationState>(Context.GetCurrentEducationInformationStatesByIdStateQuery(IdState));
            currentEducationStateInfo.Completed += new EventHandler(currentEducationStateInfo_Completed);
        }

        void currentEducationStateInfo_Completed(object sender, EventArgs e)
        {
            currentEducationStateInfo.Completed -= currentEducationStateInfo_Completed;
            var current = currentEducationStateInfo.Entities.FirstOrDefault();
            _getCurrentEducationStateInfo(current);
        }


        public void GetContacts(Action<ObservableCollection<Contact>> getContactsCallBack)
        {
            _getContactsCallBack = getContactsCallBack;
            Context.Contacts.Clear();
            _contactsLoadOperation = Context.Load<Contact>(Context.GetContactsQuery());
            _contactsLoadOperation.Completed += OnLoadContactsCompleted;

        }

        void OnLoadContactsCompleted(object sender, EventArgs e)
        {
            _contactsLoadOperation.Completed -= OnLoadContactsCompleted;
            var contacts = new EntityList<Contact>(Context.Contacts, _contactsLoadOperation.Entities);
            _getContactsCallBack(contacts);
        }

        public void GetEconomyStateInformation(Action<ObservableCollection<StateEconomicInfo>> getEconomyStateCallBack)
        {
            _getEconomyStateCallBack = getEconomyStateCallBack;
            Context.StateEconomicInfos.Clear();
            _stateEconomyLoadOperation = Context.Load<StateEconomicInfo>(Context.GetStateEconomicInfoesQuery());
            _stateEconomyLoadOperation.Completed+=OnLoadStateEconomyCompleted;
        }

        private void OnLoadStateEconomyCompleted(object sender, EventArgs e)
        {
            _stateEconomyLoadOperation.Completed -= OnLoadStateEconomyCompleted;
            var economyInfo = new EntityList<StateEconomicInfo>(Context.StateEconomicInfos, _stateEconomyLoadOperation.Entities);
            _getEconomyStateCallBack(economyInfo);
        }

        public void GetPoliticInformation(Action<ObservableCollection<PoliticalInformationState>> getPoliticStateCallBack)
        {
            _getPoliticStateCallBack = getPoliticStateCallBack;
            Context.PoliticalInformationStates.Clear();
            _politicStateLoadOperation = Context.Load<PoliticalInformationState>(Context.GetPoliticalInformationStatesQuery());
            _politicStateLoadOperation.Completed += OnLoadPoliticStateCompleted;
       
        }

        public  void GetPoliticalStateInformationByDate(Action<ObservableCollection<PoliticalInformationState>> getPoliticalStateCallBack, DateTime periodDate)
        {
            _getPoliticStateCallBack = getPoliticalStateCallBack;
            Context.PoliticalInformationStates.Clear();
            _politicStateLoadOperation = Context.Load<PoliticalInformationState>(Context.GetPoliticalInformationStatesByDateQuery(periodDate));
            _politicStateLoadOperation.Completed += OnLoadPoliticStateCompleted;
        }

        private void OnLoadPoliticStateCompleted(Object sender, EventArgs e)
        {
            _politicStateLoadOperation.Completed -= OnLoadPoliticStateCompleted;
            var politicState = new EntityList<PoliticalInformationState>(Context.PoliticalInformationStates, _politicStateLoadOperation.Entities);
            _getPoliticStateCallBack(politicState);
        }

        public void GetPoliticalMunicipalityByIdPoliticalState(Action<ObservableCollection<PoliticalInformationMunicipality>> getPoliticalMunicipalityCallBack, int Id)
        {
            _getPoliticalMunicipalityCallBack = getPoliticalMunicipalityCallBack;
            Context.PoliticalInformationMunicipalities.Clear();
            municipalityPoliticOperation = Context.Load<PoliticalInformationMunicipality>(Context.GetPoliticalInformationMunicipalitiesByIdPoliticStateQuery(Id));
            municipalityPoliticOperation.Completed += OnLoadPoliticalMunicipalityOperation;
        }

        public void OnLoadPoliticalMunicipalityOperation(Object sender, EventArgs e)
        {
            municipalityPoliticOperation.Completed -= OnLoadPoliticalMunicipalityOperation;
            var politicalMunicipality = new EntityList<PoliticalInformationMunicipality>(Context.PoliticalInformationMunicipalities, municipalityPoliticOperation.Entities);
            _getPoliticalMunicipalityCallBack(politicalMunicipality);
        }

        public void GetCompetitionInformation(Action<ObservableCollection<Competition>> getCompetitionCallBack)
        {
            _getCompetitionStateCallBack = getCompetitionCallBack;
            Context.Competitions.Clear();
            _competitionLoadOperation = Context.Load<Competition>(Context.GetCompetitionsQuery());
            _competitionLoadOperation.Completed += OnLoadCompetitionCompleted;
        }

        public void GetCompetitionByDate(Action<ObservableCollection<Competition>>getCompetitonCallBack,DateTime initialDate, DateTime finalDate)
        {
            _getCompetitionStateCallBack = getCompetitonCallBack;
            Context.Competitions.Clear();
            _competitionLoadOperation= Context.Load<Competition>(Context.GetCompetitionsByDateQuery(initialDate,finalDate));
            _competitionLoadOperation.Completed += OnLoadCompetitionCompleted;
        }

        private void OnLoadCompetitionCompleted(Object sender, EventArgs e)
        {
            _competitionLoadOperation.Completed -= OnLoadCompetitionCompleted;
            var competition = new EntityList<Competition>(Context.Competitions,_competitionLoadOperation.Entities);
            _getCompetitionStateCallBack(competition);
        }

        public void GetStates(Action<ObservableCollection<State>> getStatesCallBack)
        {
            _getStatesCallBack = getStatesCallBack;
            Context.States.Clear();
            _stateLoadOperation = Context.Load<State>(Context.GetStatesQuery());
            _stateLoadOperation.Completed += OnLoadStateCompleted;
        }

        private void OnLoadStateCompleted(Object sender, EventArgs e)
        {
            _stateLoadOperation.Completed -= OnLoadStateCompleted;
            var states = new EntityList<State>(Context.States, _stateLoadOperation.Entities);
            _getStatesCallBack(states);
        }

        public void GetYears(Action<ObservableCollection<Year>> getYearCallBack)
        {
            _getYearCallBack = getYearCallBack;
            Context.Years.Clear();
            _yearLoadOperations = Context.Load<Year>(Context.GetYearsQuery());
            _yearLoadOperations.Completed += OnLoadYearCompleted;
        }

        private void OnLoadYearCompleted(Object sender, EventArgs e)
        {
            _yearLoadOperations.Completed -= OnLoadYearCompleted;
            var years = new EntityList<Year>(Context.Years, _yearLoadOperations.Entities);
            _getYearCallBack(years);
        }

        public void GetCompetitor(Action<ObservableCollection<Competitor>> getCompetitorCallBack)
        {
            _getCompetitorStateCallBack = getCompetitorCallBack;
            Context.Competitors.Clear();
            _competitorLoadOperations = Context.Load<Competitor>(Context.GetCompetitorsQuery());
            _competitorLoadOperations.Completed += OnLoadCompetitorCompleted;
        }

        private void OnLoadCompetitorCompleted(Object sender, EventArgs e)
        {
            _competitorLoadOperations.Completed -= OnLoadCompetitorCompleted;
            var competitor = new EntityList<Competitor>(Context.Competitors, _competitorLoadOperations.Entities);
            _getCompetitorStateCallBack(competitor);
        }

        public void GetMunicipalities(Action<ObservableCollection<Municipality>> getMunicipalityCallBack,int IdState)
        {
            _getMunicipalityCallBack = getMunicipalityCallBack;
            Context.Municipalities.Clear();
            _municipalityLoadOperations = Context.Load<Municipality>(Context.GetMunicipalitiesByIdQuery(IdState));
            _municipalityLoadOperations.Completed += OnLoadMunicipalityCompleted;

        }

        private void OnLoadMunicipalityCompleted(Object sender, EventArgs e)
        {
            _municipalityLoadOperations.Completed -= OnLoadMunicipalityCompleted;
            var municipalities = new EntityList<Municipality>(Context.Municipalities,_municipalityLoadOperations.Entities);
            _getMunicipalityCallBack(municipalities);

        }

        public void GetMexicoAgreements(Action<ObservableCollection<MexicoAgreement>> getMexicoAgreementCallback)
        {
            _getMexicoAgreementCallBack = getMexicoAgreementCallback;
            Context.MexicoAgreements.Clear();
            _mexicoAgreementOperation = Context.Load<MexicoAgreement>(Context.GetMexicoAgreementsQuery());
            _mexicoAgreementOperation.Completed += OnLoadMexicoAgreementCompleted;   
        }

        public void GetMexicoAgreementsByDate(Action<ObservableCollection<MexicoAgreement>> getMexicoAgreementCallback, DateTime initialDate, DateTime finalDate)
        {
            _getMexicoAgreementCallBack = getMexicoAgreementCallback;
            Context.MexicoAgreements.Clear();
            _mexicoAgreementOperation = Context.Load<MexicoAgreement>(Context.GetMexicoAgreementsByDateQuery(initialDate,finalDate));
            _mexicoAgreementOperation.Completed += OnLoadMexicoAgreementCompleted;   
        }


        private void OnLoadMexicoAgreementCompleted(Object sender, EventArgs e)
        {
            _mexicoAgreementOperation.Completed -= OnLoadMexicoAgreementCompleted;
            var mexicoAgreement = new EntityList<MexicoAgreement>(Context.MexicoAgreements,_mexicoAgreementOperation.Entities);
            _getMexicoAgreementCallBack(mexicoAgreement);
                
        }

        public void GetEducationStateInformation(Action<ObservableCollection<EducationInformationState>> getEducationStateCallBack)
        {
            _getEducationStateCallBack = getEducationStateCallBack;
            Context.EducationInformationStates.Clear();
            _educationStateOperation = Context.Load<EducationInformationState>(Context.GetEducationInformationStatesQuery());
            _educationStateOperation.Completed += OnLoadEducationStateInformation;
        }

        private void OnLoadEducationStateInformation(Object sender, EventArgs e)
        {
            _educationStateOperation.Completed -= OnLoadEducationStateInformation;
            var education = new EntityList<EducationInformationState>(Context.EducationInformationStates, _educationStateOperation.Entities);
            _getEducationStateCallBack(education);
        }
        
        public void GetOpenSourceStateInformation(Action<ObservableCollection<OpenSourceState>> getOpenSourceStateCallBack)
        {
            _getOpenSourceStateCallBack = getOpenSourceStateCallBack;
            Context.OpenSourceStates.Clear();
            _openSourceOperation = Context.Load<OpenSourceState>(Context.GetOpenSourceStatesQuery());
            _openSourceOperation.Completed += OnLoadOpenSourceStateInformation;
        }

        private void OnLoadOpenSourceStateInformation(Object sender, EventArgs e)
        {
            _openSourceOperation.Completed -= OnLoadEducationStateInformation;
            var openSource = new EntityList<OpenSourceState>(Context.OpenSourceStates, _openSourceOperation.Entities);
            _getOpenSourceStateCallBack(openSource);
        }

        public void GetProgramMsftInformation(Action<ObservableCollection<MicrosoftProgramState>> getProgramMsftCallBack)
        {
            _getProgramMsftCallBack = getProgramMsftCallBack;
            Context.MicrosoftProgramStates.Clear();
            _programMsftOperation = Context.Load<MicrosoftProgramState>(Context.GetMicrosoftProgramStatesQuery());
            _programMsftOperation.Completed += OnLoadProgramMsftInformation;
        }

        public void GetMicrosoftProgramStateByState(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramCallBack, int IdState)
        {
            _getProgramMsftCallBack = getMsftProgramCallBack;
            Context.MicrosoftProgramStates.Clear();
            _programMsftOperation = Context.Load<MicrosoftProgramState>(Context.GetMicrosoftProgramStatesByIdStateQuery(IdState));
            _programMsftOperation.Completed += OnLoadProgramMsftInformation;
        }

        public void GetTypeAgreement(Action<ObservableCollection<TypeAgreement>> getTypeAgreementCallBack)
        {
            _getTypeAgreementCallBack = getTypeAgreementCallBack;
            Context.TypeAgreements.Clear();
            _typeAgreementOperation = Context.Load<TypeAgreement>(Context.GetTypeAgreementsQuery());
            _typeAgreementOperation.Completed += OnLoadTypeAgreements;
        }

        private void OnLoadTypeAgreements(Object sender, EventArgs e)
        {
            _typeAgreementOperation.Completed -= OnLoadTypeAgreements;
            var typeAgreement = new EntityList<TypeAgreement>(Context.TypeAgreements, _typeAgreementOperation.Entities);
            _getTypeAgreementCallBack(typeAgreement);
        }

        public void GetPoliticalParty(Action<ObservableCollection<PoliticalParty>> getPoliticalPartyCallBack)
        {
            _getPoliticalPartyCallBack = getPoliticalPartyCallBack;
            Context.PoliticalParties.Clear();
            _politicalPartyOperation = Context.Load<PoliticalParty>(Context.GetPoliticalPartiesQuery());
            _politicalPartyOperation.Completed += OnLoadPoliticalParty;
        }

        private void OnLoadPoliticalParty(Object sender, EventArgs e)
        {
            _politicalPartyOperation.Completed -= OnLoadPoliticalParty;
            var politicalParty = new EntityList<PoliticalParty>(Context.PoliticalParties,_politicalPartyOperation.Entities);
            _getPoliticalPartyCallBack(politicalParty);
        }

        public void GetPopulationAttended(Action<ObservableCollection<PopulationAttended>> getPopulationCallBack)
        {
            _getPopulationAttendedCallBack = getPopulationCallBack;
            Context.PopulationAttendeds.Clear();
            _populationAttendedOperation = Context.Load<PopulationAttended>(Context.GetPopulationAttendedsQuery());
            _populationAttendedOperation.Completed += OnLoadPopulationAttended;
        }

        private void OnLoadPopulationAttended(Object sender, EventArgs e)
        {
            _populationAttendedOperation.Completed -= OnLoadPopulationAttended;
            var population = new EntityList<PopulationAttended>(Context.PopulationAttendeds, _populationAttendedOperation.Entities);
            _getPopulationAttendedCallBack(population);
        }

        public void GetSocialCause(Action<ObservableCollection<SocialCause>>getSocialCauseCallBack)
        {
            _getSocialCauseCallBack = getSocialCauseCallBack;
            Context.SocialCauses.Clear();
            _socialCauseOperation = Context.Load<SocialCause>(Context.GetSocialCausesQuery());
            _socialCauseOperation.Completed += OnLoadSocialCause;
        }

        private void OnLoadSocialCause(Object sender, EventArgs e)
        {
            _socialCauseOperation.Completed -= OnLoadSocialCause;
            var socialCause = new EntityList<SocialCause>(Context.SocialCauses, _socialCauseOperation.Entities);
            _getSocialCauseCallBack(socialCause);
        }

        public void GetSocialOrganizationInformation(Action<ObservableCollection<SocialOrganizationInformation>> getSocialOrganizationInfoCallBack)
        {
            _getSocialInfoCallBack = getSocialOrganizationInfoCallBack;
            Context.SocialOrganizationInformations.Clear();
            _socialOrgOperation = Context.Load<SocialOrganizationInformation>(Context.GetSocialOrganizationInformationsQuery());
            _socialOrgOperation.Completed += OnLoadSocialOrgInfo;
        }

        private void OnLoadSocialOrgInfo(Object sender, EventArgs e)
        {
            _socialOrgOperation.Completed -= OnLoadSocialOrgInfo;
            var socialOrgInfo = new EntityList<SocialOrganizationInformation>(Context.SocialOrganizationInformations,_socialOrgOperation.Entities);
            _getSocialInfoCallBack(socialOrgInfo);
        }

        public void GetCapacitationCenter(Action<ObservableCollection<CapacitationCenterInformation>> getCapacitationCenterCallBack)
        {
            _getCapacitationCenterCallBack = getCapacitationCenterCallBack;
            Context.CapacitationCenterInformations.Clear();
            _capacitationCenterOperation = Context.Load<CapacitationCenterInformation>(Context.GetCapacitationCenterInformationsQuery());
            _capacitationCenterOperation.Completed += OnLoadCapacitationCenter;
        }

        private void OnLoadCapacitationCenter(Object sender, EventArgs e)
        {
            _capacitationCenterOperation.Completed -= OnLoadCapacitationCenter;
            var capacitationCenter = new EntityList<CapacitationCenterInformation>(Context.CapacitationCenterInformations, _capacitationCenterOperation.Entities);
            _getCapacitationCenterCallBack(capacitationCenter);
        }

        public void GetSocialOrganization(Action<ObservableCollection<SocialOrganization>> getSocialOrganizationCallBack)
        {
            _getSocialOrganizationCallBack = getSocialOrganizationCallBack;
            Context.SocialOrganizations.Clear();
            _socialOrganizationOperation = Context.Load<SocialOrganization>(Context.GetSocialOrganizationsQuery());
            _socialOrganizationOperation.Completed+=OnLoadSocialOrganization;
        }
        
        private void OnLoadSocialOrganization(Object sender, EventArgs e)
        {
            _socialOrganizationOperation.Completed-=OnLoadSocialOrganization;
            var socialOrganization = new EntityList<SocialOrganization>(Context.SocialOrganizations, _socialOrganizationOperation.Entities);
            _getSocialOrganizationCallBack(socialOrganization);
        }

        public void GetConectivity(Action<ObservableCollection<Conectivity>> getConectivityCallBack)
        {
            _getConectivityCallBack = getConectivityCallBack;
            Context.Conectivities.Clear();
            _conectivityOperation = Context.Load<Conectivity>(Context.GetConectivitiesQuery());
            _conectivityOperation.Completed+=OnLoadConectivity;
        }

        private void OnLoadConectivity(Object sender, EventArgs e)
        {
            _conectivityOperation.Completed -= OnLoadConectivity;
            var conectivity = new EntityList<Conectivity>(Context.Conectivities,_conectivityOperation.Entities);
            _getConectivityCallBack(conectivity);
        }

        public void GetMicrosoftProgramState(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramCallBack)
        {
            _getMsftProgramCallBack = getMsftProgramCallBack;
            Context.MicrosoftProgramStates.Clear();
            _msftOperation = Context.Load<MicrosoftProgramState>(Context.GetMicrosoftProgramStatesQuery());
            _msftOperation.Completed += OnLoadMicrosoftProgramState;
        }

        private void OnLoadMicrosoftProgramState(Object sender, EventArgs e)
        {
            _msftOperation.Completed -= OnLoadMicrosoftProgramState;
            var msftProgramState = new EntityList<MicrosoftProgramState>(Context.MicrosoftProgramStates,_msftOperation.Entities);
            _getMsftProgramCallBack(msftProgramState);
        }

        public void GetPartners(Action<ObservableCollection<Partner>> getPartnersCallBack)
        {
            _getPartnersCallBack = getPartnersCallBack;
            Context.Partners.Clear();
            _partnerOperation = Context.Load<Partner>(Context.GetPartnersQuery());
            _partnerOperation.Completed += OnLoadPartners;
        }

        private void OnLoadPartners(Object sender, EventArgs e)
        {
            _partnerOperation.Completed -= OnLoadPartners;
            var partners = new EntityList<Partner>(Context.Partners,_partnerOperation.Entities);
            _getPartnersCallBack(partners);
        }

        public void GetPrograms(Action<ObservableCollection<Program>> getProgramsCallBack)
        {
            _getProgramsCallBack = getProgramsCallBack;
            Context.Programs.Clear();
            _programOperation = Context.Load<Program>(Context.GetProgramsQuery());
            _programOperation.Completed += OnLoadPrograms;
        }

        private void OnLoadPrograms(Object sender, EventArgs e)
        {
            _programOperation.Completed -= OnLoadPrograms;
            var programs = new EntityList<Program>(Context.Programs,_programOperation.Entities);
            _getProgramsCallBack(programs);
        }

        public void GetSources(Action<ObservableCollection<Source>> getSourcesCallBack) 
        {
            _getSourcesCallBack = getSourcesCallBack;
            Context.Sources.Clear();
            _sourceOperation = Context.Load<Source>(Context.GetSourcesQuery());
            _sourceOperation.Completed += OnLoadSources;
        }

        private void OnLoadSources(Object sender, EventArgs e)
        {
            _sourceOperation.Completed -= OnLoadSources;
            var sources = new EntityList<Source>(Context.Sources,_sourceOperation.Entities);
            _getSourcesCallBack(sources);
        }

        public void GetTypeProduct(Action<ObservableCollection<TypeProduct>> getTypeProductCallBack)
        {
            _getTypeProductCallBack = getTypeProductCallBack;
            Context.TypeProducts.Clear();
            _typeProductOperation = Context.Load<TypeProduct>(Context.GetTypeProductsQuery());
            _typeProductOperation.Completed += OnLoadTypeproduct;
        }

        private void OnLoadTypeproduct(Object sender,EventArgs e)
        {
            _typeProductOperation.Completed -= OnLoadTypeproduct;
            var typeProducts = new EntityList<TypeProduct>(Context.TypeProducts, _typeProductOperation.Entities);
            _getTypeProductCallBack(typeProducts);
        }

        public void GetProduct(Action<ObservableCollection<Product>> getProductCallBack)
        {
            _getProductCallBack = getProductCallBack;
            Context.Products.Clear();
            _productOperation = Context.Load<Product>(Context.GetProductsQuery());
            _productOperation.Completed += OnLoadProduct;
        }

        private void OnLoadProduct(Object sender, EventArgs e)
        {
            _productOperation.Completed -= OnLoadProduct;
             var products = new EntityList<Product>(Context.Products, _productOperation.Entities);
            _getProductCallBack(products);
        }

        public void GetPenetration(Action<ObservableCollection<Penetration>> getPenetrationCallBack)
        {
            _getPenetrationCallBack = getPenetrationCallBack;
            Context.Penetrations.Clear();
            _penetrationOperation = Context.Load<Penetration>(Context.GetPenetrationsQuery());
            _penetrationOperation.Completed += OnLoadPenetration;
        }

        private void OnLoadPenetration(Object sender, EventArgs e)
        {
            _penetrationOperation.Completed -= OnLoadPenetration;
            var penetration = new EntityList<Penetration>(Context.Penetrations, _penetrationOperation.Entities);
            _getPenetrationCallBack(penetration);
        }

        public void GetProductByIdTypeProduct(Action<ObservableCollection<Product>> getProductCallBack,int IdTypeProduct)
        {
            _getProductCallBack = getProductCallBack;
            Context.Products.Clear();
            _productOperation = Context.Load<Product>(Context.GetProductsByIdTypeProductQuery(IdTypeProduct));
            _productOperation.Completed += OnLoadProductByTypeProduct;
        }

        private void OnLoadProductByTypeProduct(Object sender, EventArgs e)
        {
            _productOperation.Completed -= OnLoadProductByTypeProduct;
            var products = new EntityList<Product>(Context.Products, _productOperation.Entities);
            _getProductCallBack(products);
        }

        public void GetOpenSourceStateProvider(Action<ObservableCollection<OpenSourceStateProvider>> getOpenSourceProviderCallBack)
        {
            _getOpenSourceProviderCallBack = getOpenSourceProviderCallBack;
            Context.OpenSourceStateProviders.Clear();
            _openSourceProviderOperation = Context.Load<OpenSourceStateProvider>(Context.GetOpenSourceStateProvidersQuery());
            _openSourceProviderOperation.Completed += OnLoadOpenSourceProvider;
        }

        private void OnLoadOpenSourceProvider(Object sender, EventArgs e)
        {
            _openSourceProviderOperation.Completed -= OnLoadOpenSourceProvider;
            var openSourceProvider = new EntityList<OpenSourceStateProvider>(Context.OpenSourceStateProviders, _openSourceProviderOperation.Entities);
            _getOpenSourceProviderCallBack(openSourceProvider);
        }

        public void GetOpenSourceStateCommunity(Action<ObservableCollection<OpenSourceStateCommunity>> getOpenSourceCommunityCallBack)
        {
            _getOpenSourceCommunityCallBack = getOpenSourceCommunityCallBack;
            Context.OpenSourceStateCommunities.Clear();
            _openSourceCommunityOperation = Context.Load<OpenSourceStateCommunity>(Context.GetOpenSourceStateCommunitiesQuery());
            _openSourceCommunityOperation.Completed += OnLoadOpenSourceCommunity;
        }

        private void OnLoadOpenSourceCommunity(Object sender, EventArgs e)
        {
            _openSourceCommunityOperation.Completed -= OnLoadOpenSourceCommunity;
            var openSourceCommunity = new EntityList<OpenSourceStateCommunity>(Context.OpenSourceStateCommunities,_openSourceCommunityOperation.Entities);
            _getOpenSourceCommunityCallBack(openSourceCommunity);
        }

        public void GetSchoolLevels(Action<ObservableCollection<SchoolLevel>> getSchoolLevelsCallBack)
        {
            _getSchoolLevelsCallBack = getSchoolLevelsCallBack;
            Context.SchoolLevels.Clear();
            _schoolLevelOperation = Context.Load<SchoolLevel>(Context.GetSchoolLevelsQuery());
            _schoolLevelOperation.Completed += OnLoadSchoolLevels;
        }

        private void OnLoadSchoolLevels(Object sender, EventArgs e)
        {
            _schoolLevelOperation.Completed -= OnLoadSchoolLevels;
            var schoolLevels = new EntityList<SchoolLevel>(Context.SchoolLevels,_schoolLevelOperation.Entities);
            _getSchoolLevelsCallBack(schoolLevels);
        }

        public void GetSchoolGrade(Action<ObservableCollection<SchoolGrade>> getSchoolGradeCallBack)
        {
            _getSchoolGradeCallBack = getSchoolGradeCallBack;
            Context.SchoolGrades.Clear();
            _schoolGradeOperation = Context.Load<SchoolGrade>(Context.GetSchoolGradesQuery());
            _schoolGradeOperation.Completed += OnLoadSchoolGrade;

        }

        private void OnLoadSchoolGrade(Object sender, EventArgs e)
        {
            _schoolGradeOperation.Completed -= OnLoadSchoolGrade;
            var schoolGrade = new EntityList<SchoolGrade>(Context.SchoolGrades,_schoolGradeOperation.Entities);
            _getSchoolGradeCallBack(schoolGrade);

        }

        public void GetSchoolType(Action<ObservableCollection<SchoolType>> getSchoolTypeCallBack)
        {
            _getSchoolTypeCallBack = getSchoolTypeCallBack;
            Context.SchoolTypes.Clear();
            _schoolTypeOperation = Context.Load<SchoolType>(Context.GetSchoolTypesQuery());
            _schoolTypeOperation.Completed += OnLoadSchoolType;
        }

        private void OnLoadSchoolType(Object sender, EventArgs e)
        {
            _schoolTypeOperation.Completed -= OnLoadSchoolType;
            var schoolType = new EntityList<SchoolType>(Context.SchoolTypes,_schoolTypeOperation.Entities);
            _getSchoolTypeCallBack(schoolType);
        }

        public void GetTypeSepProject(Action<ObservableCollection<TypeSepProject>> getTypeSepProjectCallBack)
        {
            _getTypeSepProjectCallBack = getTypeSepProjectCallBack;
            Context.TypeSepProjects.Clear();
            _schoolTypeSepProjectOperation = Context.Load<TypeSepProject>(Context.GetTypeSepProjectsQuery());
            _schoolTypeSepProjectOperation.Completed += OnLoadTypeSepProject;
        }

        private void OnLoadTypeSepProject(Object sender, EventArgs e)
        {
            _schoolTypeSepProjectOperation.Completed -= OnLoadTypeSepProject;
            var typeSepProject = new EntityList<TypeSepProject>(Context.TypeSepProjects,_schoolTypeSepProjectOperation.Entities);
            _getTypeSepProjectCallBack(typeSepProject);
        }

        public void GetUniversitiesByState(Action<ObservableCollection<University>> getUniversitiesCallBack, int IdState)
        {
            _getUniversitiesCallBack = getUniversitiesCallBack;
            Context.Universities.Clear();
            _universityOperation = Context.Load<University>(Context.GetUniversitiesByIdStateQuery(IdState));
            _universityOperation.Completed += OnLoadUniversities;
        }

        private void OnLoadUniversities(Object sender, EventArgs e)
        {
            _universityOperation.Completed -= OnLoadUniversities;
            var universities = new EntityList<University>(Context.Universities,_universityOperation.Entities);
            _getUniversitiesCallBack(universities);
        }

        public void GetEconomyStateInformationByState(Action<ObservableCollection<StateEconomicInfo>> getEconomyStateCallBack,int IdState)
        {
            _getEconomyStateCallBack = getEconomyStateCallBack;
            Context.StateEconomicInfos.Clear();
            _stateEconomyLoadOperation = Context.Load<StateEconomicInfo>(Context.GetStateEconomicByIdStateQuery(IdState));
            _stateEconomyLoadOperation.Completed += OnLoadStateEconomyCompleted;
        }

        public void GetMicrosoftProgramStatesById(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramStateCallBack, int Id)
        {
            _getMsftProgramCallBack = getMsftProgramStateCallBack;
            Context.MicrosoftProgramStates.Clear();
            _msftOperation = Context.Load<MicrosoftProgramState>(Context.GetMicrosoftProgramStatesByIdQuery(Id));
            _msftOperation.Completed += OnLoadMicrosoftProgramState;

        }

        public void GetProgramState(Action<ObservableCollection<StateProgram>> getStateProgramCallBack)
        {
            _getStateProgramCallBack = getStateProgramCallBack;
            Context.StatePrograms.Clear();
            _stateProgramOperation = Context.Load<StateProgram>(Context.GetStateProgramsQuery());
            _stateProgramOperation.Completed += OnLoadStateProgram;
        }

        public void GetProgramStateByState(Action<ObservableCollection<StateProgram>> getStateProgramCallBack, int IdState)
        {
            _getStateProgramCallBack = getStateProgramCallBack;
            Context.StatePrograms.Clear();
            _stateProgramOperation = Context.Load<StateProgram>(Context.GetStateProgramsByIdStateQuery(IdState));
            _stateProgramOperation.Completed += OnLoadStateProgram;
        }

        public void GetProgramStateById(Action<ObservableCollection<StateProgram>> getStateProgramCallBack, int Id)
        {
            _getStateProgramCallBack = getStateProgramCallBack;
            Context.StatePrograms.Clear();
            _stateProgramOperation = Context.Load<StateProgram>(Context.GetStateProgramsByIdQuery(Id));
            _stateProgramOperation.Completed += OnLoadStateProgram;
        }

        private void OnLoadStateProgram(Object sender, EventArgs e)
        {
            _stateProgramOperation.Completed -= OnLoadStateProgram;
            var query = new EntityList<StateProgram>(Context.StatePrograms,_stateProgramOperation.Entities);
            _getStateProgramCallBack(query);
        }

        public void GetMicrosoftProgramStateByDate(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramCallBack, DateTime initialDate, DateTime finalDate)
        {
            _getProgramMsftCallBack = getMsftProgramCallBack;
            Context.MicrosoftProgramStates.Clear();
            _programMsftOperation = Context.Load<MicrosoftProgramState>(Context.GetMicrosoftProgramStatesByDateQuery(initialDate, finalDate));
            _programMsftOperation.Completed += OnLoadProgramMsftInformation;
        }

        private void OnLoadProgramMsftInformation(Object sender, EventArgs e)
        {
            _programMsftOperation.Completed -= OnLoadProgramMsftInformation;
            var programsMsft = new EntityList<MicrosoftProgramState>(Context.MicrosoftProgramStates, _programMsftOperation.Entities);
            _getProgramMsftCallBack(programsMsft);
        }

        public void GetProgramStateByDate(Action<ObservableCollection<StateProgram>> getStateProgramCallBack, DateTime initialDate, DateTime finalDate)
        {
            _getStateProgramCallBack = getStateProgramCallBack;
            Context.StatePrograms.Clear();
            _stateProgramOperation = Context.Load<StateProgram>(Context.GetStateProgramsByDateQuery(initialDate,finalDate));
            _stateProgramOperation.Completed += OnLoadStateProgram;
        }

        #endregion

        #region update

        public void UpdateContact(Action<SubmitOperation> submitCallback, Contact contact)
        {
            _updateContactCallBack = submitCallback;
            _contact = contact;
            var query =Context.GetContactsByIdQuery(contact.IdContact);
            Context.Load(query, EditContact, null);
        }

        private void EditContact(LoadOperation<Contact> contact)
        {
            ObservableCollection<Contact> contactQuery = new ObservableCollection<Contact>(contact.Entities);
            Contact contactToEdit = contactQuery.First();

            if (contactToEdit != null)
            {
                contactToEdit.FirstName = _contact.FirstName;
                contactToEdit.LastName = _contact.LastName;
                contactToEdit.Email = _contact.Email;
                contactToEdit.CellPhone = _contact.CellPhone;
                contactToEdit.Telephone = _contact.Telephone;
            }

            Context.SubmitChanges(_updateContactCallBack, null);        
        }

        public void UpdateStateEconomyInfo(Action<SubmitOperation> submitCallback, StateEconomicInfo stateEconomyInfo)
        {
            _updateStateEconomicCallBack = submitCallback;
            _stateEconomicInfo = stateEconomyInfo;
            var query = Context.GetStateEconomicInfoByIdQuery(stateEconomyInfo.IdStateEconomicInfo);
            Context.Load(query, EditEconomicState, null);
        }

        private void EditEconomicState(LoadOperation<StateEconomicInfo> stateEconomicInfo)
        {
            ObservableCollection<StateEconomicInfo> economicQuery = new ObservableCollection<StateEconomicInfo>(stateEconomicInfo.Entities);
            StateEconomicInfo economicStatetToEdit = economicQuery.First();

            if (economicStatetToEdit != null)
            {
                economicStatetToEdit.BudgetPublicAdministration = _stateEconomicInfo.BudgetPublicAdministration;
                economicStatetToEdit.BudgetSoftware = _stateEconomicInfo.BudgetSoftware;
                economicStatetToEdit.BudgetTIC = _stateEconomicInfo.BudgetTIC;
                
            }

            Context.SubmitChanges(_updateStateEconomicCallBack, null);    
        }

        public void UpdateCompetition(Action<SubmitOperation> submitCallback, Competition competition)
        {
            _updateCompetitionCallBack = submitCallback;
            _competition = competition;
            var query = Context.GetCompetitionsIdQuery(competition.IdCompetition);
            Context.Load(query, EditCompetition, null);
            
        }

        private void EditCompetition(LoadOperation<Competition> competitionInfo)
        {
            ObservableCollection<Competition> competitionQuery = new ObservableCollection<Competition>(competitionInfo.Entities);
            Competition competitionToEdit = competitionQuery.First();

            
            if (competitionToEdit != null)
            {
                competitionToEdit.Investment = _competition.Investment;
                competitionToEdit.Observations = _competition.Observations;
                competitionToEdit.Progress = _competition.Progress;

            }

            Context.SubmitChanges(_updateCompetitionCallBack, null);    
        }

        public void UpdateMexicoAgreement(Action<SubmitOperation> submitCallback, MexicoAgreement mexicoAgreement)
        {
            _updateMexicoAgreementCallBack = submitCallback;
            _mexicoAgreement = mexicoAgreement;
            var query = Context.GetMexicoAgreementsByIdQuery(mexicoAgreement.IdMexicoAgreements);
            Context.Load(query,EditMexicoAgreement,null);

        }

        private void EditMexicoAgreement(LoadOperation<MexicoAgreement> mexicoInfo)
        {
            ObservableCollection<MexicoAgreement> mexicoAgreementQuery = new ObservableCollection<MexicoAgreement>(mexicoInfo.Entities);
            MexicoAgreement mexicoAgreementToEdit = mexicoAgreementQuery.First();

            if (mexicoAgreementToEdit != null)
            {
                mexicoAgreementToEdit.Observations = _mexicoAgreement.Observations;
                mexicoAgreementToEdit.Progress = _mexicoAgreement.Progress;
            }

            Context.SubmitChanges(_updateMexicoAgreementCallBack, null);
        }

        public void UpdatePoliticalState(Action<SubmitOperation> submitCallback, PoliticalInformationState politicalState)
        {
            _updatePoliticalStateCallBack = submitCallback;
            _politicalState = politicalState;
            var query = Context.GetPoliticalInformationStatesByIdQuery(politicalState.IdPoliticalInformationState);
            Context.Load(query, EditPoliticalState, null);

        }

        private void EditPoliticalState(LoadOperation<PoliticalInformationState> politicalState)
        {
            ObservableCollection<PoliticalInformationState> politicalQuery = new ObservableCollection<PoliticalInformationState>(politicalState.Entities);
            PoliticalInformationState politicalStateToEdit = politicalQuery.First();

            if (politicalStateToEdit != null)
            {
                politicalStateToEdit.Observations = _politicalState.Observations;
                politicalStateToEdit.Sectorials = _politicalState.Sectorials;
                politicalStateToEdit.DevelopmentPlan = _politicalState.DevelopmentPlan;
            }

            Context.SubmitChanges(_updatePoliticalStateCallBack, null);
        }

        public void UpdatePoliticalParty(Action<SubmitOperation> submitCallBack, PoliticalParty politicalParty)
        {
            _updatePoliticalPartyCallBack = submitCallBack;
            _politicalParty = politicalParty;
            var query = Context.GetPoliticalPartiesByIdQuery(politicalParty.IdPoliticalParty);
            Context.Load(query, EditPoliticalParty, null);
        }

        private void EditPoliticalParty(LoadOperation<PoliticalParty> politicalParty)
        {
            ObservableCollection<PoliticalParty> politicalPartyQuery = new ObservableCollection<PoliticalParty>(politicalParty.Entities);
            PoliticalParty politicalPartyToEdit = politicalPartyQuery.First();

            if (politicalPartyToEdit != null)
            {
                politicalPartyToEdit.Name = _politicalParty.Name;
                politicalPartyToEdit.ShortName = _politicalParty.ShortName;
                politicalPartyToEdit.Status = _politicalParty.Status;
            }

            Context.SubmitChanges(_updatePoliticalPartyCallBack,null);
        }

        public void UpdateSocialOrganizationInformation(Action<SubmitOperation> submitCallBack, SocialOrganizationInformation socialOrgInfo)
        {
            _updateSocialOrganizationCallBack = submitCallBack;
            _socOrgInfo = socialOrgInfo;
            var query = Context.GetSocialOrganizationInformationsByIdQuery(socialOrgInfo.IdSocialOrganizationInformation);
            Context.Load(query, EditSocialOrgInfo, null);
        }

        private void EditSocialOrgInfo(LoadOperation<SocialOrganizationInformation> socOrfIngoOp)
        {
            ObservableCollection<SocialOrganizationInformation> socOrgInfoQuery = new ObservableCollection<SocialOrganizationInformation>(socOrfIngoOp.Entities);
            SocialOrganizationInformation socOrgInfoToEdit = socOrgInfoQuery.First();

            if (socOrgInfoToEdit != null)
            {
                socOrgInfoToEdit.Name = _socOrgInfo.Name;
                socOrgInfoToEdit.SocialCause = _socOrgInfo.SocialCause;
                socOrgInfoToEdit.PopulationAttended = _socOrgInfo.PopulationAttended;
            }

            Context.SubmitChanges(_updateSocialOrganizationCallBack, null);
        }

        public void UpdateCapacitationCenter(Action<SubmitOperation> submitCallBack, CapacitationCenterInformation capCenter)
        {
            _updateCapacitationCenterCallBack = submitCallBack;
            _capacitationCenter = capCenter;
            var query = Context.GetCapacitationCenterInformationsByIdQuery(capCenter.IdCapacitationCenterInformation);
            Context.Load(query, EditCapacitationCenter, null);
        }

        private void EditCapacitationCenter(LoadOperation<CapacitationCenterInformation> capCenter)
        {
            ObservableCollection<CapacitationCenterInformation> capCenterQuery = new ObservableCollection<CapacitationCenterInformation>(capCenter.Entities);
            CapacitationCenterInformation capCenterInfoToEdit = capCenterQuery.First();

            if (capCenterInfoToEdit != null)
            {
                capCenterInfoToEdit.Investment = _capacitationCenter.Investment;
                capCenterInfoToEdit.SoftwareInvesment = _capacitationCenter.SoftwareInvesment;
                capCenterInfoToEdit.NumberOfUsers = _capacitationCenter.NumberOfUsers;
                capCenterInfoToEdit.NumberOfTrainingUsers = _capacitationCenter.NumberOfTrainingUsers;
            }

            Context.SubmitChanges(_updateSocialOrganizationCallBack, null);

        }

        public void UpdateProgramMsft(Action<SubmitOperation> submitCallBack, MicrosoftProgramState msftProgram)
        {
            _updateMsftProgramCallBack = submitCallBack;
            _msftProgram = msftProgram;
            var query = Context.GetMicrosoftProgramStatesByIdQuery(msftProgram.IdMsftProgramState);
            Context.Load(query,EditProgramMsft,null);
        }

        private void EditProgramMsft(LoadOperation<MicrosoftProgramState> programMsftOp)
        {
            ObservableCollection<MicrosoftProgramState> msftProgramQuery = new ObservableCollection<MicrosoftProgramState>(programMsftOp.Entities);
            MicrosoftProgramState msftProgramToEdit = msftProgramQuery.First();

            if (msftProgramToEdit != null)
            {
                msftProgramToEdit.Investment = _msftProgram.Investment;
                msftProgramToEdit.ROI = _msftProgram.ROI;
                msftProgramToEdit.Progress = _msftProgram.Progress;
            }

            Context.SubmitChanges(_updateMsftProgramCallBack, null);
        }

        public void UpdateOpenSourceState(Action<SubmitOperation> submitCallBack, OpenSourceState openSourceState)
        {
            _updateOpenSourceState = submitCallBack;
            _openSourceState = openSourceState;
            var query = Context.GetOpenSourceStatesByIdQuery(openSourceState.IdOSSState);
            Context.Load(query, EditOpenSourceState, null);
        }

        private void EditOpenSourceState(LoadOperation<OpenSourceState> openSourceOp)
        {
            ObservableCollection<OpenSourceState> openSourceStateQuery = new ObservableCollection<OpenSourceState>(openSourceOp.Entities);
            OpenSourceState openSourceStateToEdit = openSourceStateQuery.First();

            if (openSourceStateToEdit != null)
            {
                openSourceStateToEdit.Penetration = _openSourceState.Penetration;
                
            }
            Context.SubmitChanges(_updateOpenSourceState, null);
        }

        public void UpdateOpenSourceProvider(Action<SubmitOperation> submitCallBack, OpenSourceStateProvider openSourceProvider)
        {
            _updateOpenSourceProvider = submitCallBack;
            _openSourceProvider = openSourceProvider;
            var query = Context.GetOpenSourceStateProvidersByIdQuery(openSourceProvider.IdOpenSourceStateProvider);
            Context.Load(query, EditOpenSourceProvider, null);
        }

        private void EditOpenSourceProvider(LoadOperation<OpenSourceStateProvider> openSourceProvider)
        {
            ObservableCollection<OpenSourceStateProvider> openSourceProviderStateQuery = new ObservableCollection<OpenSourceStateProvider>(openSourceProvider.Entities);
            OpenSourceStateProvider openSourceProviderToEdit = openSourceProviderStateQuery.First();

            if (openSourceProviderToEdit != null)
            {
                openSourceProviderToEdit.Invoicing = _openSourceProvider.Invoicing;

            }
            Context.SubmitChanges(_updateOpenSourceProvider, null);
        }

        public void UpdateOpenSourceCommunity(Action<SubmitOperation> submitCallBack, OpenSourceStateCommunity openSourceCommunity)
        {
            _updateOpenSourceCommunity = submitCallBack;
            _openSourceCommunity = openSourceCommunity;
            var query = Context.GetOpenSourceStateCommunitiesByIdQuery(openSourceCommunity.IdOpenSourceCommunityState);
            Context.Load(query, EditOpenSourceCommunity, null);
        }

        private void EditOpenSourceCommunity(LoadOperation<OpenSourceStateCommunity> openSourceCommunity)
        {
            ObservableCollection<OpenSourceStateCommunity> openSourceStateQuery = new ObservableCollection<OpenSourceStateCommunity>(openSourceCommunity.Entities);
            OpenSourceStateCommunity openSourceCommunityToEdit = openSourceStateQuery.First();

            if (openSourceCommunityToEdit != null)
            {

                openSourceCommunityToEdit.UniversityRelationship = _openSourceCommunity.UniversityRelationship;
                openSourceCommunityToEdit.IdContact = _openSourceCommunity.IdContact;

            }
            Context.SubmitChanges(_updateOpenSourceCommunity, null);
        }

        public void UpdateEducationInformationState(Action<SubmitOperation> submitCallBack, EducationInformationState educationInformationState)
        {
            _updateEducationInformationState = submitCallBack;
            _educationInformationState = educationInformationState;
            var query = Context.GetEducationInformationStatesByIdQuery(educationInformationState.IdEducationInformationState);
            Context.Load(query, EditEducationStateInformation, null);
        }

        private void EditEducationStateInformation(LoadOperation<EducationInformationState> educationStateOp)
        {
            ObservableCollection<EducationInformationState> educationInfoQuery = new ObservableCollection<EducationInformationState>(educationStateOp.Entities);
            EducationInformationState educationInfoToEdit = educationInfoQuery.First();

            if (educationInfoToEdit != null)
            {

                educationInfoToEdit.Investment = _educationInformationState.Investment;
                educationInfoToEdit.InvestmentHighSchool = _educationInformationState.InvestmentHighSchool;
                educationInfoToEdit.InvestmentITProjects = _educationInformationState.InvestmentITProjects;
                educationInfoToEdit.InvestmentPublicEducation = _educationInformationState.InvestmentPublicEducation;
                educationInfoToEdit.CurrentExpenditures = _educationInformationState.CurrentExpenditures;
                

            }
            Context.SubmitChanges(_updateEducationInformationState, null);
        }


        public void UpdateStateProgram(Action<SubmitOperation> submitCallBack, StateProgram stateProgram)
        {
            _updateStateProgram = submitCallBack;
            _stateProgram = stateProgram;
            var query = Context.GetStateProgramsByIdQuery(stateProgram.IdStateProgram);
            Context.Load(query, EditStateProgram, null);
        }

        private void EditStateProgram(LoadOperation<StateProgram> stateProgram)
        {
            ObservableCollection<StateProgram> stateProgramQuery = new ObservableCollection<StateProgram>(stateProgram.Entities);
            StateProgram stateProgramToEdit = stateProgramQuery.First();

            if (stateProgramToEdit != null)
            {

                stateProgramToEdit.Investment = _stateProgram.Investment;
                stateProgramToEdit.ROI = _stateProgram.ROI;
                stateProgramToEdit.Progress = _stateProgram.Progress;
                stateProgramToEdit.IdContactMsft = _stateProgram.IdContactMsft;
                stateProgramToEdit.IdContactState = _stateProgram.IdContactState;


            }
            Context.SubmitChanges(_updateStateProgram, null);
        }


        #endregion
    }
}
