CREATE  PROCEDURE [dbo].[sp_ClosedRequests]
(
@fromdate DateTime,
@todate DateTime
)
AS
BEGIN


select
dr.SalesRepName,dr.District,dr.CustomerName,dr.Commodity,dr.ProjectedRevenue,dr.CreatedBy,dr.CreatedOn,
CONVERT(VARCHAR(10),ROUND(n.timeSpent/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(n.timeSpent)%60) + 'mins' TimeSpent,dr.CloseReason
from tblDiscoveryRequest dr
left join tblOnboardingPhase p on p.idOnboardingPhase=dr.idOnboardingPhase
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
where p.OnboardingPhase='Closed'
and dr.activeFlag=1
and dr.createdOn >= @fromdate and dr.createdOn <= @todate


END