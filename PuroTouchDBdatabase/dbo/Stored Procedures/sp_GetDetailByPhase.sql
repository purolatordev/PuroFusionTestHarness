CREATE  PROCEDURE [dbo].[sp_GetDetailByPhase]
(
@OnboardingPhase VarChar(50)
)

AS
BEGIN


--Get all Kickoff,Discovery,Solution Determination and Implementation
--select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
--into #temp1
--from tblDiscoveryRequest r
--join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
--where o.OnboardingPhase not in ('GO-LIVE','STABILIZATION','ON HOLD','CLOSED')
--and r.ActiveFlag != 0
--group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue


----GO-LIVE and Stabilization
--select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
----into #temp2
--from tblDiscoveryRequest r
--join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
--where Year(r.ActualGoLive) = Year(GetDate())-1
--and o.OnboardingPhase  in ('GO-LIVE','STABILIZATION')
--and r.ActiveFlag != 0
--group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue

----On Hold and Closed
--select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
----into #temp3
--from tblDiscoveryRequest r
--join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
--where Year(r.CreatedOn) = Year(GetDate())-1
--and o.OnboardingPhase  in ('ON HOLD','CLOSED')
--and r.ActiveFlag != 0
--group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue

if @OnboardingPhase = 'KICKOFF' or @OnboardingPhase = 'DISCOVERY' or @OnboardingPhase = 'SYSTEM SOLUTION DETERMINATION'  or @OnboardingPhase = 'IMPLEMENTATION'
begin
  select r.CreatedOn,r.CustomerName,o.OnboardingPhase,r.ProjectedRevenue,e.FirstName + ' ' + e.LastName OnboardingSpecialist
  from tblDiscoveryRequest r
  join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
  left join tblITBA i on r.idITBA = i.idITBA
  left join PurolatorReporting..tblEmployee e on e.idEmployee=i.idEmployee
  where o.OnboardingPhase = @OnboardingPhase
  and r.ActiveFlag != 0
end

if @OnboardingPhase = 'GO-LIVE' 
begin
  select r.CreatedOn,r.CustomerName,o.OnboardingPhase,r.ProjectedRevenue,e.FirstName + ' ' + e.LastName OnboardingSpecialist
  from tblDiscoveryRequest r
  join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
  left join tblITBA i on r.idITBA = i.idITBA
  left join PurolatorReporting..tblEmployee e on e.idEmployee=i.idEmployee
  where o.OnboardingPhase = @OnboardingPhase
   --AND Year(r.ActualGoLive) = Year(GetDate())-1
  and r.ActiveFlag != 0
end

if @OnboardingPhase = 'STABILIZATION'
begin
  select r.CreatedOn,r.CustomerName,o.OnboardingPhase,r.ProjectedRevenue,e.FirstName + ' ' + e.LastName OnboardingSpecialist
  from tblDiscoveryRequest r
  join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
  left join tblITBA i on r.idITBA = i.idITBA
  left join PurolatorReporting..tblEmployee e on e.idEmployee=i.idEmployee
  where o.OnboardingPhase = @OnboardingPhase
   AND Year(r.ActualGoLive) = Year(GetDate())-1
  and r.ActiveFlag != 0
end

if @OnboardingPhase = 'CLOSED' or @OnboardingPhase = 'ON HOLD' 
begin
  select r.CreatedOn,r.CustomerName,o.OnboardingPhase,r.ProjectedRevenue,e.FirstName + ' ' + e.LastName OnboardingSpecialist
  from tblDiscoveryRequest r
  join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
  left join tblITBA i on r.idITBA = i.idITBA
  left join PurolatorReporting..tblEmployee e on e.idEmployee=i.idEmployee
  where o.OnboardingPhase = @OnboardingPhase
  AND Year(r.CreatedOn) = Year(GetDate())-1
  and r.ActiveFlag != 0
end



END