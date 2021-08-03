USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Delete]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Delete]

CREATE TRIGGER [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Delete]
    ON [dbo].[tblDiscoveryRequestServices]
    FOR DELETE
    AS
    BEGIN
        SET NoCount ON

		INSERT INTO tblDiscoveryRequestServices_Archive ([TableAction]
		,idRequestSvc
		 ,[idRequest]
      ,[idShippingSvc]
      ,[volume]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
		) 
		SELECT 'DELETE'
		,idRequestSvc
		 ,[idRequest]
      ,[idShippingSvc]
      ,[volume]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
		
		 From deleted;
    END
GO

ALTER TABLE [dbo].[tblDiscoveryRequestServices] ENABLE TRIGGER [Trigger_tblDiscoveryRequestServices_Archive_Delete]
GO

