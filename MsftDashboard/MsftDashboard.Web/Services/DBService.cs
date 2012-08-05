
namespace MsftDashboard.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using MsftDashboard.Web.Models;


    // Implements application logic using the TestArchiveEntities1 context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DBService : LinqToEntitiesDomainService<TestArchiveEntities1>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'CapacitationCenters' query.
        public IQueryable<CapacitationCenter> GetCapacitationCenters()
        {
            return this.ObjectContext.CapacitationCenters;
        }

        public void InsertCapacitationCenter(CapacitationCenter capacitationCenter)
        {
            if ((capacitationCenter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(capacitationCenter, EntityState.Added);
            }
            else
            {
                this.ObjectContext.CapacitationCenters.AddObject(capacitationCenter);
            }
        }

        public void UpdateCapacitationCenter(CapacitationCenter currentCapacitationCenter)
        {
            this.ObjectContext.CapacitationCenters.AttachAsModified(currentCapacitationCenter, this.ChangeSet.GetOriginal(currentCapacitationCenter));
        }

        public void DeleteCapacitationCenter(CapacitationCenter capacitationCenter)
        {
            if ((capacitationCenter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(capacitationCenter, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.CapacitationCenters.Attach(capacitationCenter);
                this.ObjectContext.CapacitationCenters.DeleteObject(capacitationCenter);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'CapacitationCenterInformations' query.
        public IQueryable<CapacitationCenterInformation> GetCapacitationCenterInformations()
        {
            return this.ObjectContext.CapacitationCenterInformations.Include("SocialCause").Include("SocialOrganization").Include("PopulationAttended").Include("Conectivity").Include("State");
        }

        public IQueryable<CapacitationCenterInformation> GetCapacitationCenterInformationsById(int Id)
        {
            var query = from capCenter in this.ObjectContext.CapacitationCenterInformations.Include("SocialCause").Include("SocialOrganization").Include("PopulationAttended").Include("Conectivity").Include("State")
                        where capCenter.IdCapacitationCenterInformation == Id
                        select capCenter;
            return query;
        }

        public void InsertCapacitationCenterInformation(CapacitationCenterInformation capacitationCenterInformation)
        {
            if ((capacitationCenterInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(capacitationCenterInformation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.CapacitationCenterInformations.AddObject(capacitationCenterInformation);
            }
        }

        public void UpdateCapacitationCenterInformation(CapacitationCenterInformation currentCapacitationCenterInformation)
        {
            this.ObjectContext.CapacitationCenterInformations.AttachAsModified(currentCapacitationCenterInformation, this.ChangeSet.GetOriginal(currentCapacitationCenterInformation));
        }

        public void DeleteCapacitationCenterInformation(CapacitationCenterInformation capacitationCenterInformation)
        {
            if ((capacitationCenterInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(capacitationCenterInformation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.CapacitationCenterInformations.Attach(capacitationCenterInformation);
                this.ObjectContext.CapacitationCenterInformations.DeleteObject(capacitationCenterInformation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Competitions' query.
        public IQueryable<Competition> GetCompetitions()
        {
            var query = from competition in ObjectContext.Competitions.Include("State").
                            Include("Competitor").Include("Owner").Include("TypeSource")
                        orderby competition.DateFrom descending
                        select competition;
            return query;
        }

        public IQueryable<Competition> GetCompetitionsByDate(DateTime initialDate, DateTime finalDate)
        {
            var query = from competition in ObjectContext.Competitions.Include("State").
                           Include("Competitor").Include("Owner").Include("TypeSource")

                        where competition.DateFrom >= initialDate && competition.DateTo <= finalDate
                        select competition;

            return query;
        }

        public IQueryable<Competition> GetCompetitionsId(int Id)
        {
            var query = from competition in ObjectContext.Competitions.Include("State").
                           Include("Competitor").Include("Owner").Include("TypeSource")
                        where competition.IdCompetition == Id
                        select competition;

            return query;
        }

        public void InsertCompetition(Competition competition)
        {
            if ((competition.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(competition, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Competitions.AddObject(competition);
            }
        }

        public void UpdateCompetition(Competition currentCompetition)
        {
            this.ObjectContext.Competitions.AttachAsModified(currentCompetition, this.ChangeSet.GetOriginal(currentCompetition));
        }

        public void DeleteCompetition(Competition competition)
        {
            if ((competition.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(competition, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Competitions.Attach(competition);
                this.ObjectContext.Competitions.DeleteObject(competition);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Competitors' query.
        public IQueryable<Competitor> GetCompetitors()
        {
            return this.ObjectContext.Competitors;
        }

        public void InsertCompetitor(Competitor competitor)
        {
            if ((competitor.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(competitor, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Competitors.AddObject(competitor);
            }
        }

        public void UpdateCompetitor(Competitor currentCompetitor)
        {
            this.ObjectContext.Competitors.AttachAsModified(currentCompetitor, this.ChangeSet.GetOriginal(currentCompetitor));
        }

        public void DeleteCompetitor(Competitor competitor)
        {
            if ((competitor.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(competitor, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Competitors.Attach(competitor);
                this.ObjectContext.Competitors.DeleteObject(competitor);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Conectivities' query.
        public IQueryable<Conectivity> GetConectivities()
        {
            return this.ObjectContext.Conectivities;
        }

        public void InsertConectivity(Conectivity conectivity)
        {
            if ((conectivity.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(conectivity, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Conectivities.AddObject(conectivity);
            }
        }

        public void UpdateConectivity(Conectivity currentConectivity)
        {
            this.ObjectContext.Conectivities.AttachAsModified(currentConectivity, this.ChangeSet.GetOriginal(currentConectivity));
        }

        public void DeleteConectivity(Conectivity conectivity)
        {
            if ((conectivity.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(conectivity, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Conectivities.Attach(conectivity);
                this.ObjectContext.Conectivities.DeleteObject(conectivity);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Contacts' query.

        [Query(ResultLimit = 20)]
        public IQueryable<Contact> GetContacts()
        {
            return this.ObjectContext.Contacts;
        }

        public IQueryable<Contact> GetContactsById(int idContact)
        {
            var query = from contacts in ObjectContext.Contacts
                        where contacts.IdContact == idContact
                        select contacts;
            return query;
        }

        public void InsertContact(Contact contact)
        {
            if ((contact.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(contact, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Contacts.AddObject(contact);
            }
        }

        public void UpdateContact(Contact currentContact)
        {
            this.ObjectContext.Contacts.AttachAsModified(currentContact, this.ChangeSet.GetOriginal(currentContact));
        }

        public void DeleteContact(Contact contact)
        {
            if ((contact.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(contact, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Contacts.Attach(contact);
                this.ObjectContext.Contacts.DeleteObject(contact);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EducationInformationStates' query.
        public IQueryable<EducationInformationState> GetEducationInformationStates()
        {
            return this.ObjectContext.EducationInformationStates.Include("State"); 
        }

        public IQueryable<EducationInformationState> GetEducationInformationStatesById(int Id)
        {
            return from education in this.ObjectContext.EducationInformationStates
                   where education.IdEducationInformationState == Id
                   select education;
        }

        public EducationInformationState GetCurrentEducationInformationStatesByIdState(int Id)
        {
            return (from education in this.ObjectContext.EducationInformationStates.Include("State")
                    .Include("SchoolsInformations").Include("StudentsInformations").Include("TeachersInformations")
                    .Include("MainUniversities").Include("SEPProjectStates").Include("EnlaceTests")
                    where education.IdState ==Id
                    orderby education.Year descending
                    select education
                    ).First<EducationInformationState>(); 
        }


        public void InsertEducationInformationState(EducationInformationState educationInformationState)
        {
            if ((educationInformationState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(educationInformationState, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EducationInformationStates.AddObject(educationInformationState);
            }
        }

        public void UpdateEducationInformationState(EducationInformationState currentEducationInformationState)
        {
            this.ObjectContext.EducationInformationStates.AttachAsModified(currentEducationInformationState, this.ChangeSet.GetOriginal(currentEducationInformationState));
        }

        public void DeleteEducationInformationState(EducationInformationState educationInformationState)
        {
            if ((educationInformationState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(educationInformationState, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EducationInformationStates.Attach(educationInformationState);
                this.ObjectContext.EducationInformationStates.DeleteObject(educationInformationState);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EnlaceTests' query.
        public IQueryable<EnlaceTest> GetEnlaceTests()
        {
            return this.ObjectContext.EnlaceTests;
        }

        public void InsertEnlaceTest(EnlaceTest enlaceTest)
        {
            if ((enlaceTest.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(enlaceTest, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EnlaceTests.AddObject(enlaceTest);
            }
        }

        public void UpdateEnlaceTest(EnlaceTest currentEnlaceTest)
        {
            this.ObjectContext.EnlaceTests.AttachAsModified(currentEnlaceTest, this.ChangeSet.GetOriginal(currentEnlaceTest));
        }

        public void DeleteEnlaceTest(EnlaceTest enlaceTest)
        {
            if ((enlaceTest.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(enlaceTest, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EnlaceTests.Attach(enlaceTest);
                this.ObjectContext.EnlaceTests.DeleteObject(enlaceTest);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'MainUniversities' query.
        public IQueryable<MainUniversity> GetMainUniversities()
        {
            return this.ObjectContext.MainUniversities;
        }

        public void InsertMainUniversity(MainUniversity mainUniversity)
        {
            if ((mainUniversity.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mainUniversity, EntityState.Added);
            }
            else
            {
                this.ObjectContext.MainUniversities.AddObject(mainUniversity);
            }
        }

        public void UpdateMainUniversity(MainUniversity currentMainUniversity)
        {
            this.ObjectContext.MainUniversities.AttachAsModified(currentMainUniversity, this.ChangeSet.GetOriginal(currentMainUniversity));
        }

        public void DeleteMainUniversity(MainUniversity mainUniversity)
        {
            if ((mainUniversity.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mainUniversity, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.MainUniversities.Attach(mainUniversity);
                this.ObjectContext.MainUniversities.DeleteObject(mainUniversity);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'MexicoAgreements' query.
        public IQueryable<MexicoAgreement> GetMexicoAgreements()
        {
            return this.ObjectContext.MexicoAgreements.Include("State").Include("TypeAgreement"); ;
        }

        public IQueryable<MexicoAgreement> GetMexicoAgreementsByDate(DateTime initialDate, DateTime finalDate)
        {
            return from mxAgreements in this.ObjectContext.MexicoAgreements.Include("State").Include("TypeAgreement")
                   where mxAgreements.DateFrom >= initialDate && mxAgreements.DateTo <=finalDate
                   orderby mxAgreements.State.Name,mxAgreements.TypeAgreement.IdTypeAgreement,mxAgreements.DateFrom
                    select mxAgreements ;
        }
        
        public IQueryable<MexicoAgreement> GetMexicoAgreementsById(int Id)
        {
            var query = from mexico in ObjectContext.MexicoAgreements
                        where mexico.IdMexicoAgreements == Id
                        select mexico;

            return query;
        }

        public void InsertMexicoAgreement(MexicoAgreement mexicoAgreement)
        {
            if ((mexicoAgreement.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mexicoAgreement, EntityState.Added);
            }
            else
            {
                this.ObjectContext.MexicoAgreements.AddObject(mexicoAgreement);
            }
        }

        public void UpdateMexicoAgreement(MexicoAgreement currentMexicoAgreement)
        {
            this.ObjectContext.MexicoAgreements.AttachAsModified(currentMexicoAgreement, this.ChangeSet.GetOriginal(currentMexicoAgreement));
        }

        public void DeleteMexicoAgreement(MexicoAgreement mexicoAgreement)
        {
            if ((mexicoAgreement.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mexicoAgreement, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.MexicoAgreements.Attach(mexicoAgreement);
                this.ObjectContext.MexicoAgreements.DeleteObject(mexicoAgreement);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'MicrosoftProgramStates' query.
        public IQueryable<MicrosoftProgramState> GetMicrosoftProgramStates()
        {
            var query = this.ObjectContext.MicrosoftProgramStates.Include("State").Include("Program")
                .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource");
            return query;
        }

        public IQueryable<MicrosoftProgramState> GetMicrosoftProgramStatesByDate(DateTime initialDate, DateTime finalDate)
        {

            var query = from msftProgram in this.ObjectContext.MicrosoftProgramStates.Include("State").Include("Program")
                .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource")
                        where msftProgram.DateFrom >= initialDate && msftProgram.DateTo <= finalDate
                        orderby msftProgram.State.Name, msftProgram.DateFrom
                        select msftProgram;
            return query;
        }

        public IQueryable<MicrosoftProgramState> GetMicrosoftProgramStatesById(int Id)
        {
            var query = from programMsft in this.ObjectContext.MicrosoftProgramStates.Include("State").Include("Program")
               .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource")
                        where programMsft.IdMsftProgramState == Id
                        select programMsft;

            return query;
        }

        public IQueryable<MicrosoftProgramState> GetMicrosoftProgramStatesByIdState(int Id)
        {
            var query = from programMsft in this.ObjectContext.MicrosoftProgramStates.Include("State").Include("Program")
               .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource")
                        orderby programMsft.DateFrom ascending
                        where programMsft.IdState == Id
                        select programMsft;

            return query;
        }

        public void InsertMicrosoftProgramState(MicrosoftProgramState microsoftProgramState)
        {
            if ((microsoftProgramState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(microsoftProgramState, EntityState.Added);
            }
            else
            {
                this.ObjectContext.MicrosoftProgramStates.AddObject(microsoftProgramState);
            }
        }

        public void UpdateMicrosoftProgramState(MicrosoftProgramState currentMicrosoftProgramState)
        {
            this.ObjectContext.MicrosoftProgramStates.AttachAsModified(currentMicrosoftProgramState, this.ChangeSet.GetOriginal(currentMicrosoftProgramState));
        }

        public void DeleteMicrosoftProgramState(MicrosoftProgramState microsoftProgramState)
        {
            if ((microsoftProgramState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(microsoftProgramState, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.MicrosoftProgramStates.Attach(microsoftProgramState);
                this.ObjectContext.MicrosoftProgramStates.DeleteObject(microsoftProgramState);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Months' query.
        public IQueryable<Month> GetMonths()
        {
            return this.ObjectContext.Months;
        }

        public void InsertMonth(Month month)
        {
            if ((month.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(month, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Months.AddObject(month);
            }
        }

        public void UpdateMonth(Month currentMonth)
        {
            this.ObjectContext.Months.AttachAsModified(currentMonth, this.ChangeSet.GetOriginal(currentMonth));
        }

        public void DeleteMonth(Month month)
        {
            if ((month.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(month, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Months.Attach(month);
                this.ObjectContext.Months.DeleteObject(month);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Municipalities' query.
        public IQueryable<Municipality> GetMunicipalities()
        {
            return this.ObjectContext.Municipalities;
        }

        public IQueryable<Municipality> GetMunicipalitiesById(int Id)
        {
            var query = from mun in ObjectContext.Municipalities
                        where mun.IdState == Id
                        select mun;

            return query;
        }

        public void InsertMunicipality(Municipality municipality)
        {
            if ((municipality.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(municipality, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Municipalities.AddObject(municipality);
            }
        }

        public void UpdateMunicipality(Municipality currentMunicipality)
        {
            this.ObjectContext.Municipalities.AttachAsModified(currentMunicipality, this.ChangeSet.GetOriginal(currentMunicipality));
        }

        public void DeleteMunicipality(Municipality municipality)
        {
            if ((municipality.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(municipality, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Municipalities.Attach(municipality);
                this.ObjectContext.Municipalities.DeleteObject(municipality);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'OpenSourceStates' query.
        public IQueryable<OpenSourceState> GetOpenSourceStates()
        {
            return this.ObjectContext.OpenSourceStates.Include("TypeProduct").Include("Product").Include("Penetration").Include("State");
        }

        public IQueryable<OpenSourceState> GetOpenSourceStatesById(int Id)
        {
            return from opensource in this.ObjectContext.OpenSourceStates.Include("TypeProduct").Include("Product").Include("Penetration").Include("State")
                   where opensource.IdOSSState == Id
                   select opensource;
        }

        public void InsertOpenSourceState(OpenSourceState openSourceState)
        {
            if ((openSourceState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(openSourceState, EntityState.Added);
            }
            else
            {
                this.ObjectContext.OpenSourceStates.AddObject(openSourceState);
            }
        }

        public void UpdateOpenSourceState(OpenSourceState currentOpenSourceState)
        {
            this.ObjectContext.OpenSourceStates.AttachAsModified(currentOpenSourceState, this.ChangeSet.GetOriginal(currentOpenSourceState));
        }

        public void DeleteOpenSourceState(OpenSourceState openSourceState)
        {
            if ((openSourceState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(openSourceState, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.OpenSourceStates.Attach(openSourceState);
                this.ObjectContext.OpenSourceStates.DeleteObject(openSourceState);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'OpenSourceStateCommunities' query.
        public IQueryable<OpenSourceStateCommunity> GetOpenSourceStateCommunities()
        {
            return this.ObjectContext.OpenSourceStateCommunities.Include("Contact").Include("State");
        }

        public IQueryable<OpenSourceStateCommunity> GetOpenSourceStateCommunitiesById(int Id)
        {
            var query = from openSourceCommunity in this.ObjectContext.OpenSourceStateCommunities.Include("Contact").Include("State")
                        where openSourceCommunity.IdOpenSourceCommunityState == Id
                        select openSourceCommunity;

            return query;
        }

        public void InsertOpenSourceStateCommunity(OpenSourceStateCommunity openSourceStateCommunity)
        {
            if ((openSourceStateCommunity.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(openSourceStateCommunity, EntityState.Added);
            }
            else
            {
                this.ObjectContext.OpenSourceStateCommunities.AddObject(openSourceStateCommunity);
            }
        }

        public void UpdateOpenSourceStateCommunity(OpenSourceStateCommunity currentOpenSourceStateCommunity)
        {
            this.ObjectContext.OpenSourceStateCommunities.AttachAsModified(currentOpenSourceStateCommunity, this.ChangeSet.GetOriginal(currentOpenSourceStateCommunity));
        }

        public void DeleteOpenSourceStateCommunity(OpenSourceStateCommunity openSourceStateCommunity)
        {
            if ((openSourceStateCommunity.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(openSourceStateCommunity, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.OpenSourceStateCommunities.Attach(openSourceStateCommunity);
                this.ObjectContext.OpenSourceStateCommunities.DeleteObject(openSourceStateCommunity);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'OpenSourceStateProviders' query.
        public IQueryable<OpenSourceStateProvider> GetOpenSourceStateProviders()
        {
            return this.ObjectContext.OpenSourceStateProviders.Include("Product").Include("State");
        }

        public IQueryable<OpenSourceStateProvider> GetOpenSourceStateProvidersById(int Id)
        {
            var query = from openSourceProvider in this.ObjectContext.OpenSourceStateProviders.Include("Product").Include("State")
                        where openSourceProvider.IdOpenSourceStateProvider == Id
                        select openSourceProvider;

            return query;
        }

        public void InsertOpenSourceStateProvider(OpenSourceStateProvider openSourceStateProvider)
        {
            if ((openSourceStateProvider.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(openSourceStateProvider, EntityState.Added);
            }
            else
            {
                this.ObjectContext.OpenSourceStateProviders.AddObject(openSourceStateProvider);
            }
        }

        public void UpdateOpenSourceStateProvider(OpenSourceStateProvider currentOpenSourceStateProvider)
        {
            this.ObjectContext.OpenSourceStateProviders.AttachAsModified(currentOpenSourceStateProvider, this.ChangeSet.GetOriginal(currentOpenSourceStateProvider));
        }

        public void DeleteOpenSourceStateProvider(OpenSourceStateProvider openSourceStateProvider)
        {
            if ((openSourceStateProvider.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(openSourceStateProvider, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.OpenSourceStateProviders.Attach(openSourceStateProvider);
                this.ObjectContext.OpenSourceStateProviders.DeleteObject(openSourceStateProvider);
            }
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Organizations' query.
        public IQueryable<Organization> GetOrganizations()
        {
            return this.ObjectContext.Organizations;
        }

        public void InsertOrganization(Organization organization)
        {
            if ((organization.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(organization, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Organizations.AddObject(organization);
            }
        }

        public void UpdateOrganization(Organization currentOrganization)
        {
            this.ObjectContext.Organizations.AttachAsModified(currentOrganization, this.ChangeSet.GetOriginal(currentOrganization));
        }

        public void DeleteOrganization(Organization organization)
        {
            if ((organization.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(organization, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Organizations.Attach(organization);
                this.ObjectContext.Organizations.DeleteObject(organization);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Partners' query.
        public IQueryable<Partner> GetPartners()
        {
            return this.ObjectContext.Partners;
        }

        public void InsertPartner(Partner partner)
        {
            if ((partner.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(partner, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Partners.AddObject(partner);
            }
        }

        public void UpdatePartner(Partner currentPartner)
        {
            this.ObjectContext.Partners.AttachAsModified(currentPartner, this.ChangeSet.GetOriginal(currentPartner));
        }

        public void DeletePartner(Partner partner)
        {
            if ((partner.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(partner, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Partners.Attach(partner);
                this.ObjectContext.Partners.DeleteObject(partner);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Penetrations' query.
        public IQueryable<Penetration> GetPenetrations()
        {
            return this.ObjectContext.Penetrations;
        }

        public void InsertPenetration(Penetration penetration)
        {
            if ((penetration.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(penetration, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Penetrations.AddObject(penetration);
            }
        }

        public void UpdatePenetration(Penetration currentPenetration)
        {
            this.ObjectContext.Penetrations.AttachAsModified(currentPenetration, this.ChangeSet.GetOriginal(currentPenetration));
        }

        public void DeletePenetration(Penetration penetration)
        {
            if ((penetration.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(penetration, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Penetrations.Attach(penetration);
                this.ObjectContext.Penetrations.DeleteObject(penetration);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PoliticalInformationMunicipalities' query.
        public IQueryable<PoliticalInformationMunicipality> GetPoliticalInformationMunicipalities()
        {
            return this.ObjectContext.PoliticalInformationMunicipalities;
        }


        public IQueryable<PoliticalInformationMunicipality> GetPoliticalInformationMunicipalitiesByIdPoliticState(int Id)
        {
            return from politicMun in  this.ObjectContext.PoliticalInformationMunicipalities.Include("Municipality").Include("PoliticalParty")
                   where politicMun.IdPoliticalInformationState == Id 
                   orderby politicMun.Municipality.Name ascending
                   select politicMun;
        }
        
        public void InsertPoliticalInformationMunicipality(PoliticalInformationMunicipality politicalInformationMunicipality)
        {
            if ((politicalInformationMunicipality.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalInformationMunicipality, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PoliticalInformationMunicipalities.AddObject(politicalInformationMunicipality);
            }
        }

        public void UpdatePoliticalInformationMunicipality(PoliticalInformationMunicipality currentPoliticalInformationMunicipality)
        {
            this.ObjectContext.PoliticalInformationMunicipalities.AttachAsModified(currentPoliticalInformationMunicipality, this.ChangeSet.GetOriginal(currentPoliticalInformationMunicipality));
        }

        public void DeletePoliticalInformationMunicipality(PoliticalInformationMunicipality politicalInformationMunicipality)
        {
            if ((politicalInformationMunicipality.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalInformationMunicipality, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PoliticalInformationMunicipalities.Attach(politicalInformationMunicipality);
                this.ObjectContext.PoliticalInformationMunicipalities.DeleteObject(politicalInformationMunicipality);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PoliticalInformationStates' query.
        public IQueryable<PoliticalInformationState> GetPoliticalInformationStates()
        {
            var query = from politicalState in ObjectContext.PoliticalInformationStates.Include("State").Include("PoliticalParty")
                        orderby politicalState.IdState descending
                        select politicalState;

            return query;

        }

        public IQueryable<PoliticalInformationState> GetPoliticalInformationStatesByDate(DateTime periodDate)
        {
            var query = from politicalState in ObjectContext.PoliticalInformationStates.Include("State").Include("PoliticalParty")
                        where periodDate.Year >= politicalState.DateFrom.Year && periodDate.Year <= politicalState.DateTo.Year
                        orderby politicalState.IdState descending
                        select politicalState;

            return query;

        }

        public IQueryable<PoliticalInformationState> GetPoliticalInformationStatesById(int Id)
        {
            var query = from politicalState in ObjectContext.PoliticalInformationStates.Include("State").Include("PoliticalParty")
                        where politicalState.IdPoliticalInformationState == Id
                        select politicalState;

            return query;
        }

        public void InsertPoliticalInformationState(PoliticalInformationState politicalInformationState)
        {
            if ((politicalInformationState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalInformationState, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PoliticalInformationStates.AddObject(politicalInformationState);
            }
        }

        public void UpdatePoliticalInformationState(PoliticalInformationState currentPoliticalInformationState)
        {
            this.ObjectContext.PoliticalInformationStates.AttachAsModified(currentPoliticalInformationState, this.ChangeSet.GetOriginal(currentPoliticalInformationState));
        }

        public void DeletePoliticalInformationState(PoliticalInformationState politicalInformationState)
        {
            if ((politicalInformationState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalInformationState, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PoliticalInformationStates.Attach(politicalInformationState);
                this.ObjectContext.PoliticalInformationStates.DeleteObject(politicalInformationState);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PoliticalInformationStateFiles' query.
        public IQueryable<PoliticalInformationStateFile> GetPoliticalInformationStateFiles()
        {
            return this.ObjectContext.PoliticalInformationStateFiles;
        }

        public void InsertPoliticalInformationStateFile(PoliticalInformationStateFile politicalInformationStateFile)
        {
            if ((politicalInformationStateFile.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalInformationStateFile, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PoliticalInformationStateFiles.AddObject(politicalInformationStateFile);
            }
        }

        public void UpdatePoliticalInformationStateFile(PoliticalInformationStateFile currentPoliticalInformationStateFile)
        {
            this.ObjectContext.PoliticalInformationStateFiles.AttachAsModified(currentPoliticalInformationStateFile, this.ChangeSet.GetOriginal(currentPoliticalInformationStateFile));
        }

        public void DeletePoliticalInformationStateFile(PoliticalInformationStateFile politicalInformationStateFile)
        {
            if ((politicalInformationStateFile.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalInformationStateFile, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PoliticalInformationStateFiles.Attach(politicalInformationStateFile);
                this.ObjectContext.PoliticalInformationStateFiles.DeleteObject(politicalInformationStateFile);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PoliticalParties' query.
        public IQueryable<PoliticalParty> GetPoliticalParties()
        {
            return this.ObjectContext.PoliticalParties;
        }

        public IQueryable<PoliticalParty> GetPoliticalPartiesById(int Id)
        {
            var query = from politicalParty in ObjectContext.PoliticalParties
                        where politicalParty.IdPoliticalParty == Id
                        select politicalParty;

            return query;
        }

        public void InsertPoliticalParty(PoliticalParty politicalParty)
        {
            if ((politicalParty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalParty, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PoliticalParties.AddObject(politicalParty);
            }
        }

        public void UpdatePoliticalParty(PoliticalParty currentPoliticalParty)
        {
            this.ObjectContext.PoliticalParties.AttachAsModified(currentPoliticalParty, this.ChangeSet.GetOriginal(currentPoliticalParty));
        }

        public void DeletePoliticalParty(PoliticalParty politicalParty)
        {
            if ((politicalParty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(politicalParty, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PoliticalParties.Attach(politicalParty);
                this.ObjectContext.PoliticalParties.DeleteObject(politicalParty);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PopulationAttendeds' query.
        public IQueryable<PopulationAttended> GetPopulationAttendeds()
        {
            return this.ObjectContext.PopulationAttendeds;
        }

        public void InsertPopulationAttended(PopulationAttended populationAttended)
        {
            if ((populationAttended.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(populationAttended, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PopulationAttendeds.AddObject(populationAttended);
            }
        }

        public void UpdatePopulationAttended(PopulationAttended currentPopulationAttended)
        {
            this.ObjectContext.PopulationAttendeds.AttachAsModified(currentPopulationAttended, this.ChangeSet.GetOriginal(currentPopulationAttended));
        }

        public void DeletePopulationAttended(PopulationAttended populationAttended)
        {
            if ((populationAttended.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(populationAttended, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PopulationAttendeds.Attach(populationAttended);
                this.ObjectContext.PopulationAttendeds.DeleteObject(populationAttended);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Products' query.
        public IQueryable<Product> GetProducts()
        {
            return this.ObjectContext.Products;
        }

        public IQueryable<Product> GetProductsByIdTypeProduct(int Id)
        {
            return from product in this.ObjectContext.Products
                   where product.IdTypeProduct == Id
                   select product;
        }

        public void InsertProduct(Product product)
        {
            if ((product.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(product, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Products.AddObject(product);
            }
        }

        public void UpdateProduct(Product currentProduct)
        {
            this.ObjectContext.Products.AttachAsModified(currentProduct, this.ChangeSet.GetOriginal(currentProduct));
        }

        public void DeleteProduct(Product product)
        {
            if ((product.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(product, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Products.Attach(product);
                this.ObjectContext.Products.DeleteObject(product);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Programs' query.
        public IQueryable<Program> GetPrograms()
        {
            return this.ObjectContext.Programs;
        }

        public void InsertProgram(Program program)
        {
            if ((program.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(program, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Programs.AddObject(program);
            }
        }

        public void UpdateProgram(Program currentProgram)
        {
            this.ObjectContext.Programs.AttachAsModified(currentProgram, this.ChangeSet.GetOriginal(currentProgram));
        }

        public void DeleteProgram(Program program)
        {
            if ((program.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(program, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Programs.Attach(program);
                this.ObjectContext.Programs.DeleteObject(program);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SchoolGrades' query.
        public IQueryable<SchoolGrade> GetSchoolGrades()
        {
            return this.ObjectContext.SchoolGrades;
        }

        public void InsertSchoolGrade(SchoolGrade schoolGrade)
        {
            if ((schoolGrade.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolGrade, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SchoolGrades.AddObject(schoolGrade);
            }
        }

        public void UpdateSchoolGrade(SchoolGrade currentSchoolGrade)
        {
            this.ObjectContext.SchoolGrades.AttachAsModified(currentSchoolGrade, this.ChangeSet.GetOriginal(currentSchoolGrade));
        }

        public void DeleteSchoolGrade(SchoolGrade schoolGrade)
        {
            if ((schoolGrade.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolGrade, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SchoolGrades.Attach(schoolGrade);
                this.ObjectContext.SchoolGrades.DeleteObject(schoolGrade);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SchoolLevels' query.
        public IQueryable<SchoolLevel> GetSchoolLevels()
        {
            return this.ObjectContext.SchoolLevels;
        }

        public void InsertSchoolLevel(SchoolLevel schoolLevel)
        {
            if ((schoolLevel.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolLevel, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SchoolLevels.AddObject(schoolLevel);
            }
        }

        public void UpdateSchoolLevel(SchoolLevel currentSchoolLevel)
        {
            this.ObjectContext.SchoolLevels.AttachAsModified(currentSchoolLevel, this.ChangeSet.GetOriginal(currentSchoolLevel));
        }

        public void DeleteSchoolLevel(SchoolLevel schoolLevel)
        {
            if ((schoolLevel.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolLevel, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SchoolLevels.Attach(schoolLevel);
                this.ObjectContext.SchoolLevels.DeleteObject(schoolLevel);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SchoolsInformations' query.
        public IQueryable<SchoolsInformation> GetSchoolsInformations()
        {
            return this.ObjectContext.SchoolsInformations;
        }

        public void InsertSchoolsInformation(SchoolsInformation schoolsInformation)
        {
            if ((schoolsInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolsInformation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SchoolsInformations.AddObject(schoolsInformation);
            }
        }

        public void UpdateSchoolsInformation(SchoolsInformation currentSchoolsInformation)
        {
            this.ObjectContext.SchoolsInformations.AttachAsModified(currentSchoolsInformation, this.ChangeSet.GetOriginal(currentSchoolsInformation));
        }

        public void DeleteSchoolsInformation(SchoolsInformation schoolsInformation)
        {
            if ((schoolsInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolsInformation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SchoolsInformations.Attach(schoolsInformation);
                this.ObjectContext.SchoolsInformations.DeleteObject(schoolsInformation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SchoolTypes' query.
        public IQueryable<SchoolType> GetSchoolTypes()
        {
            return this.ObjectContext.SchoolTypes;
        }

        public void InsertSchoolType(SchoolType schoolType)
        {
            if ((schoolType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SchoolTypes.AddObject(schoolType);
            }
        }

        public void UpdateSchoolType(SchoolType currentSchoolType)
        {
            this.ObjectContext.SchoolTypes.AttachAsModified(currentSchoolType, this.ChangeSet.GetOriginal(currentSchoolType));
        }

        public void DeleteSchoolType(SchoolType schoolType)
        {
            if ((schoolType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(schoolType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SchoolTypes.Attach(schoolType);
                this.ObjectContext.SchoolTypes.DeleteObject(schoolType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SEPProjectStates' query.
        public IQueryable<SEPProjectState> GetSEPProjectStates()
        {
            return this.ObjectContext.SEPProjectStates;
        }

        public void InsertSEPProjectState(SEPProjectState sEPProjectState)
        {
            if ((sEPProjectState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sEPProjectState, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SEPProjectStates.AddObject(sEPProjectState);
            }
        }

        public void UpdateSEPProjectState(SEPProjectState currentSEPProjectState)
        {
            this.ObjectContext.SEPProjectStates.AttachAsModified(currentSEPProjectState, this.ChangeSet.GetOriginal(currentSEPProjectState));
        }

        public void DeleteSEPProjectState(SEPProjectState sEPProjectState)
        {
            if ((sEPProjectState.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sEPProjectState, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SEPProjectStates.Attach(sEPProjectState);
                this.ObjectContext.SEPProjectStates.DeleteObject(sEPProjectState);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SocialCauses' query.
        public IQueryable<SocialCause> GetSocialCauses()
        {
            return this.ObjectContext.SocialCauses;
        }

        public void InsertSocialCause(SocialCause socialCause)
        {
            if ((socialCause.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(socialCause, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SocialCauses.AddObject(socialCause);
            }
        }

        public void UpdateSocialCause(SocialCause currentSocialCause)
        {
            this.ObjectContext.SocialCauses.AttachAsModified(currentSocialCause, this.ChangeSet.GetOriginal(currentSocialCause));
        }

        public void DeleteSocialCause(SocialCause socialCause)
        {
            if ((socialCause.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(socialCause, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SocialCauses.Attach(socialCause);
                this.ObjectContext.SocialCauses.DeleteObject(socialCause);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SocialOrganizations' query.
        public IQueryable<SocialOrganization> GetSocialOrganizations()
        {
            return this.ObjectContext.SocialOrganizations;
        }

        public IQueryable<SocialOrganization> GetSocialOrganizationsById(int Id)
        {
            var query = from socialOrg in ObjectContext.SocialOrganizations
                        where socialOrg.IdSocialOrganization == Id
                        select socialOrg;

            return query;
        }

        public void InsertSocialOrganization(SocialOrganization socialOrganization)
        {
            if ((socialOrganization.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(socialOrganization, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SocialOrganizations.AddObject(socialOrganization);
            }
        }

        public void UpdateSocialOrganization(SocialOrganization currentSocialOrganization)
        {
            this.ObjectContext.SocialOrganizations.AttachAsModified(currentSocialOrganization, this.ChangeSet.GetOriginal(currentSocialOrganization));
        }

        public void DeleteSocialOrganization(SocialOrganization socialOrganization)
        {
            if ((socialOrganization.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(socialOrganization, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SocialOrganizations.Attach(socialOrganization);
                this.ObjectContext.SocialOrganizations.DeleteObject(socialOrganization);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SocialOrganizationInformations' query.
        public IQueryable<SocialOrganizationInformation> GetSocialOrganizationInformations()
        {
            return this.ObjectContext.SocialOrganizationInformations.Include("PopulationAttended").Include("SocialCause").Include("State");
        }

        public IQueryable<SocialOrganizationInformation> GetSocialOrganizationInformationsById(int Id)
        {
            var query = from socOrg in this.ObjectContext.SocialOrganizationInformations
                        where socOrg.IdSocialOrganizationInformation == Id
                        select socOrg;

            return query;
        }

        public void InsertSocialOrganizationInformation(SocialOrganizationInformation socialOrganizationInformation)
        {
            if ((socialOrganizationInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(socialOrganizationInformation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SocialOrganizationInformations.AddObject(socialOrganizationInformation);
            }
        }

        public void UpdateSocialOrganizationInformation(SocialOrganizationInformation currentSocialOrganizationInformation)
        {
            this.ObjectContext.SocialOrganizationInformations.AttachAsModified(currentSocialOrganizationInformation, this.ChangeSet.GetOriginal(currentSocialOrganizationInformation));
        }

        public void DeleteSocialOrganizationInformation(SocialOrganizationInformation socialOrganizationInformation)
        {
            if ((socialOrganizationInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(socialOrganizationInformation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SocialOrganizationInformations.Attach(socialOrganizationInformation);
                this.ObjectContext.SocialOrganizationInformations.DeleteObject(socialOrganizationInformation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Sources' query.
        public IQueryable<Source> GetSources()
        {
            return this.ObjectContext.Sources;
        }

        public void InsertSource(Source source)
        {
            if ((source.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(source, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Sources.AddObject(source);
            }
        }

        public void UpdateSource(Source currentSource)
        {
            this.ObjectContext.Sources.AttachAsModified(currentSource, this.ChangeSet.GetOriginal(currentSource));
        }

        public void DeleteSource(Source source)
        {
            if ((source.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(source, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Sources.Attach(source);
                this.ObjectContext.Sources.DeleteObject(source);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'States' query.
        public IQueryable<State> GetStates()
        {
            return from state in this.ObjectContext.States
                   orderby state.Name ascending   
                   select state;
        }

        public void InsertState(State state)
        {
            if ((state.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(state, EntityState.Added);
            }
            else
            {
                this.ObjectContext.States.AddObject(state);
            }
        }

        public void UpdateState(State currentState)
        {
            this.ObjectContext.States.AttachAsModified(currentState, this.ChangeSet.GetOriginal(currentState));
        }

        public void DeleteState(State state)
        {
            if ((state.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(state, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.States.Attach(state);
                this.ObjectContext.States.DeleteObject(state);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'StateEconomicInfoes' query.
        public IQueryable<StateEconomicInfo> GetStateEconomicInfoes()
        {
            var query = from economy in ObjectContext.StateEconomicInfoes.Include("State")
                        orderby economy.FromDate
                        select economy;
            return query;
        }

        public IQueryable<StateEconomicInfo> GetStateEconomicByIdState(int Id)
        {
            var query = from economy in ObjectContext.StateEconomicInfoes.Include("State")
                        where economy.IdState == Id
                        orderby economy.FromDate descending
                        select economy;
            return query;

        }

        public StateEconomicInfo GetCurrentStateEconomicInfoByIdState(int Id)
        {
            var query = from economy in ObjectContext.StateEconomicInfoes.Include("State")
                        where economy.IdState == Id
                        orderby economy.FromDate descending
                        select economy;
            return query.FirstOrDefault<StateEconomicInfo>();
        }

        public IQueryable<StateEconomicInfo> GetStateEconomicInfoById(int Id)
        {
            var query = from economy in ObjectContext.StateEconomicInfoes.Include("State")
                        where economy.IdStateEconomicInfo == Id
                        select economy;

            return query;
        }

        public void InsertStateEconomicInfo(StateEconomicInfo stateEconomicInfo)
        {
            if ((stateEconomicInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(stateEconomicInfo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.StateEconomicInfoes.AddObject(stateEconomicInfo);
            }
        }

        public void UpdateStateEconomicInfo(StateEconomicInfo currentStateEconomicInfo)
        {
            this.ObjectContext.StateEconomicInfoes.AttachAsModified(currentStateEconomicInfo, this.ChangeSet.GetOriginal(currentStateEconomicInfo));
        }

        public void DeleteStateEconomicInfo(StateEconomicInfo stateEconomicInfo)
        {
            if ((stateEconomicInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(stateEconomicInfo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.StateEconomicInfoes.Attach(stateEconomicInfo);
                this.ObjectContext.StateEconomicInfoes.DeleteObject(stateEconomicInfo);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'StatePrograms' query.
        public IQueryable<StateProgram> GetStatePrograms()
        {
            var query = this.ObjectContext.StatePrograms.Include("State").Include("Program")
                .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource");
            return query;
        }

        public IQueryable<StateProgram> GetStateProgramsByDate(DateTime initialDate, DateTime finalDate)
        {
            var query = from programState in this.ObjectContext.StatePrograms.Include("State").Include("Program")
                .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource")
                 where programState.DateFrom >=initialDate && programState.DateTo <= finalDate
                 orderby programState.State.Name,programState.DateFrom
                 select programState;
            return query;
        }

        public IQueryable<StateProgram> GetStateProgramsById(int Id)
        {
            var query = from programsState in this.ObjectContext.StatePrograms.Include("State").Include("Program")
               .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource")
                        where programsState.IdStateProgram == Id
                        select programsState;

            return query;
        }

        public IQueryable<StateProgram> GetStateProgramsByIdState(int Id)
        {
            var query = from programState in this.ObjectContext.StatePrograms.Include("State").Include("Program")
               .Include("Source").Include("Partner").Include("Contact").Include("Contact1").Include("Owner").Include("TypeSource")
                        orderby programState.DateFrom ascending
                        where programState.IdState == Id
                        select programState;

            return query;
        }


        public void InsertStateProgram(StateProgram stateProgram)
        {
            if ((stateProgram.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(stateProgram, EntityState.Added);
            }
            else
            {
                this.ObjectContext.StatePrograms.AddObject(stateProgram);
            }
        }

        public void UpdateStateProgram(StateProgram currentStateProgram)
        {
            this.ObjectContext.StatePrograms.AttachAsModified(currentStateProgram, this.ChangeSet.GetOriginal(currentStateProgram));
        }

        public void DeleteStateProgram(StateProgram stateProgram)
        {
            if ((stateProgram.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(stateProgram, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.StatePrograms.Attach(stateProgram);
                this.ObjectContext.StatePrograms.DeleteObject(stateProgram);
            }
        }



        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'StudentsInformations' query.
        public IQueryable<StudentsInformation> GetStudentsInformations()
        {
            return this.ObjectContext.StudentsInformations;
        }

        public void InsertStudentsInformation(StudentsInformation studentsInformation)
        {
            if ((studentsInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(studentsInformation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.StudentsInformations.AddObject(studentsInformation);
            }
        }

        public void UpdateStudentsInformation(StudentsInformation currentStudentsInformation)
        {
            this.ObjectContext.StudentsInformations.AttachAsModified(currentStudentsInformation, this.ChangeSet.GetOriginal(currentStudentsInformation));
        }

        public void DeleteStudentsInformation(StudentsInformation studentsInformation)
        {
            if ((studentsInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(studentsInformation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.StudentsInformations.Attach(studentsInformation);
                this.ObjectContext.StudentsInformations.DeleteObject(studentsInformation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TeachersInformations' query.
        public IQueryable<TeachersInformation> GetTeachersInformations()
        {
            return this.ObjectContext.TeachersInformations;
        }

        public void InsertTeachersInformation(TeachersInformation teachersInformation)
        {
            if ((teachersInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(teachersInformation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TeachersInformations.AddObject(teachersInformation);
            }
        }

        public void UpdateTeachersInformation(TeachersInformation currentTeachersInformation)
        {
            this.ObjectContext.TeachersInformations.AttachAsModified(currentTeachersInformation, this.ChangeSet.GetOriginal(currentTeachersInformation));
        }

        public void DeleteTeachersInformation(TeachersInformation teachersInformation)
        {
            if ((teachersInformation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(teachersInformation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TeachersInformations.Attach(teachersInformation);
                this.ObjectContext.TeachersInformations.DeleteObject(teachersInformation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Types' query.
        //public IQueryable<Type> GetTypes()
        //{
        //    return this.ObjectContext.Types;
        //}

        //public void InsertType(Type type)
        //{
        //    if ((type.EntityState != EntityState.Detached))
        //    {
        //        this.ObjectContext.ObjectStateManager.ChangeObjectState(type, EntityState.Added);
        //    }
        //    else
        //    {
        //        this.ObjectContext.Types.AddObject(type);
        //    }
        //}

        //public void UpdateType(Type currentType)
        //{
        //    this.ObjectContext.Types.AttachAsModified(currentType, this.ChangeSet.GetOriginal(currentType));
        //}

        //public void DeleteType(Type type)
        //{
        //    if ((type.EntityState != EntityState.Detached))
        //    {
        //        this.ObjectContext.ObjectStateManager.ChangeObjectState(type, EntityState.Deleted);
        //    }
        //    else
        //    {
        //        this.ObjectContext.Types.Attach(type);
        //        this.ObjectContext.Types.DeleteObject(type);
        //    }
        //}

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TypeAgreements' query.
        public IQueryable<TypeAgreement> GetTypeAgreements()
        {
            return this.ObjectContext.TypeAgreements;
        }

        public void InsertTypeAgreement(TypeAgreement typeAgreement)
        {
            if ((typeAgreement.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeAgreement, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TypeAgreements.AddObject(typeAgreement);
            }
        }

        public void UpdateTypeAgreement(TypeAgreement currentTypeAgreement)
        {
            this.ObjectContext.TypeAgreements.AttachAsModified(currentTypeAgreement, this.ChangeSet.GetOriginal(currentTypeAgreement));
        }

        public void DeleteTypeAgreement(TypeAgreement typeAgreement)
        {
            if ((typeAgreement.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeAgreement, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TypeAgreements.Attach(typeAgreement);
                this.ObjectContext.TypeAgreements.DeleteObject(typeAgreement);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TypeProducts' query.
        public IQueryable<TypeProduct> GetTypeProducts()
        {
            return this.ObjectContext.TypeProducts;
        }

        public void InsertTypeProduct(TypeProduct typeProduct)
        {
            if ((typeProduct.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeProduct, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TypeProducts.AddObject(typeProduct);
            }
        }

        public void UpdateTypeProduct(TypeProduct currentTypeProduct)
        {
            this.ObjectContext.TypeProducts.AttachAsModified(currentTypeProduct, this.ChangeSet.GetOriginal(currentTypeProduct));
        }

        public void DeleteTypeProduct(TypeProduct typeProduct)
        {
            if ((typeProduct.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeProduct, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TypeProducts.Attach(typeProduct);
                this.ObjectContext.TypeProducts.DeleteObject(typeProduct);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TypeSepProjects' query.
        public IQueryable<TypeSepProject> GetTypeSepProjects()
        {
            return this.ObjectContext.TypeSepProjects;
        }

        public void InsertTypeSepProject(TypeSepProject typeSepProject)
        {
            if ((typeSepProject.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeSepProject, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TypeSepProjects.AddObject(typeSepProject);
            }
        }

        public void UpdateTypeSepProject(TypeSepProject currentTypeSepProject)
        {
            this.ObjectContext.TypeSepProjects.AttachAsModified(currentTypeSepProject, this.ChangeSet.GetOriginal(currentTypeSepProject));
        }

        public void DeleteTypeSepProject(TypeSepProject typeSepProject)
        {
            if ((typeSepProject.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeSepProject, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TypeSepProjects.Attach(typeSepProject);
                this.ObjectContext.TypeSepProjects.DeleteObject(typeSepProject);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Universities' query.
        public IQueryable<University> GetUniversities()
        {
            return this.ObjectContext.Universities;
        }

        public IQueryable<University> GetUniversitiesByIdState(int Id)
        {
            return from universities in this.ObjectContext.Universities
                   where universities.IdState == Id
                   select universities;
        }

        public void InsertUniversity(University university)
        {
            if ((university.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(university, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Universities.AddObject(university);
            }
        }

        public void UpdateUniversity(University currentUniversity)
        {
            this.ObjectContext.Universities.AttachAsModified(currentUniversity, this.ChangeSet.GetOriginal(currentUniversity));
        }

        public void DeleteUniversity(University university)
        {
            if ((university.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(university, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Universities.Attach(university);
                this.ObjectContext.Universities.DeleteObject(university);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Years' query.
        public IQueryable<Year> GetYears()
        {
            return this.ObjectContext.Years;
        }

        public void InsertYear(Year year)
        {
            if ((year.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(year, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Years.AddObject(year);
            }
        }

        public void UpdateYear(Year currentYear)
        {
            this.ObjectContext.Years.AttachAsModified(currentYear, this.ChangeSet.GetOriginal(currentYear));
        }

        public void DeleteYear(Year year)
        {
            if ((year.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(year, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Years.Attach(year);
                this.ObjectContext.Years.DeleteObject(year);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Owners' query.
        public IQueryable<Owner> GetOwners()
        {
            return this.ObjectContext.Owners;
        }

        public void InsertOwner(Owner owner)
        {
            if ((owner.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(owner, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Owners.AddObject(owner);
            }
        }

        public void UpdateOwner(Owner currentOwner)
        {
            this.ObjectContext.Owners.AttachAsModified(currentOwner, this.ChangeSet.GetOriginal(currentOwner));
        }

        public void DeleteOwner(Owner owner)
        {
            if ((owner.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(owner, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Owners.Attach(owner);
                this.ObjectContext.Owners.DeleteObject(owner);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TypeSources' query.
        public IQueryable<TypeSource> GetTypeSources()
        {
            return this.ObjectContext.TypeSources;
        }

        public void InsertTypeSource(TypeSource typeSource)
        {
            if ((typeSource.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeSource, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TypeSources.AddObject(typeSource);
            }
        }

        public void UpdateTypeSource(TypeSource currentTypeSource)
        {
            this.ObjectContext.TypeSources.AttachAsModified(currentTypeSource, this.ChangeSet.GetOriginal(currentTypeSource));
        }

        public void DeleteTypeSource(TypeSource typeSource)
        {
            if ((typeSource.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(typeSource, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TypeSources.Attach(typeSource);
                this.ObjectContext.TypeSources.DeleteObject(typeSource);
            }
        }
    }
}

