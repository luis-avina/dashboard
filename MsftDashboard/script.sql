USE [master]
GO
/****** Object:  Database [TestArchive]    Script Date: 7/19/2012 9:59:19 AM ******/
CREATE DATABASE [TestArchive]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Arch1', FILENAME = N'c:\Data\testarchdat1.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [FileStreamGroup1] CONTAINS FILESTREAM  DEFAULT 
( NAME = N'Arch3', FILENAME = N'c:\Data\filestream1' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'Archlog1', FILENAME = N'c:\Data\testarchlog1.ldf' , SIZE = 4224KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestArchive] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestArchive].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestArchive] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestArchive] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestArchive] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestArchive] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestArchive] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestArchive] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestArchive] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestArchive] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestArchive] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestArchive] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestArchive] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestArchive] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestArchive] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestArchive] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestArchive] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestArchive] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestArchive] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestArchive] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestArchive] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestArchive] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestArchive] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestArchive] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestArchive] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestArchive] SET RECOVERY FULL 
GO
ALTER DATABASE [TestArchive] SET  MULTI_USER 
GO
ALTER DATABASE [TestArchive] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestArchive] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestArchive] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestArchive] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestArchive', N'ON'
GO
USE [TestArchive]
GO
/****** Object:  User [lfal]    Script Date: 7/19/2012 9:59:19 AM ******/
CREATE USER [lfal] FOR LOGIN [lfal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [dashboard_user]    Script Date: 7/19/2012 9:59:19 AM ******/
CREATE USER [dashboard_user] FOR LOGIN [dashboard_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [lfal]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [lfal]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [dashboard_user]
GO
ALTER ROLE [db_datareader] ADD MEMBER [dashboard_user]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [dashboard_user]
GO
/****** Object:  Table [dbo].[CapacitationCenter]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CapacitationCenter](
	[IdCapacitationCenterInformation] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[IdSocialOrganization] [int] NOT NULL,
	[IdSocialCause] [int] NOT NULL,
	[IdPopulationAttended] [int] NOT NULL,
	[IdConectivity] [int] NOT NULL,
	[Investment] [float] NOT NULL,
	[SoftwareInvesment] [float] NOT NULL,
	[NumberOfUsers] [int] NOT NULL,
	[NumberOfTrainingUsers] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	[DateFrom] [date] NOT NULL,
 CONSTRAINT [PK_CapacitationCenter] PRIMARY KEY CLUSTERED 
(
	[IdCapacitationCenterInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CapacitationCenterInformation]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CapacitationCenterInformation](
	[IdCapacitationCenterInformation] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IdSocialOrganization] [int] NOT NULL,
	[IdSocialCause] [int] NOT NULL,
	[Investment] [float] NOT NULL,
	[SoftwareInvesment] [float] NOT NULL,
	[NumberOfUsers] [int] NOT NULL,
	[NumberOfTrainingUsers] [int] NOT NULL,
	[IdConectivity] [int] NOT NULL,
	[IdState] [int] NULL,
	[DateFrom] [date] NULL,
	[IdPopulationAttended] [int] NOT NULL,
 CONSTRAINT [PK_Capacitation_Center_Information] PRIMARY KEY CLUSTERED 
(
	[IdCapacitationCenterInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Competition]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Competition](
	[IdCompetition] [int] IDENTITY(1,1) NOT NULL,
	[IdCompetitor] [int] NOT NULL,
	[Invesment] [float] NOT NULL,
	[DateFrom] [date] NOT NULL,
	[Observations] [varchar](200) NOT NULL,
	[Progress] [int] NULL,
	[IdState] [int] NULL,
 CONSTRAINT [PK_Competition] PRIMARY KEY CLUSTERED 
(
	[IdCompetition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Competitor]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Competitor](
	[IdCompetitor] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Competitor] PRIMARY KEY CLUSTERED 
(
	[IdCompetitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conectivity]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conectivity](
	[IdConectivity] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Conectivity] PRIMARY KEY CLUSTERED 
(
	[IdConectivity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacts](
	[IdContact] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CellPhone] [varchar](20) NULL,
	[Telephone] [varchar](20) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[IdContact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Corporative_City]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporative_City](
	[IdCorporativeCity] [int] NOT NULL,
	[IdCapacitationCenterInformation] [int] NOT NULL,
	[IdSocialOrganizationInformation] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	[IdFrom] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EducationInformationState]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationInformationState](
	[IdEducationInformationState] [int] IDENTITY(1,1) NOT NULL,
	[Investment] [float] NOT NULL,
	[CurrentExpenditures] [float] NOT NULL,
	[InvestmentPublicEducation] [float] NOT NULL,
	[InvestmentHighSchool] [float] NOT NULL,
	[InvestmentITProjects] [float] NOT NULL,
	[NumberInvestigators] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Education_Information_State] PRIMARY KEY CLUSTERED 
(
	[IdEducationInformationState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnlaceTest]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnlaceTest](
	[IdEnlaceTest] [int] IDENTITY(1,1) NOT NULL,
	[IdEducationInformationState] [int] NOT NULL,
	[IdSchoolGrade] [int] NOT NULL,
	[Number] [bigint] NOT NULL,
 CONSTRAINT [PK_Enlace_Test] PRIMARY KEY CLUSTERED 
(
	[IdEnlaceTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ItemNumber] [varchar](20) NULL,
	[ItemDescription] [varchar](50) NULL,
	[ItemImage] [varbinary](max) FILESTREAM  NULL,
UNIQUE NONCLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] FILESTREAM_ON [FileStreamGroup1]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MainUniversities]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainUniversities](
	[IdMainUniversitie] [int] IDENTITY(1,1) NOT NULL,
	[IdEducationInformationState] [int] NOT NULL,
	[Penetration] [int] NOT NULL,
	[IdUniversity] [int] NOT NULL,
 CONSTRAINT [PK_MainUniversities] PRIMARY KEY CLUSTERED 
(
	[IdMainUniversitie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MexicoAgreement]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MexicoAgreement](
	[IdMexicoAgreements] [int] IDENTITY(1,1) NOT NULL,
	[Observations] [varchar](200) NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[IdTypeAgreement] [int] NOT NULL,
	[Progress] [int] NOT NULL,
	[IdState] [int] NOT NULL,
 CONSTRAINT [PK_MexicoAgreement] PRIMARY KEY CLUSTERED 
(
	[IdMexicoAgreements] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MicrosoftProgramState]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MicrosoftProgramState](
	[IdMicrosoftProgramState] [int] IDENTITY(1,1) NOT NULL,
	[IdProgram] [int] NOT NULL,
	[IdPartner] [int] NOT NULL,
	[IdSource] [int] NOT NULL,
	[IdContactMsft] [int] NOT NULL,
	[IdContactState] [int] NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[Number] [int] NOT NULL,
	[ROI] [float] NOT NULL,
	[Progress] [int] NOT NULL,
	[Investment] [float] NOT NULL,
	[IdState] [int] NOT NULL,
 CONSTRAINT [PK_MicrosoftProgramState] PRIMARY KEY CLUSTERED 
(
	[IdMicrosoftProgramState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Months]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Months](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monts] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Months] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Municipality]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Municipality](
	[IdMunicipality] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Population] [bigint] NULL,
	[MainMunicipality] [bit] NOT NULL,
	[IdState] [int] NOT NULL,
 CONSTRAINT [PK_Municipality] PRIMARY KEY CLUSTERED 
(
	[IdMunicipality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MyFsTable]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MyFsTable](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fData] [varbinary](max) FILESTREAM  NULL,
	[fName] [nvarchar](300) NULL,
	[RowGuid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] FILESTREAM_ON [FileStreamGroup1],
UNIQUE NONCLUSTERED 
(
	[RowGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] FILESTREAM_ON [FileStreamGroup1]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpenSourceState]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenSourceState](
	[IdOSSState] [int] IDENTITY(1,1) NOT NULL,
	[IdTypeProduct] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[IdPenetration] [int] NOT NULL,
	[Year] [int] NULL,
	[IdState] [int] NOT NULL,
 CONSTRAINT [PK_OSS_State] PRIMARY KEY CLUSTERED 
(
	[IdOSSState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpenSourceStateCommunity]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OpenSourceStateCommunity](
	[IdOpenSourceCommunityState] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[UniversityRelationship] [varchar](200) NOT NULL,
	[IdState] [int] NULL,
	[IdContact] [int] NOT NULL,
 CONSTRAINT [PK_OpenSourceStateCommunity] PRIMARY KEY CLUSTERED 
(
	[IdOpenSourceCommunityState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpenSourceStateProvider]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OpenSourceStateProvider](
	[IdOpenSourceStateProvider] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Invoicing] [float] NOT NULL,
	[IdState] [int] NULL,
	[DateFrom] [date] NOT NULL,
 CONSTRAINT [PK_OpenSourceStateProvider] PRIMARY KEY CLUSTERED 
(
	[IdOpenSourceStateProvider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization](
	[IdOrganization] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[IdOrganization] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Partner]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Partner](
	[IdPartner] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[IdPartner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Penetration]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Penetration](
	[IdPenetration] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Penetration] PRIMARY KEY CLUSTERED 
(
	[IdPenetration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PoliticalInformationMunicipality]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PoliticalInformationMunicipality](
	[IdPoliticalInformationMunicipality] [int] IDENTITY(1,1) NOT NULL,
	[IdPoliticalInformationState] [int] NOT NULL,
	[IdPoliticalParty] [int] NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[Observations] [varchar](1000) NULL,
	[DevelopmentPlan] [varchar](1000) NULL,
	[Sectorials] [varchar](1000) NULL,
	[IdMunicipality] [int] NOT NULL,
 CONSTRAINT [PK_PoliticalInformationMunicipality] PRIMARY KEY CLUSTERED 
(
	[IdPoliticalInformationMunicipality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PoliticalInformationState]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PoliticalInformationState](
	[IdPoliticalInformationState] [int] IDENTITY(1,1) NOT NULL,
	[IdPoliticalParty] [int] NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[DevelopmentPlan] [varchar](1000) NULL,
	[Observations] [varchar](1000) NULL,
	[Sectorials] [varchar](1000) NULL,
	[IdState] [int] NOT NULL,
 CONSTRAINT [PK_Political_Information_State] PRIMARY KEY CLUSTERED 
(
	[IdPoliticalInformationState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PoliticalInformationStateFiles]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PoliticalInformationStateFiles](
	[IdFilePoliticalStateInformation] [int] IDENTITY(1,1) NOT NULL,
	[IdPoliticalInformationState] [int] NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
	[FileName] [varchar](300) NOT NULL,
	[RowGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PoliticalInformationStateFiles] PRIMARY KEY CLUSTERED 
(
	[IdFilePoliticalStateInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PoliticalParty]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PoliticalParty](
	[IdPoliticalParty] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[ShortName] [varchar](50) NOT NULL,
	[ColorIndex] [int] NULL,
	[Color] [varchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Political_Party] PRIMARY KEY CLUSTERED 
(
	[IdPoliticalParty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PopulationAttended]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PopulationAttended](
	[IdPopulationAttended] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PopulationAttended] PRIMARY KEY CLUSTERED 
(
	[IdPopulationAttended] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[IdTypeProduct] [int] NOT NULL,
	[OpenSource] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Program]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Program](
	[IdProgram] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED 
(
	[IdProgram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SchoolGrade]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolGrade](
	[IdSchoolGrade] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SchoolGrade] PRIMARY KEY CLUSTERED 
(
	[IdSchoolGrade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SchoolLevel]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolLevel](
	[IdSchoolLevel] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
 CONSTRAINT [PK_School_Level] PRIMARY KEY CLUSTERED 
(
	[IdSchoolLevel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolsInformation]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolsInformation](
	[IdSchoolInformation] [int] IDENTITY(1,1) NOT NULL,
	[IdEducationInformationState] [int] NOT NULL,
	[IdSchoolLevel] [int] NOT NULL,
	[IdSchoolType] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_SchoolsInformation] PRIMARY KEY CLUSTERED 
(
	[IdSchoolInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolType]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolType](
	[IdSchoolType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SchoolType] PRIMARY KEY CLUSTERED 
(
	[IdSchoolType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SEPProjectState]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEPProjectState](
	[IdSepProjectState] [int] IDENTITY(1,1) NOT NULL,
	[IdEducationInformationState] [int] NOT NULL,
	[IdTypeSepProject] [int] NOT NULL,
	[Percentage] [bigint] NOT NULL,
 CONSTRAINT [PK_SEP_Project_State] PRIMARY KEY CLUSTERED 
(
	[IdSepProjectState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SocialCause]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialCause](
	[IdSocialCause] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Social_Cause] PRIMARY KEY CLUSTERED 
(
	[IdSocialCause] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SocialOrganization]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialOrganization](
	[IdSocialOrganization] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_SocialOrganization] PRIMARY KEY CLUSTERED 
(
	[IdSocialOrganization] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SocialOrganizationInformation]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialOrganizationInformation](
	[IdSocialOrganizationInformation] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[IdSocialCause] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	[IdPopulationAttended] [int] NOT NULL,
 CONSTRAINT [PK_Social_Organization_Information] PRIMARY KEY CLUSTERED 
(
	[IdSocialOrganizationInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Source]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source](
	[IdSource] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[IdSource] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[IdState] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[IdState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateEconomicInfo]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateEconomicInfo](
	[IdStateEconomicInfo] [int] IDENTITY(1,1) NOT NULL,
	[BudgetPublicAdministration] [float] NULL,
	[BudgetTIC] [float] NULL,
	[BudgetSoftware] [float] NULL,
	[IdState] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_State_Economic_Info] PRIMARY KEY CLUSTERED 
(
	[IdStateEconomicInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentsInformation]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsInformation](
	[IdStudentInformation] [int] IDENTITY(1,1) NOT NULL,
	[IdEducationInformationState] [int] NOT NULL,
	[IdSchoolType] [int] NOT NULL,
	[IdSchoolLevel] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Students_Information_1] PRIMARY KEY CLUSTERED 
(
	[IdStudentInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeachersInformation]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachersInformation](
	[IdTeachersInformation] [int] IDENTITY(1,1) NOT NULL,
	[IdEducationInformationState] [int] NOT NULL,
	[IdSchoolLevel] [int] NOT NULL,
	[IdSchoolType] [int] NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Teachers_Information] PRIMARY KEY CLUSTERED 
(
	[IdTeachersInformation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Time]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Time](
	[IdMonth] [int] NOT NULL,
	[Name] [int] NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED 
(
	[IdMonth] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Type]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Type](
	[IdType] [int] NOT NULL,
	[Name] [varchar](200) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeAgreement]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeAgreement](
	[IdTypeAgreement] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TypeAgreement] PRIMARY KEY CLUSTERED 
(
	[IdTypeAgreement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeProduct]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeProduct](
	[IdTypeProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TypeProduct] PRIMARY KEY CLUSTERED 
(
	[IdTypeProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeSepProject]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeSepProject](
	[IdTypeSepProject] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TypeSepProject] PRIMARY KEY CLUSTERED 
(
	[IdTypeSepProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Universities]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Universities](
	[IdUniversity] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[IdState] [int] NOT NULL,
 CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED 
(
	[IdUniversity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wallet_Share]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet_Share](
	[IdWalletShare] [int] NOT NULL,
	[IdStateEconomicInfo] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[Percentage] [int] NOT NULL,
 CONSTRAINT [PK_Wallet_Share] PRIMARY KEY CLUSTERED 
(
	[IdWalletShare] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Years]    Script Date: 7/19/2012 9:59:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Years](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Years] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CapacitationCenter] ON 

INSERT [dbo].[CapacitationCenter] ([IdCapacitationCenterInformation], [Name], [IdSocialOrganization], [IdSocialCause], [IdPopulationAttended], [IdConectivity], [Investment], [SoftwareInvesment], [NumberOfUsers], [NumberOfTrainingUsers], [IdState], [DateFrom]) VALUES (1, N'Cap Center 1', 1, 1, 2, 2, 329, 320, 10, 5, 1, CAST(0xFB350B00 AS Date))
SET IDENTITY_INSERT [dbo].[CapacitationCenter] OFF
SET IDENTITY_INSERT [dbo].[CapacitationCenterInformation] ON 

INSERT [dbo].[CapacitationCenterInformation] ([IdCapacitationCenterInformation], [Name], [IdSocialOrganization], [IdSocialCause], [Investment], [SoftwareInvesment], [NumberOfUsers], [NumberOfTrainingUsers], [IdConectivity], [IdState], [DateFrom], [IdPopulationAttended]) VALUES (1, N'Kakoun', 1, 1, 120101, 21210, 121, 10, 1, 1, CAST(0x26350B00 AS Date), 1)
INSERT [dbo].[CapacitationCenterInformation] ([IdCapacitationCenterInformation], [Name], [IdSocialOrganization], [IdSocialCause], [Investment], [SoftwareInvesment], [NumberOfUsers], [NumberOfTrainingUsers], [IdConectivity], [IdState], [DateFrom], [IdPopulationAttended]) VALUES (2, N'Tres Cuatro', 1, 1, 4959.98, 31929.8, 18, 5, 1, 2, CAST(0x26240B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[CapacitationCenterInformation] OFF
SET IDENTITY_INSERT [dbo].[Competition] ON 

INSERT [dbo].[Competition] ([IdCompetition], [IdCompetitor], [Invesment], [DateFrom], [Observations], [Progress], [IdState]) VALUES (2, 1, 21212, CAST(0x07240B00 AS Date), N'sadadasadasda', 84, 1)
INSERT [dbo].[Competition] ([IdCompetition], [IdCompetitor], [Invesment], [DateFrom], [Observations], [Progress], [IdState]) VALUES (4, 1, 9293, CAST(0x26350B00 AS Date), N'adsaada', 58, 24)
INSERT [dbo].[Competition] ([IdCompetition], [IdCompetitor], [Invesment], [DateFrom], [Observations], [Progress], [IdState]) VALUES (1003, 1, 0, CAST(0x62350B00 AS Date), N'dadada', 57, 5)
INSERT [dbo].[Competition] ([IdCompetition], [IdCompetitor], [Invesment], [DateFrom], [Observations], [Progress], [IdState]) VALUES (1004, 1, 0, CAST(0x75250B00 AS Date), N'asdadada', 55, 1)
SET IDENTITY_INSERT [dbo].[Competition] OFF
SET IDENTITY_INSERT [dbo].[Competitor] ON 

INSERT [dbo].[Competitor] ([IdCompetitor], [Name]) VALUES (1, N'Oracle')
SET IDENTITY_INSERT [dbo].[Competitor] OFF
SET IDENTITY_INSERT [dbo].[Conectivity] ON 

INSERT [dbo].[Conectivity] ([IdConectivity], [Name]) VALUES (1, N'Convectividad 1')
INSERT [dbo].[Conectivity] ([IdConectivity], [Name]) VALUES (2, N'Conectividad 2')
SET IDENTITY_INSERT [dbo].[Conectivity] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (8, N'Luis Fernandosssss', N'Aviña Lizarragass', N'lfal99@hotmal.com', N'5514518561', N'669065212', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (9, N'Cristofer Antoniosss', N'Gomez Lizarraga', N'cristofer_g2005@hotmail.com', N'13131313', N'12313131', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (10, N'José Joaquin', N'Gomez Lizarraga', N'joako_3715@hotmail.com', N'123131313', N'1241231231', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (11, N'José Luiz', N'Gamboa Díaz', N'gamboa_dronk@hotmail.com', N'12313123123', N'1231313131', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (12, N'Luis Manuel', N'Canizalez Tripp', N'noek_man@hotmail.com', N'21313131', N'12312313', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (13, N'José Claudio', N'Osuna Gamez', N'tintan7@hotmail.com', N'1231231231', N'2312313131', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (14, N'Juan Ramon', N'Terven Salinas', N'jr_terven@hotmail.com', N'123123131', N'12313131', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (15, N'Esther', N'Lizarraga Ramirez', N'esther@hotmail.com', N'32141411', N'121213123', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (16, N'Antonio', N'Rendon Osuna', N'ron@hotmail.com', N'89123981893', N'121312931', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (17, N'ada', N'asdada', N'asdada@hiotma.com', N'21313', N'121213', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (1017, N'Jose de Jesús', N'Robles Perez', N'ladal@hotmail.com', N'1213131', N'312313', NULL)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2017, N'Arcadio', N'Pesqueira Osuna', N'arcadiopo@gmail.com', N'213123131', N'1213123123', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2018, N'Alejandro', N'Pereira Osuna', N'a@hotmail.com', N'1231313', N'123131', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2019, N'Fernando', N'Gutierrez', N'fer_g@hotmail.com', N'131313131', N'123131313', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2020, N'Pedro', N'Pereira Diaz', N'per@hotmail.com', N'123131321', N'2313131', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2021, N'Humbertos', N'Garcia Lizarraga', N'humby_gl@hotmail.com', N'31231231313', N'231231314', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2022, N'Tomas Hernan', N'Moreno Sanchez', N'tomm_@hotmail.com', N'21313131', N'12312313', 1)
INSERT [dbo].[Contacts] ([IdContact], [FirstName], [LastName], [Email], [CellPhone], [Telephone], [Status]) VALUES (2023, N'Marisa', N'Moreno Sanchez', N'mr_@hotmail.com', N'123131', N'231231313', 1)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[EducationInformationState] ON 

INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2014, 21, 480, 8680, 891, 858, 0, 1, 2012)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2015, 388, 8768, 536, 938, 121, 0, 2, 2012)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2016, 212, 181218, 127127, 2192.28, 3848, 0, 4, 2001)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2017, 2, 3, 4, 5, 6, 0, 6, 2002)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2018, 33, 5583, 4844, 323, 48, 0, 8, 2012)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2019, 473, 5858.28, 4748, 10121, 9773, 0, 9, 2012)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2020, 338, 3830, 585850, 59858, 832, 0, 7, 2012)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2021, 33, 50, 70, 80, 68, 0, 24, 2008)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2022, 313, 313, 412, 441, 44, 0, 12, 2012)
INSERT [dbo].[EducationInformationState] ([IdEducationInformationState], [Investment], [CurrentExpenditures], [InvestmentPublicEducation], [InvestmentHighSchool], [InvestmentITProjects], [NumberInvestigators], [IdState], [Year]) VALUES (2023, 30, 40, 50, 60, 70, 0, 1, 2012)
SET IDENTITY_INSERT [dbo].[EducationInformationState] OFF
SET IDENTITY_INSERT [dbo].[EnlaceTest] ON 

INSERT [dbo].[EnlaceTest] ([IdEnlaceTest], [IdEducationInformationState], [IdSchoolGrade], [Number]) VALUES (1002, 2019, 1, 311)
SET IDENTITY_INSERT [dbo].[EnlaceTest] OFF
SET IDENTITY_INSERT [dbo].[MainUniversities] ON 

INSERT [dbo].[MainUniversities] ([IdMainUniversitie], [IdEducationInformationState], [Penetration], [IdUniversity]) VALUES (2002, 2023, 41, 6)
SET IDENTITY_INSERT [dbo].[MainUniversities] OFF
SET IDENTITY_INSERT [dbo].[MexicoAgreement] ON 

INSERT [dbo].[MexicoAgreement] ([IdMexicoAgreements], [Observations], [DateFrom], [DateTo], [IdTypeAgreement], [Progress], [IdState]) VALUES (2, N'sdadasda', CAST(0x00000000 AS Date), CAST(0x00000000 AS Date), 1, 53, 1)
INSERT [dbo].[MexicoAgreement] ([IdMexicoAgreements], [Observations], [DateFrom], [DateTo], [IdTypeAgreement], [Progress], [IdState]) VALUES (3, N'sadadadada', CAST(0x45350B00 AS Date), CAST(0x81350B00 AS Date), 1, 96, 4)
INSERT [dbo].[MexicoAgreement] ([IdMexicoAgreements], [Observations], [DateFrom], [DateTo], [IdTypeAgreement], [Progress], [IdState]) VALUES (4, N'Convenio Especificodd', CAST(0x94360B00 AS Date), CAST(0xEE360B00 AS Date), 2, 82, 24)
SET IDENTITY_INSERT [dbo].[MexicoAgreement] OFF
SET IDENTITY_INSERT [dbo].[MicrosoftProgramState] ON 

INSERT [dbo].[MicrosoftProgramState] ([IdMicrosoftProgramState], [IdProgram], [IdPartner], [IdSource], [IdContactMsft], [IdContactState], [DateFrom], [DateTo], [Number], [ROI], [Progress], [Investment], [IdState]) VALUES (4, 1, 1, 1, 9, 8, CAST(0x94250B00 AS Date), CAST(0x1D270B00 AS Date), 0, 4900, 96, 30000, 6)
SET IDENTITY_INSERT [dbo].[MicrosoftProgramState] OFF
SET IDENTITY_INSERT [dbo].[Months] ON 

INSERT [dbo].[Months] ([Id], [Monts]) VALUES (1, N'Enero')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (2, N'Febrero')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (3, N'Marzo')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (4, N'Abril')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (5, N'Mayo')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (6, N'Junio')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (7, N'Julio')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (8, N'Agosto')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (9, N'Septiembre')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (10, N'Octubre')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (11, N'Noviembre')
INSERT [dbo].[Months] ([Id], [Monts]) VALUES (12, N'Diciembre')
SET IDENTITY_INSERT [dbo].[Months] OFF
SET IDENTITY_INSERT [dbo].[Municipality] ON 

INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (1, N'Aguascalientes', 1990, 1, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (2, N'Asientos', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (3, N'Calvillo', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (4, N'Cosio', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (5, N'Jesús Maria', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (6, N'Pabellón de Arteaga', 1000, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (7, N'Rincón de Romos', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (8, N'San José de Gracia', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (9, N'Tepezalá', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (10, N'El Llano', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (11, N'San Francisco de los Romo', 0, 0, 1)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (12, N'Ensenada', 10, 1, 2)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (13, N'Mexicali', 332, 1, 2)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (14, N'Tecate', 0, 0, 2)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (15, N'Tijuana', 21219, 1, 2)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (16, N'Playas de Rosarito', 0, 0, 2)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (17, N'Comondú', 0, 0, 3)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (18, N'Mulegé', 0, 0, 3)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (19, N'La Paz', 0, 0, 3)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (20, N'Los Cabos', 0, 0, 3)
INSERT [dbo].[Municipality] ([IdMunicipality], [Name], [Population], [MainMunicipality], [IdState]) VALUES (21, N'Loreto', 0, 0, 3)
SET IDENTITY_INSERT [dbo].[Municipality] OFF
SET IDENTITY_INSERT [dbo].[MyFsTable] ON 

INSERT [dbo].[MyFsTable] ([fId], [fData], [fName], [RowGuid]) VALUES (12, 0x6572626C616465352F56696577732F5265706F7274732F504B010214001400000000000657B13E0000000000000000000000001E000000000000000000100000008ECA180053696C766572626C616465352F53696C766572626C616465352F5765622F504B010214001400000000000657B13E0000000000000000000000002800000000000000000010000000CACA180053696C766572626C616465352F53696C766572626C616465352F5765622F5265736F75726365732F504B050600000000AA00AA008441000010CB180000003E000000000000000000000000280000000000000000001000000048CA180053696C766572626C616465352F53696C76, N'Silverblade5-WCF-RIA-MVVMLight-Messenger.zip', N'00000000-0000-0000-0000-000000000000')
SET IDENTITY_INSERT [dbo].[MyFsTable] OFF
SET IDENTITY_INSERT [dbo].[OpenSourceState] ON 

INSERT [dbo].[OpenSourceState] ([IdOSSState], [IdTypeProduct], [IdProduct], [IdPenetration], [Year], [IdState]) VALUES (1, 1, 1, 1, 2010, 1)
INSERT [dbo].[OpenSourceState] ([IdOSSState], [IdTypeProduct], [IdProduct], [IdPenetration], [Year], [IdState]) VALUES (2, 3, 1, 3, 2010, 24)
INSERT [dbo].[OpenSourceState] ([IdOSSState], [IdTypeProduct], [IdProduct], [IdPenetration], [Year], [IdState]) VALUES (3, 1, 1, 1, 2009, 24)
INSERT [dbo].[OpenSourceState] ([IdOSSState], [IdTypeProduct], [IdProduct], [IdPenetration], [Year], [IdState]) VALUES (1003, 2, 2, 2, 2012, 8)
INSERT [dbo].[OpenSourceState] ([IdOSSState], [IdTypeProduct], [IdProduct], [IdPenetration], [Year], [IdState]) VALUES (1004, 3, 3, 3, 2001, 7)
INSERT [dbo].[OpenSourceState] ([IdOSSState], [IdTypeProduct], [IdProduct], [IdPenetration], [Year], [IdState]) VALUES (1005, 2, 2, 2, 2003, 4)
SET IDENTITY_INSERT [dbo].[OpenSourceState] OFF
SET IDENTITY_INSERT [dbo].[OpenSourceStateCommunity] ON 

INSERT [dbo].[OpenSourceStateCommunity] ([IdOpenSourceCommunityState], [Name], [UniversityRelationship], [IdState], [IdContact]) VALUES (5, N'Comunity Center', N'aadajdjajdajj', 1, 8)
INSERT [dbo].[OpenSourceStateCommunity] ([IdOpenSourceCommunityState], [Name], [UniversityRelationship], [IdState], [IdContact]) VALUES (6, N'sadada', N'adada', 4, 9)
INSERT [dbo].[OpenSourceStateCommunity] ([IdOpenSourceCommunityState], [Name], [UniversityRelationship], [IdState], [IdContact]) VALUES (7, N'asdada', N'Pruebas', 2, 8)
SET IDENTITY_INSERT [dbo].[OpenSourceStateCommunity] OFF
SET IDENTITY_INSERT [dbo].[OpenSourceStateProvider] ON 

INSERT [dbo].[OpenSourceStateProvider] ([IdOpenSourceStateProvider], [Name], [IdProduct], [Invoicing], [IdState], [DateFrom]) VALUES (1, N'Ese', 3, 3125, 1, CAST(0xB0250B00 AS Date))
SET IDENTITY_INSERT [dbo].[OpenSourceStateProvider] OFF
SET IDENTITY_INSERT [dbo].[Partner] ON 

INSERT [dbo].[Partner] ([IdPartner], [Name]) VALUES (1, N'Partner 1')
INSERT [dbo].[Partner] ([IdPartner], [Name]) VALUES (2, N'Partner 2')
SET IDENTITY_INSERT [dbo].[Partner] OFF
SET IDENTITY_INSERT [dbo].[Penetration] ON 

INSERT [dbo].[Penetration] ([IdPenetration], [Name]) VALUES (1, N'Alta')
INSERT [dbo].[Penetration] ([IdPenetration], [Name]) VALUES (2, N'Media')
INSERT [dbo].[Penetration] ([IdPenetration], [Name]) VALUES (3, N'Baja')
SET IDENTITY_INSERT [dbo].[Penetration] OFF
SET IDENTITY_INSERT [dbo].[PoliticalInformationMunicipality] ON 

INSERT [dbo].[PoliticalInformationMunicipality] ([IdPoliticalInformationMunicipality], [IdPoliticalInformationState], [IdPoliticalParty], [DateFrom], [DateTo], [Observations], [DevelopmentPlan], [Sectorials], [IdMunicipality]) VALUES (1, 2, 2, CAST(0x4F280B00 AS Date), CAST(0x2A2B0B00 AS Date), N'prueba 2', N'dsadada', N'sadadad', 1)
SET IDENTITY_INSERT [dbo].[PoliticalInformationMunicipality] OFF
SET IDENTITY_INSERT [dbo].[PoliticalInformationState] ON 

INSERT [dbo].[PoliticalInformationState] ([IdPoliticalInformationState], [IdPoliticalParty], [DateFrom], [DateTo], [DevelopmentPlan], [Observations], [Sectorials], [IdState]) VALUES (1, 1, CAST(0x712F0B00 AS Date), CAST(0x6E390B00 AS Date), N'sadasdasda', N'primer registro buenoS', N'Ssdadasda', 1)
INSERT [dbo].[PoliticalInformationState] ([IdPoliticalInformationState], [IdPoliticalParty], [DateFrom], [DateTo], [DevelopmentPlan], [Observations], [Sectorials], [IdState]) VALUES (2, 1, CAST(0x07240B00 AS Date), CAST(0x4F280B00 AS Date), N'asdada1131', N'pruebssss123131', N'12131sadsada', 1)
INSERT [dbo].[PoliticalInformationState] ([IdPoliticalInformationState], [IdPoliticalParty], [DateFrom], [DateTo], [DevelopmentPlan], [Observations], [Sectorials], [IdState]) VALUES (3, 1, CAST(0x26350B00 AS Date), CAST(0xB63D0B00 AS Date), N'asidjiaojdiaojdioasjdoisajoid 121', N'Pruebas nuevas 12', N'Jijadiajdioajdioajdoia ', 24)
INSERT [dbo].[PoliticalInformationState] ([IdPoliticalInformationState], [IdPoliticalParty], [DateFrom], [DateTo], [DevelopmentPlan], [Observations], [Sectorials], [IdState]) VALUES (1004, 3, CAST(0x26350B00 AS Date), CAST(0xB63D0B00 AS Date), N'123131asdaa', N'sdadad', N'adsad121', 8)
SET IDENTITY_INSERT [dbo].[PoliticalInformationState] OFF
SET IDENTITY_INSERT [dbo].[PoliticalParty] ON 

INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (1, N'Partido Acción Nacional', N'PAN', 9, N'Blue', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (2, N'Partido Revolucionario Institucional', N'PRI', 113, N'Red', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (3, N'Partido de la Revolución Democrática', N'PRD', 139, N'Yellow', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (4, N'Partido del Trabajo', N'PT', 132, N'Tomato', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (5, N'Partido Verde Ecologista de México', N'PVEM', 51, N'Green', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (6, N'Partido Movimiento Ciudadano', N'PMC', 99, N'Orange', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (7, N'Partido Nueva Alianza', N'PANAL', 3, N'Aquamarine', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (8, N'Partido Popular Socialista', N'PPS', 54, NULL, 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (9, N'Partido del Frente Cardenista', N'PFC', 10, N'BlueViolet', 1)
INSERT [dbo].[PoliticalParty] ([IdPoliticalParty], [Name], [ShortName], [ColorIndex], [Color], [Status]) VALUES (1008, N'Peoples Crazies Mazatlans', N'PCMs', 1, N'Aqua', 0)
SET IDENTITY_INSERT [dbo].[PoliticalParty] OFF
SET IDENTITY_INSERT [dbo].[PopulationAttended] ON 

INSERT [dbo].[PopulationAttended] ([IdPopulationAttended], [Name]) VALUES (1, N'Población 1')
INSERT [dbo].[PopulationAttended] ([IdPopulationAttended], [Name]) VALUES (2, N'Población 2')
SET IDENTITY_INSERT [dbo].[PopulationAttended] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([IdProduct], [Name], [IdTypeProduct], [OpenSource]) VALUES (1, N'MySql', 1, 1)
INSERT [dbo].[Products] ([IdProduct], [Name], [IdTypeProduct], [OpenSource]) VALUES (2, N'Java', 2, 1)
INSERT [dbo].[Products] ([IdProduct], [Name], [IdTypeProduct], [OpenSource]) VALUES (3, N'Linux', 3, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Program] ON 

INSERT [dbo].[Program] ([IdProgram], [Name]) VALUES (1, N'BizPark')
INSERT [dbo].[Program] ([IdProgram], [Name]) VALUES (2, N'DreamSpark')
INSERT [dbo].[Program] ([IdProgram], [Name]) VALUES (3, N'MyPIME creSE')
SET IDENTITY_INSERT [dbo].[Program] OFF
SET IDENTITY_INSERT [dbo].[SchoolGrade] ON 

INSERT [dbo].[SchoolGrade] ([IdSchoolGrade], [Name]) VALUES (1, N'Primaria')
INSERT [dbo].[SchoolGrade] ([IdSchoolGrade], [Name]) VALUES (2, N'Secundaria')
INSERT [dbo].[SchoolGrade] ([IdSchoolGrade], [Name]) VALUES (3, N'Preparatoria')
SET IDENTITY_INSERT [dbo].[SchoolGrade] OFF
SET IDENTITY_INSERT [dbo].[SchoolLevel] ON 

INSERT [dbo].[SchoolLevel] ([IdSchoolLevel], [Name]) VALUES (1, N'Básica                                                                                              ')
INSERT [dbo].[SchoolLevel] ([IdSchoolLevel], [Name]) VALUES (2, N'Media                                                                                               ')
INSERT [dbo].[SchoolLevel] ([IdSchoolLevel], [Name]) VALUES (3, N'Superior                                                                                            ')
SET IDENTITY_INSERT [dbo].[SchoolLevel] OFF
SET IDENTITY_INSERT [dbo].[SchoolsInformation] ON 

INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2005, 2014, 1, 1, 312)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2006, 2014, 2, 1, 82)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2007, 2014, 3, 1, 548)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2008, 2015, 1, 1, 1)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2009, 2015, 2, 1, 4)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2010, 2015, 3, 1, 7)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2011, 2015, 1, 2, 10)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2012, 2015, 2, 2, 13)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2013, 2015, 3, 2, 16)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2014, 2017, 1, 1, 120)
INSERT [dbo].[SchoolsInformation] ([IdSchoolInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2015, 2018, 1, 1, 212)
SET IDENTITY_INSERT [dbo].[SchoolsInformation] OFF
SET IDENTITY_INSERT [dbo].[SchoolType] ON 

INSERT [dbo].[SchoolType] ([IdSchoolType], [Name]) VALUES (1, N'Pública')
INSERT [dbo].[SchoolType] ([IdSchoolType], [Name]) VALUES (2, N'Privada')
SET IDENTITY_INSERT [dbo].[SchoolType] OFF
SET IDENTITY_INSERT [dbo].[SEPProjectState] ON 

INSERT [dbo].[SEPProjectState] ([IdSepProjectState], [IdEducationInformationState], [IdTypeSepProject], [Percentage]) VALUES (1002, 2022, 1, 67)
SET IDENTITY_INSERT [dbo].[SEPProjectState] OFF
SET IDENTITY_INSERT [dbo].[SocialCause] ON 

INSERT [dbo].[SocialCause] ([IdSocialCause], [Name]) VALUES (1, N'Causa Social 1')
INSERT [dbo].[SocialCause] ([IdSocialCause], [Name]) VALUES (2, N'Causa Social 2')
SET IDENTITY_INSERT [dbo].[SocialCause] OFF
SET IDENTITY_INSERT [dbo].[SocialOrganization] ON 

INSERT [dbo].[SocialOrganization] ([IdSocialOrganization], [Name]) VALUES (1, N'Social Organización 1')
INSERT [dbo].[SocialOrganization] ([IdSocialOrganization], [Name]) VALUES (2, N'Social Organización 2')
SET IDENTITY_INSERT [dbo].[SocialOrganization] OFF
SET IDENTITY_INSERT [dbo].[SocialOrganizationInformation] ON 

INSERT [dbo].[SocialOrganizationInformation] ([IdSocialOrganizationInformation], [Name], [IdSocialCause], [IdState], [IdPopulationAttended]) VALUES (1, N'nombre 1', 2, 2, 2)
INSERT [dbo].[SocialOrganizationInformation] ([IdSocialOrganizationInformation], [Name], [IdSocialCause], [IdState], [IdPopulationAttended]) VALUES (2, N's9inaa', 1, 24, 1)
INSERT [dbo].[SocialOrganizationInformation] ([IdSocialOrganizationInformation], [Name], [IdSocialCause], [IdState], [IdPopulationAttended]) VALUES (3, N'jaliscos', 1, 14, 1)
INSERT [dbo].[SocialOrganizationInformation] ([IdSocialOrganizationInformation], [Name], [IdSocialCause], [IdState], [IdPopulationAttended]) VALUES (1002, N'Duffiex', 1, 8, 1)
SET IDENTITY_INSERT [dbo].[SocialOrganizationInformation] OFF
SET IDENTITY_INSERT [dbo].[Source] ON 

INSERT [dbo].[Source] ([IdSource], [Name]) VALUES (1, N'Cloud Computing')
INSERT [dbo].[Source] ([IdSource], [Name]) VALUES (2, N'Software')
INSERT [dbo].[Source] ([IdSource], [Name]) VALUES (3, N'')
SET IDENTITY_INSERT [dbo].[Source] OFF
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([IdState], [Name]) VALUES (1, N'Aguascalientes')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (2, N'Baja California Norte')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (3, N'Baja California Sur')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (4, N'Campeche')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (5, N'Chiapas')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (6, N'Coahuila')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (7, N'Colima')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (8, N'Distrito Federal')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (9, N'Durango')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (10, N'Estado de México')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (11, N'Guanajuato')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (12, N'Guerrero')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (13, N'Hidalgo')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (14, N'Jalisco')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (15, N'Michoacan')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (16, N'Morelos')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (17, N'Nayarit')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (18, N'Nuevo León')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (19, N'Oaxaca')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (20, N'Puebla')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (21, N'Queretaro')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (22, N'Quintana Roo')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (23, N'San Luis Potosi')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (24, N'Sinaloa')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (25, N'Sonora')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (26, N'Tabasco')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (27, N'Tamaulipas')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (28, N'Tlaxcala')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (29, N'Veracruz')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (30, N'Yucatan')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (31, N'Zacatecas')
INSERT [dbo].[State] ([IdState], [Name]) VALUES (32, N'Chihuahua')
SET IDENTITY_INSERT [dbo].[State] OFF
SET IDENTITY_INSERT [dbo].[StudentsInformation] ON 

INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2005, 2014, 1, 1, 312)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2006, 2014, 1, 2, 82)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2007, 2014, 1, 3, 548)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2008, 2015, 1, 1, 1)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2009, 2015, 1, 2, 4)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2010, 2015, 1, 3, 7)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2011, 2015, 2, 1, 10)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2012, 2015, 2, 2, 13)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2013, 2015, 2, 3, 16)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2014, 2017, 1, 1, 120)
INSERT [dbo].[StudentsInformation] ([IdStudentInformation], [IdEducationInformationState], [IdSchoolType], [IdSchoolLevel], [Number]) VALUES (2015, 2018, 1, 1, 212)
SET IDENTITY_INSERT [dbo].[StudentsInformation] OFF
SET IDENTITY_INSERT [dbo].[TeachersInformation] ON 

INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2005, 2014, 1, 1, 312)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2006, 2014, 2, 1, 82)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2007, 2014, 3, 1, 548)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2008, 2015, 1, 1, 1)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2009, 2015, 2, 1, 4)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2010, 2015, 3, 1, 7)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2011, 2015, 1, 2, 10)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2012, 2015, 2, 2, 13)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2013, 2015, 3, 2, 16)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2014, 2017, 1, 1, 120)
INSERT [dbo].[TeachersInformation] ([IdTeachersInformation], [IdEducationInformationState], [IdSchoolLevel], [IdSchoolType], [Number]) VALUES (2015, 2018, 1, 1, 212)
SET IDENTITY_INSERT [dbo].[TeachersInformation] OFF
SET IDENTITY_INSERT [dbo].[TypeAgreement] ON 

INSERT [dbo].[TypeAgreement] ([IdTypeAgreement], [Name]) VALUES (1, N'Marco')
INSERT [dbo].[TypeAgreement] ([IdTypeAgreement], [Name]) VALUES (2, N'Especifico')
SET IDENTITY_INSERT [dbo].[TypeAgreement] OFF
SET IDENTITY_INSERT [dbo].[TypeProduct] ON 

INSERT [dbo].[TypeProduct] ([IdTypeProduct], [Name]) VALUES (1, N'Base de Datos')
INSERT [dbo].[TypeProduct] ([IdTypeProduct], [Name]) VALUES (2, N'Programación')
INSERT [dbo].[TypeProduct] ([IdTypeProduct], [Name]) VALUES (3, N'Servidores')
SET IDENTITY_INSERT [dbo].[TypeProduct] OFF
SET IDENTITY_INSERT [dbo].[TypeSepProject] ON 

INSERT [dbo].[TypeSepProject] ([IdTypeSepProject], [Name]) VALUES (1, N'HDT')
INSERT [dbo].[TypeSepProject] ([IdTypeSepProject], [Name]) VALUES (2, N'ABT')
INSERT [dbo].[TypeSepProject] ([IdTypeSepProject], [Name]) VALUES (3, N'Enciclomedia')
SET IDENTITY_INSERT [dbo].[TypeSepProject] OFF
SET IDENTITY_INSERT [dbo].[Universities] ON 

INSERT [dbo].[Universities] ([IdUniversity], [Name], [IdState]) VALUES (6, N' Universidad Tecnológica de Aguascalientes', 1)
INSERT [dbo].[Universities] ([IdUniversity], [Name], [IdState]) VALUES (7, N' Universidad Politécnica de Aguascalientes ', 1)
INSERT [dbo].[Universities] ([IdUniversity], [Name], [IdState]) VALUES (8, N'INSTITUTO TECNOLÓGICO DE AGUASCALIENTES ', 1)
SET IDENTITY_INSERT [dbo].[Universities] OFF
SET IDENTITY_INSERT [dbo].[Years] ON 

INSERT [dbo].[Years] ([Id], [Year]) VALUES (1, 2000)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (2, 2001)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (3, 2002)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (4, 2003)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (5, 2004)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (6, 2005)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (7, 2006)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (8, 2007)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (9, 2008)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (10, 2009)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (11, 2010)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (12, 2012)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (13, 2013)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (14, 2014)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (15, 2015)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (16, 2016)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (17, 2017)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (18, 2018)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (19, 2019)
INSERT [dbo].[Years] ([Id], [Year]) VALUES (20, 2020)
SET IDENTITY_INSERT [dbo].[Years] OFF
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[MyFsTable] ADD  DEFAULT (newid()) FOR [RowGuid]
GO
ALTER TABLE [dbo].[PoliticalParty] ADD  CONSTRAINT [DF_Political_Party_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StateEconomicInfo] ADD  CONSTRAINT [DF_StateEconomicInfo_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[CapacitationCenter]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenter_Conectivity] FOREIGN KEY([IdConectivity])
REFERENCES [dbo].[Conectivity] ([IdConectivity])
GO
ALTER TABLE [dbo].[CapacitationCenter] CHECK CONSTRAINT [FK_CapacitationCenter_Conectivity]
GO
ALTER TABLE [dbo].[CapacitationCenter]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenter_PopulationAttended] FOREIGN KEY([IdPopulationAttended])
REFERENCES [dbo].[PopulationAttended] ([IdPopulationAttended])
GO
ALTER TABLE [dbo].[CapacitationCenter] CHECK CONSTRAINT [FK_CapacitationCenter_PopulationAttended]
GO
ALTER TABLE [dbo].[CapacitationCenter]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenter_SocialCause] FOREIGN KEY([IdSocialCause])
REFERENCES [dbo].[SocialCause] ([IdSocialCause])
GO
ALTER TABLE [dbo].[CapacitationCenter] CHECK CONSTRAINT [FK_CapacitationCenter_SocialCause]
GO
ALTER TABLE [dbo].[CapacitationCenter]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenter_SocialOrganization] FOREIGN KEY([IdSocialOrganization])
REFERENCES [dbo].[SocialOrganization] ([IdSocialOrganization])
GO
ALTER TABLE [dbo].[CapacitationCenter] CHECK CONSTRAINT [FK_CapacitationCenter_SocialOrganization]
GO
ALTER TABLE [dbo].[CapacitationCenter]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenter_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[CapacitationCenter] CHECK CONSTRAINT [FK_CapacitationCenter_State]
GO
ALTER TABLE [dbo].[CapacitationCenterInformation]  WITH CHECK ADD  CONSTRAINT [FK_Capacitation_Center_Information_PopulationAttended] FOREIGN KEY([IdPopulationAttended])
REFERENCES [dbo].[PopulationAttended] ([IdPopulationAttended])
GO
ALTER TABLE [dbo].[CapacitationCenterInformation] CHECK CONSTRAINT [FK_Capacitation_Center_Information_PopulationAttended]
GO
ALTER TABLE [dbo].[CapacitationCenterInformation]  WITH CHECK ADD  CONSTRAINT [FK_Capacitation_Center_Information_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[CapacitationCenterInformation] CHECK CONSTRAINT [FK_Capacitation_Center_Information_State]
GO
ALTER TABLE [dbo].[CapacitationCenterInformation]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenterInformation_Conectivity] FOREIGN KEY([IdConectivity])
REFERENCES [dbo].[Conectivity] ([IdConectivity])
GO
ALTER TABLE [dbo].[CapacitationCenterInformation] CHECK CONSTRAINT [FK_CapacitationCenterInformation_Conectivity]
GO
ALTER TABLE [dbo].[CapacitationCenterInformation]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenterInformation_SocialCause] FOREIGN KEY([IdSocialCause])
REFERENCES [dbo].[SocialCause] ([IdSocialCause])
GO
ALTER TABLE [dbo].[CapacitationCenterInformation] CHECK CONSTRAINT [FK_CapacitationCenterInformation_SocialCause]
GO
ALTER TABLE [dbo].[CapacitationCenterInformation]  WITH CHECK ADD  CONSTRAINT [FK_CapacitationCenterInformation_SocialOrganization] FOREIGN KEY([IdSocialOrganization])
REFERENCES [dbo].[SocialOrganization] ([IdSocialOrganization])
GO
ALTER TABLE [dbo].[CapacitationCenterInformation] CHECK CONSTRAINT [FK_CapacitationCenterInformation_SocialOrganization]
GO
ALTER TABLE [dbo].[Competition]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Competitor] FOREIGN KEY([IdCompetitor])
REFERENCES [dbo].[Competitor] ([IdCompetitor])
GO
ALTER TABLE [dbo].[Competition] CHECK CONSTRAINT [FK_Competition_Competitor]
GO
ALTER TABLE [dbo].[Competition]  WITH CHECK ADD  CONSTRAINT [FK_Competition_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[Competition] CHECK CONSTRAINT [FK_Competition_State]
GO
ALTER TABLE [dbo].[Corporative_City]  WITH CHECK ADD  CONSTRAINT [FK_Corporative_City_Social_Organization_Information] FOREIGN KEY([IdSocialOrganizationInformation])
REFERENCES [dbo].[SocialOrganizationInformation] ([IdSocialOrganizationInformation])
GO
ALTER TABLE [dbo].[Corporative_City] CHECK CONSTRAINT [FK_Corporative_City_Social_Organization_Information]
GO
ALTER TABLE [dbo].[Corporative_City]  WITH CHECK ADD  CONSTRAINT [FK_Corporative_City_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[Corporative_City] CHECK CONSTRAINT [FK_Corporative_City_State]
GO
ALTER TABLE [dbo].[Corporative_City]  WITH CHECK ADD  CONSTRAINT [FK_Corporative_City_Time] FOREIGN KEY([IdFrom])
REFERENCES [dbo].[Time] ([IdMonth])
GO
ALTER TABLE [dbo].[Corporative_City] CHECK CONSTRAINT [FK_Corporative_City_Time]
GO
ALTER TABLE [dbo].[EducationInformationState]  WITH CHECK ADD  CONSTRAINT [FK_Education_Information_State_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[EducationInformationState] CHECK CONSTRAINT [FK_Education_Information_State_State]
GO
ALTER TABLE [dbo].[EnlaceTest]  WITH CHECK ADD  CONSTRAINT [FK_Enlace_Test_Education_Information_State] FOREIGN KEY([IdEducationInformationState])
REFERENCES [dbo].[EducationInformationState] ([IdEducationInformationState])
GO
ALTER TABLE [dbo].[EnlaceTest] CHECK CONSTRAINT [FK_Enlace_Test_Education_Information_State]
GO
ALTER TABLE [dbo].[EnlaceTest]  WITH CHECK ADD  CONSTRAINT [FK_EnlaceTest_SchoolGrade] FOREIGN KEY([IdSchoolGrade])
REFERENCES [dbo].[SchoolGrade] ([IdSchoolGrade])
GO
ALTER TABLE [dbo].[EnlaceTest] CHECK CONSTRAINT [FK_EnlaceTest_SchoolGrade]
GO
ALTER TABLE [dbo].[MainUniversities]  WITH CHECK ADD  CONSTRAINT [FK_Main_Universities_Education_Information_State] FOREIGN KEY([IdEducationInformationState])
REFERENCES [dbo].[EducationInformationState] ([IdEducationInformationState])
GO
ALTER TABLE [dbo].[MainUniversities] CHECK CONSTRAINT [FK_Main_Universities_Education_Information_State]
GO
ALTER TABLE [dbo].[MainUniversities]  WITH CHECK ADD  CONSTRAINT [FK_Main_Universities_Universities] FOREIGN KEY([IdUniversity])
REFERENCES [dbo].[Universities] ([IdUniversity])
GO
ALTER TABLE [dbo].[MainUniversities] CHECK CONSTRAINT [FK_Main_Universities_Universities]
GO
ALTER TABLE [dbo].[MexicoAgreement]  WITH CHECK ADD  CONSTRAINT [FK_MexicoAgreement_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[MexicoAgreement] CHECK CONSTRAINT [FK_MexicoAgreement_State]
GO
ALTER TABLE [dbo].[MexicoAgreement]  WITH CHECK ADD  CONSTRAINT [FK_MexicoAgreement_TypeAgreement] FOREIGN KEY([IdTypeAgreement])
REFERENCES [dbo].[TypeAgreement] ([IdTypeAgreement])
GO
ALTER TABLE [dbo].[MexicoAgreement] CHECK CONSTRAINT [FK_MexicoAgreement_TypeAgreement]
GO
ALTER TABLE [dbo].[MicrosoftProgramState]  WITH CHECK ADD  CONSTRAINT [FK_Microsoft_Program_State_Partner] FOREIGN KEY([IdPartner])
REFERENCES [dbo].[Partner] ([IdPartner])
GO
ALTER TABLE [dbo].[MicrosoftProgramState] CHECK CONSTRAINT [FK_Microsoft_Program_State_Partner]
GO
ALTER TABLE [dbo].[MicrosoftProgramState]  WITH CHECK ADD  CONSTRAINT [FK_Microsoft_Program_State_Program] FOREIGN KEY([IdProgram])
REFERENCES [dbo].[Program] ([IdProgram])
GO
ALTER TABLE [dbo].[MicrosoftProgramState] CHECK CONSTRAINT [FK_Microsoft_Program_State_Program]
GO
ALTER TABLE [dbo].[MicrosoftProgramState]  WITH CHECK ADD  CONSTRAINT [FK_Microsoft_Program_State_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[MicrosoftProgramState] CHECK CONSTRAINT [FK_Microsoft_Program_State_State]
GO
ALTER TABLE [dbo].[MicrosoftProgramState]  WITH CHECK ADD  CONSTRAINT [FK_MicrosoftProgramState_Contacts] FOREIGN KEY([IdContactMsft])
REFERENCES [dbo].[Contacts] ([IdContact])
GO
ALTER TABLE [dbo].[MicrosoftProgramState] CHECK CONSTRAINT [FK_MicrosoftProgramState_Contacts]
GO
ALTER TABLE [dbo].[MicrosoftProgramState]  WITH CHECK ADD  CONSTRAINT [FK_MicrosoftProgramState_Contacts1] FOREIGN KEY([IdContactState])
REFERENCES [dbo].[Contacts] ([IdContact])
GO
ALTER TABLE [dbo].[MicrosoftProgramState] CHECK CONSTRAINT [FK_MicrosoftProgramState_Contacts1]
GO
ALTER TABLE [dbo].[MicrosoftProgramState]  WITH CHECK ADD  CONSTRAINT [FK_MicrosoftProgramState_Source] FOREIGN KEY([IdSource])
REFERENCES [dbo].[Source] ([IdSource])
GO
ALTER TABLE [dbo].[MicrosoftProgramState] CHECK CONSTRAINT [FK_MicrosoftProgramState_Source]
GO
ALTER TABLE [dbo].[Municipality]  WITH CHECK ADD  CONSTRAINT [FK_Municipality_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[Municipality] CHECK CONSTRAINT [FK_Municipality_State]
GO
ALTER TABLE [dbo].[OpenSourceState]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceState_Penetration] FOREIGN KEY([IdPenetration])
REFERENCES [dbo].[Penetration] ([IdPenetration])
GO
ALTER TABLE [dbo].[OpenSourceState] CHECK CONSTRAINT [FK_OpenSourceState_Penetration]
GO
ALTER TABLE [dbo].[OpenSourceState]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceState_Products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Products] ([IdProduct])
GO
ALTER TABLE [dbo].[OpenSourceState] CHECK CONSTRAINT [FK_OpenSourceState_Products]
GO
ALTER TABLE [dbo].[OpenSourceState]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceState_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[OpenSourceState] CHECK CONSTRAINT [FK_OpenSourceState_State]
GO
ALTER TABLE [dbo].[OpenSourceState]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceState_TypeProduct] FOREIGN KEY([IdTypeProduct])
REFERENCES [dbo].[TypeProduct] ([IdTypeProduct])
GO
ALTER TABLE [dbo].[OpenSourceState] CHECK CONSTRAINT [FK_OpenSourceState_TypeProduct]
GO
ALTER TABLE [dbo].[OpenSourceStateCommunity]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceStateCommunity_Contacts] FOREIGN KEY([IdContact])
REFERENCES [dbo].[Contacts] ([IdContact])
GO
ALTER TABLE [dbo].[OpenSourceStateCommunity] CHECK CONSTRAINT [FK_OpenSourceStateCommunity_Contacts]
GO
ALTER TABLE [dbo].[OpenSourceStateCommunity]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceStateCommunity_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[OpenSourceStateCommunity] CHECK CONSTRAINT [FK_OpenSourceStateCommunity_State]
GO
ALTER TABLE [dbo].[OpenSourceStateProvider]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceStateProvider_Products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Products] ([IdProduct])
GO
ALTER TABLE [dbo].[OpenSourceStateProvider] CHECK CONSTRAINT [FK_OpenSourceStateProvider_Products]
GO
ALTER TABLE [dbo].[OpenSourceStateProvider]  WITH CHECK ADD  CONSTRAINT [FK_OpenSourceStateProvider_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[OpenSourceStateProvider] CHECK CONSTRAINT [FK_OpenSourceStateProvider_State]
GO
ALTER TABLE [dbo].[PoliticalInformationMunicipality]  WITH CHECK ADD  CONSTRAINT [FK_Political_Information_Municipality_Municipality] FOREIGN KEY([IdMunicipality])
REFERENCES [dbo].[Municipality] ([IdMunicipality])
GO
ALTER TABLE [dbo].[PoliticalInformationMunicipality] CHECK CONSTRAINT [FK_Political_Information_Municipality_Municipality]
GO
ALTER TABLE [dbo].[PoliticalInformationMunicipality]  WITH CHECK ADD  CONSTRAINT [FK_Political_Information_Municipality_Political_Party] FOREIGN KEY([IdPoliticalParty])
REFERENCES [dbo].[PoliticalParty] ([IdPoliticalParty])
GO
ALTER TABLE [dbo].[PoliticalInformationMunicipality] CHECK CONSTRAINT [FK_Political_Information_Municipality_Political_Party]
GO
ALTER TABLE [dbo].[PoliticalInformationState]  WITH CHECK ADD  CONSTRAINT [FK_Political_Information_State_Political_Party] FOREIGN KEY([IdPoliticalParty])
REFERENCES [dbo].[PoliticalParty] ([IdPoliticalParty])
GO
ALTER TABLE [dbo].[PoliticalInformationState] CHECK CONSTRAINT [FK_Political_Information_State_Political_Party]
GO
ALTER TABLE [dbo].[PoliticalInformationState]  WITH CHECK ADD  CONSTRAINT [FK_Political_Information_State_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[PoliticalInformationState] CHECK CONSTRAINT [FK_Political_Information_State_State]
GO
ALTER TABLE [dbo].[PoliticalInformationStateFiles]  WITH CHECK ADD  CONSTRAINT [FK_PoliticalInformationStateFiles_PoliticalInformationState] FOREIGN KEY([IdPoliticalInformationState])
REFERENCES [dbo].[PoliticalInformationState] ([IdPoliticalInformationState])
GO
ALTER TABLE [dbo].[PoliticalInformationStateFiles] CHECK CONSTRAINT [FK_PoliticalInformationStateFiles_PoliticalInformationState]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_TypeProduct] FOREIGN KEY([IdTypeProduct])
REFERENCES [dbo].[TypeProduct] ([IdTypeProduct])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_TypeProduct]
GO
ALTER TABLE [dbo].[SchoolsInformation]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Information_Education_Information_State] FOREIGN KEY([IdEducationInformationState])
REFERENCES [dbo].[EducationInformationState] ([IdEducationInformationState])
GO
ALTER TABLE [dbo].[SchoolsInformation] CHECK CONSTRAINT [FK_Schools_Information_Education_Information_State]
GO
ALTER TABLE [dbo].[SchoolsInformation]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Information_School_Level] FOREIGN KEY([IdSchoolLevel])
REFERENCES [dbo].[SchoolLevel] ([IdSchoolLevel])
GO
ALTER TABLE [dbo].[SchoolsInformation] CHECK CONSTRAINT [FK_Schools_Information_School_Level]
GO
ALTER TABLE [dbo].[SchoolsInformation]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Information_School_Type] FOREIGN KEY([IdSchoolType])
REFERENCES [dbo].[SchoolType] ([IdSchoolType])
GO
ALTER TABLE [dbo].[SchoolsInformation] CHECK CONSTRAINT [FK_Schools_Information_School_Type]
GO
ALTER TABLE [dbo].[SEPProjectState]  WITH CHECK ADD  CONSTRAINT [FK_SEP_Project_State_Education_Information_State] FOREIGN KEY([IdEducationInformationState])
REFERENCES [dbo].[EducationInformationState] ([IdEducationInformationState])
GO
ALTER TABLE [dbo].[SEPProjectState] CHECK CONSTRAINT [FK_SEP_Project_State_Education_Information_State]
GO
ALTER TABLE [dbo].[SEPProjectState]  WITH CHECK ADD  CONSTRAINT [FK_SEPProjectState_TypeSepProject] FOREIGN KEY([IdTypeSepProject])
REFERENCES [dbo].[TypeSepProject] ([IdTypeSepProject])
GO
ALTER TABLE [dbo].[SEPProjectState] CHECK CONSTRAINT [FK_SEPProjectState_TypeSepProject]
GO
ALTER TABLE [dbo].[SocialOrganizationInformation]  WITH CHECK ADD  CONSTRAINT [FK_Social_Organization_Information_PopulationAttended] FOREIGN KEY([IdPopulationAttended])
REFERENCES [dbo].[PopulationAttended] ([IdPopulationAttended])
GO
ALTER TABLE [dbo].[SocialOrganizationInformation] CHECK CONSTRAINT [FK_Social_Organization_Information_PopulationAttended]
GO
ALTER TABLE [dbo].[SocialOrganizationInformation]  WITH CHECK ADD  CONSTRAINT [FK_Social_Organization_Information_Social_Cause] FOREIGN KEY([IdSocialCause])
REFERENCES [dbo].[SocialCause] ([IdSocialCause])
GO
ALTER TABLE [dbo].[SocialOrganizationInformation] CHECK CONSTRAINT [FK_Social_Organization_Information_Social_Cause]
GO
ALTER TABLE [dbo].[SocialOrganizationInformation]  WITH CHECK ADD  CONSTRAINT [FK_Social_Organization_Information_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[SocialOrganizationInformation] CHECK CONSTRAINT [FK_Social_Organization_Information_State]
GO
ALTER TABLE [dbo].[StateEconomicInfo]  WITH CHECK ADD  CONSTRAINT [FK_State_Economic_Info_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[StateEconomicInfo] CHECK CONSTRAINT [FK_State_Economic_Info_State]
GO
ALTER TABLE [dbo].[StudentsInformation]  WITH CHECK ADD  CONSTRAINT [FK_Students_Information_Education_Information_State] FOREIGN KEY([IdEducationInformationState])
REFERENCES [dbo].[EducationInformationState] ([IdEducationInformationState])
GO
ALTER TABLE [dbo].[StudentsInformation] CHECK CONSTRAINT [FK_Students_Information_Education_Information_State]
GO
ALTER TABLE [dbo].[StudentsInformation]  WITH CHECK ADD  CONSTRAINT [FK_Students_Information_School_Level] FOREIGN KEY([IdSchoolLevel])
REFERENCES [dbo].[SchoolLevel] ([IdSchoolLevel])
GO
ALTER TABLE [dbo].[StudentsInformation] CHECK CONSTRAINT [FK_Students_Information_School_Level]
GO
ALTER TABLE [dbo].[StudentsInformation]  WITH CHECK ADD  CONSTRAINT [FK_Students_Information_School_Type] FOREIGN KEY([IdSchoolType])
REFERENCES [dbo].[SchoolType] ([IdSchoolType])
GO
ALTER TABLE [dbo].[StudentsInformation] CHECK CONSTRAINT [FK_Students_Information_School_Type]
GO
ALTER TABLE [dbo].[TeachersInformation]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Information_Education_Information_State] FOREIGN KEY([IdEducationInformationState])
REFERENCES [dbo].[EducationInformationState] ([IdEducationInformationState])
GO
ALTER TABLE [dbo].[TeachersInformation] CHECK CONSTRAINT [FK_Teachers_Information_Education_Information_State]
GO
ALTER TABLE [dbo].[TeachersInformation]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Information_School_Level] FOREIGN KEY([IdSchoolLevel])
REFERENCES [dbo].[SchoolLevel] ([IdSchoolLevel])
GO
ALTER TABLE [dbo].[TeachersInformation] CHECK CONSTRAINT [FK_Teachers_Information_School_Level]
GO
ALTER TABLE [dbo].[TeachersInformation]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Information_School_Type] FOREIGN KEY([IdSchoolType])
REFERENCES [dbo].[SchoolType] ([IdSchoolType])
GO
ALTER TABLE [dbo].[TeachersInformation] CHECK CONSTRAINT [FK_Teachers_Information_School_Type]
GO
ALTER TABLE [dbo].[Universities]  WITH CHECK ADD  CONSTRAINT [FK_Universities_State] FOREIGN KEY([IdState])
REFERENCES [dbo].[State] ([IdState])
GO
ALTER TABLE [dbo].[Universities] CHECK CONSTRAINT [FK_Universities_State]
GO
ALTER TABLE [dbo].[Wallet_Share]  WITH CHECK ADD  CONSTRAINT [FK_Wallet_Share_Products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Products] ([IdProduct])
GO
ALTER TABLE [dbo].[Wallet_Share] CHECK CONSTRAINT [FK_Wallet_Share_Products]
GO
ALTER TABLE [dbo].[Wallet_Share]  WITH CHECK ADD  CONSTRAINT [FK_Wallet_Share_State_Economic_Info] FOREIGN KEY([IdStateEconomicInfo])
REFERENCES [dbo].[StateEconomicInfo] ([IdStateEconomicInfo])
GO
ALTER TABLE [dbo].[Wallet_Share] CHECK CONSTRAINT [FK_Wallet_Share_State_Economic_Info]
GO
USE [master]
GO
ALTER DATABASE [TestArchive] SET  READ_WRITE 
GO
