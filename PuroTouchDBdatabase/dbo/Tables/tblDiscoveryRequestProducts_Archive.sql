CREATE TABLE [dbo].[tblDiscoveryRequestProducts_Archive] (
    [idDRProduct_Archive] INT           IDENTITY (1, 1) NOT NULL,
    [idDRProduct]         INT           NOT NULL,
    [TableAction]         VARCHAR (50)  NOT NULL,
    [idRequest]           INT           NOT NULL,
    [idShippingProduct]   INT           NOT NULL,
    [UpdatedBy]           VARCHAR (100) NULL,
    [UpdatedOn]           DATETIME      NULL,
    [CreatedBy]           VARCHAR (100) NULL,
    [CreatedOn]           DATETIME      NULL,
    CONSTRAINT [PK_tblDiscoveryRequestProducts_Archive] PRIMARY KEY CLUSTERED ([idDRProduct_Archive] ASC)
);

