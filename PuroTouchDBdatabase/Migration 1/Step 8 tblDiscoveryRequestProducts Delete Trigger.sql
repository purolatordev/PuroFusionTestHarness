USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Delete]    Script Date: 8/3/2021 11:24:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--	DROP TRIGGER if exists [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Delete]

create TRIGGER [dbo].[Trigger_tblDiscoveryRequestProducts_Archive_Delete]
    ON [dbo].[tblDiscoveryRequestProducts]
    FOR DELETE
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
		SELECT 'DELETE'
		,[idDRProduct]
      ,[idRequest]
      ,[idShippingProduct]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
		
		 From deleted;
    END
GO



ALTER TABLE [dbo].[tblDiscoveryRequestProducts] ENABLE TRIGGER [Trigger_tblDiscoveryRequestProducts_Archive_Delete]
GO

