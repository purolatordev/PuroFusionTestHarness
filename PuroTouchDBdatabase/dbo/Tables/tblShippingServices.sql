CREATE TABLE [dbo].[tblShippingServices] (
    [idShippingSvc] INT           IDENTITY (1, 1) NOT NULL,
    [serviceDesc]   VARCHAR (100) NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblShippingServices] PRIMARY KEY CLUSTERED ([idShippingSvc] ASC)
);

