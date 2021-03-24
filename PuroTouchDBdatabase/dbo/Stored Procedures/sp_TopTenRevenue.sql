CREATE  PROCEDURE [dbo].[sp_TopTenRevenue]
(
@fromdate DateTime,
@todate DateTime,
@idITBA int
)
AS
BEGIN


select
dr.idITBA,b.ITBA,dr.CustomerName, p.OnboardingPhase, dr.ProjectedRevenue,
 CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
 into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
left join vw_ITBA b on b.idITBA=dr.idITBA
left join tblOnboardingPhase p on p.idOnboardingPhase=dr.idOnboardingPhase
where dr.createdOn >= @fromdate and Convert(date,dr.createdOn) <= @todate
and dr.activeFlag=1 and dr.idITBA is not null
group by dr.idITBA,b.ITBA,dr.CustomerName,p.OnboardingPhase, dr.ProjectedRevenue
order by sum(dr.ProjectedRevenue) desc

if @idITBA > 0    
	select top 10 * from #temp where idITBA = @idITBA order by ProjectedRevenue desc;
else
    select top 10 * from #temp order by ProjectedRevenue desc;


END