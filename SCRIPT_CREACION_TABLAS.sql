
USE [DevLab]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE CatTipoCliente(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[TipoCliente] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE TblClientes(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[RazonSocial] [varchar](200) NOT NULL,
	[IdTipoCliente] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[RFC] [varchar](50) NOT NULL,
	CONSTRAINT fk_CatTipoCliente FOREIGN KEY (IdTipoCliente) REFERENCES CatTipoCliente (Id)
) ON [PRIMARY]
GO

ALTER TABLE TblClientes ADD  CONSTRAINT [DF_TblClientes_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO


CREATE TABLE TblFacturas(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[FechaEmisionFactura] [datetime] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[NumeroFactura] [int] NOT NULL,
	[NumeroTotalArticulos] [int] NOT NULL,
	[SubTotalFactura] [decimal](18, 0) NOT NULL,
	[TotalImpuesto] [decimal](18, 0) NOT NULL,
	[TotalFactura] [decimal](18, 0) NOT NULL,
	CONSTRAINT fk_TblClientes FOREIGN KEY (IdCliente) REFERENCES TblClientes (Id)
) ON [PRIMARY]
GO

ALTER TABLE TblFacturas ADD  CONSTRAINT [DF_TblFacturas_FechaEmisionFactura]  DEFAULT (getdate()) FOR [FechaEmisionFactura]
GO

CREATE TABLE CatProductos(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[ImagenProducto] [varchar](max) NULL,
	[PrecioUnitario] [decimal](18, 0) NOT NULL,
	[ext] [varchar](5) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE TblDetallesFactura(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[CantidadDeProducto] [int] NOT NULL,
	[PrecioUnitarioProducto] [decimal](18, 0) NOT NULL,
	[SubtotalProducto] [decimal](18, 0) NOT NULL,
	[Notas] [varchar](200) NOT NULL,
	CONSTRAINT fk_TblFacturas FOREIGN KEY (IdFactura) REFERENCES TblFacturas (Id),
	CONSTRAINT fk_CatProductos FOREIGN KEY (IdProducto) REFERENCES CatProductos (Id)
)
GO