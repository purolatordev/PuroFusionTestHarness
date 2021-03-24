CREATE TABLE [dbo].[tblDiscoveryRequestServices] (
    [idRequestSvc]  INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]     INT           NOT NULL,
    [idShippingSvc] INT           NOT NULL,
    [volume]        INT           NOT NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    CONSTRAINT [PK_tblDiscoveryRequestServices] PRIMARY KEY CLUSTERED ([idRequestSvc] ASC)
);


GO
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
CREATE TRIGGER [dbo].[Trigger_tblDiscoveryRequestServices_Archive_Update]
    ON [dbo].[tblDiscoveryRequestServices]
    AFTER UPDATE
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
		SELECT 'UPDATE'
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