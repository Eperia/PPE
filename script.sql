USE [master]
GO
/****** Object:  Database [megacasting]    Script Date: 06/12/2018 04:42:33 ******/
CREATE DATABASE [megacasting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'megacasting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\megacasting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'megacasting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\megacasting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [megacasting] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [megacasting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [megacasting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [megacasting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [megacasting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [megacasting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [megacasting] SET ARITHABORT OFF 
GO
ALTER DATABASE [megacasting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [megacasting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [megacasting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [megacasting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [megacasting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [megacasting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [megacasting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [megacasting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [megacasting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [megacasting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [megacasting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [megacasting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [megacasting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [megacasting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [megacasting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [megacasting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [megacasting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [megacasting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [megacasting] SET  MULTI_USER 
GO
ALTER DATABASE [megacasting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [megacasting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [megacasting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [megacasting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [megacasting] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [megacasting] SET QUERY_STORE = OFF
GO
USE [megacasting]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [megacasting]
GO
/****** Object:  Table [dbo].[ContenuEditorial]    Script Date: 06/12/2018 04:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContenuEditorial](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Titre] [nvarchar](50) NOT NULL,
	[Contenue] [text] NOT NULL,
	[description] [nvarchar](150) NOT NULL,
	[Id_Employe] [bigint] NOT NULL,
	[Id_TypeContenu] [bigint] NOT NULL,
 CONSTRAINT [PK_ContenuEditorial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomaineMetier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DomaineMetier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employe]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employe](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[Id_TypeUtilisateur] [bigint] NOT NULL,
	[mdp] [varchar](50) NOT NULL,
 CONSTRAINT [PK_employe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Id_DomaineMetier] [bigint] NOT NULL,
 CONSTRAINT [PK_Metier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metier_OffreCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metier_OffreCasting](
	[Id_Metier] [bigint] NOT NULL,
	[Id_OffreCasting] [bigint] NOT NULL,
	[Id_TypeContrat] [bigint] NOT NULL,
 CONSTRAINT [PK_Metier_OffreCasting] PRIMARY KEY CLUSTERED 
(
	[Id_Metier] ASC,
	[Id_OffreCasting] ASC,
	[Id_TypeContrat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffreCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OffreCasting](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Professionel] [bigint] NOT NULL,
	[Id_Employe] [bigint] NULL,
	[Titre] [nvarchar](50) NOT NULL,
	[dt_debut_publi] [datetime] NULL,
	[dure_dif] [int] NOT NULL,
	[dt_debut_contrat] [datetime] NOT NULL,
	[localisation] [nvarchar](100) NULL,
	[desc] [text] NOT NULL,
	[dt_demande] [datetime] NOT NULL,
	[Etat] [char](10) NULL,
 CONSTRAINT [PK_OffreCasting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackCasting](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[libelle] [nvarchar](50) NOT NULL,
	[NbrPost] [int] NOT NULL,
 CONSTRAINT [PK_PackCasting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partenaire]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partenaire](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](150) NULL,
	[Rue] [varchar](100) NOT NULL,
	[Telephone] [nvarchar](10) NOT NULL,
	[Fax] [nvarchar](10) NULL,
	[CodePostal] [nvarchar](10) NOT NULL,
	[Ville] [nvarchar](50) NOT NULL,
	[Pays] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[mdp] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_partenaire] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrixPack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrixPack](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Prix] [float] NOT NULL,
	[dt_deb] [datetime] NOT NULL,
	[dt_fin] [datetime] NULL,
	[Id_PackCasting] [bigint] NOT NULL,
 CONSTRAINT [PK_PrixPack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professionnel]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professionnel](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Telephone] [nvarchar](10) NOT NULL,
	[Url] [nvarchar](100) NULL,
	[Fax] [nvarchar](50) NULL,
	[rue] [nvarchar](100) NOT NULL,
	[mdp] [nvarchar](200) NOT NULL,
	[NbrPost] [int] NOT NULL,
	[CodePostal] [nvarchar](10) NOT NULL,
	[Ville] [nvarchar](50) NOT NULL,
	[Pays] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Professionnel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professionnel_PackCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professionnel_PackCasting](
	[Id_Professionnel] [bigint] NOT NULL,
	[Id_PackCasting] [bigint] NOT NULL,
	[dt-achat] [datetime] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Professionnel_PackCasting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeContenu]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeContenu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeContrat]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeContrat](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeContrat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUtilisateur]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUtilisateur](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[libelle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeUtilisateur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContenuEditorial]  WITH CHECK ADD  CONSTRAINT [FK_ContenuEditorial_employe] FOREIGN KEY([Id_Employe])
REFERENCES [dbo].[employe] ([Id])
GO
ALTER TABLE [dbo].[ContenuEditorial] CHECK CONSTRAINT [FK_ContenuEditorial_employe]
GO
ALTER TABLE [dbo].[ContenuEditorial]  WITH CHECK ADD  CONSTRAINT [FK_ContenuEditorial_TypeContrat] FOREIGN KEY([Id_TypeContenu])
REFERENCES [dbo].[TypeContrat] ([Id])
GO
ALTER TABLE [dbo].[ContenuEditorial] CHECK CONSTRAINT [FK_ContenuEditorial_TypeContrat]
GO
ALTER TABLE [dbo].[employe]  WITH CHECK ADD  CONSTRAINT [FK_employe_TypeUtilisateur] FOREIGN KEY([Id_TypeUtilisateur])
REFERENCES [dbo].[TypeUtilisateur] ([Id])
GO
ALTER TABLE [dbo].[employe] CHECK CONSTRAINT [FK_employe_TypeUtilisateur]
GO
ALTER TABLE [dbo].[Metier]  WITH CHECK ADD  CONSTRAINT [FK_Metier_DomaineMetier] FOREIGN KEY([Id_DomaineMetier])
REFERENCES [dbo].[DomaineMetier] ([Id])
GO
ALTER TABLE [dbo].[Metier] CHECK CONSTRAINT [FK_Metier_DomaineMetier]
GO
ALTER TABLE [dbo].[Metier_OffreCasting]  WITH CHECK ADD  CONSTRAINT [FK_Metier_OffreCasting_Metier] FOREIGN KEY([Id_Metier])
REFERENCES [dbo].[Metier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Metier_OffreCasting] CHECK CONSTRAINT [FK_Metier_OffreCasting_Metier]
GO
ALTER TABLE [dbo].[Metier_OffreCasting]  WITH CHECK ADD  CONSTRAINT [FK_Metier_OffreCasting_OffreCasting] FOREIGN KEY([Id_OffreCasting])
REFERENCES [dbo].[OffreCasting] ([Id])
GO
ALTER TABLE [dbo].[Metier_OffreCasting] CHECK CONSTRAINT [FK_Metier_OffreCasting_OffreCasting]
GO
ALTER TABLE [dbo].[Metier_OffreCasting]  WITH CHECK ADD  CONSTRAINT [FK_Metier_OffreCasting_TypeContrat] FOREIGN KEY([Id_TypeContrat])
REFERENCES [dbo].[TypeContrat] ([Id])
GO
ALTER TABLE [dbo].[Metier_OffreCasting] CHECK CONSTRAINT [FK_Metier_OffreCasting_TypeContrat]
GO
ALTER TABLE [dbo].[OffreCasting]  WITH CHECK ADD  CONSTRAINT [FK_OffreCasting_employe] FOREIGN KEY([Id_Employe])
REFERENCES [dbo].[employe] ([Id])
GO
ALTER TABLE [dbo].[OffreCasting] CHECK CONSTRAINT [FK_OffreCasting_employe]
GO
ALTER TABLE [dbo].[OffreCasting]  WITH CHECK ADD  CONSTRAINT [FK_OffreCasting_Professionnel] FOREIGN KEY([Id_Professionel])
REFERENCES [dbo].[Professionnel] ([Id])
GO
ALTER TABLE [dbo].[OffreCasting] CHECK CONSTRAINT [FK_OffreCasting_Professionnel]
GO
ALTER TABLE [dbo].[PrixPack]  WITH CHECK ADD  CONSTRAINT [FK_PrixPack_PackCasting] FOREIGN KEY([Id_PackCasting])
REFERENCES [dbo].[PackCasting] ([id])
GO
ALTER TABLE [dbo].[PrixPack] CHECK CONSTRAINT [FK_PrixPack_PackCasting]
GO
ALTER TABLE [dbo].[Professionnel_PackCasting]  WITH CHECK ADD  CONSTRAINT [FK_Professionnel_PackCasting_PackCasting] FOREIGN KEY([Id_PackCasting])
REFERENCES [dbo].[PackCasting] ([id])
GO
ALTER TABLE [dbo].[Professionnel_PackCasting] CHECK CONSTRAINT [FK_Professionnel_PackCasting_PackCasting]
GO
ALTER TABLE [dbo].[Professionnel_PackCasting]  WITH CHECK ADD  CONSTRAINT [FK_Professionnel_PackCasting_Professionnel] FOREIGN KEY([Id_Professionnel])
REFERENCES [dbo].[Professionnel] ([Id])
GO
ALTER TABLE [dbo].[Professionnel_PackCasting] CHECK CONSTRAINT [FK_Professionnel_PackCasting_Professionnel]
GO
/****** Object:  StoredProcedure [dbo].[DeleteDomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteDomaineMetier]( @id bigint)
As
DELETE FROM DomaineMetier

WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[DeleteMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeleteMetier]( @id bigint)
As
DELETE FROM Metier

WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[DeletePartenaire]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DeletePartenaire]( @id bigint)
As
DELETE FROM partenaire

WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[DeleteProfessionnel]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteProfessionnel]( @id bigint)
As
DELETE FROM Professionnel

WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[InsertDomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsertDomaineMetier] ( @nom nvarchar(50), @IdReturn bigint out)
As

insert into DomaineMetier(Nom) values (@nom)
select @IdReturn = @@IDENTITY


GO
/****** Object:  StoredProcedure [dbo].[InsertMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsertMetier] ( @Nom nvarchar(50),@Id_DomaineMetier bigint, @IdReturn bigint out)
As

insert into Metier(Nom, [Id_DomaineMetier]) values (@Nom,@Id_DomaineMetier);
select @IdReturn = @@IDENTITY


GO
/****** Object:  StoredProcedure [dbo].[InsertPackCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertPackCasting](@nom nvarchar(50),@nbrPoste int,@IdReturn bigint out)
as

insert PackCasting(libelle,NbrPost)values(@nom,@nbrPoste)
select @IdReturn = @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[InsertPartenaire]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsertPartenaire] (@libelle nvarchar(50),@email nvarchar(150) ,@URL nvarchar(150) ,@telephone nvarchar(10) ,@fax nvarchar(10),@Rue nvarchar(100),@Ville nvarchar(50),@CodePostal nvarchar(10),@Pays nvarchar(50),@mdp nvarchar(200))
As

insert into partenaire (libelle,URL,Rue,telephone,fax,Ville,CodePostal,Pays,mdp,Email) values (@libelle,@URL,@Rue,@telephone,@fax,@Ville,@CodePostal,@Pays,@mdp,@email)

GO
/****** Object:  StoredProcedure [dbo].[InsertPrix]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertPrix](@prix nvarchar(50),@Id_PackCasting bigint)
as

insert PrixPack(Prix,dt_deb,Id_PackCasting)values(@prix,SYSDATETIME(),@Id_PackCasting)

GO
/****** Object:  StoredProcedure [dbo].[InsertPrixPack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertPrixPack](@prix nvarchar(50),@Id_PackCasting bigint)
as

insert PrixPack(Prix,dt_deb,Id_PackCasting)values(@prix,SYSDATETIME(),@Id_PackCasting)

GO
/****** Object:  StoredProcedure [dbo].[InsertProfessionnel]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[InsertProfessionnel] ( @libelle nvarchar(50), @URL nvarchar(150),@Rue nvarchar(100),@Ville nvarchar(50),@CodePostal nvarchar(10),@Pays nvarchar(50),@telephone nvarchar(10),@fax nvarchar(10),@email nvarchar(50),@nbrPost int,@mdp nvarchar(50))
As

insert into Professionnel(Nom,URL,rue,Ville,CodePostal,Pays,telephone,fax,Email,NbrPost,mdp) values (@libelle,@URL,@rue,@Ville,@CodePostal,@Pays,@telephone,@fax,@email,@nbrPost,@mdp)


GO
/****** Object:  StoredProcedure [dbo].[InsertProfessionnelPack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[InsertProfessionnelPack] ( @id_PackCasting bigint ,@id_Professionnel bigint)
As

Insert Professionnel_PackCasting (Id_PackCasting,Id_Professionnel, [dt-achat])
Values (@id_PackCasting,@id_Professionnel, SYSDATETIME())

GO
/****** Object:  StoredProcedure [dbo].[SelectDomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SelectDomaineMetier]
AS

Select id,Nom
from DomaineMetier


GO
/****** Object:  StoredProcedure [dbo].[SelectEmploye]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script de la commande SelectTopNRows à partir de SSMS  ******/


  create proc [dbo].[SelectEmploye]
  as
  SELECT [Id]
      ,[Nom]
      ,[Prenom]
      ,[email]
      ,[Id_TypeUtilisateur]
      ,[mdp]
  FROM [megacasting].[dbo].[employe]
GO
/****** Object:  StoredProcedure [dbo].[SelectHistoriquePack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectHistoriquePack] (@id bigint)
As

select [dt-achat]
      ,[Professionnel_PackCasting].[Id_PackCasting]
      ,[Professionnel_PackCasting].[Id]
  FROM [megacasting].[dbo].[Professionnel_PackCasting]
where Id_Professionnel=@id



GO
/****** Object:  StoredProcedure [dbo].[SelectHistoriquePrix]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectHistoriquePrix] (@id bigint,@dt_achat DateTime)
as
Select id, PrixPack.Prix, PrixPack.dt_deb,PrixPack.dt_fin,PrixPack.Id_PackCasting
from PrixPack
where Id_PackCasting = @id
and dt_deb < @dt_achat 
and dt_fin >@dt_achat
GO
/****** Object:  StoredProcedure [dbo].[SelectIdDomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[SelectIdDomaineMetier] (@nom varchar(50))
as

Select id
from DomaineMetier
where DomaineMetier.Nom = @nom

GO
/****** Object:  StoredProcedure [dbo].[SelectMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SelectMetier]
AS

Select id,Nom,[Id_DomaineMetier]
from Metier


GO
/****** Object:  StoredProcedure [dbo].[SelectNameDomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  proc [dbo].[SelectNameDomaineMetier] (@id bigint)
as

select Nom
from DomaineMetier
where id = @id

GO
/****** Object:  StoredProcedure [dbo].[SelectOffreCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectOffreCasting]
as
  select [Id]
      ,[Id_Professionel]
      ,[Id_Employe]
      ,[Titre]
      ,[dt_debut_publi]
      ,[dure_dif]
      ,[dt_debut_contrat]
      ,[localisation]
      ,[desc]
      ,[dt_demande]
	  from OffreCasting
where DATEADD(MONTH,dure_dif,dt_debut_publi) > SYSDATETIME()

GO
/****** Object:  StoredProcedure [dbo].[SelectOffreCastingCinq]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SelectOffreCastingCinq]
As

Select Top 5 [Id]
      ,[Id_Professionel]
      ,[Id_Employe]
      ,[Titre]
      ,[dt_debut_publi]
      ,[dure_dif]
      ,[dt_debut_contrat]
      ,[nb_post]
      ,[localisation]
      ,[desc]
      ,[dt_demande]

From OffreCasting
where Etat = 'attente'
Order by [dt_demande] desc

GO
/****** Object:  StoredProcedure [dbo].[SelectOffreCastingUn]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[SelectOffreCastingUn]
As

Select Top 5 [Id]
      ,[Id_Professionel]
      ,[Id_Employe]
      ,[Titre]
      ,[dt_debut_publi]
      ,[dure_dif]
      ,[dt_debut_contrat]
      ,[nb_post]
      ,[localisation]
      ,[desc]
      ,[dt_demande]

From OffreCasting
where Etat = 'attente'
Order by [dt_demande] desc

GO
/****** Object:  StoredProcedure [dbo].[SelectOnePack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectOnePack] (@id bigint)
As

SELECT [id]
      ,[libelle]
      ,[NbrPost]
  FROM [megacasting].[dbo].[PackCasting]
  where id = @id

GO
/****** Object:  StoredProcedure [dbo].[SelectOneProfessionnel]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[SelectOneProfessionnel] (@id bigint)
As

SELECT TOP (1000) [Id]
      ,[Nom]
      ,[Email]
      ,[Telephone]
      ,[Url]
      ,[Fax]
      ,[rue]
      ,[mdp]
      ,[NbrPost]
      ,[CodePostal]
      ,[Ville]
      ,[Pays]
  FROM [megacasting].[dbo].[Professionnel]
  where id = @id

GO
/****** Object:  StoredProcedure [dbo].[SelectPackCasting]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectPackCasting]
as

Select id,libelle,NbrPost
from PackCasting

GO
/****** Object:  StoredProcedure [dbo].[SelectPartenaire]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SelectPartenaire]
AS

Select id,libelle,[URL],telephone,Rue,Ville,CodePostal,Pays,email,fax
from partenaire

GO
/****** Object:  StoredProcedure [dbo].[SelectPrixPack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectPrixPack] (@id bigint)
as

Select id, PrixPack.Prix, PrixPack.dt_deb,PrixPack.dt_fin,PrixPack.Id_PackCasting
from PrixPack
where Id_PackCasting = @id
and dt_fin is null

GO
/****** Object:  StoredProcedure [dbo].[SelectProfessionnel]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SelectProfessionnel]
AS

Select id,Nom,[URL],telephone,Rue,Ville,CodePostal,Pays,email,fax,NbrPost
from Professionnel

GO
/****** Object:  StoredProcedure [dbo].[UpdateDomaineMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateDomaineMetier]( @id bigint ,@Nom nvarchar(50))
As

UPDATE DomaineMetier 
SET Nom = @Nom

WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[UpdateMetier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateMetier]( @id bigint ,@Nom nvarchar(50), @Id_DomaineMetier bigint)
As

UPDATE Metier 
SET Nom = @Nom, [Id_DomaineMetier] = @Id_DomaineMetier

WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[UpdatePack]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[UpdatePack] (@id bigint,@nom varchar(50),@nbrPoste int, @prix float)
as

update PackCasting
set libelle=@nom, NbrPost=@nbrPoste
where id = @id

if(@prix != 0)

Update PrixPack
set dt_fin = SYSDATETIME() 
where PrixPack.dt_fin is null
and PrixPack.Id_PackCasting = 1

if(@prix != 0)

insert PrixPack (Prix,dt_deb,Id_PackCasting)Values(@prix,SYSDATETIME(),@id)

GO
/****** Object:  StoredProcedure [dbo].[UpdatePartenaire]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdatePartenaire]( @id bigint ,@libelle nvarchar(50) ,@URL nvarchar(150) ,@telephone nvarchar(10) ,@fax nvarchar(10),@Rue nvarchar(100),@Ville nvarchar(50),@CodePostal nvarchar(10),@Pays nvarchar(50),@mdp nvarchar(250))
As

UPDATE partenaire 
SET libelle = @libelle, Rue = @Rue ,URL= @URL, telephone = @telephone, fax = @fax,Ville=@Ville,CodePostal=@CodePostal,Pays=@Pays,mdp = @mdp
WHERE id = @id


GO
/****** Object:  StoredProcedure [dbo].[UpdateProfessionnel]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UpdateProfessionnel]( @id bigint ,@libelle nvarchar(50) ,@URL nvarchar(150),@telephone nvarchar(10) ,@fax nvarchar(10),@email nvarchar(50),@nbrPost int,@Rue nvarchar(100),@Ville nvarchar(50),@CodePostal nvarchar(10),@Pays nvarchar(50))
As

UPDATE Professionnel 
SET Nom = @libelle,URL= @URL, telephone = @telephone, fax = @fax, email = @email, NbrPost = @nbrPost,Ville=@Ville,CodePostal=@CodePostal,Pays=@Pays

WHERE id = @id

GO
/****** Object:  StoredProcedure [dbo].[UpdateProfessionnelWithmdp]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[UpdateProfessionnelWithmdp] ( @id bigint ,@libelle nvarchar(50) ,@URL nvarchar(150),@telephone nvarchar(10) ,@fax nvarchar(10),@email nvarchar(50),@nbrPost int,@Rue nvarchar(100),@Ville nvarchar(50),@CodePostal nvarchar(10),@Pays nvarchar(50),@mdp nvarchar(250) )
As

UPDATE Professionnel 
SET Nom = @libelle,URL= @URL, telephone = @telephone, fax = @fax, email = @email, NbrPost = @nbrPost,Ville=@Ville,CodePostal=@CodePostal,Pays=@Pays,mdp =@mdp

WHERE id = @id

GO
/****** Object:  StoredProcedure [dbo].[VerifDomaineMetier_Metier]    Script Date: 06/12/2018 04:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[VerifDomaineMetier_Metier]( @id bigint, @IdReturn bigint out)
As
select @IdReturn = count(id)
from Metier

WHERE Id_DomaineMetier = @id


GO
USE [master]
GO
ALTER DATABASE [megacasting] SET  READ_WRITE 
GO
