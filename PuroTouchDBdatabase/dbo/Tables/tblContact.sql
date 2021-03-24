CREATE TABLE [dbo].[tblContact] (
    [idContact]     INT            IDENTITY (1, 1) NOT NULL,
    [idRequest]     INT            NOT NULL,
    [idContactType] INT            NOT NULL,
    [Name]          NVARCHAR (255) NULL,
    [Title]         NVARCHAR (255) NULL,
    [Phone]         NVARCHAR (255) NULL,
    [Email]         NVARCHAR (255) NULL,
    [CreatedBy]     NVARCHAR (100) NULL,
    [CreatedOn]     DATETIME       NULL,
    [UpdatedBy]     NVARCHAR (100) NULL,
    [UpdatedOn]     DATETIME       NULL,
    [ActiveFlag]    BIT            NULL,
    CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED ([idContact] ASC),
    CONSTRAINT [FK_idContactType_ContactType] FOREIGN KEY ([idContactType]) REFERENCES [dbo].[tblContactType] ([idContactType])
);

