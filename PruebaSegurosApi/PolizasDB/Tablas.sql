USE [PolizasDB]
GO
ALTER TABLE [dbo].[PolizaCoberturas] DROP CONSTRAINT [FK_PolizaCoberturas_Poliza]
GO
ALTER TABLE [dbo].[PolizaCoberturas] DROP CONSTRAINT [FK_PolizaCoberturas_Cubrimiento]
GO
ALTER TABLE [dbo].[Poliza] DROP CONSTRAINT [FK_Poliza_Riesgo]
GO
/****** Object:  Table [dbo].[Riesgo]    Script Date: 25/02/2019 11:12:37 a.m. ******/
DROP TABLE [dbo].[Riesgo]
GO
/****** Object:  Table [dbo].[PolizaCoberturas]    Script Date: 25/02/2019 11:12:37 a.m. ******/
DROP TABLE [dbo].[PolizaCoberturas]
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 25/02/2019 11:12:37 a.m. ******/
DROP TABLE [dbo].[Poliza]
GO
/****** Object:  Table [dbo].[Cubrimiento]    Script Date: 25/02/2019 11:12:37 a.m. ******/
DROP TABLE [dbo].[Cubrimiento]
GO
/****** Object:  Table [dbo].[Cubrimiento]    Script Date: 25/02/2019 11:12:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cubrimiento](
	[CubrimientoId] [int] IDENTITY(1,1) NOT NULL,
	[CubrimientoDescripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cubrimiento] PRIMARY KEY CLUSTERED 
(
	[CubrimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 25/02/2019 11:12:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Poliza](
	[PolizaId] [int] NOT NULL,
	[PolizaNombre] [varchar](50) NOT NULL,
	[PolizaDescripcion] [varchar](50) NOT NULL,
	[PolizaInicio] [datetime] NOT NULL,
	[PolizaPeriodoCobertura] [int] NOT NULL,
	[PolizaPrecio] [int] NOT NULL,
	[PolizaRiesgo] [int] NOT NULL,
 CONSTRAINT [PK_Poliza] PRIMARY KEY CLUSTERED 
(
	[PolizaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PolizaCoberturas]    Script Date: 25/02/2019 11:12:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolizaCoberturas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PolizaId] [int] NOT NULL,
	[CoberturaId] [int] NOT NULL,
	[Porcentaje] [int] NOT NULL,
 CONSTRAINT [PK_PolizaCoberturas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Riesgo]    Script Date: 25/02/2019 11:12:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Riesgo](
	[RiesgoId] [int] IDENTITY(1,1) NOT NULL,
	[RiesgoDescripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Riesgo] PRIMARY KEY CLUSTERED 
(
	[RiesgoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Poliza]  WITH CHECK ADD  CONSTRAINT [FK_Poliza_Riesgo] FOREIGN KEY([PolizaRiesgo])
REFERENCES [dbo].[Riesgo] ([RiesgoId])
GO
ALTER TABLE [dbo].[Poliza] CHECK CONSTRAINT [FK_Poliza_Riesgo]
GO
ALTER TABLE [dbo].[PolizaCoberturas]  WITH CHECK ADD  CONSTRAINT [FK_PolizaCoberturas_Cubrimiento] FOREIGN KEY([CoberturaId])
REFERENCES [dbo].[Cubrimiento] ([CubrimientoId])
GO
ALTER TABLE [dbo].[PolizaCoberturas] CHECK CONSTRAINT [FK_PolizaCoberturas_Cubrimiento]
GO
ALTER TABLE [dbo].[PolizaCoberturas]  WITH CHECK ADD  CONSTRAINT [FK_PolizaCoberturas_Poliza] FOREIGN KEY([PolizaId])
REFERENCES [dbo].[Poliza] ([PolizaId])
GO
ALTER TABLE [dbo].[PolizaCoberturas] CHECK CONSTRAINT [FK_PolizaCoberturas_Poliza]
GO
