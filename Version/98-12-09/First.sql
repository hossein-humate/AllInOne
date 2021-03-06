/*
Run this script on:

        ..AllInOne_Host    -  This database will be modified

to synchronize it with:

        ..AllInOne

You are recommended to back up your database before running this script

Script created by SQL Compare version 13.1.1.5299 from Red Gate Software Ltd at 09/12/1398 09:09:35 ب.ظ

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
CREATE SCHEMA [BaseInfo]
AUTHORIZATION [dbo]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Address]'
GO
ALTER TABLE [Identity].[Address] DROP CONSTRAINT [PK_Address]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Email]'
GO
ALTER TABLE [Identity].[Email] DROP CONSTRAINT [PK_Email]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Permission]'
GO
ALTER TABLE [Identity].[Permission] DROP CONSTRAINT [PK_Permission]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Person]'
GO
ALTER TABLE [Identity].[Person] DROP CONSTRAINT [PK_Person]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Phone]'
GO
ALTER TABLE [Identity].[Phone] DROP CONSTRAINT [PK_Phone]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[RolePermission]'
GO
ALTER TABLE [Identity].[RolePermission] DROP CONSTRAINT [PK_RolePermission]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Role]'
GO
ALTER TABLE [Identity].[Role] DROP CONSTRAINT [PK_Role]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[SocialNetwork]'
GO
ALTER TABLE [Identity].[SocialNetwork] DROP CONSTRAINT [PK_SocialNetwork]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[Unit]'
GO
ALTER TABLE [Identity].[Unit] DROP CONSTRAINT [PK_Unit]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[UserPermission]'
GO
ALTER TABLE [Identity].[UserPermission] DROP CONSTRAINT [PK_UserPermission]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[UserRole]'
GO
ALTER TABLE [Identity].[UserRole] DROP CONSTRAINT [PK_UserRole]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[UserUnitRole]'
GO
ALTER TABLE [Identity].[UserUnitRole] DROP CONSTRAINT [PK_UserUnitRole]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[UserUnit]'
GO
ALTER TABLE [Identity].[UserUnit] DROP CONSTRAINT [PK_UserUnit]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [Identity].[User]'
GO
ALTER TABLE [Identity].[User] DROP CONSTRAINT [PK_User]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[User]'
GO
DROP TABLE [Identity].[User]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[UserUnit]'
GO
DROP TABLE [Identity].[UserUnit]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[UserUnitRole]'
GO
DROP TABLE [Identity].[UserUnitRole]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[UserRole]'
GO
DROP TABLE [Identity].[UserRole]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[UserPermission]'
GO
DROP TABLE [Identity].[UserPermission]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Unit]'
GO
DROP TABLE [Identity].[Unit]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[SocialNetwork]'
GO
DROP TABLE [Identity].[SocialNetwork]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Role]'
GO
DROP TABLE [Identity].[Role]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[RolePermission]'
GO
DROP TABLE [Identity].[RolePermission]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Phone]'
GO
DROP TABLE [Identity].[Phone]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Person]'
GO
DROP TABLE [Identity].[Person]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Permission]'
GO
DROP TABLE [Identity].[Permission]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Email]'
GO
DROP TABLE [Identity].[Email]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [Identity].[Address]'
GO
DROP TABLE [Identity].[Address]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[AssignedTask]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[AssignedTask] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[Contract]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Contract] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Contract] ALTER COLUMN [Title] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Contract] ALTER COLUMN [ContractCode] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Contract] ALTER COLUMN [StartDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Contract] ALTER COLUMN [EndDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[Customer]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Name] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Title] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Address] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Phone] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Mobile] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [Email] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Customer] ALTER COLUMN [WebSite] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[Developer]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Developer] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Developer] ALTER COLUMN [FirstName] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Developer] ALTER COLUMN [LastName] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Developer] ALTER COLUMN [Mobile] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Developer] ALTER COLUMN [Email] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[Payment]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Payment] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[Project]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Project] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Project] ALTER COLUMN [Name] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Project] ALTER COLUMN [StartDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[Tag]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Tag] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[Tag] ALTER COLUMN [Name] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[TaskChecklist]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [Title] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [TagId] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [StartDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [StartTime] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [EndDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[TaskChecklist] ALTER COLUMN [EndTime] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[ToDo]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [Title] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [Code] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [StartDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [StartTime] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [EndDate] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[ToDo] ALTER COLUMN [EndTime] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [AllInOne].[WorkSheet]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [AllInOne].[WorkSheet] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [Application].[Database]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [CreationDate] [datetime] NOT NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [LastModifiedDate] [datetime] NOT NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [DeletionDate] [datetime] NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [DataSource] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [ServerName] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [Provider] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [Username] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Database] ALTER COLUMN [Password] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [Application].[Software]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ADD
[TokenHash] [varbinary] (max) NULL,
[TokenSalt] [varbinary] (max) NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [CreationDate] [datetime] NOT NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [LastModifiedDate] [datetime] NOT NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [DeletionDate] [datetime] NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [FaName] [nvarchar] (100) COLLATE Arabic_CI_AS NOT NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [EnName] [nvarchar] (100) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [ProgrammingLanguage] [nvarchar] (50) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Application].[Software] ALTER COLUMN [Methodology] [nvarchar] (50) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [Identity].[Visitors]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [Ip] [varchar] (20) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [Browser] [nvarchar] (100) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [Device] [nvarchar] (100) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [Platform] [nvarchar] (100) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [UserAgent] [nvarchar] (500) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [UrlPath] [nvarchar] (500) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Identity].[Visitors] ALTER COLUMN [Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [BaseInfo].[MasterDetails]'
GO
CREATE TABLE [BaseInfo].[MasterDetails]
(
[Id] [uniqueidentifier] NOT NULL,
[Title] [nvarchar] (100) COLLATE Arabic_CI_AS NULL,
[FaName] [nvarchar] (100) COLLATE Arabic_CI_AS NOT NULL,
[EnName] [nvarchar] (100) COLLATE Arabic_CI_AS NULL,
[MasterId] [uniqueidentifier] NOT NULL,
[Order] [int] NULL,
[LastModifiedDate] [datetime] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[IsActive] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_MasterDetails] on [BaseInfo].[MasterDetails]'
GO
ALTER TABLE [BaseInfo].[MasterDetails] ADD CONSTRAINT [PK_MasterDetails] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Addresses]'
GO
CREATE TABLE [Identity].[Addresses]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[UserId] [uniqueidentifier] NOT NULL,
[Country] [nvarchar] (50) COLLATE Arabic_CI_AS NULL,
[State] [nvarchar] (50) COLLATE Arabic_CI_AS NULL,
[City] [nvarchar] (50) COLLATE Arabic_CI_AS NULL,
[PostalCode] [nvarchar] (10) COLLATE Arabic_CI_AS NULL,
[Primary] [bit] NULL,
[Confirmed] [bit] NULL,
[Type] [smallint] NULL,
[CityAreaId] [uniqueidentifier] NULL,
[Latitude] [varchar] (20) COLLATE Arabic_CI_AS NULL,
[Longitude] [varchar] (20) COLLATE Arabic_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Addresses] on [Identity].[Addresses]'
GO
ALTER TABLE [Identity].[Addresses] ADD CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Emails]'
GO
CREATE TABLE [Identity].[Emails]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[UserId] [uniqueidentifier] NOT NULL,
[Name] [varchar] (50) COLLATE Arabic_CI_AS NOT NULL,
[Type] [tinyint] NULL,
[Primary] [bit] NULL,
[Confirmed] [bit] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Emails] on [Identity].[Emails]'
GO
ALTER TABLE [Identity].[Emails] ADD CONSTRAINT [PK_Emails] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Permissions]'
GO
CREATE TABLE [Identity].[Permissions]
(
[Id] [uniqueidentifier] NOT NULL,
[SoftwareId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[FaName] [nvarchar] (200) COLLATE Arabic_CI_AS NOT NULL,
[EnName] [varchar] (50) COLLATE Arabic_CI_AS NULL,
[Action] [nvarchar] (500) COLLATE Arabic_CI_AS NOT NULL,
[Type] [tinyint] NULL,
[SortOrder] [smallint] NULL,
[Public] [bit] NULL,
[ParentId] [uniqueidentifier] NOT NULL,
[Icon] [nvarchar] (500) COLLATE Arabic_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Permissions] on [Identity].[Permissions]'
GO
ALTER TABLE [Identity].[Permissions] ADD CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Persons]'
GO
CREATE TABLE [Identity].[Persons]
(
[Id] [uniqueidentifier] NOT NULL,
[SoftwareId] [uniqueidentifier] NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[Firstname] [nvarchar] (50) COLLATE Arabic_CI_AS NULL,
[Lastname] [nvarchar] (50) COLLATE Arabic_CI_AS NULL,
[Middlename] [nvarchar] (50) COLLATE Arabic_CI_AS NULL,
[NationalId] [varchar] (50) COLLATE Arabic_CI_AS NULL,
[PicturePath] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[Gender] [tinyint] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Persons] on [Identity].[Persons]'
GO
ALTER TABLE [Identity].[Persons] ADD CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Phones]'
GO
CREATE TABLE [Identity].[Phones]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[UserId] [uniqueidentifier] NOT NULL,
[Number] [varchar] (12) COLLATE Arabic_CI_AS NOT NULL,
[CountryCode] [varchar] (7) COLLATE Arabic_CI_AS NULL,
[CityCode] [varchar] (7) COLLATE Arabic_CI_AS NULL,
[Primary] [bit] NULL,
[Confirmed] [bit] NULL,
[Type] [tinyint] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Phones] on [Identity].[Phones]'
GO
ALTER TABLE [Identity].[Phones] ADD CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[RolePermissions]'
GO
CREATE TABLE [Identity].[RolePermissions]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[RoleId] [uniqueidentifier] NOT NULL,
[PermissionId] [uniqueidentifier] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_RolePermissions] on [Identity].[RolePermissions]'
GO
ALTER TABLE [Identity].[RolePermissions] ADD CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Roles]'
GO
CREATE TABLE [Identity].[Roles]
(
[Id] [uniqueidentifier] NOT NULL,
[SoftwareId] [uniqueidentifier] NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[Name] [nvarchar] (50) COLLATE Arabic_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Roles] on [Identity].[Roles]'
GO
ALTER TABLE [Identity].[Roles] ADD CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[SocialNetworks]'
GO
CREATE TABLE [Identity].[SocialNetworks]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[UserId] [uniqueidentifier] NOT NULL,
[Username] [nvarchar] (100) COLLATE Arabic_CI_AS NOT NULL,
[Provider] [smallint] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_SocialNetworks] on [Identity].[SocialNetworks]'
GO
ALTER TABLE [Identity].[SocialNetworks] ADD CONSTRAINT [PK_SocialNetworks] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[UserRoles]'
GO
CREATE TABLE [Identity].[UserRoles]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[RoleId] [uniqueidentifier] NOT NULL,
[UserId] [uniqueidentifier] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_UserRoles] on [Identity].[UserRoles]'
GO
ALTER TABLE [Identity].[UserRoles] ADD CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[UserSoftwares]'
GO
CREATE TABLE [Identity].[UserSoftwares]
(
[Id] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[SoftwareId] [uniqueidentifier] NOT NULL,
[UserId] [uniqueidentifier] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Identity].[Users]'
GO
CREATE TABLE [Identity].[Users]
(
[Id] [uniqueidentifier] NOT NULL,
[SoftwareId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[DeletionDate] [datetime] NULL,
[IsActive] [bit] NOT NULL,
[CreationDate] [datetime] NOT NULL,
[LastModifiedDate] [datetime] NOT NULL,
[Description] [nvarchar] (max) COLLATE Arabic_CI_AS NULL,
[Username] [nvarchar] (100) COLLATE Arabic_CI_AS NOT NULL,
[LastLoginDate] [datetime] NULL,
[RegisterIp] [varchar] (20) COLLATE Arabic_CI_AS NULL,
[RegisterDate] [datetime] NULL,
[LastLoginIp] [varchar] (20) COLLATE Arabic_CI_AS NULL,
[PasswordHash] [varbinary] (max) NOT NULL,
[PasswordSalt] [varbinary] (max) NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[TwoFactorEnable] [bit] NULL,
[TwoFactorPhoneId] [uniqueidentifier] NULL,
[TwoFactorEmailId] [uniqueidentifier] NULL,
[Password] [nvarchar] (100) COLLATE Arabic_CI_AS NULL,
[LoginTimes] [int] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Users] on [Identity].[Users]'
GO
ALTER TABLE [Identity].[Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED  ([Id])
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
