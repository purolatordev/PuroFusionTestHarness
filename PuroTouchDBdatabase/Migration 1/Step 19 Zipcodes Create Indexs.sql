--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO

/****** Object:  Table [dbo].[tblITBA]    Script Date: 8/3/2021 1:09:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.ZIPCodes', N'U') IS NOT NULL
begin
	print 'Drop -- Index_ZIPCodes_City Index'
	DROP INDEX IF EXISTS Index_ZIPCodes_City ON ZIPCodes;
end

IF OBJECT_ID(N'dbo.ZIPCodes', N'U') IS NOT NULL
begin
	print 'Drop -- Index_ZIPCodes_State Index'
	DROP INDEX IF EXISTS [Index_ZIPCodes_State] ON ZIPCodes;
end

IF OBJECT_ID(N'dbo.ZIPCodes', N'U') IS NOT NULL
begin
	print 'Drop -- Index_ZIPCodes_ZipCode Index'
	DROP INDEX IF EXISTS [Index_ZIPCodes_ZipCode] ON ZIPCodes;
end

CREATE NONCLUSTERED INDEX [Index_ZIPCodes_City]
    ON [dbo].[ZIPCodes]([City] ASC);
GO

CREATE NONCLUSTERED INDEX [Index_ZIPCodes_State]
    ON [dbo].[ZIPCodes]([State] ASC);
GO

CREATE NONCLUSTERED INDEX [Index_ZIPCodes_ZipCode]
    ON [dbo].[ZIPCodes]([ZipCode] ASC);
GO

