using System;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;
using System.ServiceModel.DomainServices.Client;

namespace MsftDashboard.Services
{
    public interface IMsftService
    {
        event EventHandler<HasChangesEventArgs> NotifyHasChanges;	

        //Insert operations
        
        void SaveContact(Action<SubmitOperation> submitCallback, Contact contact);
        void SaveEconomyState(Action<SubmitOperation> submitCallback, StateEconomicInfo stateEconomyInfo);
        void SaveCompetition(Action<SubmitOperation> submitCallback, Competition competition);
        void SaveMunicipality(Action<SubmitOperation> submitCallback, object state);
        void SaveMexicoAgreement(Action<SubmitOperation> submitCallBack, MexicoAgreement mexicoAgreement);
        void SavePoliticalState(Action<SubmitOperation> submitCallBack,PoliticalInformationState politicalState);
        void SavePoliticalParty(Action<SubmitOperation> submitCallBack,PoliticalParty politicalParty);
        void SaveSocialOrganizationInformation(Action<SubmitOperation> submitCallBack,SocialOrganizationInformation socOrgInfo);
        void SaveCapacitationCenter(Action<SubmitOperation>submitCallBack,CapacitationCenterInformation capCenter);
        void SaveProgramMsft(Action<SubmitOperation>submitCallBack,MicrosoftProgramState programMsft);
        void SaveOpenSourceState(Action<SubmitOperation>submitCallBack,OpenSourceState openSourceState);
        void SaveOpenSourceCommunity(Action<SubmitOperation> submitCallBack, OpenSourceStateCommunity openSourceCommunity);
        void SaveOpenSourceProvider(Action<SubmitOperation> submitCallBack, OpenSourceStateProvider openSourceProvider);
        void SaveEducationInformationState(Action<SubmitOperation> submitCallBack,EducationInformationState educationInformationState);
        void SaveSepProject(Action<SubmitOperation>submitCallBack,ObservableCollection<SEPProjectState>sepProjectCollection);
        void SaveStateProgram(Action<SubmitOperation> submitCallBack,StateProgram stateProgram);

        //Select operations
        void GetContacts(Action<ObservableCollection<Contact>> getContactsCallBack);
        void GetEconomyStateInformation(Action<ObservableCollection<StateEconomicInfo>> getEconomyStateCallBack);
        void GetPoliticInformation(Action<ObservableCollection<PoliticalInformationState>> getPoliticStateCallBack);
        void GetCompetitionInformation(Action<ObservableCollection<Competition>> getCompetitionCallBack);
        void GetMunicipalities(Action<ObservableCollection<Municipality>> getMunicipalityCallBack,int IdState);
        void GetMexicoAgreements(Action<ObservableCollection<MexicoAgreement>> getMexicoAgreementCallback);
        void GetEducationStateInformation(Action<ObservableCollection<EducationInformationState>> getEducationStateCallBack);
        void GetOpenSourceStateInformation(Action<ObservableCollection<OpenSourceState>> getOpenSourceStateCallBack);
        void GetMicrosoftProgramState(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramCallBack);
        void GetSocialOrganizationInformation(Action<ObservableCollection<SocialOrganizationInformation>> getSocialOrganizationInfoCallBack);
        void GetCapacitationCenter(Action<ObservableCollection<CapacitationCenterInformation>> getCapacitationCenterCallBack);
        void GetOpenSourceStateProvider(Action<ObservableCollection<OpenSourceStateProvider>> getOpenSourceProviderCallBack);
        void GetOpenSourceStateCommunity(Action<ObservableCollection<OpenSourceStateCommunity>> getOpenSourceCommunityCallBack);
        void GetEconomyStateInformationByState(Action<ObservableCollection<StateEconomicInfo>> getEconomyStateCallBack,int IdState);
        void GetMicrosoftProgramStateByState(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramCallBack,int IdState);
        void GetMicrosoftProgramStatesById(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramStateCallBack, int Id);
        void GetProgramState(Action<ObservableCollection<StateProgram>> getStateProgramCallBack);
        void GetProgramStateByState(Action<ObservableCollection<StateProgram>> getStateProgramCallBack, int IdState);
        void GetProgramStateById(Action<ObservableCollection<StateProgram>> getStateProgramCallBack, int Id);
        void GetPoliticalStateInformationByDate(Action<ObservableCollection<PoliticalInformationState>> getPoliticalStateCallBack, DateTime periodDate);
        void GetPoliticalMunicipalityByIdPoliticalState(Action<ObservableCollection<PoliticalInformationMunicipality>>getPoliticalMunicipalityCallBack,int Id);
        void GetMexicoAgreementsByDate(Action<ObservableCollection<MexicoAgreement>> getMexicoAgreementCallback,DateTime initialDate,DateTime finalDate);
        void GetMicrosoftProgramStateByDate(Action<ObservableCollection<MicrosoftProgramState>> getMsftProgramCallBack,DateTime initialDate,DateTime finalDate);
        void GetProgramStateByDate(Action<ObservableCollection<StateProgram>> getStateProgramCallBack, DateTime initialDate, DateTime finalDate);
        void GetCompetitionByDate(Action<ObservableCollection<Competition>>getCompetitonCallBack,DateTime initialDate, DateTime finalDate);

        //Select Operations Catalogs
        void GetStates(Action<ObservableCollection<State>> getStatesCallBack);
        void GetYears(Action<ObservableCollection<Year>> getYearCallBack);
        void GetCompetitor(Action<ObservableCollection<Competitor>> getCompetitorCallBack);
        void GetTypeAgreement(Action<ObservableCollection<TypeAgreement>> getTypeAgreementCallBack);
        void GetPoliticalParty(Action<ObservableCollection<PoliticalParty>> getPoliticalPartyCallBack);
        void GetPopulationAttended(Action<ObservableCollection<PopulationAttended>> getPopulationCallBack);
        void GetSocialCause(Action<ObservableCollection<SocialCause>>getSocialCauseCallBack);
        void GetSocialOrganization(Action<ObservableCollection<SocialOrganization>> getSocialOrganizationCallBack);
        void GetConectivity(Action<ObservableCollection<Conectivity>> getConectivityCallBack);
        void GetPartners(Action<ObservableCollection<Partner>> getPartnersCallBack);
        void GetPrograms(Action<ObservableCollection<Program>> getProgramsCallBack);
        void GetSources(Action<ObservableCollection<Source>> getSourcesCallBack);
        void GetTypeProduct(Action<ObservableCollection<TypeProduct>> getTypeProductCallBack);
        void GetProduct(Action<ObservableCollection<Product>> getProductCallBack);
        void GetPenetration(Action<ObservableCollection<Penetration>> getPenetrationCallBack);
        void GetProductByIdTypeProduct(Action<ObservableCollection<Product>> getProductCallBack,int IdTypeProduct);
        void GetSchoolLevels(Action<ObservableCollection<SchoolLevel>>getSchoolLevelsCallBack);
        void GetSchoolGrade(Action<ObservableCollection<SchoolGrade>> getSchoolGradeCallBack);
        void GetSchoolType(Action<ObservableCollection<SchoolType>> getSchoolTypeCallBack);
        void GetTypeSepProject(Action<ObservableCollection<TypeSepProject>> getTypeSepProjectCallBack);
        void GetUniversitiesByState(Action<ObservableCollection<University>>getUniversitiesCallBack,int IdState);
        //void GetCurrentTIme(Action<ObservableCollection<DateTime>> getTimeCallBack);
        
        void GetCurrentStateEconomicInfo(Action<StateEconomicInfo> getCurrentStateEconomicInfo,int idState);
        void GetCurrentEducationStateInfo(Action<EducationInformationState> getCurrentEducationInfo,int IdState);
        


        //Update operations
        void UpdateContact(Action<SubmitOperation> submitCallback, Contact contact);
        void UpdateStateEconomyInfo(Action<SubmitOperation> submitCallback, StateEconomicInfo stateEconomyInfo);
        void UpdateCompetition(Action<SubmitOperation> submitCallback, Competition competition);
        void UpdateMexicoAgreement(Action<SubmitOperation> submitCallback, MexicoAgreement mexicoAgreement);
        void UpdatePoliticalState(Action<SubmitOperation> submitCallback, PoliticalInformationState politicalState);
        void UpdatePoliticalParty(Action<SubmitOperation> submitCallBack,PoliticalParty politicalParty);
        void UpdateSocialOrganizationInformation(Action<SubmitOperation> submitCallBack,SocialOrganizationInformation socialOrgInfo);
        void UpdateCapacitationCenter(Action<SubmitOperation> submitCallBack,CapacitationCenterInformation capCenter);
        void UpdateProgramMsft(Action<SubmitOperation> submitCallBack,MicrosoftProgramState msftProgram);
        void UpdateOpenSourceState(Action<SubmitOperation> submitCallBack, OpenSourceState openSourceState);
        void UpdateOpenSourceProvider(Action<SubmitOperation> submitCallBack, OpenSourceStateProvider openSourceProvider);
        void UpdateOpenSourceCommunity(Action<SubmitOperation> submitCallBack, OpenSourceStateCommunity openSourceCommunity);
        void UpdateEducationInformationState(Action<SubmitOperation> submitCallBack, EducationInformationState educationInformationState);
        void UpdateStateProgram(Action<SubmitOperation> submitCallBack, StateProgram stateProgram);
    }
}
