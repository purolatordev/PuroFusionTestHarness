CREATE TABLE [dbo].[tblDiscoveryRequestNotes] (
    [idNote]      INT           IDENTITY (1, 1) NOT NULL,
    [idTaskType]  INT           NULL,
    [idRequest]   INT           NULL,
    [noteDate]    DATETIME      NULL,
    [timeSpent]   INT           NULL,
    [publicNote]  VARCHAR (MAX) NULL,
    [privateNote] VARCHAR (MAX) NULL,
    [CreatedBy]   VARCHAR (50)  NULL,
    [CreatedOn]   DATETIME      NULL,
    [UpdatedBy]   VARCHAR (50)  NULL,
    [UpdatedOn]   DATETIME      NULL,
    [ActiveFlag]  BIT           NULL,
    CONSTRAINT [PK_tblNotes] PRIMARY KEY CLUSTERED ([idNote] ASC)
);


GO
create TRIGGER [dbo].[Trigger_tblDiscoveryRequestNotes_Archive_Insert]
    ON [dbo].[tblDiscoveryRequestNotes]
    AFTER INSERT
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestNotes_Archive ([TableAction]
		,[idNote]
      ,[idTaskType]
      ,[idRequest]
      ,[noteDate]
      ,[timeSpent]
      ,[publicNote]
      ,[privateNote]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		) 
		SELECT 'INSERT'
		,[idNote]
      ,[idTaskType]
      ,[idRequest]
      ,[noteDate]
      ,[timeSpent]
      ,[publicNote]
      ,[privateNote]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		
		 From inserted;
    END
GO
create TRIGGER [dbo].[Trigger_tblDiscoveryRequestNotes_Archive_Update]
    ON [dbo].[tblDiscoveryRequestNotes]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestNotes_Archive ([TableAction]
		,[idNote]
      ,[idTaskType]
      ,[idRequest]
      ,[noteDate]
      ,[timeSpent]
      ,[publicNote]
      ,[privateNote]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		) 
		SELECT 'UPDATE'
		,[idNote]
      ,[idTaskType]
      ,[idRequest]
      ,[noteDate]
      ,[timeSpent]
      ,[publicNote]
      ,[privateNote]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		
		 From inserted;
    END
GO
create TRIGGER [dbo].[Trigger_tblDiscoveryRequestNotes_Archive_Delete]
    ON [dbo].[tblDiscoveryRequestNotes]
    FOR DELETE
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestNotes_Archive ([TableAction]
		,[idNote]
      ,[idTaskType]
      ,[idRequest]
      ,[noteDate]
      ,[timeSpent]
      ,[publicNote]
      ,[privateNote]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		) 
		SELECT 'DELETE'
		,[idNote]
      ,[idTaskType]
      ,[idRequest]
      ,[noteDate]
      ,[timeSpent]
      ,[publicNote]
      ,[privateNote]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		
		 From deleted;
    END