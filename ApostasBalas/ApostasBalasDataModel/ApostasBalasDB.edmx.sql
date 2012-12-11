
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/11/2012 21:34:13
-- Generated from EDMX file: C:\Projectos\B&B\trunk\ApostasBalas\ApostasBalasDataModel\ApostasBalasDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ApostasBalasDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Utilizador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utilizador];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Utilizador'
CREATE TABLE [dbo].[Utilizador] (
    [IdUtilizador] int IDENTITY(1,1) NOT NULL,
    [NomeUtilizador] varchar(max)  NULL,
    [Password] varchar(max)  NULL,
    [Administrador] bit  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdUtilizador] in table 'Utilizador'
ALTER TABLE [dbo].[Utilizador]
ADD CONSTRAINT [PK_Utilizador]
    PRIMARY KEY CLUSTERED ([IdUtilizador] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------