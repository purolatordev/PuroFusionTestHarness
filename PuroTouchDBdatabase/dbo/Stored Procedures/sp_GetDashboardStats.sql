CREATE  PROCEDURE [dbo].[sp_GetDashboardStats]

AS
BEGIN


----Summary CY
--select r.idOnboardingPhase,count(*) NumberRequestsCY,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenueCY,0 NumberRequestsPY, 0 ProjectedRevenuePY,o.OnboardingPhase 
--into #tempCY
--from tblDiscoveryRequest r
--join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
--where Year(r.CreatedOn) = Year(GetDate())
--and r.ActiveFlag != 0
--group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue


----Summary PY
--select r.idOnboardingPhase,0 NumberRequestsCY,0 ProjectedRevnueCY,count(*) NumberRequestsPY,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenuePY,o.OnboardingPhase 
--into #tempPY
--from tblDiscoveryRequest r
--join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
--where Year(r.CreatedOn) = Year(GetDate())-1
--and r.ActiveFlag != 0
--group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue



--select op.idOnboardingPhase,op.OnboardingPhase,
--t1.NumberRequestsCY,t1.ProjectedRevenueCY,t2.NumberRequestsPY, t2.ProjectedRevenuePY
--from tblOnboardingPhase op
--left join #tempCY t1 on op.idOnboardingPhase = t1.idOnboardingPhase
--left join #tempPY t2 on op.idOnboardingPhase = t2.idOnboardingPhase
--where op.OnboardingPhase != 'Unassigned'
--order by op.SortValue

--Get all Kickoff,Discovery,Solution Determination and Implementation
select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
into #temp1
from tblDiscoveryRequest r
join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
where o.OnboardingPhase not in ('GO-LIVE','STABILIZATION','ON HOLD','CLOSED')
and r.ActiveFlag != 0
group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue


--GO-LIVE and Stabilization
Insert Into #temp1
select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
from tblDiscoveryRequest r
join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
where --Year(r.ActualGoLive) = Year(GetDate())-1 and 
o.OnboardingPhase  = 'GO-LIVE'
and r.ActiveFlag != 0
group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue

--Stabilization
Insert Into #temp1
select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
from tblDiscoveryRequest r
join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
where Year(r.ActualGoLive) = Year(GetDate())-1
and o.OnboardingPhase  = 'STABILIZATION'
and r.ActiveFlag != 0
group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue

--On Hold and Closed
Insert Into #temp1
select r.idOnboardingPhase,count(*) NumberRequests,o.sortValue,sum(r.ProjectedRevenue) ProjectedRevenue,o.OnboardingPhase 
from tblDiscoveryRequest r
join tblOnboardingPhase o on r.idOnboardingPhase=o.idOnboardingPhase
where 
--Year(r.CreatedOn) = Year(GetDate())-1 and 
o.OnboardingPhase  in ('ON HOLD','CLOSED')
and r.ActiveFlag != 0
group by r.idOnboardingPhase,o.OnboardingPhase,o.sortValue



select op.idOnboardingPhase,op.OnboardingPhase,
t1.NumberRequests,t1.ProjectedRevenue
from tblOnboardingPhase op
left join #temp1 t1 on op.idOnboardingPhase = t1.idOnboardingPhase
where op.OnboardingPhase != 'Unassigned'
order by op.SortValue


END