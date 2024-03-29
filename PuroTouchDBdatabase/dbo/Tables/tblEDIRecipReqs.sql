﻿CREATE TABLE [dbo].[tblEDIRecipReqs] (
    [idEDIRecipReqs]        INT            IDENTITY (1, 1) NOT NULL,
    [RecipReqNum]           INT            NOT NULL,
    [idRequest]             INT            NOT NULL,
    [idEDITranscation]      INT            NOT NULL,
    [PanelTitle]            VARCHAR (50)   NULL,
    [idFileType]            INT            NOT NULL,
    [X12_ISA]               VARCHAR (50)   NULL,
    [X12_GS]                VARCHAR (50)   NULL,
    [X12_Qualifier]         VARCHAR (50)   NULL,
    [idCommunicationMethod] INT            NOT NULL,
    [FTPAddress]            NVARCHAR (100) NULL,
    [UserName]              VARCHAR (50)   NULL,
    [Password]              VARCHAR (50)   NULL,
    [FolderPath]            NVARCHAR (100) NULL,
    [Email]                 NVARCHAR (100) NULL,
    [idTriggerMechanism]    INT            NOT NULL,
    [idTiming]              INT            NOT NULL,
    [TimeOfFile]            DATETIME       NULL,
    [EDITranscationType]    VARCHAR (50)   NULL,
    [Category]              VARCHAR (50)   NOT NULL,
    [CreatedBy]             NVARCHAR (100) NULL,
    [CreatedOn]             DATETIME       NULL,
    [UpdatedBy]             NVARCHAR (100) NULL,
    [UpdatedOn]             DATETIME       NULL,
    [ActiveFlag]            BIT            NULL,
    CONSTRAINT [PK_tblEDIRecipReq] PRIMARY KEY CLUSTERED ([idEDIRecipReqs] ASC),
    CONSTRAINT [FK_idComMeth_EDIRecipReqs_ComMeth] FOREIGN KEY ([idCommunicationMethod]) REFERENCES [dbo].[tblCommunicationMethod] ([idCommunicationMethod]),
    CONSTRAINT [FK_idFileType_EDIRecipReqs_FileType] FOREIGN KEY ([idFileType]) REFERENCES [dbo].[tblFileType] ([idFileType]),
    CONSTRAINT [FK_idTime_EDIRecipReqs_Timing] FOREIGN KEY ([idTiming]) REFERENCES [dbo].[tblTiming] ([idTiming]),
    CONSTRAINT [FK_idTrans_RecipReqs_Trans] FOREIGN KEY ([idEDITranscation]) REFERENCES [dbo].[tblEDITranscations] ([idEDITranscation]),
    CONSTRAINT [FK_idTrig_EDIRecipReqs_TrigMech] FOREIGN KEY ([idTriggerMechanism]) REFERENCES [dbo].[tblTriggerMechanism] ([idTriggerMechanism])
);







