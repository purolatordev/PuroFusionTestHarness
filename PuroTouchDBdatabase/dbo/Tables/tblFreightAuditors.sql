CREATE TABLE [dbo].[tblFreightAuditors] (
    [idFreightAuditor] INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]      VARCHAR (255) NULL,
    [UpdatedBy]        VARCHAR (100) NULL,
    [UpdatedOn]        DATETIME      NULL,
    [CreatedBy]        VARCHAR (100) NULL,
    [CreatedOn]        DATETIME      NULL,
    [ActiveFlag]       BIT           NULL,
    CONSTRAINT [PK_tblFreightAuditors] PRIMARY KEY CLUSTERED ([idFreightAuditor] ASC)
);

