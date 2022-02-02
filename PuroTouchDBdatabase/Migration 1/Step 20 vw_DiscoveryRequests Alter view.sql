--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv6]
GO

/****** Object:  View [dbo].[vw_DiscoveryRequests]    Script Date: 8/3/2021 1:30:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--drop table [vw_DiscoveryRequests]

alter VIEW [dbo].[vw_DiscoveryRequests]
AS
SELECT        dbo.tblDiscoveryRequest.idRequest, dbo.tblDiscoveryRequest.isNewRequest, dbo.tblRequestTypes.RequestType, dbo.tblDiscoveryRequest.SalesRepName, 
                         dbo.tblDiscoveryRequest.SalesRepEmail, dbo.tblDiscoveryRequest.idOnboardingPhase, dbo.tblDiscoveryRequest.District, 
                         dbo.tblDiscoveryRequest.CustomerName, dbo.tblDiscoveryRequest.Address, dbo.tblDiscoveryRequest.City, dbo.tblDiscoveryRequest.State, 
                         dbo.tblDiscoveryRequest.Zipcode, dbo.tblDiscoveryRequest.Country, dbo.tblDiscoveryRequest.Commodity, dbo.tblDiscoveryRequest.ProjectedRevenue, 
                         dbo.tblDiscoveryRequest.CurrentSolution, 
                         dbo.tblDiscoveryRequest.ProposedCustoms, dbo.tblDiscoveryRequest.CallDate1, dbo.tblDiscoveryRequest.CallDate2, dbo.tblDiscoveryRequest.CallDate3, 
                         dbo.tblDiscoveryRequest.UpdatedBy, dbo.tblDiscoveryRequest.UpdatedOn, dbo.tblDiscoveryRequest.CreatedBy, dbo.tblDiscoveryRequest.CreatedOn, 
                         dbo.tblDiscoveryRequest.ActiveFlag, dbo.tblDiscoveryRequestNotes.idNote, dbo.tblDiscoveryRequestNotes.idTaskType, dbo.tblDiscoveryRequestNotes.noteDate, 
                         dbo.tblDiscoveryRequestNotes.timeSpent, dbo.tblDiscoveryRequestNotes.publicNote, dbo.tblDiscoveryRequestNotes.privateNote, 
                         dbo.tblDiscoveryRequestServices.idRequestSvc, dbo.tblDiscoveryRequestServices.idShippingSvc, dbo.tblDiscoveryRequestServices.volume, 
                         dbo.tblTaskType.TaskType, dbo.tblShippingServices.serviceDesc, dbo.tblOnboardingPhase.OnboardingPhase, dbo.tblOnboardingPhase.SortValue
FROM            dbo.tblDiscoveryRequest INNER JOIN
                         dbo.tblDiscoveryRequestNotes ON dbo.tblDiscoveryRequest.idRequest = dbo.tblDiscoveryRequestNotes.idRequest INNER JOIN
                         dbo.tblDiscoveryRequestServices ON dbo.tblDiscoveryRequest.idRequest = dbo.tblDiscoveryRequestServices.idRequest INNER JOIN
                         dbo.tblTaskType ON dbo.tblDiscoveryRequestNotes.idTaskType = dbo.tblTaskType.idTaskType INNER JOIN
                         dbo.tblShippingServices ON dbo.tblDiscoveryRequestServices.idShippingSvc = dbo.tblShippingServices.idShippingSvc INNER JOIN
                         dbo.tblOnboardingPhase ON dbo.tblDiscoveryRequest.idOnboardingPhase = dbo.tblOnboardingPhase.idOnboardingPhase LEFT OUTER JOIN
                         dbo.tblRequestTypes ON dbo.tblDiscoveryRequest.idRequestType = dbo.tblRequestTypes.idRequestType
GO

--select * from [vw_DiscoveryRequests]
