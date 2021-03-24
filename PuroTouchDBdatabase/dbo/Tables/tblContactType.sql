CREATE TABLE [dbo].[tblContactType] (
    [idContactType] INT          IDENTITY (1, 1) NOT NULL,
    [ContactType]   VARCHAR (50) NULL,
    [UpdatedBy]     VARCHAR (50) NULL,
    [UpdatedOn]     DATETIME     NULL,
    [CreatedBy]     VARCHAR (50) NULL,
    [CreatedOn]     DATETIME     NULL,
    [ActiveFlag]    BIT          NULL,
    CONSTRAINT [PK_tblContactType] PRIMARY KEY CLUSTERED ([idContactType] ASC)
);

