CREATE  PROCEDURE [dbo].[sp_OnboardingNotesReport]
(
--@fromdate DateTime,
--@todate DateTime,
@idITBA int,
@customer VarChar(100)
)
AS
BEGIN


select 
b.idITBA,b.ITBA,dr.CustomerName,p.OnboardingPhase, t.TaskType, n.noteDate,n.publicNote, CONVERT(VARCHAR(10),ROUND(n.timeSpent/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(n.timeSpent)%60) + 'mins' TimeSpent
into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
left join vw_ITBA b on b.idITBA=dr.idITBA
left join tblTaskType t on t.idTaskType=n.idTaskType
left join tblOnboardingPhase p on p.idOnboardingPhase=t.idOnboardingPhase
where 
--dr.CreatedOn>=@fromdate and Convert(Date,dr.CreatedOn) <= @todate and
dr.activeFlag=1 and dr.idITBA is not null
Order by b.ITBA,dr.CustomerName,p.OnboardingPhase,noteDate;

if @idITBA > 0
    delete from #temp where idITBA != @idITBA;


if @customer != 'All'
	delete from #temp where CustomerName != @customer;


select * from #temp;



END