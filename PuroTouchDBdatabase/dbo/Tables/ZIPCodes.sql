CREATE TABLE [dbo].[ZIPCodes] (
    [ZipCode]        CHAR (5)        NOT NULL,
    [City]           VARCHAR (35)    NULL,
    [State]          CHAR (2)        NULL,
    [Latitude]       DECIMAL (12, 4) NULL,
    [Longitude]      DECIMAL (12, 4) NULL,
    [Classification] VARCHAR (1)     NULL,
    [Population]     INT             NULL
);


GO
CREATE NONCLUSTERED INDEX [Index_ZIPCodes_ZipCode]
    ON [dbo].[ZIPCodes]([ZipCode] ASC);


GO
CREATE NONCLUSTERED INDEX [Index_ZIPCodes_State]
    ON [dbo].[ZIPCodes]([State] ASC);


GO
CREATE NONCLUSTERED INDEX [Index_ZIPCodes_City]
    ON [dbo].[ZIPCodes]([City] ASC);

