CREATE TABLE [dbo].[tblStatusCodesCourierEDI] (
    [idStatusCodesCourierEDI] INT           IDENTITY (1, 1) NOT NULL,
    [StatusCode]              VARCHAR (100) NULL,
    [UpdatedBy]               VARCHAR (100) NULL,
    [UpdatedOn]               DATETIME      NULL,
    [CreatedBy]               VARCHAR (100) NULL,
    [CreatedOn]               DATETIME      NULL,
    [ActiveFlag]              BIT           NULL,
    CONSTRAINT [PK_tblStatusCodesCourierEDI] PRIMARY KEY CLUSTERED ([idStatusCodesCourierEDI] ASC)
);

