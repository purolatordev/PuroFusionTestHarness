CREATE TABLE [dbo].[tblFreightAuditorsDiscReq] (
    [idFreightAuditorDiscReq] INT           IDENTITY (1, 1) NOT NULL,
    [idFreightAuditor]        INT           NOT NULL,
    [idRequest]               INT           NOT NULL,
    [UpdatedBy]               VARCHAR (100) NULL,
    [UpdatedOn]               DATETIME      NULL,
    [CreatedBy]               VARCHAR (100) NULL,
    [CreatedOn]               DATETIME      NULL,
    [ActiveFlag]              BIT           NULL,
    CONSTRAINT [PK_tblFreightAuditorsDiscReq] PRIMARY KEY CLUSTERED ([idFreightAuditorDiscReq] ASC),
    CONSTRAINT [FK_idFreightAuditor_tblFreightAuditor] FOREIGN KEY ([idFreightAuditor]) REFERENCES [dbo].[tblFreightAuditors] ([idFreightAuditor]),
    CONSTRAINT [FK_idRequest_tblFreightAuditorsDiscReq] FOREIGN KEY ([idRequest]) REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
);

