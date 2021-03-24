CREATE  PROCEDURE [dbo].[sp_ChangingTargetDates]
(
@fromdate DateTime,
@todate DateTime
)
AS
BEGIN


SELECT r.idRequest,r.[CustomerName],
r.CurrentGoLive,r.TargetGoLive,r.ActualGoLive,
td.TargetDate,td.ChangeReason,
r.SalesRepName,
itba.ITBA,
p.OnboardingPhase,
r.ProjectedRevenue
from
tblDiscoveryRequest r
join tblDiscoveryRequestTargetDates td on td.idRequest=r.idRequest
join tblOnboardingPhase p on p.idOnboardingPhase=r.idOnboardingPhase
join vw_ITBA itba on itba.idITBA=r.idITBA
where r.ActiveFlag != 0
and r.CurrentGoLive >= @fromdate and r.CurrentGoLive <= @todate
ORDER BY CustomerName, td.idTargetDate
END