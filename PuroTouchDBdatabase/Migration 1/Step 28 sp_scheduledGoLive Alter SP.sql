--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv4]
GO

/****** Object:  StoredProcedure [dbo].[sp_scheduledGoLive]    Script Date: 8/3/2021 1:50:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[sp_scheduledGoLive]

AS
BEGIN


select 
r.idRequest,r.TargetGoLive,r.CurrentGoLive,r.ActualGoLive, p.OnboardingPhase,c.ShippingChannel,r.CustomerName,r.ProjectedRevenue,r.SalesRepName,b.ITBA,
CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
from tblDiscoveryRequest r
left outer join tblOnboardingPhase p on p.idOnboardingPhase=r.idOnboardingPhase
left outer join tblShippingChannel c on c.idShippingChannel=r.idShippingChannel
left outer join vw_ITBA b on b.idITBA=r.idITBA
left outer join tblDiscoveryRequestNotes n on n.idRequest=r.idRequest
where r.CurrentGoLive > getdate()
and r.ActiveFlag != 0
group by r.idRequest,r.TargetGoLive,r.CurrentGoLive,r.ActualGoLive, p.OnboardingPhase,c.ShippingChannel,r.CustomerName,r.ProjectedRevenue,r.SalesRepName,b.ITBA,p.SortValue
order by r.CurrentGoLive,p.SortValue

END
GO


