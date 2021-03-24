create  PROCEDURE [dbo].[sp_GetOnboardingPhaseCountDistrict]
(
@district nvarchar(255)
)
AS
BEGIN


select op.OnboardingPhase, count(*) NumReq
from tblDiscoveryRequest dr
join tblOnboardingPhase op on dr.idOnboardingPhase = op.idOnboardingPhase
where dr.ActiveFlag != 0
and dr.District = @district
group by op.OnboardingPhase

END