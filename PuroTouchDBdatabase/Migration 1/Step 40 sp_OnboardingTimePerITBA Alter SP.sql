--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv6]
GO

/****** Object:  StoredProcedure [dbo].[sp_OnboardingTimePerITBA]    Script Date: 2022/01/24 11:33:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER  PROCEDURE [dbo].[sp_OnboardingTimePerITBA]
(
@fromdate DateTime,
@todate DateTime,
@idITBA int
)
AS
BEGIN



	select itba.idITBA,e.FirstName + ' ' + e.LastName ITBA, CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
	into #temp
	from tblDiscoveryRequest dr 
	left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
	join purolatorReporting..tblEmployee e on e.ActiveDirectoryName = n.CreatedBy
	join tblITBA itba on e.ActiveDirectoryName = itba.login
	where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
	and dr.activeFlag=1 and itba.idITBA is not null
	and n.idTaskType != 14
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
		join tblITBA itba on e.ActiveDirectoryName = itba.login
		where n.noteDate >= @fromdate and n.noteDate <= @todate and n.activeFlag=1
		and dr.activeFlag=1 and itba.idITBA is not null
		and n.idTaskType != 14

		select * from #temp order by idITBA;
	END

END



GO


