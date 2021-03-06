USE [master]
GO
/****** Object:  Database [EvolentProjectAssessment]    Script Date: 3/2/2020 9:27:34 AM ******/
CREATE DATABASE [EvolentProjectAssessment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EvolentProjectAssessment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EvolentProjectAssessment.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EvolentProjectAssessment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EvolentProjectAssessment_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EvolentProjectAssessment] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EvolentProjectAssessment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EvolentProjectAssessment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET ARITHABORT OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EvolentProjectAssessment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EvolentProjectAssessment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EvolentProjectAssessment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EvolentProjectAssessment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EvolentProjectAssessment] SET  MULTI_USER 
GO
ALTER DATABASE [EvolentProjectAssessment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EvolentProjectAssessment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EvolentProjectAssessment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EvolentProjectAssessment] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EvolentProjectAssessment] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EvolentProjectAssessment]
GO
/****** Object:  Table [dbo].[ContactDetails]    Script Date: 3/2/2020 9:27:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [bigint] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [EvolentProjectAssessment] SET  READ_WRITE 
GO
