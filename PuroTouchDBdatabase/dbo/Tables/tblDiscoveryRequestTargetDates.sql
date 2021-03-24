CREATE TABLE [dbo].[tblDiscoveryRequestTargetDates] (
    [idTargetDate] INT            IDENTITY (1, 1) NOT NULL,
    [idRequest]    INT            NULL,
    [TargetDate]   DATETIME       NULL,
    [ChangeReason] VARCHAR (1000) NULL,
    [CreatedBy]    VARCHAR (250)  NULL,
    [CreatedOn]    DATETIME       NULL,
    CONSTRAINT [PK_tblDiscoveryRequestTargetDates] PRIMARY KEY CLUSTERED ([idTargetDate] ASC)
);

