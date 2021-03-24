CREATE  PROCEDURE [dbo].[sp_OnboardingTimePerITBA]
(
@fromdate DateTime,
@todate DateTime,
@idITBA int
)
AS
BEGIN


--select 
--dr.idITBA,b.ITBA, CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
--into #temp
--from tblDiscoveryRequest dr 
--left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
--join vw_ITBA b on b.idITBA=dr.idITBA
--where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
--and dr.activeFlag=1 and dr.idITBA is not null
--group by dr.idITBA,b.ITBA;

--go by task owner instead of Customer Owner

	select itba.idITBA,e.FirstName + ' ' + e.LastName ITBA, CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
	into #temp
	from tblDiscoveryRequest dr 
	left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
	join purolatorReporting..tblEmployee e on e.ActiveDirectoryName = n.CreatedBy
	join tblITBA itba on e.ActiveDirectoryName = itba.login
	where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
	and dr.activeFlag=1 and itba.idITBA is not null
	group by itba.idITBA,e.FirstName,e.LastName

if @idITBA > 0    
	select * from #temp where idITBA = @idITBA Order by ITBA;
else
	--insert totals
	BEGIN
	insert 	into #temp
		select
		9999,'Total', CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
		from tblDiscoveryRequest dr 
		left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
		join purolatorReporting..tblEmployee e on e.ActiveDirectoryName = n.CreatedBy
		where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
		and dr.activeFlag=1 and dr.idITBA is not null;

		select * from #temp order by idITBA;
	END

END