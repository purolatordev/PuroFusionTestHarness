CREATE TABLE [dbo].[tblBillingSpecialist] (
    [idBillingSpecialist] INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee]          INT           NOT NULL,
    [UpdatedBy]           VARCHAR (100) NULL,
    [UpdatedOn]           DATETIME      NULL,
    [CreatedBy]           VARCHAR (100) NULL,
    [CreatedOn]           DATETIME      NULL,
    [ActiveFlag]          BIT           NULL,
    [email]               VARCHAR (255) NULL,
    [ReceiveNewReqEmail]  BIT           NULL,
    [login]               VARCHAR (50)  NULL,
    CONSTRAINT [PK_tblBillingSpecialist] PRIMARY KEY CLUSTERED ([idBillingSpecialist] ASC)
);

