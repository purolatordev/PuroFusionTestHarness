CREATE  PROCEDURE [dbo].[sp_email_OnHoldAndClosed]

AS
BEGIN

--PUT ON HOLD OR CLOSED IN LAST 7 DAYS
--
--select 
--r.PhaseChangeDate DateChanged,p.OnboardingPhase,
--r.CloseReason,
--Case WHen r.TargetGoLive is null Then '' Else Cast(Cast(r.TargetGoLive as date) as varchar(10)) END as TargetGoLive,
--Case When r.CurrentGoLive is null Then '' Else Cast(Cast(r.CurrentGoLive as date) as varchar(10)) END as CurrentGoLive,
--Case When r.ActualGoLive is null THen '' Else Cast(Cast(r.ActualGoLive as date) as varchar(10)) END as  TargetGoLive, 
--c.ShippingChannel,r.CustomerName,CONVERT(varchar, CAST(r.ProjectedRevenue AS money), 1) ProjectedRevenue,r.SalesRepName,b.ITBA,
--CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins' TimeSpent
--from tblDiscoveryRequest r
--join tblOnboardingPhase p on p.idOnboardingPhase=r.idOnboardingPhase
--join tblShippingChannel c on c.idShippingChannel=r.idShippingChannel
--left join vw_ITBA b on b.idITBA=r.idITBA
--join tblDiscoveryRequestNotes n on n.idRequest=r.idRequest
--where r.PhaseChangeDate >= dateadd(day, -7, getdate())
--and r.ActiveFlag != 0
--group by r.PhaseChangeDate,r.CloseReason,r.idRequest,r.CurrentGoLive,r.TargetGoLive, r.ActualGoLive, p.OnboardingPhase,c.ShippingChannel,r.CustomerName,r.ProjectedRevenue,r.SalesRepName,b.ITBA,p.SortValue
--order by r.CurrentGoLive,r.TargetGoLive,p.SortValue


DECLARE @HTML_Header VARCHAR(MAX) ;
	SET @HTML_Header = '<html><style>tr:nth-of-type(even) { background-color:#ccc; } </style><body>';
	
	DECLARE @HTML_Footer VARCHAR(MAX) ;
	SET @HTML_Footer = '</body></html>'
	
	DECLARE @HTML_Body VARCHAR(MAX) ;
	SET @HTML_Body =
		'<table border="1" bordercolor=#F5FFFA align=center>' +
		'<tr><th bgcolor=#566D7E>DateChanged</th><th bgcolor=#566D7E>OnboardingPhase</th><th bgcolor=#566D7E>Reason</th><th bgcolor=#566D7E>TargetGoLive</th><th bgcolor=#566D7E>CurrentGoLive</th><th bgcolor=#566D7E>ActualGoLive</th><th bgcolor=#566D7E>ShippingChannel</th><th bgcolor=#566D7E>CustomerName</th><th bgcolor=#566D7E>ProjectedRevenue</th><th bgcolor=#566D7E>SalesRepName</th><th bgcolor=#566D7E>ITBA</th><th bgcolor=#566D7E>TimeSpent</th></tr>'+
		CAST ((	SELECT 
		        td=Cast(r.PhaseChangeDate As date),'',
		        td=p.OnboardingPhase,'',
		        td=r.CloseReason,'',
		        td=Case WHen r.TargetGoLive is null Then '' Else Cast(Cast(r.TargetGoLive as date) as varchar(10)) END,'',
				td=Case When r.CurrentGoLive is null Then '' Else Cast(Cast(r.CurrentGoLive as date) as varchar(10)) END,'',
				td=Case When r.ActualGoLive is null THen '' Else Cast(Cast(r.ActualGoLive as date) as varchar(10)) END,'',				
                td=c.ShippingChannel,'',
				td=r.CustomerName,'',	
				td=CONVERT(varchar, CAST(r.ProjectedRevenue AS money), 1),'',
				td=r.SalesRepName,'',
				td=b.ITBA,'',
				td=CONVERT(VARCHAR(10),ROUND(sum(n.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(n.timeSpent)%60)) + 'mins',''		
				
				FROM  tblDiscoveryRequest r
				join tblOnboardingPhase p on p.idOnboardingPhase=r.idOnboardingPhase
				join tblShippingChannel c on c.idShippingChannel=r.idShippingChannel
				left join vw_ITBA b on b.idITBA=r.idITBA
				join tblDiscoveryRequestNotes n on n.idRequest=r.idRequest
				where r.PhaseChangeDate >= dateadd(day, -7, getdate()) and
				r.ActiveFlag != 0
				group by r.PhaseChangeDate,r.CloseReason,r.TargetGoLive,r.CurrentGoLive,r.ActualGoLive, p.OnboardingPhase,c.ShippingChannel,r.CustomerName,r.ProjectedRevenue,r.SalesRepName,b.ITBA,p.SortValue
				order by r.PhaseChangeDate,r.CustomerName							
										
				For XML PATH('tr'), TYPE ) AS NVARCHAR(MAX)) + 
		'</table>';

	DECLARE @HTML_EMAIL VARCHAR(MAX);
	Set @HTML_EMAIL = @HTML_Header + ISNULL(@HTML_Body,'null') + @HTML_Footer

	select @HTML_EMAIL

IF ( @HTML_EMAIL is not null ) 
EXEC msdb.dbo.sp_send_dbmail 
	@profile_name = 'DB Mail',
	@recipients='Michele.Kennedy@purolator.com',
    @subject = 'OnHold And Closed Requests Past 7 Days',
    @body = @HTML_EMAIL,
    @body_format = 'HTML';




END