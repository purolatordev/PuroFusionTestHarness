CREATE  PROCEDURE [dbo].[sp_CustomerDelayReport]
(
@fromdate DateTime,
@todate DateTime,
@idITBA int,
@customer VarChar(100)
)
AS
BEGIN


select 
b.idITBA,b.ITBA,dr.CustomerName,v.VendorType,p.OnboardingPhase,  dr.CreatedOn 'SubmittedDate',dr.TargetGoLive,dr.CurrentGoLive ,t.TaskType, n.noteDate,n.privateNote,CONVERT(VARCHAR(10),ROUND(n.timeSpent/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(n.timeSpent)%60) + 'mins' TimeSpent
into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
left join vw_ITBA b on b.idITBA=dr.idITBA
left join tblTaskType t on t.idTaskType=n.idTaskType
left join tblOnboardingPhase p on p.idOnboardingPhase=dr.idOnboardingPhase
left join tblVendorType v on v.idVendorType = dr.idVendorType
where 
n.idTaskType = 1014 and
n.noteDate>=@fromdate and Convert(Date,n.noteDate) <= @todate and
dr.activeFlag=1 --and dr.idITBA is not null
and n.ActiveFlag=1
Order by b.ITBA,dr.CustomerName,p.OnboardingPhase,noteDate;

if @idITBA != 0
begin
    delete from #temp where idITBA is null;
    delete from #temp where idITBA != @idITBA;
end


if @customer != 'All'
begin
	delete from #temp where CustomerName != @customer;
end


select * from #temp;



END