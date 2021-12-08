USE [master]
GO

/****** Object:  Database [DC_DB]    Script Date: 18/11/2021 20:23:21 ******/
CREATE DATABASE [DC_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N' DC-DB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ DC-DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N' DC-DB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ DC-DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

ALTER DATABASE [DC_DB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DC_DB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DC_DB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DC_DB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DC_DB] SET ARITHABORT OFF 
GO

ALTER DATABASE [DC_DB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DC_DB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DC_DB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DC_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DC_DB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DC_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DC_DB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DC_DB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DC_DB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DC_DB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DC_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DC_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DC_DB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DC_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DC_DB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DC_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DC_DB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DC_DB] SET RECOVERY FULL 
GO

ALTER DATABASE [DC_DB] SET  MULTI_USER 
GO

ALTER DATABASE [DC_DB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DC_DB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DC_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DC_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DC_DB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DC_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [DC_DB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [DC_DB] SET  READ_WRITE 
GO

USE [DC_DB]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 18/11/2021 20:26:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[id] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[CUIL] [varchar](100) NOT NULL,
	[edad] [int] NOT NULL,
	[sexo] [char](1) NOT NULL,
	[idPresupuesto] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DC_DB]
GO

/****** Object:  Table [dbo].[ComponenteElectronico]    Script Date: 18/11/2021 20:26:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ComponenteElectronico](
	[id] [int] NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[modelo] [varchar](200) NOT NULL,
	[potencia] [varchar](200) NOT NULL,
	[consumo] [float] NOT NULL,
	[precio] [float] NOT NULL,
	[espacioDisco] [int] NULL,
	[tipoDisco] [varchar](50) NULL,
	[tipoFuente] [varchar](50) NULL,
	[tipoMemoria] [varchar](50) NULL,
	[tecnologiaMemoria] [varchar](50) NULL,
	[nombreFabricante] [varchar](50) NULL,
	[cantidadNucleos] [varchar](50) NULL,
	[tipoPlacamadre] [varchar](50) NULL,
	[tipoSocket] [varchar](50) NULL,
	[tipoPlacaVideo] [varchar](50) NULL,
	[memoriaGrafica] [float] NULL,
	[discriminator] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ComponenteElectronico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DC_DB]
GO

/****** Object:  Table [dbo].[Presupuesto]    Script Date: 18/11/2021 20:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Presupuesto](
	[id] [int] NOT NULL,
	[fechaEmision] [date] NOT NULL,
	[precioFinal] [float] NOT NULL,
	[idCliente] [int] NULL,
 CONSTRAINT [PK_Presupuesto_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_Presupuesto_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([id])
GO

ALTER TABLE [dbo].[Presupuesto] CHECK CONSTRAINT [FK_Presupuesto_Cliente]
GO

USE [DC_DB]
GO

/****** Object:  Table [dbo].[Despensas]    Script Date: 18/11/2021 20:27:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Despensas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[idPresupuesto] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Despensas]  WITH CHECK ADD  CONSTRAINT [FK_Despensas_ComponenteElectronico] FOREIGN KEY([idProducto])
REFERENCES [dbo].[ComponenteElectronico] ([id])
GO

ALTER TABLE [dbo].[Despensas] CHECK CONSTRAINT [FK_Despensas_ComponenteElectronico]
GO

ALTER TABLE [dbo].[Despensas]  WITH CHECK ADD  CONSTRAINT [FK_Despensas_Presupuesto] FOREIGN KEY([idPresupuesto])
REFERENCES [dbo].[Presupuesto] ([id])
GO

ALTER TABLE [dbo].[Despensas] CHECK CONSTRAINT [FK_Despensas_Presupuesto]
GO

-- Agrupar total de ventas por presupuestos y cantidad de clientes, presupuestos y componentes
CREATE PROCEDURE CantidadDatos
@totalVentas FLOAT OUT,
@cantidadClientes INT OUT,
@cantidadPresupuestos INT OUT,
@cantidadComponentes INT OUT
AS
SET @totalVentas = (SELECT SUM(precioFinal) AS TotalVentas FROM Presupuesto)
SET @cantidadClientes = (SELECT COUNT(id) AS CantidadClientes FROM Cliente)
SET @cantidadPresupuestos = (SELECT COUNT(id) AS CantidadPresupeustos FROM Presupuesto)
SET @cantidadComponentes = (SELECT COUNT(id) AS CantidadComponentes FROM ComponenteElectronico)
GO

--- Tipos y cantidad de productos que existen en la base de datos
CREATE PROCEDURE TipoCantidadProductos
AS
SELECT discriminator AS TipoProducto, COUNT(discriminator) AS Cantidad FROM ComponenteElectronico
GROUP BY discriminator
ORDER BY COUNT(discriminator) DESC
GO

-- 5 Productos más elegidos por los clientes
CREATE PROCEDURE ProductosPreferidos
AS
SELECT TOP(5) cE.modelo AS ProductoPreferido, COUNT(cE.discriminator) AS Cantidad
FROM ComponenteElectronico cE
inner join Despensas d ON cE.id = d.idProducto
inner join Presupuesto p ON p.id = d.idPresupuesto
inner join Cliente c ON c.id = p.idCliente
GROUP BY cE.modelo
ORDER BY COUNT(discriminator) DESC
GO

-- Presupuesto más caro
CREATE PROCEDURE PresupuestoMasCaro
@PresuMasCaro FLOAT OUT
AS
SET @PresuMasCaro = (SELECT TOP(1) p.precioFinal AS PresupuestoMasCaro
FROM Presupuesto p 
ORDER BY p.precioFinal DESC)
GO



