CREATE TABLE [dbo].[tblCustomsTypes] (
    [idCustomsType] INT           IDENTITY (1, 1) NOT NULL,
    [CustomsType]   VARCHAR (100) NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblCustomsTypes] PRIMARY KEY CLUSTERED ([idCustomsType] ASC)
);

