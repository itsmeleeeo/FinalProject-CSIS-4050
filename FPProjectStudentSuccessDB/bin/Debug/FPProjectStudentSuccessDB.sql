﻿/*
Deployment script for FPProjectStudentSuccessDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "FPProjectStudentSuccessDB"
:setvar DefaultFilePrefix "FPProjectStudentSuccessDB"
:setvar DefaultDataPath "C:\Users\henri\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\henri\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating Table [dbo].[Plataform]...';


GO
CREATE TABLE [dbo].[Plataform] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [Type] VARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Product] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100)  NOT NULL,
    [Publisher]   VARCHAR (50)   NOT NULL,
    [PlataformId] INT            NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Year]        INT            NOT NULL,
    [Price]       DECIMAL (7, 2) NOT NULL,
    [ShelfId]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Sales]...';


GO
CREATE TABLE [dbo].[Sales] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]   INT            NOT NULL,
    [ProductName] VARCHAR (100)  NOT NULL,
    [Quantity]    INT            NOT NULL,
    [SalesTotal]  DECIMAL (7, 2) NOT NULL,
    [UserId]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Shelf]...';


GO
CREATE TABLE [dbo].[Shelf] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Color]       VARCHAR (25) NOT NULL,
    [Capacity]    INT          NOT NULL,
    [PlataformId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [Email]     VARCHAR (50) NOT NULL,
    [Username]  VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    [IsAdmin]   BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Product]...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD FOREIGN KEY ([PlataformId]) REFERENCES [dbo].[Plataform] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Product]...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD FOREIGN KEY ([ShelfId]) REFERENCES [dbo].[Shelf] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Sales]...';


GO
ALTER TABLE [dbo].[Sales] WITH NOCHECK
    ADD FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Sales]...';


GO
ALTER TABLE [dbo].[Sales] WITH NOCHECK
    ADD FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[Shelf]...';


GO
ALTER TABLE [dbo].[Shelf] WITH NOCHECK
    ADD FOREIGN KEY ([PlataformId]) REFERENCES [dbo].[Plataform] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Product'), OBJECT_ID(N'dbo.Sales'), OBJECT_ID(N'dbo.Shelf'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO
