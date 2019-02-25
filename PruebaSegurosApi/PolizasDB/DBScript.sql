﻿USE [master]
GO

/****** Object:  Database [PolizasDB]    Script Date: 25/02/2019 11:10:16 a.m. ******/
CREATE DATABASE [PolizasDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PolizasDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PolizasDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PolizasDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PolizasDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [PolizasDB] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PolizasDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PolizasDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PolizasDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PolizasDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PolizasDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PolizasDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [PolizasDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PolizasDB] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [PolizasDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PolizasDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PolizasDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PolizasDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PolizasDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PolizasDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PolizasDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PolizasDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PolizasDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PolizasDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PolizasDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PolizasDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PolizasDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PolizasDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PolizasDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PolizasDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PolizasDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PolizasDB] SET  MULTI_USER 
GO

ALTER DATABASE [PolizasDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PolizasDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PolizasDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PolizasDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [PolizasDB] SET  READ_WRITE 
GO

