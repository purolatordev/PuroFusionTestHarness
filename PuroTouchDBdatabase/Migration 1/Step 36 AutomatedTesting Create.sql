--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO


CREATE TABLE [dbo].[AutomatedTesting] (
    [ID]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [TestName] NVARCHAR (50) NOT NULL,
    [Category] NVARCHAR (50) NOT NULL,
    [Step]     NVARCHAR (50) NOT NULL,
    [Pass]     BIT           NOT NULL,
    [RunDate]  DATETIME      NOT NULL,
    CONSTRAINT [PK_AutomatedTesting] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO
