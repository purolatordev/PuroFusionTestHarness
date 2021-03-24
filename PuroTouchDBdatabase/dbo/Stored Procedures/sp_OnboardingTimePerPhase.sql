CREATE  PROCEDURE [dbo].[sp_OnboardingTimePerPhase]
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
dr.idITBA,b.ITBA,dr.CustomerName,p.OnboardingPhase,sum(n.timeSpent) 'MinutesSpent', CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
join vw_ITBA b on b.idITBA=dr.idITBA
join tblTaskType t on t.idTaskType=n.idTaskType
join tblOnboardingPhase p on p.idOnboardingPhase=t.idOnboardingPhase
where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
and dr.activeFlag=1 and dr.idITBA is not null
group by dr.idITBA,b.ITBA,dr.CustomerName,p.OnboardingPhase
--Order by b.ITBA,dr.CustomerName,p.OnboardingPhase

if @idITBA > 0
    delete from #temp where idITBA != @idITBA;


if @customer != 'All'
	delete from #temp where CustomerName != @customer;


select * from #temp order by MinutesSpent desc;

END