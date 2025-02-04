USE [master]
GO

/****** Object:  Database [maravillas]    Script Date: 6/07/2020 19:17:38 ******/
CREATE DATABASE [maravillas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'maravillas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\maravillas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'maravillas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\maravillas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [maravillas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [maravillas] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [maravillas] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [maravillas] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [maravillas] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [maravillas] SET ARITHABORT OFF 
GO

ALTER DATABASE [maravillas] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [maravillas] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [maravillas] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [maravillas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [maravillas] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [maravillas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [maravillas] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [maravillas] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [maravillas] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [maravillas] SET  DISABLE_BROKER 
GO

ALTER DATABASE [maravillas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [maravillas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [maravillas] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [maravillas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [maravillas] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [maravillas] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [maravillas] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [maravillas] SET RECOVERY FULL 
GO

ALTER DATABASE [maravillas] SET  MULTI_USER 
GO

ALTER DATABASE [maravillas] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [maravillas] SET DB_CHAINING OFF 
GO

ALTER DATABASE [maravillas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [maravillas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [maravillas] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [maravillas] SET QUERY_STORE = OFF
GO

ALTER DATABASE [maravillas] SET  READ_WRITE 
GO

/////////////// TABLES//////////////////////

USE [maravillas]
GO

/****** Object:  Table [dbo].[ciudad]    Script Date: 6/07/2020 19:18:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ciudad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigociudad] [nchar](10) NOT NULL,
	[descripcionciudad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ciudad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [maravillas]
GO

/****** Object:  Table [dbo].[reserva]    Script Date: 6/07/2020 19:18:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[reserva](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigoreserva] [nchar](10) NOT NULL,
	[codigociudadorigen] [nchar](10) NOT NULL,
	[codigociudaddestino] [nchar](10) NOT NULL,
	[tiporeserva] [nvarchar](50) NOT NULL,
	[inicioreserva] [datetime] NOT NULL,
	[finreserva] [datetime] NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_reserva] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [maravillas]
GO

/****** Object:  Table [dbo].[reservahotel]    Script Date: 6/07/2020 19:18:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[reservahotel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigoreservahotel] [nchar](10) NOT NULL,
	[nombrehotel] [nvarchar](50) NOT NULL,
	[numerodias] [nchar](10) NOT NULL,
	[cantidadpersonas] [nchar](10) NOT NULL,
	[numerohabitaciones] [nchar](10) NOT NULL,
	[montototal] [nchar](10) NOT NULL,
	[fechaingreso] [datetime] NOT NULL,
 CONSTRAINT [PK_hotel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [maravillas]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 7/07/2020 21:24:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dniUsuario] [int] NOT NULL,
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[apellidoUsuario] [nvarchar](50) NOT NULL,
	[correoUsuario] [nvarchar](50) NOT NULL,
	[generoUsuario] [nchar](10) NOT NULL,
	[contraseñaUsuario] [nchar](10) NOT NULL,
	[fechNacimientoUsuario] [datetime] NOT NULL,
	[pais] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

