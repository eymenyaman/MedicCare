USE [master]
GO
/****** Object:  Database [MedicCare]    Script Date: 16.08.2025 02:44:09 ******/
CREATE DATABASE [MedicCare]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MedicCare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDERS\MSSQL\DATA\MedicCare.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MedicCare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDERS\MSSQL\DATA\MedicCare_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MedicCare] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicCare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicCare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicCare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicCare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicCare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicCare] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicCare] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MedicCare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicCare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicCare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicCare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicCare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicCare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicCare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicCare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicCare] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MedicCare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicCare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicCare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicCare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicCare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicCare] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MedicCare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicCare] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MedicCare] SET  MULTI_USER 
GO
ALTER DATABASE [MedicCare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicCare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicCare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicCare] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedicCare] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedicCare] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MedicCare] SET QUERY_STORE = OFF
GO
USE [MedicCare]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.08.2025 02:44:09 ******/
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
/****** Object:  Table [dbo].[Abouts]    Script Date: 16.08.2025 02:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Years] [nvarchar](max) NOT NULL,
	[İmage1] [nvarchar](max) NOT NULL,
	[İmage2] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Abouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 16.08.2025 02:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experiences]    Script Date: 16.08.2025 02:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Icon] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 16.08.2025 02:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Testimonials]    Script Date: 16.08.2025 02:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testimonials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Testimonials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250813142838_InitialCreate', N'8.0.19')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250814121452_DeletButton', N'8.0.19')
GO
SET IDENTITY_INSERT [dbo].[Abouts] ON 

INSERT [dbo].[Abouts] ([Id], [Title], [Text], [Years], [İmage1], [İmage2]) VALUES (1, N'Protect yourself and others by wearing masks and washing hands frequently. Outdoor is safer than indoor for gatherings or holding events. People who get sick with Coronavirus disease (COVID-19) will experience mild to moderate symptoms and recover without special treatments.', N'You can feel free to use this CSS template for your medical profession or health care related websites. You can support us a little via PayPal if this template is good and useful for your work.', N'13', N' medium-shot-man-getting-vaccine.jpg', N'female-doctor-with-presenting-hand-gesture.jpg')
SET IDENTITY_INSERT [dbo].[Abouts] OFF
GO
SET IDENTITY_INSERT [dbo].[Experiences] ON 

INSERT [dbo].[Experiences] ([Id], [Title], [Text], [Icon], [DateTime]) VALUES (1, N'Get the vaccine', N'Donec facilisis urna dui, a dignissim mauris pretium a. Quisque quis libero fermentum, tempus felis eu, consequat nibh.', N'bi-patch-check-fill timeline-icon', CAST(N'2020-05-24T14:35:50.0000000' AS DateTime2))
INSERT [dbo].[Experiences] ([Id], [Title], [Text], [Icon], [DateTime]) VALUES (2, N'Consulting your health', N'You are fully permitted to use this template for your commercial or personal website. You are not permitted to redistribute the template ZIP file for a download purpose on any other Free CSS collection website.', N'bi-book timeline-icon', CAST(N'2020-05-24T14:35:50.0000000' AS DateTime2))
INSERT [dbo].[Experiences] ([Id], [Title], [Text], [Icon], [DateTime]) VALUES (3, N'Certified Nurses', N'Phasellus eleifend, urna interdum congue viverra, arcu neque ultrices ligula, id pulvinar nisi nibh et lacus. Vivamus gravida, ipsum non euismod tincidunt, sapien elit fermentum mi, quis iaculis enim ligula at arcu.', N'bi-file-medical timeline-icon', CAST(N'2020-05-24T14:35:50.0000000' AS DateTime2))
INSERT [dbo].[Experiences] ([Id], [Title], [Text], [Icon], [DateTime]) VALUES (4, N'Covid-19 Hospitals', N'Fusce vestibulum euismod nulla sed ultrices. Praesent rutrum nulla vel sapien euismod, quis tempus dui placerat.

Integer posuere erat a ante venenatis dapibus posuere velit aliquet. Maecenas faucibus mollis interdum. Donec ullamcorper nulla non metus auctor fringilla', N'bi-globe timeline-icon', CAST(N'2020-05-24T14:35:50.0000000' AS DateTime2))
INSERT [dbo].[Experiences] ([Id], [Title], [Text], [Icon], [DateTime]) VALUES (5, N'Freelance Nursing', N'If you need a working contact form that submits email to your inbox, please visit our contact page for more information.', N'bi-person timeline-icon', CAST(N'2020-05-24T14:35:50.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Experiences] OFF
GO
SET IDENTITY_INSERT [dbo].[Profiles] ON 

INSERT [dbo].[Profiles] ([Id], [Name], [Title], [Text], [Phone]) VALUES (1, N'Eymen', N'Days', N'Medic Care is a Bootstrap 5 Template provided by TemplateMo website. Credits go to FreePik and RawPixel for images used in this template.', N'536-441-4949')
SET IDENTITY_INSERT [dbo].[Profiles] OFF
GO
USE [master]
GO
ALTER DATABASE [MedicCare] SET  READ_WRITE 
GO
