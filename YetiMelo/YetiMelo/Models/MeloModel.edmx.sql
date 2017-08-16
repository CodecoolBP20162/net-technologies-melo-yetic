
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/16/2017 23:49:30
-- Generated from EDMX file: C:\Users\Noncsi\Desktop\Sheiwa\C#\net-technologies-melo-yetic\YetiMelo\YetiMelo\Models\MeloModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MeloDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FoldersSet'
CREATE TABLE [dbo].[FoldersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Music] bit  NOT NULL,
    [Picture] bit  NOT NULL,
    [Video] bit  NOT NULL
);
GO

-- Creating table 'SettingsSet'
CREATE TABLE [dbo].[SettingsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [Extension] nvarchar(max)  NOT NULL,
    [Check] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FoldersSet'
ALTER TABLE [dbo].[FoldersSet]
ADD CONSTRAINT [PK_FoldersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SettingsSet'
ALTER TABLE [dbo].[SettingsSet]
ADD CONSTRAINT [PK_SettingsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------