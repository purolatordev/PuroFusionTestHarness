USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestNotes_Archive_Update]   Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestNotes_Archive_Update]


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



ALTER TABLE [dbo].[tblDiscoveryRequestNotes] ENABLE TRIGGER [Trigger_tblDiscoveryRequestNotes_Archive_Update]
GO

