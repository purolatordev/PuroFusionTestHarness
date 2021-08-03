USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Update]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Update]

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

ALTER TABLE [dbo].[tblDiscoveryRequestUploads] ENABLE TRIGGER [Trigger_tblDiscoveryRequestUploads_Archive_Update]
GO

