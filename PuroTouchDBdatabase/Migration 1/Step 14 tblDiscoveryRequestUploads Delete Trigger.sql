USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Delete]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestUploads_Archive_Delete]

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
GO

ALTER TABLE [dbo].[tblDiscoveryRequestUploads] ENABLE TRIGGER [Trigger_tblDiscoveryRequestUploads_Archive_Delete]
GO

