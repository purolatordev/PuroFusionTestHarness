CREATE  PROCEDURE [dbo].[sp_GetProjRevenueITBA]
(
@ITBAUserLogin nvarchar(50)
)
AS
BEGIN

--select DateName(Month,dr.ActualGoLive) MonthName,Month(dr.ActualGoLive) month,sum(dr.ProjectedRevenue) Rev
--from tblDiscoveryRequest dr
--join tblITBA ba on dr.idITBA = ba.idITBA
--join PurolatorReporting..tblEmployee e on ba.idEmployee = e.idEmployee
--where 
--dr.ActiveFlag != 0
--and 
--ActualGoLive IS NOT NULL
--and e.ActiveDirectoryName=@ITBAUserLogin
--Group by DateName(Month,dr.ActualGoLive),Month(dr.ActualGoLive)
--order by  Month(dr.ActualGoLive)


select DateName(Month,dr.TargetGoLive) MonthName,Month(dr.TargetGoLive) month,sum(dr.ProjectedRevenue) Rev
from tblDiscoveryRequest dr
join tblITBA ba on dr.idITBA = ba.idITBA
join PurolatorReporting..tblEmployee e on ba.idEmployee = e.idEmployee
where 
dr.ActiveFlag != 0
and 
TargetGoLive IS NOT NULL
and e.ActiveDirectoryName=@ITBAUserLogin
and Year(dr.TargetGoLive) = Year(GetDate())
Group by DateName(Month,dr.TargetGoLive),Month(dr.TargetGoLive)
order by  Month(dr.TargetGoLive)

END