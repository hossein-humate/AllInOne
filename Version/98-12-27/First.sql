/*
Run this script on:

        localhost.AllInOne_Host    -  This database will be modified

to synchronize it with:

        localhost.AllInOne

You are recommended to back up your database before running this script

Script created by SQL Compare version 13.1.1.5299 from Red Gate Software Ltd at 27/12/1398 12:14:25 ق.ظ

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
CREATE USER [AllInOne] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[AllInOne]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering members of role db_backupoperator'
GO
EXEC sp_addrolemember N'db_backupoperator', N'AllInOne'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering members of role db_datareader'
GO
EXEC sp_addrolemember N'db_datareader', N'AllInOne'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering members of role db_datawriter'
GO
EXEC sp_addrolemember N'db_datawriter', N'AllInOne'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering members of role db_ddladmin'
GO
EXEC sp_addrolemember N'db_ddladmin', N'AllInOne'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering schemas'
GO
ALTER AUTHORIZATION ON SCHEMA::[AllInOne] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[Application] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[BaseInfo] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[Identity] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_accessadmin] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_backupoperator] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_datareader] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_datawriter] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_ddladmin] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_denydatareader] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_denydatawriter] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_owner] TO [AllInOne]
GO
ALTER AUTHORIZATION ON SCHEMA::[db_securityadmin] TO [AllInOne]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [Blog].[Articles]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [Blog].[Articles] ADD
[Author] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Blog].[DocumentImages]'
GO
CREATE TABLE [Blog].[DocumentImages]
(
[Id] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Alt] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Width] [varchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Height] [varchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DocumentId] [uniqueidentifier] NOT NULL,
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
PRINT N'Creating primary key [PK_DocumentImages] on [Blog].[DocumentImages]'
GO
ALTER TABLE [Blog].[DocumentImages] ADD CONSTRAINT [PK_DocumentImages] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Blog].[Documents]'
GO
CREATE TABLE [Blog].[Documents]
(
[Id] [uniqueidentifier] NOT NULL,
[Name] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Title] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Summary] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ParentId] [uniqueidentifier] NULL,
[VisitNumber] [int] NOT NULL,
[Author] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MetaRobots] [nvarchar] (200) COLLATE Arabic_CI_AS NULL,
[MetaKeywords] [nvarchar] (200) COLLATE Arabic_CI_AS NULL,
[MetaDescription] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SortOrder] [smallint] NULL,
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
PRINT N'Creating primary key [PK_Documents] on [Blog].[Documents]'
GO
ALTER TABLE [Blog].[Documents] ADD CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
GRANT ALTER TO [AllInOne]
GRANT ALTER ANY ASYMMETRIC KEY TO [AllInOne]
GRANT ALTER ANY APPLICATION ROLE TO [AllInOne]
GRANT ALTER ANY ASSEMBLY TO [AllInOne]
GRANT ALTER ANY CERTIFICATE TO [AllInOne]
GRANT ALTER ANY DATABASE AUDIT TO [AllInOne]
GRANT ALTER ANY DATASPACE TO [AllInOne]
GRANT ALTER ANY DATABASE EVENT NOTIFICATION TO [AllInOne]
GRANT ALTER ANY FULLTEXT CATALOG TO [AllInOne]
GRANT ALTER ANY MESSAGE TYPE TO [AllInOne]
GRANT ALTER ANY ROLE TO [AllInOne]
GRANT ALTER ANY ROUTE TO [AllInOne]
GRANT ALTER ANY REMOTE SERVICE BINDING TO [AllInOne]
GRANT ALTER ANY CONTRACT TO [AllInOne]
GRANT ALTER ANY SYMMETRIC KEY TO [AllInOne]
GRANT ALTER ANY SCHEMA TO [AllInOne]
GRANT ALTER ANY SERVICE TO [AllInOne]
GRANT ALTER ANY DATABASE DDL TRIGGER TO [AllInOne]
GRANT ALTER ANY USER TO [AllInOne]
GRANT AUTHENTICATE TO [AllInOne]
GRANT BACKUP DATABASE TO [AllInOne]
GRANT BACKUP LOG TO [AllInOne]
GRANT CONTROL TO [AllInOne]
GRANT CONNECT REPLICATION TO [AllInOne]
GRANT CHECKPOINT TO [AllInOne]
GRANT CREATE AGGREGATE TO [AllInOne]
GRANT CREATE ASYMMETRIC KEY TO [AllInOne]
GRANT CREATE ASSEMBLY TO [AllInOne]
GRANT CREATE CERTIFICATE TO [AllInOne]
GRANT CREATE DEFAULT TO [AllInOne]
GRANT CREATE DATABASE DDL EVENT NOTIFICATION TO [AllInOne]
GRANT CREATE FUNCTION TO [AllInOne]
GRANT CREATE FULLTEXT CATALOG TO [AllInOne]
GRANT CREATE MESSAGE TYPE TO [AllInOne]
GRANT CREATE PROCEDURE TO [AllInOne]
GRANT CREATE QUEUE TO [AllInOne]
GRANT CREATE ROLE TO [AllInOne]
GRANT CREATE ROUTE TO [AllInOne]
GRANT CREATE RULE TO [AllInOne]
GRANT CREATE REMOTE SERVICE BINDING TO [AllInOne]
GRANT CREATE CONTRACT TO [AllInOne]
GRANT CREATE SYMMETRIC KEY TO [AllInOne]
GRANT CREATE SCHEMA TO [AllInOne]
GRANT CREATE SYNONYM TO [AllInOne]
GRANT CREATE SERVICE TO [AllInOne]
GRANT CREATE TABLE TO [AllInOne]
GRANT CREATE TYPE TO [AllInOne]
GRANT CREATE VIEW TO [AllInOne]
GRANT CREATE XML SCHEMA COLLECTION TO [AllInOne]
GRANT DELETE TO [AllInOne]
GRANT EXECUTE TO [AllInOne]
GRANT INSERT TO [AllInOne]
GRANT REFERENCES TO [AllInOne]
GRANT SELECT TO [AllInOne]
GRANT SHOWPLAN TO [AllInOne]
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [AllInOne]
GRANT TAKE OWNERSHIP TO [AllInOne]
GRANT UPDATE TO [AllInOne]
GRANT VIEW DEFINITION TO [AllInOne]
GRANT VIEW DATABASE STATE TO [AllInOne]
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
