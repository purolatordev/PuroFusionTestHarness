CREATE TABLE [dbo].[tblEquipment] (
    [idEquipment] INT           IDENTITY (1, 1) NOT NULL,
    [Equipment]   VARCHAR (100) NULL,
    [UpdatedBy]   VARCHAR (100) NULL,
    [UpdatedOn]   DATETIME      NULL,
    [CreatedBy]   VARCHAR (100) NULL,
    [CreatedOn]   DATETIME      NULL,
    [ActiveFlag]  BIT           NULL,
    CONSTRAINT [PK_tblEquipment] PRIMARY KEY CLUSTERED ([idEquipment] ASC)
);

