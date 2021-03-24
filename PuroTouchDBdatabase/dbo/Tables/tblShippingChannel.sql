CREATE TABLE [dbo].[tblShippingChannel] (
    [idShippingChannel] INT           IDENTITY (1, 1) NOT NULL,
    [ShippingChannel]   VARCHAR (100) NULL,
    [UpdatedBy]         VARCHAR (100) NULL,
    [UpdatedOn]         DATETIME      NULL,
    [CreatedBy]         VARCHAR (100) NULL,
    [CreatedOn]         DATETIME      NULL,
    [ActiveFlag]        BIT           NULL,
    CONSTRAINT [PK_tblShippingChannel] PRIMARY KEY CLUSTERED ([idShippingChannel] ASC)
);

