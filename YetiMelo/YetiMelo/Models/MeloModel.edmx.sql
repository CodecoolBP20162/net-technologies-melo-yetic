
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/20/2017 16:59:58
-- Generated from EDMX file: D:\CC Projects\C#\net-technologies-melo-yetic\YetiMelo\YetiMelo\Models\MeloModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [YetiDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FoldersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoldersSet];
GO
IF OBJECT_ID(N'[dbo].[SettingsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SettingsSet];
GO

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