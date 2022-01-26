--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO

CREATE TABLE [dbo].[tblEDIShipMethods] (
    [idEDIShipMethod]     INT            IDENTITY (1, 1) NOT NULL,
    [idRequest]           INT            NOT NULL,
    [idEDIShipMethodType] INT            NOT NULL,
    [CreatedBy]           NVARCHAR (100) NULL,
    [CreatedOn]           DATETIME       NULL,
    [UpdatedBy]           NVARCHAR (100) NULL,
    [UpdatedOn]           DATETIME       NULL,
    [ActiveFlag]          BIT            NULL,
    CONSTRAINT [PK_tblEDIShipMethods] PRIMARY KEY CLUSTERED ([idEDIShipMethod] ASC),
    CONSTRAINT [FK_idEDIShipMethType_EDIShipMethTypes] FOREIGN KEY ([idEDIShipMethodType]) REFERENCES [dbo].[tblEDIShipMethodTypes] ([idEDIShipMethodTypes]),
    CONSTRAINT [FK_idRequest_DiscoveryRequest] FOREIGN KEY ([idRequest]) REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
);
GO

