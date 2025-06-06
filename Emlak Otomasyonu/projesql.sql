USE [master]
GO
/****** Object:  Database [emlak]    Script Date: 18.12.2024 18:33:52 ******/
CREATE DATABASE [emlak]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'emlak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\emlak.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'emlak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\emlak_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [emlak] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [emlak].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [emlak] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [emlak] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [emlak] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [emlak] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [emlak] SET ARITHABORT OFF 
GO
ALTER DATABASE [emlak] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [emlak] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [emlak] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [emlak] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [emlak] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [emlak] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [emlak] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [emlak] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [emlak] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [emlak] SET  DISABLE_BROKER 
GO
ALTER DATABASE [emlak] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [emlak] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [emlak] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [emlak] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [emlak] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [emlak] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [emlak] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [emlak] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [emlak] SET  MULTI_USER 
GO
ALTER DATABASE [emlak] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [emlak] SET DB_CHAINING OFF 
GO
ALTER DATABASE [emlak] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [emlak] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [emlak] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [emlak] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [emlak] SET QUERY_STORE = ON
GO
ALTER DATABASE [emlak] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [emlak]
GO
/****** Object:  Table [dbo].[konut_bilgi]    Script Date: 18.12.2024 18:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[konut_bilgi](
	[ilan_id] [int] IDENTITY(1,1) NOT NULL,
	[satis_turu] [nvarchar](50) NOT NULL,
	[konut_tipi] [nvarchar](50) NOT NULL,
	[metrekare] [int] NOT NULL,
	[oda_sayisi] [nvarchar](20) NOT NULL,
	[kat] [nvarchar](10) NOT NULL,
	[banyo_sayisi] [nvarchar](10) NOT NULL,
	[bina_yas] [nvarchar](10) NOT NULL,
	[il] [nvarchar](50) NOT NULL,
	[ilce] [nvarchar](50) NOT NULL,
	[fiyat] [int] NOT NULL,
	[kullanici_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ilan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanici_bilgi]    Script Date: 18.12.2024 18:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici_bilgi](
	[Tc] [int] NULL,
	[ad_soyad] [nvarchar](50) NULL,
	[telefon] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
 CONSTRAINT [UQ_Tc] UNIQUE NONCLUSTERED 
(
	[Tc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resim_tablosu]    Script Date: 18.12.2024 18:33:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resim_tablosu](
	[resim_id] [int] IDENTITY(1,1) NOT NULL,
	[konut_id] [int] NULL,
	[resim] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[resim_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[resim_tablosu]  WITH CHECK ADD FOREIGN KEY([konut_id])
REFERENCES [dbo].[konut_bilgi] ([ilan_id])
GO
ALTER TABLE [dbo].[resim_tablosu]  WITH CHECK ADD FOREIGN KEY([konut_id])
REFERENCES [dbo].[konut_bilgi] ([ilan_id])
GO
USE [master]
GO
ALTER DATABASE [emlak] SET  READ_WRITE 
GO
