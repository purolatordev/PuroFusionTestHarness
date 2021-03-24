CREATE TABLE [dbo].[tblDiscoveryRequestEDI] (
    [idDREDI]             INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]           INT           NOT NULL,
    [Solution]            VARCHAR (255) NULL,
    [FileFormat]          VARCHAR (255) NULL,
    [CommunicationMethod] VARCHAR (255) NULL,
    [UpdatedBy]           VARCHAR (100) NULL,
    [UpdatedOn]           DATETIME      NULL,
    [CreatedBy]           VARCHAR (100) NULL,
    [CreatedOn]           DATETIME      NULL,
    CONSTRAINT [PK_tblDiscoveryRequestEDI] PRIMARY KEY CLUSTERED ([idDREDI] ASC)
);

