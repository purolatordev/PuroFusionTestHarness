CREATE TABLE [dbo].[tblDiscoveryRequestUploads] (
    [idFileUpload] INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]    INT           NULL,
    [UploadDate]   DATETIME      NULL,
    [Description]  VARCHAR (MAX) NULL,
    [FilePath]     VARCHAR (MAX) NULL,
    [CreatedBy]    VARCHAR (50)  NULL,
    [CreatedOn]    DATETIME      NULL,
    [UpdatedBy]    VARCHAR (50)  NULL,
    [UpdatedOn]    DATETIME      NULL,
    [ActiveFlag]   BIT           NULL,
    CONSTRAINT [PK_tblUploads] PRIMARY KEY CLUSTERED ([idFileUpload] ASC)
);


GO
create TRIGGER [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Insert]
    ON [dbo].[tblDiscoveryRequestUploads]
    AFTER INSERT
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestUploads_Archive ([TableAction]
		,[idFileUpload]
      ,[idRequest]
      ,[UploadDate]
      ,[Description]
      ,[FilePath]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		) 
		SELECT 'INSERT'
		,[idFileUpload]
      ,[idRequest]
      ,[UploadDate]
      ,[Description]
      ,[FilePath]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		
		 From inserted;
    END
GO
create TRIGGER [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Update]
    ON [dbo].[tblDiscoveryRequestUploads]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestUploads_Archive ([TableAction]
		,[idFileUpload]
      ,[idRequest]
      ,[UploadDate]
      ,[Description]
      ,[FilePath]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		) 
		SELECT 'UPDATE'
		,[idFileUpload]
      ,[idRequest]
      ,[UploadDate]
      ,[Description]
      ,[FilePath]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		
		 From inserted;
    END
GO
create TRIGGER [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Delete]
    ON [dbo].[tblDiscoveryRequestUploads]
    FOR DELETE
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestUploads_Archive ([TableAction]
		,[idFileUpload]
      ,[idRequest]
      ,[UploadDate]
      ,[Description]
      ,[FilePath]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		) 
		SELECT 'DELETE'
		,[idFileUpload]
      ,[idRequest]
      ,[UploadDate]
      ,[Description]
      ,[FilePath]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[ActiveFlag]
		
		 From deleted;
    END