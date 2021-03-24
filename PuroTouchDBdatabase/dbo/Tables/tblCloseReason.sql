CREATE TABLE [dbo].[tblCloseReason] (
    [idCloseReason] INT           IDENTITY (1, 1) NOT NULL,
    [CloseReason]   VARCHAR (255) NULL,
    [CreatedBy]     VARCHAR (50)  NULL,
    [CreatedOn]     DATETIME      NULL,
    [UpdatedBy]     VARCHAR (50)  NULL,
    [UpdatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblCloseReason] PRIMARY KEY CLUSTERED ([idCloseReason] ASC)
);

