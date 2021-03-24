CREATE TABLE [dbo].[tblShippingProducts] (
    [idShippingProduct] INT           IDENTITY (1, 1) NOT NULL,
    [idShippingSvc]     INT           NULL,
    [ShippingProduct]   VARCHAR (100) NULL,
    [UpdatedBy]         VARCHAR (100) NULL,
    [UpdatedOn]         DATETIME      NULL,
    [CreatedBy]         VARCHAR (100) NULL,
    [CreatedOn]         DATETIME      NULL,
    [ActiveFlag]        BIT           NULL,
    CONSTRAINT [PK_tblShippingProducts] PRIMARY KEY CLUSTERED ([idShippingProduct] ASC)
);

