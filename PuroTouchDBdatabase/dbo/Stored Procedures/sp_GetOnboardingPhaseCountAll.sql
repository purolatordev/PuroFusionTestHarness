CREATE  PROCEDURE [dbo].[sp_GetOnboardingPhaseCountAll]

AS
BEGIN


select op.OnboardingPhase,count(*) NumReq
from tblDiscoveryRequest dr
join tblOnboardingPhase op on dr.idOnboardingPhase = op.idOnboardingPhase
where dr.ActiveFlag != 0
group by op.OnboardingPhase

END