CREATE TABLE [dbo].[tblDiscoveryRequestNotes_Archive] (
    [idNote_Archive] INT           IDENTITY (1, 1) NOT NULL,
    [idNote]         INT           NOT NULL,
    [TableAction]    VARCHAR (50)  NOT NULL,
    [idTaskType]     INT           NULL,
    [idRequest]      INT           NULL,
    [noteDate]       DATETIME      NULL,
    [timeSpent]      INT           NULL,
    [publicNote]     VARCHAR (MAX) NULL,
    [privateNote]    VARCHAR (MAX) NULL,
    [CreatedBy]      VARCHAR (50)  NULL,
    [CreatedOn]      DATETIME      NULL,
    [UpdatedBy]      VARCHAR (50)  NULL,
    [UpdatedOn]      DATETIME      NULL,
    [ActiveFlag]     BIT           NULL,
    CONSTRAINT [PK_tblNotes_Archive] PRIMARY KEY CLUSTERED ([idNote_Archive] ASC)
);

