USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Trigger [dbo].[Trigger_tblDiscoveryRequest_Archive_Insert]    Script Date: 8/2/2021 3:39:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create TRIGGER [dbo].[Trigger_tblDiscoveryRequest_Archive_Insert]
    ON [dbo].[tblDiscoveryRequest]
    AFTER INSERT
    AS
    BEGIN
        SET NoCount ON

		INSERT INTO tblDiscoveryRequest_Archive ([TableAction],
		[idRequest]
      ,[isNewRequest]
      ,[SalesRepName]
      ,[SalesRepEmail]
      ,[idOnboardingPhase]
      ,[District]
      ,[CustomerName]
      ,[Address]
      ,[City]
      ,[State]
      ,[Zipcode]
      ,[Country]
      ,[Commodity]
      ,[ProjectedRevenue]
      ,[CurrentSolution]
      ,[ProposedCustoms]
      ,[CallDate1]
      ,[CallDate2]
      ,[CallDate3]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ActiveFlag]
      ,[SalesComments]
      ,[idITBA]
      ,[idShippingChannel]
      ,[TargetGoLive]
      ,[ActualGoLive]
      ,[SolutionSummary]
      ,[CustomerWebsite]
      ,[Branch]
      ,[idVendor]
      ,[worldpakFlag]
      ,[thirdpartyFlag]
      ,[customFlag]
      ,[CloseReason]
      ,[DataScrubFlag]
      ,[StrategicFlag]
	  ,[ReturnsAcctNbr]
	  ,[ReturnsAddress] 
	  ,[ReturnsCity] 
	  ,[ReturnsState]
	  ,[ReturnsZip]
	  ,[ReturnsCountry]
	  ,[ReturnsDestroyFlag] 
	  ,[ReturnsCreateLabelFlag] 
	  ,[WPKSandboxUsername] 
	  ,[WPKSandboxPwd] 
	  ,[WPKProdUsername] 
	  ,[WPKProdPwd] 
	  ,[WPKCustomExportFlag] 
	  ,[WPKGhostScanFlag] 
	  ,[WPKEastWestSplitFlag] 
	  ,[WPKAddressUploadFlag] 
	  ,[WPKProductUploadFlag] 
	  ,[WPKDataEntryMethod] 
	  ,[WPKEquipmentFlag] 
	  ,[EWSelectBy] 
	  ,[EWSortCodeFlag]
	  ,[EWEastSortCode]
	  ,[EWWestSortCode]
	  ,[EWSepCloseoutFlag] 
	  ,[EWSepPUFlag] 
	  ,[EWSortDetails] 
	  ,[EWMissortDetails] 
	  ,[CurrentGoLive] 
	  ,[PhaseChangeDate] 
	  ,[idRequestType] 
	  ,[CurrentlyShippingFlag] 
	  ,[idShippingVendor] 
	  ,[OtherVendorName] 
	  ,[idBroker] 
	  ,[OtherBrokerName]
	  ,[idVendorType] 
	  ,[Route]
	  ,[idSolutionType]
	  ,[FreightAuditor]
	  ,[EDIDetails] 
	  ,[idEDISpecialist]
	  ,[idBillingSpecialist]
	  ,[idCollectionSpecialist]
	  ,[AuditorPortal] 
	  ,[AuditorURL] 
	  ,[AuditorUserName]
	  ,[AuditorPassword]
	  ,[EDITargetGoLive]
	  ,[EDICurrentGoLive]
	  ,[EDIActualGoLive]
	  ,[idEDIOnboardingPhase]
		) 
		SELECT 'INSERT', 
		[idRequest]
      ,[isNewRequest]
      ,[SalesRepName]
      ,[SalesRepEmail]
      ,[idOnboardingPhase]
      ,[District]
      ,[CustomerName]
      ,[Address]
      ,[City]
      ,[State]
      ,[Zipcode]
      ,[Country]
      ,[Commodity]
      ,[ProjectedRevenue]
	  ,[CurrentSolution]
      ,[ProposedCustoms]
      ,[CallDate1]
      ,[CallDate2]
      ,[CallDate3]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ActiveFlag]
      ,[SalesComments]
      ,[idITBA]
      ,[idShippingChannel]
      ,[TargetGoLive]
      ,[ActualGoLive]
      ,[SolutionSummary]
      ,[CustomerWebsite]
      ,[Branch]
      ,[idVendor]
      ,[worldpakFlag]
      ,[thirdpartyFlag]
      ,[customFlag]
      ,[CloseReason]
      ,[DataScrubFlag]
      ,[StrategicFlag]
	  ,[ReturnsAcctNbr]
	  ,[ReturnsAddress] 
	  ,[ReturnsCity] 
	  ,[ReturnsState]
	  ,[ReturnsZip]
	  ,[ReturnsCountry]
	  ,[ReturnsDestroyFlag] 
	  ,[ReturnsCreateLabelFlag] 
	  ,[WPKSandboxUsername] 
	  ,[WPKSandboxPwd] 
	  ,[WPKProdUsername] 
	  ,[WPKProdPwd] 
	  ,[WPKCustomExportFlag] 
	  ,[WPKGhostScanFlag] 
	  ,[WPKEastWestSplitFlag] 
	  ,[WPKAddressUploadFlag] 
	  ,[WPKProductUploadFlag] 
	  ,[WPKDataEntryMethod] 
	  ,[WPKEquipmentFlag] 
	  ,[EWSelectBy] 
	  ,[EWSortCodeFlag]
	  ,[EWEastSortCode]
	  ,[EWWestSortCode]
	  ,[EWSepCloseoutFlag] 
	  ,[EWSepPUFlag] 
	  ,[EWSortDetails] 
	  ,[EWMissortDetails] 
	  ,[CurrentGoLive] 
	  ,[PhaseChangeDate] 
	  ,[idRequestType] 
	  ,[CurrentlyShippingFlag] 
	  ,[idShippingVendor] 
	  ,[OtherVendorName] 
	  ,[idBroker] 
	  ,[OtherBrokerName]
	  ,[idVendorType] 
	  ,[Route]
	  ,[idSolutionType]
	  ,[FreightAuditor]
	  ,[EDIDetails] 
	  ,[idEDISpecialist]
	  ,[idBillingSpecialist]
	  ,[idCollectionSpecialist]
	  ,[AuditorPortal] 
	  ,[AuditorURL] 
	  ,[AuditorUserName]
	  ,[AuditorPassword]
	  ,[EDITargetGoLive]
	  ,[EDICurrentGoLive]
	  ,[EDIActualGoLive]
	  ,[idEDIOnboardingPhase]
		 From inserted;
    END
GO

ALTER TABLE [dbo].[tblDiscoveryRequest] ENABLE TRIGGER [Trigger_tblDiscoveryRequest_Archive_Insert]
GO


--select [idRequest],[CustomerBusContact],[CustomerBusTitle],[CustomerBusEmail],[CustomerBusPhone],
--CustomerITContact,[CustomerITTitle],[CustomerITEmail],[CustomerITPhone] 
--from tblDiscoveryRequest 
--where  CustomerBusContact is not null or CustomerITContact is not null

