USE [master]
GO
/****** Object:  Database [Parkbeheer]    Script Date: 5/01/2024 19:31:08 ******/
CREATE DATABASE [Parkbeheer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Parkbeheer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Parkbeheer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Parkbeheer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Parkbeheer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Parkbeheer] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Parkbeheer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Parkbeheer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Parkbeheer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Parkbeheer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Parkbeheer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Parkbeheer] SET ARITHABORT OFF 
GO
ALTER DATABASE [Parkbeheer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Parkbeheer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Parkbeheer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Parkbeheer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Parkbeheer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Parkbeheer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Parkbeheer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Parkbeheer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Parkbeheer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Parkbeheer] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Parkbeheer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Parkbeheer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Parkbeheer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Parkbeheer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Parkbeheer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Parkbeheer] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Parkbeheer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Parkbeheer] SET RECOVERY FULL 
GO
ALTER DATABASE [Parkbeheer] SET  MULTI_USER 
GO
ALTER DATABASE [Parkbeheer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Parkbeheer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Parkbeheer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Parkbeheer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Parkbeheer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Parkbeheer] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Parkbeheer', N'ON'
GO
ALTER DATABASE [Parkbeheer] SET QUERY_STORE = ON
GO
ALTER DATABASE [Parkbeheer] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Parkbeheer]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/01/2024 19:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HuisHuurders]    Script Date: 5/01/2024 19:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HuisHuurders](
	[HuisEFId] [int] NOT NULL,
	[HuurderEFId] [int] NOT NULL,
 CONSTRAINT [PK_HuisHuurders] PRIMARY KEY CLUSTERED 
(
	[HuisEFId] ASC,
	[HuurderEFId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Huizen]    Script Date: 5/01/2024 19:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Huizen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Straat] [nvarchar](250) NULL,
	[Nr] [int] NOT NULL,
	[Actief] [bit] NOT NULL,
	[ParkId] [nvarchar](20) NULL,
 CONSTRAINT [PK_Huizen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Huurcontracten]    Script Date: 5/01/2024 19:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Huurcontracten](
	[Id] [nvarchar](25) NOT NULL,
	[StartDatum] [datetime2](7) NOT NULL,
	[EindDatum] [datetime2](7) NOT NULL,
	[AantalDagen] [int] NOT NULL,
	[HuurderId] [int] NULL,
	[HuisId] [int] NULL,
 CONSTRAINT [PK_Huurcontracten] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Huurders]    Script Date: 5/01/2024 19:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Huurders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](100) NOT NULL,
	[Telefoon] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Adres] [nvarchar](100) NULL,
 CONSTRAINT [PK_Huurders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parken]    Script Date: 5/01/2024 19:31:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parken](
	[Id] [nvarchar](20) NOT NULL,
	[Naam] [nvarchar](250) NOT NULL,
	[Locatie] [nvarchar](500) NULL,
 CONSTRAINT [PK_Parken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231227214241_InitialCreate', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240104204928_CascadeDeleteConfig', N'7.0.14')
GO
INSERT [dbo].[HuisHuurders] ([HuisEFId], [HuurderEFId]) VALUES (10, 8)
INSERT [dbo].[HuisHuurders] ([HuisEFId], [HuurderEFId]) VALUES (13, 8)
INSERT [dbo].[HuisHuurders] ([HuisEFId], [HuurderEFId]) VALUES (11, 9)
INSERT [dbo].[HuisHuurders] ([HuisEFId], [HuurderEFId]) VALUES (12, 10)
GO
SET IDENTITY_INSERT [dbo].[Huizen] ON 

INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (10, N'GewijzigdeStraat', 123, 1, N'2')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (11, N'Straat B', 456, 1, N'2')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (12, N'Straat C', 789, 1, N'3')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (13, N'Straat D', 101, 1, N'4')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (21, N'NieuweStraat', 555, 1, NULL)
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (22, N'NieuweStraat', 555, 1, NULL)
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (23, N'NieuweStraat', 555, 1, NULL)
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (24, N'NieuweStraat', 555, 1, NULL)
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (29, N'New Street', 555, 1, N'6')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (30, N'New Street', 555, 1, N'3')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (31, N'New Street', 555, 1, N'3')
INSERT [dbo].[Huizen] ([Id], [Straat], [Nr], [Actief], [ParkId]) VALUES (32, N'NieuweStraat', 555, 1, N'3')
SET IDENTITY_INSERT [dbo].[Huizen] OFF
GO
INSERT [dbo].[Huurcontracten] ([Id], [StartDatum], [EindDatum], [AantalDagen], [HuurderId], [HuisId]) VALUES (N'ContractId5', CAST(N'2023-12-05T18:21:30.2168594' AS DateTime2), CAST(N'2024-01-04T17:44:42.2538060' AS DateTime2), 30, 8, 10)
INSERT [dbo].[Huurcontracten] ([Id], [StartDatum], [EindDatum], [AantalDagen], [HuurderId], [HuisId]) VALUES (N'ContractId6', CAST(N'2023-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), 28, 9, 11)
INSERT [dbo].[Huurcontracten] ([Id], [StartDatum], [EindDatum], [AantalDagen], [HuurderId], [HuisId]) VALUES (N'ContractId7', CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-01T00:00:00.0000000' AS DateTime2), 31, 10, 12)
INSERT [dbo].[Huurcontracten] ([Id], [StartDatum], [EindDatum], [AantalDagen], [HuurderId], [HuisId]) VALUES (N'ContractId8', CAST(N'2023-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2023-02-15T00:00:00.0000000' AS DateTime2), 31, 8, 13)
GO
SET IDENTITY_INSERT [dbo].[Huurders] ON 

INSERT [dbo].[Huurders] ([Id], [Naam], [Telefoon], [Email], [Adres]) VALUES (8, N'Gewijzigde Naam', N'123456789', N'huurder1@email.com', N'Adres 1')
INSERT [dbo].[Huurders] ([Id], [Naam], [Telefoon], [Email], [Adres]) VALUES (9, N'Huurder 2', N'987654321', N'huurder2@email.com', N'Adres 2')
INSERT [dbo].[Huurders] ([Id], [Naam], [Telefoon], [Email], [Adres]) VALUES (10, N'Huurder 3', N'111222333', N'huurder3@email.com', N'Adres 3')
INSERT [dbo].[Huurders] ([Id], [Naam], [Telefoon], [Email], [Adres]) VALUES (11, N'Huurder 1', N'123456789', N'huurder1@email.com', N'Adres 1')
INSERT [dbo].[Huurders] ([Id], [Naam], [Telefoon], [Email], [Adres]) VALUES (12, N'Huurder 1', N'123456789', N'huurder1@email.com', N'Adres 1')
SET IDENTITY_INSERT [dbo].[Huurders] OFF
GO
INSERT [dbo].[Parken] ([Id], [Naam], [Locatie]) VALUES (N'2', N'Park 1', N'Locatie 1')
INSERT [dbo].[Parken] ([Id], [Naam], [Locatie]) VALUES (N'3', N'Park 2', N'Locatie 2')
INSERT [dbo].[Parken] ([Id], [Naam], [Locatie]) VALUES (N'4', N'Park 3', N'Locatie 3')
INSERT [dbo].[Parken] ([Id], [Naam], [Locatie]) VALUES (N'5', N'Park 4', N'Locatie 4')
INSERT [dbo].[Parken] ([Id], [Naam], [Locatie]) VALUES (N'6', N'Nieuw Park', N'Nieuwe Locatie')
GO
/****** Object:  Index [IX_HuisHuurders_HuurderEFId]    Script Date: 5/01/2024 19:31:08 ******/
CREATE NONCLUSTERED INDEX [IX_HuisHuurders_HuurderEFId] ON [dbo].[HuisHuurders]
(
	[HuurderEFId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Huizen_ParkId]    Script Date: 5/01/2024 19:31:08 ******/
CREATE NONCLUSTERED INDEX [IX_Huizen_ParkId] ON [dbo].[Huizen]
(
	[ParkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Huurcontracten_HuisId]    Script Date: 5/01/2024 19:31:08 ******/
CREATE NONCLUSTERED INDEX [IX_Huurcontracten_HuisId] ON [dbo].[Huurcontracten]
(
	[HuisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Huurcontracten_HuurderId]    Script Date: 5/01/2024 19:31:08 ******/
CREATE NONCLUSTERED INDEX [IX_Huurcontracten_HuurderId] ON [dbo].[Huurcontracten]
(
	[HuurderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HuisHuurders]  WITH CHECK ADD  CONSTRAINT [FK_HuisHuurders_Huizen_HuisEFId] FOREIGN KEY([HuisEFId])
REFERENCES [dbo].[Huizen] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HuisHuurders] CHECK CONSTRAINT [FK_HuisHuurders_Huizen_HuisEFId]
GO
ALTER TABLE [dbo].[HuisHuurders]  WITH CHECK ADD  CONSTRAINT [FK_HuisHuurders_Huurders_HuurderEFId] FOREIGN KEY([HuurderEFId])
REFERENCES [dbo].[Huurders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HuisHuurders] CHECK CONSTRAINT [FK_HuisHuurders_Huurders_HuurderEFId]
GO
ALTER TABLE [dbo].[Huizen]  WITH CHECK ADD  CONSTRAINT [FK_Huizen_Parken_ParkId] FOREIGN KEY([ParkId])
REFERENCES [dbo].[Parken] ([Id])
GO
ALTER TABLE [dbo].[Huizen] CHECK CONSTRAINT [FK_Huizen_Parken_ParkId]
GO
ALTER TABLE [dbo].[Huurcontracten]  WITH CHECK ADD  CONSTRAINT [FK_Huurcontracten_Huizen_HuisId] FOREIGN KEY([HuisId])
REFERENCES [dbo].[Huizen] ([Id])
GO
ALTER TABLE [dbo].[Huurcontracten] CHECK CONSTRAINT [FK_Huurcontracten_Huizen_HuisId]
GO
ALTER TABLE [dbo].[Huurcontracten]  WITH CHECK ADD  CONSTRAINT [FK_Huurcontracten_Huurders_HuurderId] FOREIGN KEY([HuurderId])
REFERENCES [dbo].[Huurders] ([Id])
GO
ALTER TABLE [dbo].[Huurcontracten] CHECK CONSTRAINT [FK_Huurcontracten_Huurders_HuurderId]
GO
USE [master]
GO
ALTER DATABASE [Parkbeheer] SET  READ_WRITE 
GO
