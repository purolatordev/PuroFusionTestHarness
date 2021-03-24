CREATE TABLE [dbo].[tblDataEntryMethods] (
    [idDataEntry] INT           IDENTITY (1, 1) NOT NULL,
    [DataEntry]   VARCHAR (100) NULL,
    [UpdatedBy]   VARCHAR (100) NULL,
    [UpdatedOn]   DATETIME      NULL,
    [CreatedBy]   VARCHAR (100) NULL,
    [CreatedOn]   DATETIME      NULL,
    [ActiveFlag]  BIT           NULL,
    CONSTRAINT [PK_tblDataEntryMethods] PRIMARY KEY CLUSTERED ([idDataEntry] ASC)
);

