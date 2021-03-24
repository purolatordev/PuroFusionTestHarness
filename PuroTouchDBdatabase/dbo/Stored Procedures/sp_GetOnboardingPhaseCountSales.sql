CREATE  PROCEDURE [dbo].[sp_GetOnboardingPhaseCountSales]
(
@salesUserLogin nvarchar(50)
)
AS
BEGIN


select op.OnboardingPhase, count(*) NumReq
from tblDiscoveryRequest dr
join tblOnboardingPhase op on dr.idOnboardingPhase = op.idOnboardingPhase
where dr.ActiveFlag != 0
and dr.CreatedBy = @salesUserLogin
group by op.OnboardingPhase

END