CREATE TABLE [dbo].[tblBrokers] (
    [idBroker]   INT           IDENTITY (1, 1) NOT NULL,
    [Broker]     VARCHAR (100) NULL,
    [UpdatedBy]  VARCHAR (100) NULL,
    [UpdatedOn]  DATETIME      NULL,
    [CreatedBy]  VARCHAR (100) NULL,
    [CreatedOn]  DATETIME      NULL,
    [ActiveFlag] BIT           NULL,
    CONSTRAINT [PK_tblBrokers] PRIMARY KEY CLUSTERED ([idBroker] ASC)
);

