CREATE TABLE [dbo].[tblProductTypeRel] (
    [idProductTypeRel] INT          IDENTITY (1, 1) NOT NULL,
    [idProductType]    INT          NULL,
    [idProduct]        INT          NULL,
    [CreatedBy]        VARCHAR (50) NULL,
    [CreatedDate]      DATETIME     NULL,
    [Modifiedby]       VARCHAR (50) NULL,
    [ModifiedDate]     DATETIME     NULL
);

