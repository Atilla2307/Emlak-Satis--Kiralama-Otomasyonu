USE [emlak]
GO
/****** Object:  Table [dbo].[konut_bilgi]    Script Date: 19.12.2024 00:14:07 ******/
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
/****** Object:  Table [dbo].[kullanici_bilgi]    Script Date: 19.12.2024 00:14:07 ******/
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
/****** Object:  Table [dbo].[resim_tablosu]    Script Date: 19.12.2024 00:14:07 ******/
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
