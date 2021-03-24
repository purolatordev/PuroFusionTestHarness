CREATE  PROCEDURE [dbo].[sp_OnboardingDetailReport]
(
--@fromdate DateTime,
--@todate DateTime,
@idITBA int,
@customer Varchar(100)
)
AS
BEGIN


select 
dr.idITBA,b.ITBA,dr.CustomerName,dr.SalesRepName,dr.Commodity,dr.ProjectedRevenue,sc.ShippingChannel,dr.WorldPakFlag,dr.thirdpartyFlag,dr.customFlag,dr.CustomsSupportedFlag,dr.ElinkFlag,
dr.Pars,dr.Pass,dr.ProposedCustoms,dr.CustomsBroker,
p.OnboardingPhase,dr.CurrentSolution,dr.SalesComments,dr.SolutionSummary,dr.TargetGoLive,
CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent))%60) + 'mins' TimeSpent
into #temp
from tblDiscoveryRequest dr 
left join tblDiscoveryRequestNotes n on n.idRequest=dr.idRequest
left join vw_ITBA b on b.idITBA=dr.idITBA
left join tblShippingChannel sc on sc.idShippingChannel = dr.idShippingChannel
left join tblOnboardingPhase p on p.idOnboardingPhase=dr.idOnboardingPhase
where 
--dr.CreatedOn>=@fromdate and Convert(Date,dr.CreatedOn) <= @todate and
dr.activeFlag=1 and dr.idITBA is not null
Group by dr.idITBA,b.ITBA,dr.CustomerName,dr.SalesRepName,dr.Commodity,dr.ProjectedRevenue,sc.ShippingChannel,dr.WorldPakFlag,dr.thirdpartyFlag,dr.customFlag,dr.CustomsSupportedFlag,dr.ElinkFlag,
dr.Pars,dr.Pass,dr.ProposedCustoms,dr.CustomsBroker,
p.OnboardingPhase,dr.CurrentSolution,dr.SalesComments,dr.SolutionSummary,dr.TargetGoLive
Order by b.ITBA,dr.CustomerName;

if @idITBA > 0
    delete from #temp where idITBA != @idITBA;


if @customer != 'All'
	delete from #temp where CustomerName != @customer;


select * from #temp;

END