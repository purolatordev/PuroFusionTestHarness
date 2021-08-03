USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Update]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Update]

create TRIGGER [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Update]
    ON [dbo].[tblDiscoveryRequestProducts]
    AFTER UPDATE
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
		SELECT 'UPDATE'
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

ALTER TABLE [dbo].[tblDiscoveryRequestProducts] ENABLE TRIGGER [Trigger_tblDiscoveryRequestProducts_Archive_Update]
GO

