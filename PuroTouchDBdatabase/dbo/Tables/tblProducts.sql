CREATE TABLE [dbo].[tblProducts] (
    [idProduct]    INT           IDENTITY (1, 1) NOT NULL,
    [Product]      VARCHAR (50)  NULL,
    [Description]  VARCHAR (255) NULL,
    [Createdby]    VARCHAR (50)  NULL,
    [Createddate]  DATETIME      NULL,
    [ModifiedBy]   VARCHAR (50)  NULL,
    [Modifieddate] DATETIME      NULL
);

