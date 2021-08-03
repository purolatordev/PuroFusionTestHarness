USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Insert]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Insert]

create TRIGGER [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Insert]
    ON [dbo].[tblDiscoveryRequestProducts]
    AFTER INSERT
    AS
    BEGIN
        SET NoCount ON


		INSERT INTO tblDiscoveryRequestProducts_Archive ([TableAction]
		,[idDRProduct]
      ,[idRequest]
      ,[idShippingProduct]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
		) 
		SELECT 'INSERT'
		,[idDRProduct]
      ,[idRequest]
      ,[idShippingProduct]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
		
		 From inserted;
    END
GO

ALTER TABLE [dbo].[tblDiscoveryRequestProducts] ENABLE TRIGGER [Trigger_tblDiscoveryRequestProducts_Archive_Insert]
GO

