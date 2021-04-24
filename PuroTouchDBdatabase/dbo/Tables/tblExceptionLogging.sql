CREATE TABLE [dbo].[tblExceptionLogging] (
    [Logid]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Method]          VARCHAR (100)  NULL,
    [ExceptionMsg]    NVARCHAR (MAX) NULL,
    [ExceptionType]   VARCHAR (100)  NULL,
    [ExceptionSource] NVARCHAR (MAX) NULL,
    [ExceptionURL]    VARCHAR (100)  NULL,
    [CreatedBy]       NVARCHAR (100) NULL,
    [CreatedOn]       DATETIME       NULL,
    CONSTRAINT [PK_tblExceptionLogging] PRIMARY KEY CLUSTERED ([Logid] ASC)
);

