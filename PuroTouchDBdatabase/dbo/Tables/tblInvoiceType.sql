CREATE TABLE [dbo].[tblInvoiceType] (
    [idInvoiceType] INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceType]   VARCHAR (100) NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblInvoiceType] PRIMARY KEY CLUSTERED ([idInvoiceType] ASC)
);

