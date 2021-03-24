CREATE TABLE [dbo].[tblBillingTypes] (
    [idBillingType] INT           IDENTITY (1, 1) NOT NULL,
    [BillingType]   VARCHAR (50)  NULL,
    [Description]   VARCHAR (255) NULL,
    [Createdby]     VARCHAR (50)  NULL,
    [Createddate]   DATETIME      NULL,
    [Modifiedby]    VARCHAR (50)  NULL,
    [ModifiedDate]  DATETIME      NULL
);

