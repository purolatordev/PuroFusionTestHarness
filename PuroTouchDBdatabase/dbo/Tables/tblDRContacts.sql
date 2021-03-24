CREATE TABLE [dbo].[tblDRContacts] (
    [idContact]     INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]     INT           NULL,
    [idContactType] INT           NULL,
    [Contact]       VARCHAR (255) NULL,
    [Title]         VARCHAR (255) NULL,
    [Email]         VARCHAR (255) NULL,
    [Phone]         VARCHAR (255) NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblDRContacts] PRIMARY KEY CLUSTERED ([idContact] ASC)
);

