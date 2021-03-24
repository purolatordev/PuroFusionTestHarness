CREATE TABLE [dbo].[tblShippingVendor] (
    [idShippingVendor] INT           IDENTITY (1, 1) NOT NULL,
    [VendorName]       VARCHAR (250) NULL,
    [CreatedBy]        VARCHAR (100) NULL,
    [CreatedOn]        DATETIME      NULL,
    [UpdatedBy]        VARCHAR (100) NULL,
    [UpdatedOn]        DATETIME      NULL,
    [ActiveFlag]       BIT           NULL,
    [SortFlag]         BIT           NULL,
    CONSTRAINT [PK_tblCAVendor] PRIMARY KEY CLUSTERED ([idShippingVendor] ASC)
);

