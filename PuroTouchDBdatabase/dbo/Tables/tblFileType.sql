CREATE TABLE [dbo].[tblFileType] (
    [idFileType] INT           IDENTITY (1, 1) NOT NULL,
    [FileType]   VARCHAR (100) NULL,
    [UpdatedBy]  VARCHAR (100) NULL,
    [UpdatedOn]  DATETIME      NULL,
    [CreatedBy]  VARCHAR (100) NULL,
    [CreatedOn]  DATETIME      NULL,
    [ActiveFlag] BIT           NULL,
    CONSTRAINT [PK_tblFileType] PRIMARY KEY CLUSTERED ([idFileType] ASC)
);

