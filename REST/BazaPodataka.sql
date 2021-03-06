USE [master]
GO
/****** Object:  Database [BazaPodataka]    Script Date: 3/6/2021 12:16:02 PM ******/
CREATE DATABASE [BazaPodataka]
GO
ALTER DATABASE [BazaPodataka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BazaPodataka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BazaPodataka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BazaPodataka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BazaPodataka] SET ARITHABORT OFF 
GO
ALTER DATABASE [BazaPodataka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BazaPodataka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BazaPodataka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BazaPodataka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BazaPodataka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BazaPodataka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BazaPodataka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BazaPodataka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BazaPodataka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BazaPodataka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BazaPodataka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BazaPodataka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BazaPodataka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BazaPodataka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BazaPodataka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BazaPodataka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BazaPodataka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BazaPodataka] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BazaPodataka] SET  MULTI_USER 
GO
ALTER DATABASE [BazaPodataka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BazaPodataka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BazaPodataka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BazaPodataka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BazaPodataka] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BazaPodataka] SET QUERY_STORE = OFF
GO
USE [BazaPodataka]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BazaPodataka]
GO
/****** Object:  Table [dbo].[Kartica]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kartica](
	[KarticaID] [int] IDENTITY(1,1) NOT NULL,
	[SkupKarticaID] [int] NOT NULL,
	[TekstFront] [varchar](200) NULL,
	[TekstBack] [varchar](200) NULL,
 CONSTRAINT [PK_Kartica] PRIMARY KEY CLUSTERED 
(
	[KarticaID] ASC,
	[SkupKarticaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Komentar]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Komentar](
	[KomentarID] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[SkupKarticaID] [int] NOT NULL,
	[Tekst] [varchar](200) NULL,
 CONSTRAINT [PK_Komentar_1] PRIMARY KEY CLUSTERED 
(
	[KomentarID] ASC,
	[KorisnikID] ASC,
	[SkupKarticaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[KorisnikID] [int] IDENTITY(1,1) NOT NULL,
	[KorisnickoIme] [varchar](50) NULL,
	[Sifra] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Uloga] [int] NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lajk]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lajk](
	[KorisnikID] [int] NOT NULL,
	[SkupKartica] [int] NOT NULL,
 CONSTRAINT [PK_Lajk] PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC,
	[SkupKartica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Podkomentar]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Podkomentar](
	[PodKomentarID] [int] IDENTITY(1,1) NOT NULL,
	[KomentarID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[SkupKartica] [int] NOT NULL,
	[Tekst] [varchar](200) NULL,
	[PodkomentarisaoID] [int] NULL,
 CONSTRAINT [PK_Podkomentar_1] PRIMARY KEY CLUSTERED 
(
	[PodKomentarID] ASC,
	[KomentarID] ASC,
	[KorisnikID] ASC,
	[SkupKartica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predmet]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmet](
	[PredmetID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](200) NULL,
	[GodinaStudija] [int] NULL,
	[Semestar] [int] NULL,
	[Smer] [int] NULL,
 CONSTRAINT [PK_Predmet] PRIMARY KEY CLUSTERED 
(
	[PredmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkupKartica]    Script Date: 3/6/2021 12:16:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkupKartica](
	[SkupKarticaID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](50) NULL,
	[DatumKreiranja] [datetime] NULL,
	[KorisnikID] [int] NULL,
	[PredmetID] [int] NULL,
 CONSTRAINT [PK_SkupKartica] PRIMARY KEY CLUSTERED 
(
	[SkupKarticaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Kartica]  WITH CHECK ADD  CONSTRAINT [FK_Kartica_SkupKartica] FOREIGN KEY([SkupKarticaID])
REFERENCES [dbo].[SkupKartica] ([SkupKarticaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kartica] CHECK CONSTRAINT [FK_Kartica_SkupKartica]
GO
ALTER TABLE [dbo].[Komentar]  WITH CHECK ADD  CONSTRAINT [FK_Komentar_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Komentar] CHECK CONSTRAINT [FK_Komentar_Korisnik]
GO
ALTER TABLE [dbo].[Komentar]  WITH CHECK ADD  CONSTRAINT [FK_Komentar_SkupKartica] FOREIGN KEY([SkupKarticaID])
REFERENCES [dbo].[SkupKartica] ([SkupKarticaID])
GO
ALTER TABLE [dbo].[Komentar] CHECK CONSTRAINT [FK_Komentar_SkupKartica]
GO
ALTER TABLE [dbo].[Lajk]  WITH CHECK ADD  CONSTRAINT [FK_Lajk_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lajk] CHECK CONSTRAINT [FK_Lajk_Korisnik]
GO
ALTER TABLE [dbo].[Lajk]  WITH CHECK ADD  CONSTRAINT [FK_Lajk_SkupKartica] FOREIGN KEY([SkupKartica])
REFERENCES [dbo].[SkupKartica] ([SkupKarticaID])
GO
ALTER TABLE [dbo].[Lajk] CHECK CONSTRAINT [FK_Lajk_SkupKartica]
GO
ALTER TABLE [dbo].[Podkomentar]  WITH CHECK ADD  CONSTRAINT [FK_Podkomentar_Komentar] FOREIGN KEY([KomentarID], [KorisnikID], [SkupKartica])
REFERENCES [dbo].[Komentar] ([KomentarID], [KorisnikID], [SkupKarticaID])
GO
ALTER TABLE [dbo].[Podkomentar] CHECK CONSTRAINT [FK_Podkomentar_Komentar]
GO
ALTER TABLE [dbo].[Podkomentar]  WITH CHECK ADD  CONSTRAINT [FK_Podkomentar_Korisnik] FOREIGN KEY([PodkomentarisaoID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Podkomentar] CHECK CONSTRAINT [FK_Podkomentar_Korisnik]
GO
ALTER TABLE [dbo].[SkupKartica]  WITH CHECK ADD  CONSTRAINT [FK_SkupKartica_Korisnik] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SkupKartica] CHECK CONSTRAINT [FK_SkupKartica_Korisnik]
GO
ALTER TABLE [dbo].[SkupKartica]  WITH CHECK ADD  CONSTRAINT [FK_SkupKartica_Predmet] FOREIGN KEY([PredmetID])
REFERENCES [dbo].[Predmet] ([PredmetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SkupKartica] CHECK CONSTRAINT [FK_SkupKartica_Predmet]
GO
USE [master]
GO
ALTER DATABASE [BazaPodataka] SET  READ_WRITE 
GO
