USE [master]
GO

/****** Object:  Database [NLP_Statistic_db]    Script Date: 8/23/2016 1:56:14 PM ******/
CREATE DATABASE [NLP_Statistic_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NLP_Statistic_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NLP_Statistic_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NLP_Statistic_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NLP_Statistic_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [NLP_Statistic_db] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NLP_Statistic_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [NLP_Statistic_db] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET ARITHABORT OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [NLP_Statistic_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [NLP_Statistic_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET  DISABLE_BROKER 
GO

ALTER DATABASE [NLP_Statistic_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [NLP_Statistic_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET RECOVERY FULL 
GO

ALTER DATABASE [NLP_Statistic_db] SET  MULTI_USER 
GO

ALTER DATABASE [NLP_Statistic_db] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [NLP_Statistic_db] SET DB_CHAINING OFF 
GO

ALTER DATABASE [NLP_Statistic_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [NLP_Statistic_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [NLP_Statistic_db] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [NLP_Statistic_db] SET QUERY_STORE = OFF
GO

USE [NLP_Statistic_db]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [NLP_Statistic_db] SET  READ_WRITE 
GO

