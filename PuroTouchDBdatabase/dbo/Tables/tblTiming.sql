CREATE TABLE [dbo].[tblTiming] (
    [idTiming]   INT           IDENTITY (1, 1) NOT NULL,
    [Timing]     VARCHAR (100) NULL,
    [UpdatedBy]  VARCHAR (100) NULL,
    [UpdatedOn]  DATETIME      NULL,
    [CreatedBy]  VARCHAR (100) NULL,
    [CreatedOn]  DATETIME      NULL,
    [ActiveFlag] BIT           NULL,
    CONSTRAINT [PK_tbTiming] PRIMARY KEY CLUSTERED ([idTiming] ASC)
);

