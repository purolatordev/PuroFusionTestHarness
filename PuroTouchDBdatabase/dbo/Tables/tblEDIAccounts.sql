CREATE TABLE [dbo].[tblEDIAccounts] (
    [idEDIAccount]       INT            IDENTITY (1, 1) NOT NULL,
    [AccountNumber]      VARCHAR (50)   NULL,
    [idRequest]          INT            NOT NULL,
    [idEDITranscation]   INT            NOT NULL,
    [EDITranscationType] VARCHAR (50)   NULL,
    [Category]           VARCHAR (50)   NOT NULL,
    [CreatedBy]          NVARCHAR (100) NULL,
    [CreatedOn]          DATETIME       NULL,
    [UpdatedBy]          NVARCHAR (100) NULL,
    [UpdatedOn]          DATETIME       NULL,
    [ActiveFlag]         BIT            NULL,
    CONSTRAINT [PK_tbltblEDIAccounts] PRIMARY KEY CLUSTERED ([idEDIAccount] ASC),
    CONSTRAINT [FK_idTrans_Accts_Trans] FOREIGN KEY ([idEDITranscation]) REFERENCES [dbo].[tblEDITranscations] ([idEDITranscation])
);

