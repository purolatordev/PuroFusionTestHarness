USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Insert]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Insert]

CREATE TRIGGER [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Insert]
    ON [dbo].[tblDiscoveryRequestServices]
    AFTER INSERT
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
		SELECT 'INSERT'
		,idRequestSvc
		 ,[idRequest]
      ,[idShippingSvc]
      ,[volume]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
		
		 From inserted;
    END
GO

ALTER TABLE [dbo].[tblDiscoveryRequestServices] ENABLE TRIGGER [Trigger_tblDiscoveryRequestServices_Archive_Insert]
GO

