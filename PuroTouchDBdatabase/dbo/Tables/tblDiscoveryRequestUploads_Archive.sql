CREATE TABLE [dbo].[tblDiscoveryRequestUploads_Archive] (
    [idFileUpload_Archive] INT           IDENTITY (1, 1) NOT NULL,
    [idFileUpload]         INT           NOT NULL,
    [TableAction]          VARCHAR (50)  NOT NULL,
    [idRequest]            INT           NULL,
    [UploadDate]           DATETIME      NULL,
    [Description]          VARCHAR (MAX) NULL,
    [FilePath]             VARCHAR (MAX) NULL,
    [CreatedBy]            VARCHAR (50)  NULL,
    [CreatedOn]            DATETIME      NULL,
    [UpdatedBy]            VARCHAR (50)  NULL,
    [UpdatedOn]            DATETIME      NULL,
    [ActiveFlag]           BIT           NULL,
    CONSTRAINT [PK_tblUploads_Archive] PRIMARY KEY CLUSTERED ([idFileUpload_Archive] ASC)
);

