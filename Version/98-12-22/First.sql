/*
Run this script on:

        localhost.AllInOne_Host    -  This database will be modified

to synchronize it with:

        ..AllInOne

You are recommended to back up your database before running this script

Script created by SQL Compare version 13.1.1.5299 from Red Gate Software Ltd at 22/12/1398 07:51:01 ب.ظ

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating schemas'
GO
CREATE SCHEMA [Blog]
AUTHORIZATION [dbo]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Blog].[ArticleGroups]'
GO
CREATE TABLE [Blog].[ArticleGroups]
(
[Id] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Title] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ParentId] [uniqueidentifier] NULL,
[Image] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MetaRobots] [nvarchar] (200) COLLATE Arabic_CI_AS NULL,
[MetaKeywords] [nvarchar] (200) COLLATE Arabic_CI_AS NULL,
[MetaDescription] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_ArticleGroups] on [Blog].[ArticleGroups]'
GO
ALTER TABLE [Blog].[ArticleGroups] ADD CONSTRAINT [PK_ArticleGroups] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Blog].[ArticleImages]'
GO
CREATE TABLE [Blog].[ArticleImages]
(
[Id] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Alt] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Width] [varchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Height] [varchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ArticleId] [uniqueidentifier] NOT NULL,
[Caption] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_ArticleImages] on [Blog].[ArticleImages]'
GO
ALTER TABLE [Blog].[ArticleImages] ADD CONSTRAINT [PK_ArticleImages] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Blog].[Articles]'
GO
CREATE TABLE [Blog].[Articles]
(
[Id] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Title] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Image] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Summary] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ArticleGroupId] [uniqueidentifier] NULL,
[VisitNumber] [int] NOT NULL,
[MetaRobots] [nvarchar] (200) COLLATE Arabic_CI_AS NULL,
[MetaKeywords] [nvarchar] (200) COLLATE Arabic_CI_AS NULL,
[MetaDescription] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Articles] on [Blog].[Articles]'
GO
ALTER TABLE [Blog].[Articles] ADD CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
-- This statement writes to the SQL Server Log so SQL Monitor can show this deployment.
IF HAS_PERMS_BY_NAME(N'sys.xp_logevent', N'OBJECT', N'EXECUTE') = 1
BEGIN
    DECLARE @databaseName AS nvarchar(2048), @eventMessage AS nvarchar(2048)
    SET @databaseName = REPLACE(REPLACE(DB_NAME(), N'\', N'\\'), N'"', N'\"')
    SET @eventMessage = N'Redgate SQL Compare: { "deployment": { "description": "Redgate SQL Compare deployed to ' + @databaseName + N'", "database": "' + @databaseName + N'" }}'
    EXECUTE sys.xp_logevent 55000, @eventMessage
END
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
