CREATE TABLE [dbo].[tblDiscoveryRequestServices_Archive] (
    [idRequestSvc_Archive] INT           IDENTITY (1, 1) NOT NULL,
    [idRequestSvc]         INT           NOT NULL,
    [TableAction]          VARCHAR (50)  NOT NULL,
    [idRequest]            INT           NOT NULL,
    [idShippingSvc]        INT           NOT NULL,
    [volume]               INT           NOT NULL,
    [UpdatedBy]            VARCHAR (100) NULL,
    [UpdatedOn]            DATETIME      NULL,
    [CreatedBy]            VARCHAR (100) NULL,
    [CreatedOn]            DATETIME      NULL,
    CONSTRAINT [PK_tblDiscoveryRequestServices_Archive] PRIMARY KEY CLUSTERED ([idRequestSvc_Archive] ASC)
);

