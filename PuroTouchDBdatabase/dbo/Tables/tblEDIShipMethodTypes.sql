CREATE TABLE [dbo].[tblEDIShipMethodTypes] (
    [idEDIShipMethodTypes] INT          IDENTITY (1, 1) NOT NULL,
    [MethodType]           VARCHAR (50) NULL,
    [UpdatedBy]            VARCHAR (50) NULL,
    [UpdatedOn]            DATETIME     NULL,
    [CreatedBy]            VARCHAR (50) NULL,
    [CreatedOn]            DATETIME     NULL,
    [ActiveFlag]           BIT          NULL,
    CONSTRAINT [PK_tblEDIShipMethodTypes] PRIMARY KEY CLUSTERED ([idEDIShipMethodTypes] ASC)
);

