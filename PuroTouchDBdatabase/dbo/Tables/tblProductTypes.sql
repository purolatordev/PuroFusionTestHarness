CREATE TABLE [dbo].[tblProductTypes] (
    [idProductType] INT           IDENTITY (1, 1) NOT NULL,
    [ProductType]   VARCHAR (100) NOT NULL,
    [Description]   VARCHAR (255) NULL,
    [CreatedBy]     VARCHAR (50)  NULL,
    [Createddate]   DATETIME      NULL,
    [ModifiedBy]    VARCHAR (50)  NULL,
    [ModifiedDate]  DATETIME      NULL
);

