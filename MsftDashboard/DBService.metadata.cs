
namespace MsftDashboard.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies CapacitationCenterMetadata as the class
    // that carries additional metadata for the CapacitationCenter class.
    [MetadataTypeAttribute(typeof(CapacitationCenter.CapacitationCenterMetadata))]
    public partial class CapacitationCenter
    {

        // This class allows you to attach custom attributes to properties
        // of the CapacitationCenter class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CapacitationCenterMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CapacitationCenterMetadata()
            {
            }

            public Conectivity Conectivity { get; set; }

            public DateTime DateFrom { get; set; }

            public int IdCapacitationCenterInformation { get; set; }

            public int IdConectivity { get; set; }

            public int IdPopulationAttended { get; set; }

            public int IdSocialCause { get; set; }

            public int IdSocialOrganization { get; set; }

            public int IdState { get; set; }

            public double Investment { get; set; }

            public string Name { get; set; }

            public int NumberOfTrainingUsers { get; set; }

            public int NumberOfUsers { get; set; }

            public PopulationAttended PopulationAttended { get; set; }

            public SocialCause SocialCause { get; set; }

            public SocialOrganization SocialOrganization { get; set; }

            public double SoftwareInvesment { get; set; }

            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CapacitationCenterInformationMetadata as the class
    // that carries additional metadata for the CapacitationCenterInformation class.
    [MetadataTypeAttribute(typeof(CapacitationCenterInformation.CapacitationCenterInformationMetadata))]
    public partial class CapacitationCenterInformation
    {

        // This class allows you to attach custom attributes to properties
        // of the CapacitationCenterInformation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CapacitationCenterInformationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CapacitationCenterInformationMetadata()
            {
            }

            [Include]
            public Conectivity Conectivity { get; set; }

            public Nullable<DateTime> DateFrom { get; set; }

            public int IdCapacitationCenterInformation { get; set; }

            public int IdConectivity { get; set; }

            public int IdPopulationAttended { get; set; }

            public int IdSocialCause { get; set; }

            public int IdSocialOrganization { get; set; }

            public Nullable<int> IdState { get; set; }

            public double Investment { get; set; }

            public string Name { get; set; }

            public int NumberOfTrainingUsers { get; set; }

            public int NumberOfUsers { get; set; }

            [Include]
            public PopulationAttended PopulationAttended { get; set; }

            [Include]
            public SocialCause SocialCause { get; set; }

            [Include]
            public SocialOrganization SocialOrganization { get; set; }

            public double SoftwareInvesment { get; set; }

            [Include]
            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CompetitionMetadata as the class
    // that carries additional metadata for the Competition class.
    [MetadataTypeAttribute(typeof(Competition.CompetitionMetadata))]
    public partial class Competition
    {

        // This class allows you to attach custom attributes to properties
        // of the Competition class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CompetitionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CompetitionMetadata()
            {
            }

            [Include]
            public Competitor Competitor { get; set; }

            public DateTime DateFrom { get; set; }

            public Nullable<DateTime> DateTo { get; set; }

            public int IdCompetition { get; set; }

            public int IdCompetitor { get; set; }

            public int IdOwner { get; set; }

            public Nullable<int> IdState { get; set; }

            public int IdType { get; set; }

            public double Investment { get; set; }

            public Nullable<int> Number { get; set; }

            public string Observations { get; set; }

            [Include]
            public Owner Owner { get; set; }

            public Nullable<int> Progress { get; set; }

            public double ROI { get; set; }

            [Include]
            public State State { get; set; }

            [Include]
            public TypeSource TypeSource { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CompetitorMetadata as the class
    // that carries additional metadata for the Competitor class.
    [MetadataTypeAttribute(typeof(Competitor.CompetitorMetadata))]
    public partial class Competitor
    {

        // This class allows you to attach custom attributes to properties
        // of the Competitor class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CompetitorMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CompetitorMetadata()
            {
            }

            public EntityCollection<Competition> Competitions { get; set; }

            public int IdCompetitor { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ConectivityMetadata as the class
    // that carries additional metadata for the Conectivity class.
    [MetadataTypeAttribute(typeof(Conectivity.ConectivityMetadata))]
    public partial class Conectivity
    {

        // This class allows you to attach custom attributes to properties
        // of the Conectivity class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ConectivityMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ConectivityMetadata()
            {
            }

            public EntityCollection<CapacitationCenterInformation> CapacitationCenterInformations { get; set; }

            public EntityCollection<CapacitationCenter> CapacitationCenters { get; set; }

            public int IdConectivity { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ContactMetadata as the class
    // that carries additional metadata for the Contact class.
    [MetadataTypeAttribute(typeof(Contact.ContactMetadata))]
    public partial class Contact
    {

        // This class allows you to attach custom attributes to properties
        // of the Contact class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ContactMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ContactMetadata()
            {
            }

            public string CellPhone { get; set; }

            public string Email { get; set; }

            public string FirstName { get; set; }

            public int IdContact { get; set; }

            public string LastName { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates1 { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }

            public EntityCollection<StateProgram> StatePrograms1 { get; set; }

            public EntityCollection<OpenSourceStateCommunity> OpenSourceStateCommunities { get; set; }

            public Nullable<bool> Status { get; set; }

            public string Telephone { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies EducationInformationStateMetadata as the class
    // that carries additional metadata for the EducationInformationState class.
    [MetadataTypeAttribute(typeof(EducationInformationState.EducationInformationStateMetadata))]
    public partial class EducationInformationState
    {

        // This class allows you to attach custom attributes to properties
        // of the EducationInformationState class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EducationInformationStateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EducationInformationStateMetadata()
            {
            }

            public double CurrentExpenditures { get; set; }

            [Include]
            public EntityCollection<EnlaceTest> EnlaceTests { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdState { get; set; }

            public double Investment { get; set; }

            public double InvestmentHighSchool { get; set; }

            public double InvestmentITProjects { get; set; }

            public double InvestmentPublicEducation { get; set; }

            [Include]
            public EntityCollection<MainUniversity> MainUniversities { get; set; }

            public int NumberInvestigators { get; set; }

            [Include]
            public EntityCollection<SchoolsInformation> SchoolsInformations { get; set; }

            [Include]
            public EntityCollection<SEPProjectState> SEPProjectStates { get; set; }

            [Include]
            public State State { get; set; }

            [Include]
            public EntityCollection<StudentsInformation> StudentsInformations { get; set; }

            [Include]
            public EntityCollection<TeachersInformation> TeachersInformations { get; set; }

            public int Year { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies EnlaceTestMetadata as the class
    // that carries additional metadata for the EnlaceTest class.
    [MetadataTypeAttribute(typeof(EnlaceTest.EnlaceTestMetadata))]
    public partial class EnlaceTest
    {

        // This class allows you to attach custom attributes to properties
        // of the EnlaceTest class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EnlaceTestMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EnlaceTestMetadata()
            {
            }

            public EducationInformationState EducationInformationState { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdEnlaceTest { get; set; }

            public int IdSchoolGrade { get; set; }

            public long Number { get; set; }

            public SchoolGrade SchoolGrade { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MainUniversityMetadata as the class
    // that carries additional metadata for the MainUniversity class.
    [MetadataTypeAttribute(typeof(MainUniversity.MainUniversityMetadata))]
    public partial class MainUniversity
    {

        // This class allows you to attach custom attributes to properties
        // of the MainUniversity class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MainUniversityMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MainUniversityMetadata()
            {
            }

            public EducationInformationState EducationInformationState { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdMainUniversitie { get; set; }

            public int IdUniversity { get; set; }

            public int Penetration { get; set; }

            public University University { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MexicoAgreementMetadata as the class
    // that carries additional metadata for the MexicoAgreement class.
    [MetadataTypeAttribute(typeof(MexicoAgreement.MexicoAgreementMetadata))]
    public partial class MexicoAgreement
    {

        // This class allows you to attach custom attributes to properties
        // of the MexicoAgreement class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MexicoAgreementMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MexicoAgreementMetadata()
            {
            }

            public DateTime DateFrom { get; set; }

            public DateTime DateTo { get; set; }

            public int IdMexicoAgreements { get; set; }

            public int IdState { get; set; }

            public int IdTypeAgreement { get; set; }

            public string Observations { get; set; }

            public int Progress { get; set; }

            [Include]
            public State State { get; set; }

            [Include]
            public TypeAgreement TypeAgreement { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MicrosoftProgramStateMetadata as the class
    // that carries additional metadata for the MicrosoftProgramState class.
    [MetadataTypeAttribute(typeof(MicrosoftProgramState.MicrosoftProgramStateMetadata))]
    public partial class MicrosoftProgramState
    {

        // This class allows you to attach custom attributes to properties
        // of the MicrosoftProgramState class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MicrosoftProgramStateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MicrosoftProgramStateMetadata()
            {
            }

            [Include]
            public Contact Contact { get; set; }

            [Include]
            public Contact Contact1 { get; set; }

            public Nullable<DateTime> DateFrom { get; set; }

            public Nullable<DateTime> DateTo { get; set; }

            public Nullable<int> IdContactMsft { get; set; }

            public Nullable<int> IdContactState { get; set; }

            public int IdMsftProgramState { get; set; }

            public int IdOwner { get; set; }

            public int IdPartner { get; set; }

            public int IdProgram { get; set; }

            public int IdSource { get; set; }

            public int IdState { get; set; }

            public Nullable<int> IdType { get; set; }

            public Nullable<double> Investment { get; set; }

            public Nullable<int> Number { get; set; }

            [Include]
            public Owner Owner { get; set; }

            [Include]
            public Partner Partner { get; set; }

            [Include]
            public Program Program { get; set; }

            public Nullable<int> Progress { get; set; }

            public Nullable<double> ROI { get; set; }

            [Include]
            public Source Source { get; set; }
            
            [Include]
            public State State { get; set; }
            
            [Include]
            public TypeSource TypeSource { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MonthMetadata as the class
    // that carries additional metadata for the Month class.
    [MetadataTypeAttribute(typeof(Month.MonthMetadata))]
    public partial class Month
    {

        // This class allows you to attach custom attributes to properties
        // of the Month class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MonthMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MonthMetadata()
            {
            }

            public int Id { get; set; }

            public string Monts { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MunicipalityMetadata as the class
    // that carries additional metadata for the Municipality class.
    [MetadataTypeAttribute(typeof(Municipality.MunicipalityMetadata))]
    public partial class Municipality
    {

        // This class allows you to attach custom attributes to properties
        // of the Municipality class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MunicipalityMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MunicipalityMetadata()
            {
            }

            public int IdMunicipality { get; set; }

            public int IdState { get; set; }

            public bool MainMunicipality { get; set; }

            public string Name { get; set; }

            public EntityCollection<PoliticalInformationMunicipality> PoliticalInformationMunicipalities { get; set; }

            public Nullable<long> Population { get; set; }

            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OpenSourceStateMetadata as the class
    // that carries additional metadata for the OpenSourceState class.
    [MetadataTypeAttribute(typeof(OpenSourceState.OpenSourceStateMetadata))]
    public partial class OpenSourceState
    {

        // This class allows you to attach custom attributes to properties
        // of the OpenSourceState class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OpenSourceStateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OpenSourceStateMetadata()
            {
            }

            public int IdOSSState { get; set; }

            public int IdPenetration { get; set; }

            public int IdProduct { get; set; }

            public int IdState { get; set; }

            public int IdTypeProduct { get; set; }

            [Include]
            public Penetration Penetration { get; set; }

            [Include]
            public Product Product { get; set; }

            [Include]
            public State State { get; set; }

            [Include]
            public TypeProduct TypeProduct { get; set; }

            public Nullable<int> Year { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OpenSourceStateCommunityMetadata as the class
    // that carries additional metadata for the OpenSourceStateCommunity class.
    [MetadataTypeAttribute(typeof(OpenSourceStateCommunity.OpenSourceStateCommunityMetadata))]
    public partial class OpenSourceStateCommunity
    {

        // This class allows you to attach custom attributes to properties
        // of the OpenSourceStateCommunity class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OpenSourceStateCommunityMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OpenSourceStateCommunityMetadata()
            {
            }

            [Include]
            public Contact Contact { get; set; }

            public int IdContact { get; set; }

            public int IdOpenSourceCommunityState { get; set; }

            public Nullable<int> IdState { get; set; }

            public string Name { get; set; }

            [Include]
            public State State { get; set; }

            public string UniversityRelationship { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OpenSourceStateProviderMetadata as the class
    // that carries additional metadata for the OpenSourceStateProvider class.
    [MetadataTypeAttribute(typeof(OpenSourceStateProvider.OpenSourceStateProviderMetadata))]
    public partial class OpenSourceStateProvider
    {

        // This class allows you to attach custom attributes to properties
        // of the OpenSourceStateProvider class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OpenSourceStateProviderMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OpenSourceStateProviderMetadata()
            {
            }

            public DateTime DateFrom { get; set; }

            public int IdOpenSourceStateProvider { get; set; }

            public int IdProduct { get; set; }

            public Nullable<int> IdState { get; set; }

            public double Invoicing { get; set; }

            public string Name { get; set; }

            [Include]
            public Product Product { get; set; }

            [Include]
            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OrganizationMetadata as the class
    // that carries additional metadata for the Organization class.
    [MetadataTypeAttribute(typeof(Organization.OrganizationMetadata))]
    public partial class Organization
    {

        // This class allows you to attach custom attributes to properties
        // of the Organization class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OrganizationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OrganizationMetadata()
            {
            }

            public int IdOrganization { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PartnerMetadata as the class
    // that carries additional metadata for the Partner class.
    [MetadataTypeAttribute(typeof(Partner.PartnerMetadata))]
    public partial class Partner
    {

        // This class allows you to attach custom attributes to properties
        // of the Partner class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PartnerMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PartnerMetadata()
            {
            }

            public int IdPartner { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public string Name { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PenetrationMetadata as the class
    // that carries additional metadata for the Penetration class.
    [MetadataTypeAttribute(typeof(Penetration.PenetrationMetadata))]
    public partial class Penetration
    {

        // This class allows you to attach custom attributes to properties
        // of the Penetration class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PenetrationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PenetrationMetadata()
            {
            }

            public int IdPenetration { get; set; }

            public string Name { get; set; }

            public EntityCollection<OpenSourceState> OpenSourceStates { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PoliticalInformationMunicipalityMetadata as the class
    // that carries additional metadata for the PoliticalInformationMunicipality class.
    [MetadataTypeAttribute(typeof(PoliticalInformationMunicipality.PoliticalInformationMunicipalityMetadata))]
    public partial class PoliticalInformationMunicipality
    {

        // This class allows you to attach custom attributes to properties
        // of the PoliticalInformationMunicipality class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PoliticalInformationMunicipalityMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PoliticalInformationMunicipalityMetadata()
            {
            }

            public DateTime DateFrom { get; set; }

            public DateTime DateTo { get; set; }

            public string DevelopmentPlan { get; set; }

            public int IdMunicipality { get; set; }

            public int IdPoliticalInformationMunicipality { get; set; }

            public int IdPoliticalInformationState { get; set; }

            public int IdPoliticalParty { get; set; }

            [Include]
            public Municipality Municipality { get; set; }

            public string Observations { get; set; }

            [Include]
            public PoliticalParty PoliticalParty { get; set; }

            public string Sectorials { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PoliticalInformationStateMetadata as the class
    // that carries additional metadata for the PoliticalInformationState class.
    [MetadataTypeAttribute(typeof(PoliticalInformationState.PoliticalInformationStateMetadata))]
    public partial class PoliticalInformationState
    {

        // This class allows you to attach custom attributes to properties
        // of the PoliticalInformationState class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PoliticalInformationStateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PoliticalInformationStateMetadata()
            {
            }

            public DateTime DateFrom { get; set; }

            public DateTime DateTo { get; set; }

            public string DevelopmentPlan { get; set; }

            public int IdPoliticalInformationState { get; set; }

            public int IdPoliticalParty { get; set; }

            public int IdState { get; set; }

            public string Observations { get; set; }

            public EntityCollection<PoliticalInformationStateFile> PoliticalInformationStateFiles { get; set; }

            [Include]
            public PoliticalParty PoliticalParty { get; set; }

            public string Sectorials { get; set; }

            [Include]
            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PoliticalInformationStateFileMetadata as the class
    // that carries additional metadata for the PoliticalInformationStateFile class.
    [MetadataTypeAttribute(typeof(PoliticalInformationStateFile.PoliticalInformationStateFileMetadata))]
    public partial class PoliticalInformationStateFile
    {

        // This class allows you to attach custom attributes to properties
        // of the PoliticalInformationStateFile class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PoliticalInformationStateFileMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PoliticalInformationStateFileMetadata()
            {
            }

            public byte[] FileData { get; set; }

            public string FileName { get; set; }

            public int IdFilePoliticalStateInformation { get; set; }

            public int IdPoliticalInformationState { get; set; }

            public PoliticalInformationState PoliticalInformationState { get; set; }

            public Guid RowGuid { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PoliticalPartyMetadata as the class
    // that carries additional metadata for the PoliticalParty class.
    [MetadataTypeAttribute(typeof(PoliticalParty.PoliticalPartyMetadata))]
    public partial class PoliticalParty
    {

        // This class allows you to attach custom attributes to properties
        // of the PoliticalParty class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PoliticalPartyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PoliticalPartyMetadata()
            {
            }

            public string Color { get; set; }

            public Nullable<int> ColorIndex { get; set; }

            public int IdPoliticalParty { get; set; }

            public string Name { get; set; }

            public EntityCollection<PoliticalInformationMunicipality> PoliticalInformationMunicipalities { get; set; }

            public EntityCollection<PoliticalInformationState> PoliticalInformationStates { get; set; }

            public string ShortName { get; set; }

            public bool Status { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PopulationAttendedMetadata as the class
    // that carries additional metadata for the PopulationAttended class.
    [MetadataTypeAttribute(typeof(PopulationAttended.PopulationAttendedMetadata))]
    public partial class PopulationAttended
    {

        // This class allows you to attach custom attributes to properties
        // of the PopulationAttended class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PopulationAttendedMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PopulationAttendedMetadata()
            {
            }

            public EntityCollection<CapacitationCenterInformation> CapacitationCenterInformations { get; set; }

            public EntityCollection<CapacitationCenter> CapacitationCenters { get; set; }

            public int IdPopulationAttended { get; set; }

            public string Name { get; set; }

            public EntityCollection<SocialOrganizationInformation> SocialOrganizationInformations { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ProductMetadata as the class
    // that carries additional metadata for the Product class.
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product
    {

        // This class allows you to attach custom attributes to properties
        // of the Product class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProductMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProductMetadata()
            {
            }

            public int IdProduct { get; set; }

            public int IdTypeProduct { get; set; }

            public string Name { get; set; }

            public bool OpenSource { get; set; }

            public EntityCollection<OpenSourceStateProvider> OpenSourceStateProviders { get; set; }

            public EntityCollection<OpenSourceState> OpenSourceStates { get; set; }

            public TypeProduct TypeProduct { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ProgramMetadata as the class
    // that carries additional metadata for the Program class.
    [MetadataTypeAttribute(typeof(Program.ProgramMetadata))]
    public partial class Program
    {

        // This class allows you to attach custom attributes to properties
        // of the Program class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProgramMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProgramMetadata()
            {
            }

            public int IdProgram { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public string Name { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SchoolGradeMetadata as the class
    // that carries additional metadata for the SchoolGrade class.
    [MetadataTypeAttribute(typeof(SchoolGrade.SchoolGradeMetadata))]
    public partial class SchoolGrade
    {

        // This class allows you to attach custom attributes to properties
        // of the SchoolGrade class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SchoolGradeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SchoolGradeMetadata()
            {
            }

            public EntityCollection<EnlaceTest> EnlaceTests { get; set; }

            public int IdSchoolGrade { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SchoolLevelMetadata as the class
    // that carries additional metadata for the SchoolLevel class.
    [MetadataTypeAttribute(typeof(SchoolLevel.SchoolLevelMetadata))]
    public partial class SchoolLevel
    {

        // This class allows you to attach custom attributes to properties
        // of the SchoolLevel class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SchoolLevelMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SchoolLevelMetadata()
            {
            }

            public int IdSchoolLevel { get; set; }

            public string Name { get; set; }

            public EntityCollection<SchoolsInformation> SchoolsInformations { get; set; }

            public EntityCollection<StudentsInformation> StudentsInformations { get; set; }

            public EntityCollection<TeachersInformation> TeachersInformations { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SchoolsInformationMetadata as the class
    // that carries additional metadata for the SchoolsInformation class.
    [MetadataTypeAttribute(typeof(SchoolsInformation.SchoolsInformationMetadata))]
    public partial class SchoolsInformation
    {

        // This class allows you to attach custom attributes to properties
        // of the SchoolsInformation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SchoolsInformationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SchoolsInformationMetadata()
            {
            }

            public EducationInformationState EducationInformationState { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdSchoolInformation { get; set; }

            public int IdSchoolLevel { get; set; }

            public int IdSchoolType { get; set; }

            public int Number { get; set; }

            public SchoolLevel SchoolLevel { get; set; }

            public SchoolType SchoolType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SchoolTypeMetadata as the class
    // that carries additional metadata for the SchoolType class.
    [MetadataTypeAttribute(typeof(SchoolType.SchoolTypeMetadata))]
    public partial class SchoolType
    {

        // This class allows you to attach custom attributes to properties
        // of the SchoolType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SchoolTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SchoolTypeMetadata()
            {
            }

            public int IdSchoolType { get; set; }

            public string Name { get; set; }

            public EntityCollection<SchoolsInformation> SchoolsInformations { get; set; }

            public EntityCollection<StudentsInformation> StudentsInformations { get; set; }

            public EntityCollection<TeachersInformation> TeachersInformations { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SEPProjectStateMetadata as the class
    // that carries additional metadata for the SEPProjectState class.
    [MetadataTypeAttribute(typeof(SEPProjectState.SEPProjectStateMetadata))]
    public partial class SEPProjectState
    {

        // This class allows you to attach custom attributes to properties
        // of the SEPProjectState class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SEPProjectStateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SEPProjectStateMetadata()
            {
            }

            public EducationInformationState EducationInformationState { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdSepProjectState { get; set; }

            public int IdTypeSepProject { get; set; }

            public long Percentage { get; set; }

            public TypeSepProject TypeSepProject { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SocialCauseMetadata as the class
    // that carries additional metadata for the SocialCause class.
    [MetadataTypeAttribute(typeof(SocialCause.SocialCauseMetadata))]
    public partial class SocialCause
    {

        // This class allows you to attach custom attributes to properties
        // of the SocialCause class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SocialCauseMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SocialCauseMetadata()
            {
            }

            public EntityCollection<CapacitationCenterInformation> CapacitationCenterInformations { get; set; }

            public EntityCollection<CapacitationCenter> CapacitationCenters { get; set; }

            public int IdSocialCause { get; set; }

            public string Name { get; set; }

            public EntityCollection<SocialOrganizationInformation> SocialOrganizationInformations { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SocialOrganizationMetadata as the class
    // that carries additional metadata for the SocialOrganization class.
    [MetadataTypeAttribute(typeof(SocialOrganization.SocialOrganizationMetadata))]
    public partial class SocialOrganization
    {

        // This class allows you to attach custom attributes to properties
        // of the SocialOrganization class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SocialOrganizationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SocialOrganizationMetadata()
            {
            }

            public EntityCollection<CapacitationCenterInformation> CapacitationCenterInformations { get; set; }

            public EntityCollection<CapacitationCenter> CapacitationCenters { get; set; }

            public int IdSocialOrganization { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SocialOrganizationInformationMetadata as the class
    // that carries additional metadata for the SocialOrganizationInformation class.
    [MetadataTypeAttribute(typeof(SocialOrganizationInformation.SocialOrganizationInformationMetadata))]
    public partial class SocialOrganizationInformation
    {

        // This class allows you to attach custom attributes to properties
        // of the SocialOrganizationInformation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SocialOrganizationInformationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SocialOrganizationInformationMetadata()
            {
            }

            public int IdPopulationAttended { get; set; }

            public int IdSocialCause { get; set; }

            public int IdSocialOrganizationInformation { get; set; }

            public int IdState { get; set; }

            public string Name { get; set; }

            [Include]
            public PopulationAttended PopulationAttended { get; set; }

            [Include]
            public SocialCause SocialCause { get; set; }

            [Include]
            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SourceMetadata as the class
    // that carries additional metadata for the Source class.
    [MetadataTypeAttribute(typeof(Source.SourceMetadata))]
    public partial class Source
    {

        // This class allows you to attach custom attributes to properties
        // of the Source class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SourceMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SourceMetadata()
            {
            }

            public int IdSource { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public string Name { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies StateMetadata as the class
    // that carries additional metadata for the State class.
    [MetadataTypeAttribute(typeof(State.StateMetadata))]
    public partial class State
    {

        // This class allows you to attach custom attributes to properties
        // of the State class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class StateMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private StateMetadata()
            {
            }

            public EntityCollection<CapacitationCenterInformation> CapacitationCenterInformations { get; set; }

            public EntityCollection<CapacitationCenter> CapacitationCenters { get; set; }

            public EntityCollection<Competition> Competitions { get; set; }

            public EntityCollection<EducationInformationState> EducationInformationStates { get; set; }

            public int IdState { get; set; }

            public EntityCollection<MexicoAgreement> MexicoAgreements { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }

            public EntityCollection<Municipality> Municipalities { get; set; }

            public string Name { get; set; }

            public EntityCollection<OpenSourceState> OpenSourceStates { get; set; }

            public EntityCollection<OpenSourceStateCommunity> OpenSourceStateCommunities { get; set; }

            public EntityCollection<OpenSourceStateProvider> OpenSourceStateProviders { get; set; }

            public EntityCollection<PoliticalInformationState> PoliticalInformationStates { get; set; }

            public EntityCollection<SocialOrganizationInformation> SocialOrganizationInformations { get; set; }

            public EntityCollection<StateEconomicInfo> StateEconomicInfoes { get; set; }

            public EntityCollection<University> Universities { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies StateEconomicInfoMetadata as the class
    // that carries additional metadata for the StateEconomicInfo class.
    [MetadataTypeAttribute(typeof(StateEconomicInfo.StateEconomicInfoMetadata))]
    public partial class StateEconomicInfo
    {

        // This class allows you to attach custom attributes to properties
        // of the StateEconomicInfo class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class StateEconomicInfoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private StateEconomicInfoMetadata()
            {
            }

            public Nullable<double> BudgetPublicAdministration { get; set; }

            public Nullable<double> BudgetSoftware { get; set; }

            public Nullable<double> BudgetTIC { get; set; }

            public DateTime FromDate { get; set; }

            public int IdState { get; set; }

            public int IdStateEconomicInfo { get; set; }

            [Include]
            public State State { get; set; }

            public bool Status { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies StateProgramMetadata as the class
    // that carries additional metadata for the StateProgram class.
    [MetadataTypeAttribute(typeof(StateProgram.StateProgramMetadata))]
    public partial class StateProgram
    {

        // This class allows you to attach custom attributes to properties
        // of the StateProgram class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class StateProgramMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private StateProgramMetadata()
            {
            }

            [Include]
            public Contact Contact { get; set; }

            [Include]
            public Contact Contact1 { get; set; }

            public DateTime DateFrom { get; set; }

            public DateTime DateTo { get; set; }

            public Nullable<int> IdContactMsft { get; set; }

            public Nullable<int> IdContactState { get; set; }

            public int IdOwner { get; set; }

            public int IdPartner { get; set; }

            public int IdProgram { get; set; }

            public int IdSource { get; set; }

            public int IdState { get; set; }

            public int IdStateProgram { get; set; }

            public int IdType { get; set; }

            public double Investment { get; set; }

            public int Number { get; set; }

            [Include]
            public Owner Owner { get; set; }

            [Include]
            public Partner Partner { get; set; }

            [Include]
            public Program Program { get; set; }

            public int Progress { get; set; }

            public double ROI { get; set; }

            [Include]
            public Source Source { get; set; }

            [Include]
            public State State { get; set; }

            [Include]
            public TypeSource TypeSource { get; set; }
        }
    }


    // The MetadataTypeAttribute identifies StudentsInformationMetadata as the class
    // that carries additional metadata for the StudentsInformation class.
    [MetadataTypeAttribute(typeof(StudentsInformation.StudentsInformationMetadata))]
    public partial class StudentsInformation
    {

        // This class allows you to attach custom attributes to properties
        // of the StudentsInformation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class StudentsInformationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private StudentsInformationMetadata()
            {
            }

            public EducationInformationState EducationInformationState { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdSchoolLevel { get; set; }

            public int IdSchoolType { get; set; }

            public int IdStudentInformation { get; set; }

            public int Number { get; set; }

            public SchoolLevel SchoolLevel { get; set; }

            public SchoolType SchoolType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TeachersInformationMetadata as the class
    // that carries additional metadata for the TeachersInformation class.
    [MetadataTypeAttribute(typeof(TeachersInformation.TeachersInformationMetadata))]
    public partial class TeachersInformation
    {

        // This class allows you to attach custom attributes to properties
        // of the TeachersInformation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TeachersInformationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TeachersInformationMetadata()
            {
            }

            public EducationInformationState EducationInformationState { get; set; }

            public int IdEducationInformationState { get; set; }

            public int IdSchoolLevel { get; set; }

            public int IdSchoolType { get; set; }

            public int IdTeachersInformation { get; set; }

            public int Number { get; set; }

            public SchoolLevel SchoolLevel { get; set; }

            public SchoolType SchoolType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TypeMetadata as the class
    // that carries additional metadata for the Type class.
    [MetadataTypeAttribute(typeof(Type.TypeMetadata))]
    public partial class Type
    {

        // This class allows you to attach custom attributes to properties
        // of the Type class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TypeMetadata()
            {
            }

            public int IdType { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TypeAgreementMetadata as the class
    // that carries additional metadata for the TypeAgreement class.
    [MetadataTypeAttribute(typeof(TypeAgreement.TypeAgreementMetadata))]
    public partial class TypeAgreement
    {

        // This class allows you to attach custom attributes to properties
        // of the TypeAgreement class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TypeAgreementMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TypeAgreementMetadata()
            {
            }

            public int IdTypeAgreement { get; set; }

            public EntityCollection<MexicoAgreement> MexicoAgreements { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TypeProductMetadata as the class
    // that carries additional metadata for the TypeProduct class.
    [MetadataTypeAttribute(typeof(TypeProduct.TypeProductMetadata))]
    public partial class TypeProduct
    {

        // This class allows you to attach custom attributes to properties
        // of the TypeProduct class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TypeProductMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TypeProductMetadata()
            {
            }

            public int IdTypeProduct { get; set; }

            public string Name { get; set; }

            public EntityCollection<OpenSourceState> OpenSourceStates { get; set; }

            public EntityCollection<Product> Products { get; set; }
        }
    }

    [MetadataTypeAttribute(typeof(TypeSepProject.TypeSepProjectMetadata))]
    public partial class TypeSepProject
    {

        // This class allows you to attach custom attributes to properties
        // of the TypeSepProject class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TypeSepProjectMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TypeSepProjectMetadata()
            {
            }

            public int IdTypeSepProject { get; set; }

            public string Name { get; set; }

            public EntityCollection<SEPProjectState> SEPProjectStates { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies UniversityMetadata as the class
    // that carries additional metadata for the University class.
    [MetadataTypeAttribute(typeof(University.UniversityMetadata))]
    public partial class University
    {

        // This class allows you to attach custom attributes to properties
        // of the University class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UniversityMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private UniversityMetadata()
            {
            }

            public int IdState { get; set; }

            public int IdUniversity { get; set; }

            public EntityCollection<MainUniversity> MainUniversities { get; set; }

            public string Name { get; set; }

            public State State { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies YearMetadata as the class
    // that carries additional metadata for the Year class.
    [MetadataTypeAttribute(typeof(Year.YearMetadata))]
    public partial class Year
    {

        // This class allows you to attach custom attributes to properties
        // of the Year class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class YearMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private YearMetadata()
            {
            }

            public int Id { get; set; }

            public int Year1 { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TypeSourceMetadata as the class
    // that carries additional metadata for the TypeSource class.
    [MetadataTypeAttribute(typeof(TypeSource.TypeSourceMetadata))]
    public partial class TypeSource
    {

        // This class allows you to attach custom attributes to properties
        // of the TypeSource class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TypeSourceMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TypeSourceMetadata()
            {
            }

            public EntityCollection<Competition> Competitions { get; set; }

            public int IdType { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public string Name { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OwnerMetadata as the class
    // that carries additional metadata for the Owner class.
    [MetadataTypeAttribute(typeof(Owner.OwnerMetadata))]
    public partial class Owner
    {

        // This class allows you to attach custom attributes to properties
        // of the Owner class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OwnerMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OwnerMetadata()
            {
            }

            public EntityCollection<Competition> Competitions { get; set; }

            public int IdOwner { get; set; }

            public EntityCollection<MicrosoftProgramState> MicrosoftProgramStates { get; set; }

            public string Name { get; set; }

            public EntityCollection<StateProgram> StatePrograms { get; set; }
        }
    }
}
