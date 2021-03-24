CREATE TABLE [dbo].[tblDiscoveryRequestProducts] (
    [idDRProduct]       INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]         INT           NOT NULL,
    [idShippingProduct] INT           NOT NULL,
    [UpdatedBy]         VARCHAR (100) NULL,
    [UpdatedOn]         DATETIME      NULL,
    [CreatedBy]         VARCHAR (100) NULL,
    [CreatedOn]         DATETIME      NULL,
    CONSTRAINT [PK_tblDiscoveryRequestProducts] PRIMARY KEY CLUSTERED ([idDRProduct] ASC)
);


GO
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