CREATE TABLE [dbo].[tblStatusCodesAll] (
    [idStatusCodesAll]     INT           IDENTITY (1, 1) NOT NULL,
    [idEDIRecipReqs]       INT           NOT NULL,
    [idStatusCodes]        INT           NOT NULL,
    [StatusCode]           VARCHAR (50)  NULL,
    [idEDITranscationType] INT           NOT NULL,
    [EDITranscationType]   VARCHAR (50)  NULL,
    [CategoryID]           INT           NOT NULL,
    [Category]             VARCHAR (50)  NOT NULL,
    [UpdatedBy]            VARCHAR (100) NULL,
    [UpdatedOn]            DATETIME      NULL,
    [CreatedBy]            VARCHAR (100) NULL,
    [CreatedOn]            DATETIME      NULL,
    [ActiveFlag]           BIT           NULL,
    CONSTRAINT [PK_tblStatusCodesAll] PRIMARY KEY CLUSTERED ([idStatusCodesAll] ASC),
    CONSTRAINT [FK_idEDIRecipReqs_tatusCodesAll_EDIRecipReqs] FOREIGN KEY ([idEDIRecipReqs]) REFERENCES [dbo].[tblEDIRecipReqs] ([idEDIRecipReqs]),
    CONSTRAINT [FK_idEDITransType_StatCodesAll_EDITransType] FOREIGN KEY ([idEDITranscationType]) REFERENCES [dbo].[tblEDITranscationType] ([idEDITranscationType])
);

