CREATE  PROCEDURE [dbo].[sp_GetOnboardingPhaseCountITBA]
(
@ITBAUserLogin nvarchar(50)
)
AS
BEGIN


select op.OnboardingPhase,count(*) NumReq
from tblDiscoveryRequest dr
join tblOnboardingPhase op on dr.idOnboardingPhase = op.idOnboardingPhase
join tblITBA ba on dr.idITBA = ba.idITBA
join PurolatorReporting..tblEmployee e on ba.idEmployee = e.idEmployee
where dr.ActiveFlag != 0
and e.ActiveDirectoryName=@ITBAUserLogin
group by op.OnboardingPhase

END