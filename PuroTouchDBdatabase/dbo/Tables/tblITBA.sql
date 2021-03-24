CREATE TABLE [dbo].[tblITBA] (
    [idITBA]             INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee]         INT           NOT NULL,
    [UpdatedBy]          VARCHAR (100) NULL,
    [UpdatedOn]          DATETIME      NULL,
    [CreatedBy]          VARCHAR (100) NULL,
    [CreatedOn]          DATETIME      NULL,
    [ActiveFlag]         BIT           NULL,
    [ITBAemail]          VARCHAR (255) NULL,
    [ReceiveNewReqEmail] BIT           NULL,
    [login]              VARCHAR (50)  NULL,
    CONSTRAINT [PK_tblITBA] PRIMARY KEY CLUSTERED ([idITBA] ASC)
);

