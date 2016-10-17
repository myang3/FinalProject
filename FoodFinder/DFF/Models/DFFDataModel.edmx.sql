
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2016 10:18:35
-- Generated from EDMX file: C:\Users\Mo\Documents\GitHub\FinalProject2\FoodFinder\DFF\Models\DFFDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [foodfinder];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MatchUp_DonationData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchUp] DROP CONSTRAINT [FK_MatchUp_DonationData];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchUp_ReceiverData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchUp] DROP CONSTRAINT [FK_MatchUp_ReceiverData];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DonationData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DonationData];
GO
IF OBJECT_ID(N'[dbo].[MatchUp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MatchUp];
GO
IF OBJECT_ID(N'[dbo].[ReceiverData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceiverData];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DonationData'
CREATE TABLE [dbo].[DonationData] (
    [DonationID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(15)  NOT NULL,
    [FoodType] nvarchar(max)  NULL,
    [Location] nvarchar(max)  NOT NULL,
    [PickupDate] nvarchar(10)  NOT NULL,
    [PickupTime] nvarchar(50)  NOT NULL,
    [shortDescription] varchar(max)  NULL
);
GO

-- Creating table 'MatchUp'
CREATE TABLE [dbo].[MatchUp] (
    [MatchID] int IDENTITY(1,1) NOT NULL,
    [DonationID] int  NOT NULL,
    [ReceiverID] int  NOT NULL
);
GO

-- Creating table 'ReceiverData'
CREATE TABLE [dbo].[ReceiverData] (
    [ReceiverID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(15)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DonationID] in table 'DonationData'
ALTER TABLE [dbo].[DonationData]
ADD CONSTRAINT [PK_DonationData]
    PRIMARY KEY CLUSTERED ([DonationID] ASC);
GO

-- Creating primary key on [MatchID] in table 'MatchUp'
ALTER TABLE [dbo].[MatchUp]
ADD CONSTRAINT [PK_MatchUp]
    PRIMARY KEY CLUSTERED ([MatchID] ASC);
GO

-- Creating primary key on [ReceiverID] in table 'ReceiverData'
ALTER TABLE [dbo].[ReceiverData]
ADD CONSTRAINT [PK_ReceiverData]
    PRIMARY KEY CLUSTERED ([ReceiverID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DonationID] in table 'MatchUp'
ALTER TABLE [dbo].[MatchUp]
ADD CONSTRAINT [FK_MatchUp_DonationData]
    FOREIGN KEY ([DonationID])
    REFERENCES [dbo].[DonationData]
        ([DonationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchUp_DonationData'
CREATE INDEX [IX_FK_MatchUp_DonationData]
ON [dbo].[MatchUp]
    ([DonationID]);
GO

-- Creating foreign key on [ReceiverID] in table 'MatchUp'
ALTER TABLE [dbo].[MatchUp]
ADD CONSTRAINT [FK_MatchUp_ReceiverData]
    FOREIGN KEY ([ReceiverID])
    REFERENCES [dbo].[ReceiverData]
        ([ReceiverID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchUp_ReceiverData'
CREATE INDEX [IX_FK_MatchUp_ReceiverData]
ON [dbo].[MatchUp]
    ([ReceiverID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------