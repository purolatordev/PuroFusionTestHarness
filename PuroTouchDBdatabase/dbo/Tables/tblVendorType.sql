CREATE TABLE [dbo].[tblVendorType] (
    [idVendorType] INT           IDENTITY (1, 1) NOT NULL,
    [VendorType]   VARCHAR (100) NULL,
    [UpdatedBy]    VARCHAR (100) NULL,
    [UpdatedOn]    DATETIME      NULL,
    [CreatedBy]    VARCHAR (100) NULL,
    [CreatedOn]    DATETIME      NULL,
    [ActiveFlag]   BIT           NULL,
    CONSTRAINT [PK_tblVendorType] PRIMARY KEY CLUSTERED ([idVendorType] ASC)
);

