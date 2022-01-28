--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv4]
GO

/****** Object:  View [dbo].[vw_DiscoveryRequestSummary]    Script Date: 8/3/2021 1:33:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[vw_DiscoveryRequestSummary]
AS
SELECT        dbo.tblDiscoveryRequest.idRequest, dbo.tblDiscoveryRequest.isNewRequest,tblSolutionType.SolutionType,vw_EDISpecialist.Name as EDISpecialistName,vw_EDISpecialist.ActiveDirectoryName EDISpecActiveDir, dbo.tblRequestTypes.RequestType, dbo.tblVendorType.VendorType, dbo.tblDiscoveryRequest.SalesRepName, 
                         dbo.tblDiscoveryRequest.SalesRepEmail, dbo.tblDiscoveryRequest.idOnboardingPhase, dbo.tblDiscoveryRequest.District, dbo.tblDiscoveryRequest.CustomerName, dbo.tblDiscoveryRequest.Address, 
                         dbo.tblDiscoveryRequest.City, dbo.tblDiscoveryRequest.State, dbo.tblDiscoveryRequest.Zipcode, dbo.tblDiscoveryRequest.Country, dbo.tblDiscoveryRequest.Commodity, dbo.tblDiscoveryRequest.ProjectedRevenue, 
                         dbo.tblDiscoveryRequest.CurrentSolution, 
                         dbo.tblDiscoveryRequest.ProposedCustoms, dbo.tblDiscoveryRequest.CallDate1, dbo.tblDiscoveryRequest.CallDate2, dbo.tblDiscoveryRequest.CallDate3, dbo.tblDiscoveryRequest.UpdatedBy, 
                         dbo.tblDiscoveryRequest.UpdatedOn, dbo.tblDiscoveryRequest.CreatedBy, dbo.tblDiscoveryRequest.CreatedOn, dbo.tblDiscoveryRequest.ActiveFlag, dbo.tblDiscoveryRequest.CurrentGoLive, 
                         dbo.tblDiscoveryRequest.TargetGoLive, dbo.tblDiscoveryRequest.ActualGoLive, dbo.tblDiscoveryRequest.worldpakFlag, SUM(dbo.tblDiscoveryRequestNotes.timeSpent) AS TotalMinutes, CONVERT(varchar, 
                         FLOOR(SUM(dbo.tblDiscoveryRequestNotes.timeSpent) / 60.0)) + ':' + RIGHT('0' + CONVERT(varchar, SUM(dbo.tblDiscoveryRequestNotes.timeSpent) % 60), 2) AS TotalTimeSpent, dbo.tblOnboardingPhase.OnboardingPhase, 
                         dbo.tblDiscoveryRequest.idITBA, dbo.vw_ITBA.ITBA, dbo.vw_ITBA.ActiveDirectoryName, dbo.tblShippingChannel.ShippingChannel, dbo.tblThirdPartyVendor.VendorName, 
						 dbo.tblEDIOnboardingPhase.EDIOnboardingPhaseType,dbo.tblDiscoveryRequest.EDIActualGoLive,dbo.tblDiscoveryRequest.EDITargetGoLive,dbo.tblDiscoveryRequest.EDICurrentGoLive
FROM            dbo.tblDiscoveryRequest 
						 LEFT OUTER JOIN dbo.tblDiscoveryRequestNotes ON dbo.tblDiscoveryRequest.idRequest = dbo.tblDiscoveryRequestNotes.idRequest 
						 LEFT OUTER JOIN dbo.tblOnboardingPhase ON dbo.tblDiscoveryRequest.idOnboardingPhase = dbo.tblOnboardingPhase.idOnboardingPhase 
						 LEFT OUTER JOIN dbo.vw_ITBA ON dbo.tblDiscoveryRequest.idITBA = dbo.vw_ITBA.idITBA 
						 LEFT OUTER JOIN dbo.tblShippingChannel ON dbo.tblDiscoveryRequest.idShippingChannel = dbo.tblShippingChannel.idShippingChannel 
						 LEFT OUTER JOIN dbo.tblRequestTypes ON dbo.tblDiscoveryRequest.idRequestType = dbo.tblRequestTypes.idRequestType 
						 LEFT OUTER JOIN dbo.tblVendorType ON dbo.tblDiscoveryRequest.idVendorType = dbo.tblVendorType.idVendorType
						 LEFT OUTER JOIN dbo.tblThirdPartyVendor ON dbo.tblDiscoveryRequest.idVendor = dbo.tblThirdPartyVendor.idThirdPartyVendor
						 LEFT OUTER JOIN tblSolutionType on tblDiscoveryRequest.idSolutionType = tblSolutionType.idSolutionType
						 LEFT OUTER JOIN vw_EDISpecialist on tblDiscoveryRequest.idEDISpecialist = vw_EDISpecialist.idEDISpecialist
						 LEFT OUTER JOIN dbo.tblEDIOnboardingPhase ON dbo.tblDiscoveryRequest.idEDIOnboardingPhase = dbo.tblEDIOnboardingPhase.idEDIOnboardingPhase 
GROUP BY dbo.tblDiscoveryRequest.idRequest, dbo.tblDiscoveryRequest.isNewRequest, tblSolutionType.SolutionType,vw_EDISpecialist.Name,vw_EDISpecialist.ActiveDirectoryName,tblDiscoveryRequest.idEDISpecialist, dbo.tblRequestTypes.RequestType, dbo.tblVendorType.VendorType, dbo.tblDiscoveryRequest.SalesRepName, 
                         dbo.tblDiscoveryRequest.SalesRepEmail, dbo.tblDiscoveryRequest.idOnboardingPhase, dbo.tblDiscoveryRequest.District, dbo.tblDiscoveryRequest.CustomerName, dbo.tblDiscoveryRequest.Address, 
                         dbo.tblDiscoveryRequest.City, dbo.tblDiscoveryRequest.State, dbo.tblDiscoveryRequest.Zipcode, dbo.tblDiscoveryRequest.Country, dbo.tblDiscoveryRequest.Commodity, dbo.tblDiscoveryRequest.ProjectedRevenue, 
                         dbo.tblDiscoveryRequest.CurrentSolution, 
                         dbo.tblDiscoveryRequest.ProposedCustoms, dbo.tblDiscoveryRequest.CallDate1, dbo.tblDiscoveryRequest.CallDate2, dbo.tblDiscoveryRequest.CallDate3, dbo.tblDiscoveryRequest.UpdatedBy, 
                         dbo.tblDiscoveryRequest.UpdatedOn, dbo.tblDiscoveryRequest.CreatedBy, dbo.tblDiscoveryRequest.CreatedOn, dbo.tblDiscoveryRequest.ActiveFlag, dbo.tblDiscoveryRequest.CurrentGoLive, 
                         dbo.tblDiscoveryRequest.TargetGoLive, dbo.tblDiscoveryRequest.ActualGoLive, dbo.tblDiscoveryRequest.worldpakFlag, dbo.tblOnboardingPhase.OnboardingPhase, dbo.tblDiscoveryRequest.idITBA, dbo.vw_ITBA.ITBA, 
                         dbo.vw_ITBA.ActiveDirectoryName, dbo.tblShippingChannel.ShippingChannel, dbo.tblThirdPartyVendor.VendorName, 
						 dbo.tblEDIOnboardingPhase.EDIOnboardingPhaseType,dbo.tblDiscoveryRequest.EDIActualGoLive,dbo.tblDiscoveryRequest.EDITargetGoLive,dbo.tblDiscoveryRequest.EDICurrentGoLive
GO


