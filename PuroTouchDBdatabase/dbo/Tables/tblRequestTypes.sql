CREATE TABLE [dbo].[tblRequestTypes] (
    [idRequestType] INT          IDENTITY (1, 1) NOT NULL,
    [RequestType]   VARCHAR (50) NULL,
    [CreatedBy]     VARCHAR (50) NULL,
    [CreatedOn]     DATETIME     NULL,
    [UpdatedBy]     VARCHAR (50) NULL,
    [UpdatedOn]     DATETIME     NULL,
    [ActiveFlag]    BIT          NULL,
    CONSTRAINT [PK_tblRequestTypes] PRIMARY KEY CLUSTERED ([idRequestType] ASC)
);

