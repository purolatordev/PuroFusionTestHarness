CREATE  PROCEDURE [dbo].[sp_OnboardingTimePerCustomer]
(
@fromdate DateTime,
@todate DateTime,
@idITBA int,
@customer Varchar(100)
)
AS
BEGIN

IF 1=0 BEGIN
     SET FMTONLY OFF
 END


select 
dr.idITBA,b.ITBA,dr.CustomerName, p.OnboardingPhase, sum(n.timeSpent) 'MinutesSpent',
CASE WHEN p.OnboardingPhase = 'Stabilization' then 'LIVE' else '' END AS 'LiveFlag',
CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
left join vw_ITBA b on b.idITBA=dr.idITBA
--join tblTaskType t on t.idTaskType=n.idTaskType
left join tblOnboardingPhase p on p.idOnboardingPhase=dr.idOnboardingPhase
where ((n.noteDate >= @fromdate and n.noteDate <= @todate) or (n.noteDate is null)) and n.activeFlag=1
and dr.activeFlag=1 and dr.idITBA is not null 
--for only live customers:
--and p.OnboardingPhase = 'Stabilization'
group by dr.idITBA,b.ITBA,dr.CustomerName,p.OnboardingPhase
--order by dr.CustomerName


if @idITBA > 0
    delete from #temp where idITBA != @idITBA;


if @customer != 'All'
	delete from #temp where CustomerName != @customer;


select * from #temp order by MinutesSpent desc;


END