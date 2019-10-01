USE [Haito]
GO

/****** Object:  Table [dbo].[cotizacion]    Script Date: 18/09/2019 04:04:32 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].remision(
	idRemision [int] NOT NULL,
	[idCliente] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[observaciones] [nvarchar](500) NULL,
	[idEncabezado] [int] NOT NULL,
	[idMoneda] [int] NULL
) ON [PRIMARY]

GO

USE [Haito]
GO

/****** Object:  Table [dbo].[cotizacionDetalle]    Script Date: 18/09/2019 04:17:47 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].remisionDetalle(
	idRemisionDetalle [int] IDENTITY(1,1) NOT NULL,
	idRemision [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [decimal](10, 2) NOT NULL,
	[precioUnitario] [decimal](10, 2) NOT NULL,
	[idUnidadMedida] [nvarchar](10) NULL,
	[idEncabezado] [int] NULL
	)



