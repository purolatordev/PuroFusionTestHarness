CREATE TABLE [dbo].[tblInductionPoints] (
    [idInduction]  INT           IDENTITY (1, 1) NOT NULL,
    [Description]  VARCHAR (100) NULL,
    [Address]      VARCHAR (100) NULL,
    [City]         VARCHAR (100) NULL,
    [State]        VARCHAR (100) NULL,
    [Zip]          VARCHAR (100) NULL,
    [Country]      VARCHAR (100) NULL,
    [UpdatedBy]    VARCHAR (100) NULL,
    [UpdatedOn]    DATETIME      NULL,
    [CreatedBy]    VARCHAR (100) NULL,
    [CreatedOn]    DATETIME      NULL,
    [ActiveFlag]   BIT           NULL,
    [PuroPostFlag] BIT           NULL,
    CONSTRAINT [PK_tblInductionPoints] PRIMARY KEY CLUSTERED ([idInduction] ASC)
);

