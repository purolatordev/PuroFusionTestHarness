USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestNotes_Archive_Delete]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--IF OBJECT_ID(N'dbo.Trigger_tblDiscoveryRequestNotes_Archive_Delete', N'U') IS NOT NULL
--begin
--	print 'Exists -- Trigger_tblDiscoveryRequestNotes_Archive_Delete table'
--	DROP TRIGGER if exists [dbo].Trigger_tblDiscoveryRequestNotes_Archive_Delete
--end

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
GO

ALTER TABLE [dbo].[tblDiscoveryRequestNotes] ENABLE TRIGGER [Trigger_tblDiscoveryRequestNotes_Archive_Delete]
GO

