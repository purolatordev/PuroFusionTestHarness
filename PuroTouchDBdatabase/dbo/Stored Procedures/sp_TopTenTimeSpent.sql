CREATE  PROCEDURE [dbo].[sp_TopTenTimeSpent]
(
@fromdate DateTime,
@todate DateTime,
@idITBA int
)
AS
BEGIN


select
dr.idITBA,b.ITBA,dr.CustomerName, p.OnboardingPhase, dr.ProjectedRevenue,
 CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent, sum(n.timeSpent) TotalMinutes
 into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
left join vw_ITBA b on b.idITBA=dr.idITBA
--join tblTaskType t on t.idTaskType=n.idTaskType
left join tblOnboardingPhase p on p.idOnboardingPhase=dr.idOnboardingPhase
where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
and dr.activeFlag=1 and dr.idITBA is not null
group by dr.idITBA,b.ITBA,dr.CustomerName,p.OnboardingPhase, dr.ProjectedRevenue
order by sum(n.timeSpent) desc

if @idITBA > 0
    delete from #temp where idITBA != @idITBA;

select top 10 * from #temp order by TotalMinutes desc;

END