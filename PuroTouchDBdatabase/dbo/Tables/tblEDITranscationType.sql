CREATE TABLE [dbo].[tblEDITranscationType] (
    [idEDITranscationType] INT          IDENTITY (1, 1) NOT NULL,
    [EDITranscationType]   VARCHAR (50) NULL,
    [CategoryID]           INT          NOT NULL,
    [Category]             VARCHAR (50) NOT NULL,
    [UpdatedBy]            VARCHAR (50) NULL,
    [UpdatedOn]            DATETIME     NULL,
    [CreatedBy]            VARCHAR (50) NULL,
    [CreatedOn]            DATETIME     NULL,
    [ActiveFlag]           BIT          NULL,
    CONSTRAINT [PK_tblEDITranscationType] PRIMARY KEY CLUSTERED ([idEDITranscationType] ASC)
);



