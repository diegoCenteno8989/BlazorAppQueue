-- Verificar si la base de datos existe
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'DbPrueba')
BEGIN
    -- Crear la base de datos si no existe
    CREATE DATABASE DbPrueba;
END;
go

USE DbPrueba

-- Verificar si la tabla existe en la base de datos
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Persona')
BEGIN
    -- Crear la tabla si no existe
    
CREATE TABLE [dbo].[Persona](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[TiempoRegistro] [datetime] NOT NULL,
	[ColaId] [int] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END;
go
