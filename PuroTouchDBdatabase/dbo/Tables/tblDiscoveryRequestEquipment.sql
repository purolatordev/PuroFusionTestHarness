CREATE TABLE [dbo].[tblDiscoveryRequestEquipment] (
    [idDREquipment] INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]     INT           NOT NULL,
    [EquipmentDesc] VARCHAR (255) NULL,
    [number]        INT           NOT NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    CONSTRAINT [PK_tblDiscoveryRequestEquipment] PRIMARY KEY CLUSTERED ([idDREquipment] ASC)
);

