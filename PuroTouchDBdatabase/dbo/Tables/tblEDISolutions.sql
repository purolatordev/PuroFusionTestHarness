CREATE TABLE [dbo].[tblEDISolutions] (
    [idSolution] INT           IDENTITY (1, 1) NOT NULL,
    [Solution]   VARCHAR (100) NULL,
    [UpdatedBy]  VARCHAR (100) NULL,
    [UpdatedOn]  DATETIME      NULL,
    [CreatedBy]  VARCHAR (100) NULL,
    [CreatedOn]  DATETIME      NULL,
    [ActiveFlag] BIT           NULL,
    CONSTRAINT [PK_tblEDISolutions] PRIMARY KEY CLUSTERED ([idSolution] ASC)
);

