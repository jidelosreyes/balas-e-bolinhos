
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/01/2013 22:50:24
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

IF OBJECT_ID(N'[dbo].[Aposta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aposta];
GO
IF OBJECT_ID(N'[dbo].[Classificacao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classificacao];
GO
IF OBJECT_ID(N'[dbo].[Competicao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competicao];
GO
IF OBJECT_ID(N'[dbo].[Jogo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jogo];
GO
IF OBJECT_ID(N'[dbo].[Jornada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jornada];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[Noticia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Noticia];
GO
IF OBJECT_ID(N'[dbo].[Utilizador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utilizador];
GO
IF OBJECT_ID(N'[dbo].[UtilizadorCompeticao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtilizadorCompeticao];
GO
IF OBJECT_ID(N'[dbo].[JornadaJogoCompeticao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JornadaJogoCompeticao];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aposta'
CREATE TABLE [dbo].[Aposta] (
    [IdAposta] int IDENTITY(1,1) NOT NULL,
    [IdUtilizador] int  NULL,
    [IdJornadaJogoCompeticao] int  NULL,
    [Descricao] varchar(max)  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'Classificacao'
CREATE TABLE [dbo].[Classificacao] (
    [IdClassificacao] int IDENTITY(1,1) NOT NULL,
    [IdUtilizador] int  NULL,
    [IdCompeticao] int  NULL,
    [Jogos] int  NULL,
    [Vitorias] int  NULL,
    [Empates] int  NULL,
    [Derrotas] int  NULL,
    [GolosMarcados] int  NULL,
    [GolosSofridos] int  NULL,
    [Pontos] int  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'Competicao'
CREATE TABLE [dbo].[Competicao] (
    [IdCompeticao] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(max)  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'Jogo'
CREATE TABLE [dbo].[Jogo] (
    [IdJogo] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(max)  NULL,
    [Data] datetime  NULL,
    [Resultado] varchar(max)  NULL,
    [Realizado] bit  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'Jornada'
CREATE TABLE [dbo].[Jornada] (
    [IdJornada] int IDENTITY(1,1) NOT NULL,
    [IdCompeticao] int  NULL,
    [Descricao] varchar(100)  NULL,
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

-- Creating table 'Noticia'
CREATE TABLE [dbo].[Noticia] (
    [IdNoticia] int IDENTITY(1,1) NOT NULL,
    [Titulo] varchar(max)  NULL,
    [Descricao] varchar(max)  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'Utilizador'
CREATE TABLE [dbo].[Utilizador] (
    [IdUtilizador] int IDENTITY(1,1) NOT NULL,
    [Email] varchar(100)  NULL,
    [NomeUtilizador] varchar(max)  NULL,
    [Password] varchar(max)  NULL,
    [Administrador] bit  NULL,
    [Activo] bit  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'UtilizadorCompeticao'
CREATE TABLE [dbo].[UtilizadorCompeticao] (
    [IdUtilizadorCompeticao] int IDENTITY(1,1) NOT NULL,
    [IdUtilizador] int  NULL,
    [IdCompeticao] int  NULL,
    [Activo] bit  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- Creating table 'JornadaJogoCompeticao'
CREATE TABLE [dbo].[JornadaJogoCompeticao] (
    [IdJornadaJogoCompeticao] int IDENTITY(1,1) NOT NULL,
    [IdCompeticao] int  NULL,
    [IdJornada] int  NULL,
    [IdJogo] int  NULL,
    [DataCriacao] datetime  NULL,
    [DataActualizacao] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAposta] in table 'Aposta'
ALTER TABLE [dbo].[Aposta]
ADD CONSTRAINT [PK_Aposta]
    PRIMARY KEY CLUSTERED ([IdAposta] ASC);
GO

-- Creating primary key on [IdClassificacao] in table 'Classificacao'
ALTER TABLE [dbo].[Classificacao]
ADD CONSTRAINT [PK_Classificacao]
    PRIMARY KEY CLUSTERED ([IdClassificacao] ASC);
GO

-- Creating primary key on [IdCompeticao] in table 'Competicao'
ALTER TABLE [dbo].[Competicao]
ADD CONSTRAINT [PK_Competicao]
    PRIMARY KEY CLUSTERED ([IdCompeticao] ASC);
GO

-- Creating primary key on [IdJogo] in table 'Jogo'
ALTER TABLE [dbo].[Jogo]
ADD CONSTRAINT [PK_Jogo]
    PRIMARY KEY CLUSTERED ([IdJogo] ASC);
GO

-- Creating primary key on [IdJornada] in table 'Jornada'
ALTER TABLE [dbo].[Jornada]
ADD CONSTRAINT [PK_Jornada]
    PRIMARY KEY CLUSTERED ([IdJornada] ASC);
GO

-- Creating primary key on [Id], [Date], [Thread], [Level], [Logger], [Message] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id], [Date], [Thread], [Level], [Logger], [Message] ASC);
GO

-- Creating primary key on [IdNoticia] in table 'Noticia'
ALTER TABLE [dbo].[Noticia]
ADD CONSTRAINT [PK_Noticia]
    PRIMARY KEY CLUSTERED ([IdNoticia] ASC);
GO

-- Creating primary key on [IdUtilizador] in table 'Utilizador'
ALTER TABLE [dbo].[Utilizador]
ADD CONSTRAINT [PK_Utilizador]
    PRIMARY KEY CLUSTERED ([IdUtilizador] ASC);
GO

-- Creating primary key on [IdUtilizadorCompeticao] in table 'UtilizadorCompeticao'
ALTER TABLE [dbo].[UtilizadorCompeticao]
ADD CONSTRAINT [PK_UtilizadorCompeticao]
    PRIMARY KEY CLUSTERED ([IdUtilizadorCompeticao] ASC);
GO

-- Creating primary key on [IdJornadaJogoCompeticao] in table 'JornadaJogoCompeticao'
ALTER TABLE [dbo].[JornadaJogoCompeticao]
ADD CONSTRAINT [PK_JornadaJogoCompeticao]
    PRIMARY KEY CLUSTERED ([IdJornadaJogoCompeticao] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------