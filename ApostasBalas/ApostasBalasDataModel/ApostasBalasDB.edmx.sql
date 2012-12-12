
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/12/2012 11:30:11
-- Generated from EDMX file: C:\JP\Projects\B&B\trunk\ApostasBalas\ApostasBalasDataModel\ApostasBalasDB.edmx
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

IF OBJECT_ID(N'[ApostasBalasDBModelStoreContainer].[Log]', 'U') IS NOT NULL
    DROP TABLE [ApostasBalasDBModelStoreContainer].[Log];
GO
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

-- Creating table 'Log'
CREATE TABLE [dbo].[Log] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Thread] varchar(255)  NOT NULL,
    [Level] varchar(50)  NOT NULL,
    [Logger] varchar(255)  NOT NULL,
    [Message] varchar(4000)  NOT NULL,
    [Exception] varchar(2000)  NULL
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

-- Creating primary key on [Id], [Date], [Thread], [Level], [Logger], [Message] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id], [Date], [Thread], [Level], [Logger], [Message] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------