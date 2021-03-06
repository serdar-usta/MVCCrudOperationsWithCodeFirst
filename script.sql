USE [master]
GO
/****** Object:  Database [XCourseDb]    Script Date: 06.10.2016 00:07:49 ******/
CREATE DATABASE [XCourseDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XCourseDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\XCourseDb.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XCourseDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\XCourseDb_log.ldf' , SIZE = 1600KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [XCourseDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XCourseDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XCourseDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XCourseDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XCourseDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XCourseDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XCourseDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [XCourseDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [XCourseDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XCourseDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XCourseDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XCourseDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XCourseDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XCourseDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XCourseDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XCourseDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XCourseDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [XCourseDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XCourseDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XCourseDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XCourseDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XCourseDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XCourseDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [XCourseDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XCourseDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [XCourseDb] SET  MULTI_USER 
GO
ALTER DATABASE [XCourseDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XCourseDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XCourseDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XCourseDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [XCourseDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'XCourseDb', N'ON'
GO
ALTER DATABASE [XCourseDb] SET QUERY_STORE = OFF
GO
USE [XCourseDb]
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
USE [XCourseDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 06.10.2016 00:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 06.10.2016 00:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 06.10.2016 00:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Proficiency] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student_FirstName]    Script Date: 06.10.2016 00:07:50 ******/
CREATE NONCLUSTERED INDEX [IX_Student_FirstName] ON [dbo].[Student]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 06.10.2016 00:07:50 ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[Student]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_dbo.Students_dbo.Teachers_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [XCourseDb] SET  READ_WRITE 
GO
