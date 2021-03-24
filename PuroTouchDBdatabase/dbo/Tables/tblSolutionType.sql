CREATE TABLE [dbo].[tblSolutionType] (
    [idSolutionType] INT          IDENTITY (1, 1) NOT NULL,
    [SolutionType]   VARCHAR (50) NULL,
    [UpdatedBy]      VARCHAR (50) NULL,
    [UpdatedOn]      DATETIME     NULL,
    [CreatedBy]      VARCHAR (50) NULL,
    [CreatedOn]      DATETIME     NULL,
    [ActiveFlag]     BIT          NULL
);

