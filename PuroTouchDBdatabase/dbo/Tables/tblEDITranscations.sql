CREATE TABLE [dbo].[tblEDITranscations] (
    [idEDITranscation]     INT            IDENTITY (1, 1) NOT NULL,
    [idRequest]            INT            NOT NULL,
    [idEDITranscationType] INT            NOT NULL,
    [CreatedBy]            NVARCHAR (100) NULL,
    [CreatedOn]            DATETIME       NULL,
    [UpdatedBy]            NVARCHAR (100) NULL,
    [UpdatedOn]            DATETIME       NULL,
    [ActiveFlag]           BIT            NULL,
    CONSTRAINT [PK_tblEDITranscations] PRIMARY KEY CLUSTERED ([idEDITranscation] ASC),
    CONSTRAINT [FK_idEDITransType_EDITransType] FOREIGN KEY ([idEDITranscationType]) REFERENCES [dbo].[tblEDITranscationType] ([idEDITranscationType]),
    CONSTRAINT [FK_idReq_EDITran_DisReq] FOREIGN KEY ([idRequest]) REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
);

