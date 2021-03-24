CREATE TABLE [dbo].[tblCommunicationMethod] (
    [idCommunicationMethod] INT           IDENTITY (1, 1) NOT NULL,
    [CommunicationMethod]   VARCHAR (100) NULL,
    [UpdatedBy]             VARCHAR (100) NULL,
    [UpdatedOn]             DATETIME      NULL,
    [CreatedBy]             VARCHAR (100) NULL,
    [CreatedOn]             DATETIME      NULL,
    [ActiveFlag]            BIT           NULL,
    CONSTRAINT [PK_tblCommunicationMethod] PRIMARY KEY CLUSTERED ([idCommunicationMethod] ASC)
);

