USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_email_OnboardingSnapshot]    Script Date: 8/3/2021 1:46:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_email_OnboardingSnapshot]

AS
BEGIN

    DECLARE @HTML_Header VARCHAR(MAX) ;
	SET @HTML_Header = '<html><style>tr:nth-of-type(even) { background-color:#ccc; } </style><body>';
	
	DECLARE @HTML_Footer VARCHAR(MAX) ;
	SET @HTML_Footer = '</body></html>'

	DECLARE @HTML_Body VARCHAR(MAX) ;
	
	--BODY

	-- OnBoarding - 1 - On the Runway ( Last week and this week ) 
--SELECT 
--	-- tblDiscoveryRequest.idRequest,	
--       CONVERT(date, TargetGoLive)       as 'Target GoLive',
--       CONVERT(date, CurrentGoLive)      as 'Current GoLive',
--       CONVERT(date, ActualGoLive)       as 'Actual GoLive',  
--       CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase as 'Stage',  
--       tblDiscoveryRequest.CustomerName  as 'Customer',       
--       tblShippingChannel.ShippingChannel as 'Shipping Channel',
--       '$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00','') as 'Projected Revenue',
--       tblITBA.login as 'IT BA',
--       tblDiscoveryRequest.SalesRepName 'Sales Rep',
--       CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' TimeSpent 
--FROM PuroTouchDB.dbo.tblDiscoveryRequest 
--LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
--LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
--LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
--LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
--WHERE 1=1
--and tblOnboardingPhase.SortValue not in ( 70, 80, 90, 100 ) -- filert out Stabilization, onHold, OnClose, Unassigned
--and CurrentGoLive > DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) - 8 -- Previous weeks Sunday
--and CurrentGoLive < DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) + 6 -- Next Sunday
--and tblDiscoveryRequest.ActiveFlag = 1
--Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName
--Order by tblOnboardingPhase.SortValue, TargetGoLive

------ OnBoarding - 2 - OnHold
--SELECT 
--       CONVERT(date, TargetGoLive)       as 'Target GoLive',
--       CONVERT(date, CurrentGoLive)      as 'Current GoLive',
--       CONVERT(date, ActualGoLive)       as 'Actual GoLive',  
--       CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase as 'Stage',  
--       tblDiscoveryRequest.CustomerName  as 'Customer',       
--       tblShippingChannel.ShippingChannel as 'Shipping Channel',
--       '$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00','') as 'Projected Revenue',
--       tblITBA.login as 'IT BA',

--       tblDiscoveryRequest.SalesRepName 'Sales Rep',
--       CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' TimeSpentm,
--	   CASE WHEN tblDiscoveryRequest.PhaseChangeDate is null THEN '0'
--			ELSE Datediff(dd,tblDiscoveryRequest.PhaseChangeDate, getdate()) 
--		END as 'Days OnHold'
--FROM PuroTouchDB.dbo.tblDiscoveryRequest 
--LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
--LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
--LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
--LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
--WHERE 1=1
--and tblOnboardingPhase.SortValue in ( 80 ) -- filert out Stabilization, onHold, OnClose, Unassigned
--and tblDiscoveryRequest.ActiveFlag = 1
--Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName, tblDiscoveryRequest.PhaseChangeDate
--Order by tblOnboardingPhase.SortValue, tblDiscoveryRequest.TargetGoLive desc, tblDiscoveryRequest.CurrentGoLive desc, tblDiscoveryRequest.CustomerName

------ OnBoarding - 3 - closed in the last 30days
--SELECT 
--       CONVERT(date, TargetGoLive)       as 'Target GoLive',
--       CONVERT(date, CurrentGoLive)      as 'Current GoLive',
--       CONVERT(date, ActualGoLive)       as 'Actual GoLive',  
--       CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase as 'Stage',  
--       tblDiscoveryRequest.CustomerName  as 'Customer',       
--       tblShippingChannel.ShippingChannel as 'Shipping Channel',
--       '$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00','') as 'Projected Revenue',
--       tblITBA.login as 'IT BA',
--       tblDiscoveryRequest.SalesRepName 'Sales Rep',
--       CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' as 'TimeSpent',
--	   tblDiscoveryRequest.CloseReason,
--	   CASE WHEN tblDiscoveryRequest.PhaseChangeDate is null THEN '0'
--			ELSE Datediff(dd,tblDiscoveryRequest.PhaseChangeDate, getdate()) 
--		END as 'Days Closed'
--FROM PuroTouchDB.dbo.tblDiscoveryRequest 
--LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
--LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
--LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
--LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
--WHERE 1=1
--and tblOnboardingPhase.SortValue in ( 90 ) -- filert out Stabilization, onHold, OnClose, Unassigned
--and tblDiscoveryRequest.PhaseChangeDate > GETDATE() - 30 -- Previous 30days
--and tblDiscoveryRequest.ActiveFlag = 1
--Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName,tblDiscoveryRequest.CloseReason,tblDiscoveryRequest.PhaseChangeDate
--Order by tblOnboardingPhase.SortValue, tblDiscoveryRequest.TargetGoLive desc, tblDiscoveryRequest.CurrentGoLive desc, tblDiscoveryRequest.CustomerName

------ OnBoarding - 4 - Active Queue
--SELECT 
--	-- tblDiscoveryRequest.idRequest,	
--       CONVERT(date, TargetGoLive)       as 'Target GoLive',
--       CONVERT(date, CurrentGoLive)      as 'Current GoLive',
--       CONVERT(date, ActualGoLive)       as 'Actual GoLive',  
--       CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase as 'Stage',  
--       tblDiscoveryRequest.CustomerName  as 'Customer',       
--       tblShippingChannel.ShippingChannel as 'Shipping Channel',
--       '$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00','') as 'Projected Revenue',
--       tblITBA.login as 'IT BA',
--       tblDiscoveryRequest.SalesRepName 'Sales Rep',
--       CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' TimeSpent 
--FROM PuroTouchDB.dbo.tblDiscoveryRequest 
--LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
--LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
--LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
--LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
--WHERE 1=1
--and tblOnboardingPhase.SortValue not in ( 70, 80, 90, 100 ) -- filert out Stabilization, onHold, OnClose, Unassigned
--and tblDiscoveryRequest.ActiveFlag = 1
--Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName
--Order by tblOnboardingPhase.SortValue, TargetGoLive

	SET @HTML_Body = '<table border="1" bordercolor=#F5FFFA align=center>';

	--First Query
	DECLARE @HTML_Body1 VARCHAR(MAX) ;
	SET @HTML_Body1 =
		'<tr><th bgcolor=#247c76 colspan=5>Last Week and This Week Go-Live</th></tr>' +
		'<tr><th bgcolor=#247c76>Target GoLive</th><th bgcolor=#247c76>Current GoLive</th><th bgcolor=#247c76>Actual GoLive</th><th bgcolor=#247c76>IT Stage</th><th bgcolor=#247c76>Customer</th><th bgcolor=#247c76>Shipping Channel</th><th bgcolor=#247c76>Projected Revenue</th><th bgcolor=#247c76>IT BA</th><th bgcolor=#247c76>Sales Rep</th><th bgcolor=#247c76>Time Spent</th><th></th><th></th></tr>'+
		CAST ((	SELECT 
		        td=Case WHen TargetGoLive is null Then '' Else FORMAT(TargetGoLive,'MM/dd/yy') END,'',
				td=Case When CurrentGoLive is null Then '' Else FORMAT(CurrentGoLive,'MM/dd/yy') END,'',
				td=Case When ActualGoLive is null THen '' Else FORMAT( ActualGoLive,'MM/dd/yy') END,'',
				td=CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase,'',
				td=CustomerName,'',
                td=Case When ShippingChannel is null Then '' Else ShippingChannel END,'',					
				td='$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00',''),'',				
				td=Case When tblITBA.login is null Then '' Else tblITBA.login END,'',
				td=SalesRepName,'',
				td=CASE WHEN sum(tblDiscoveryRequestNotes.timeSpent) is null Then '' Else CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' END,'',
				td='','',
				td='',''
				FROM PuroTouchDB.dbo.tblDiscoveryRequest 
				LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
				LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
				LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
				LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
				WHERE 1=1
				and tblDiscoveryRequestNotes.timeSpent is not null
				and tblOnboardingPhase.SortValue not in ( 70, 80, 90, 100 ) -- filert out Stabilization, onHold, OnClose, Unassigned
				and CurrentGoLive > DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) - 8 -- Previous weeks Sunday
				and CurrentGoLive < DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0) + 6 -- Next Sunday
				and tblDiscoveryRequest.ActiveFlag = 1
				Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName
				Order by tblOnboardingPhase.SortValue, TargetGoLive						
										
				For XML PATH('tr'), TYPE ) AS NVARCHAR(MAX));

				print @HTML_Body1;

		--Second Query
		DECLARE @HTML_Body2 VARCHAR(MAX) ;
		SET @HTML_Body2 =
		'<tr><th bgcolor=#566D7E colspan=5>Current Customers with No IT Activity (No Progess 30 Days)</th>' +
		'<tr><th bgcolor=#566D7E>Target GoLive</th><th bgcolor=#566D7E>Current GoLive</th><th bgcolor=#566D7E>Actual GoLive</th><th bgcolor=#566D7E>IT Stage</th><th bgcolor=#566D7E>Customer</th><th bgcolor=#566D7E>Shipping Channel</th><th bgcolor=#566D7E>Projected Revenue</th><th bgcolor=#566D7E>IT BA</th><th bgcolor=#566D7E>Sales Rep</th><th bgcolor=#566D7E>Time Spent</th><th bgcolor=#566D7E>Hold Reason</th><th bgcolor=#566D7E>Days On Hold</th></tr>'+
		CAST ((	SELECT 
			td=Case WHen TargetGoLive is null Then '' Else FORMAT(TargetGoLive,'MM/dd/yy') END,'',
			td=Case When CurrentGoLive is null Then '' Else FORMAT(CurrentGoLive,'MM/dd/yy') END,'',
			td=Case When ActualGoLive is null Then '' Else FORMAT( ActualGoLive,'MM/dd/yy') END,'',
			td=CASE WHEN tblOnboardingPhase.SortValue is null Then '' Else CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase END, '',
			td=CASE WHEN tblDiscoveryRequest.CustomerName is null Then '' Else tblDiscoveryRequest.CustomerName END, '',      
			td=Case When ShippingChannel is null Then '' Else ShippingChannel END,'',
			td=Case When tblDiscoveryRequest.ProjectedRevenue is null then '' Else '$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00','') END,'',
			td=Case When tblITBA.login is null Then '' Else tblITBA.login END,'',
			td=Case When tblDiscoveryRequest.SalesRepName is null Then '' Else tblDiscoveryRequest.SalesRepName END,'',
			td=CASE WHEN sum(tblDiscoveryRequestNotes.timeSpent) is null Then '' Else CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' END,'',
			td=CASE WHEN CloseReason is null Then '' Else CloseReason END,'',
			td=CASE WHEN tblDiscoveryRequest.PhaseChangeDate is null THEN '0' ELSE Datediff(dd,tblDiscoveryRequest.PhaseChangeDate, getdate()) END,''		
			FROM PuroTouchDB.dbo.tblDiscoveryRequest 
			LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
			LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
			LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
			LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
			WHERE 1=1
			and tblDiscoveryRequestNotes.timeSpent is not null
			and tblOnboardingPhase.SortValue in ( 80 ) -- filert out Stabilization, onHold, OnClose, Unassigned
			and tblDiscoveryRequest.ActiveFlag = 1
			Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName, tblDiscoveryRequest.PhaseChangeDate, tblDiscoveryRequest.CloseReason
			Order by tblOnboardingPhase.SortValue, tblDiscoveryRequest.TargetGoLive desc, tblDiscoveryRequest.CurrentGoLive desc, tblDiscoveryRequest.CustomerName						
										
				For XML PATH('tr'), TYPE ) AS NVARCHAR(MAX));

				print @HTML_Body2;

		--Third Query
		DECLARE @HTML_Body3 VARCHAR(MAX) ;
		SET @HTML_Body3 = 
		'<tr><th bgcolor=#845e61 colspan=5>Customers Back in Sales Queue (No IT Activity 90 Days)</th>' +
		'<tr><th bgcolor=#845e61>Target GoLive</th><th bgcolor=#845e61>Current GoLive</th><th bgcolor=#845e61>Actual GoLive</th><th bgcolor=#845e61>IT Stage</th><th bgcolor=#845e61>Customer</th><th bgcolor=#845e61>Shipping Channel</th><th bgcolor=#845e61>Projected Revenue</th><th bgcolor=#845e61>IT BA</th><th bgcolor=#845e61>Sales Rep</th><th bgcolor=#845e61>Time Spent</th><th bgcolor=#845e61>Close Reason</th><th bgcolor=#845e61>Days Closed</th></tr>'+
		CAST ((	SELECT 
			td=Case WHen TargetGoLive is null Then '' Else FORMAT(TargetGoLive,'MM/dd/yy') END,'',
			td=Case When CurrentGoLive is null Then '' Else FORMAT(CurrentGoLive,'MM/dd/yy') END,'',
			td=Case When ActualGoLive is null THen '' Else FORMAT( ActualGoLive,'MM/dd/yy') END,'',
			td=CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase, '',
			td=tblDiscoveryRequest.CustomerName, '',      
			td=Case When ShippingChannel is null Then '' Else ShippingChannel END,'',
			td='$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00',''),'',
			td=Case When tblITBA.login is null Then '' Else tblITBA.login END,'',
			td=tblDiscoveryRequest.SalesRepName,'',
			td=CASE WHEN sum(tblDiscoveryRequestNotes.timeSpent) is null Then '' Else CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' END,'',
			td=CASE WHEN CloseReason is null Then '' Else CloseReason END,'',
			td=CASE WHEN tblDiscoveryRequest.PhaseChangeDate is null THEN '0'
				ELSE Datediff(dd,tblDiscoveryRequest.PhaseChangeDate, getdate()) 
				END,''		
			FROM PuroTouchDB.dbo.tblDiscoveryRequest 
			LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
			LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
			LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
			LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
			WHERE 1=1
			and tblDiscoveryRequestNotes.timeSpent is not null
			and tblOnboardingPhase.SortValue in ( 90 ) -- filert out Stabilization, onHold, OnClose, Unassigned
			and tblDiscoveryRequest.PhaseChangeDate > GETDATE() - 30
			and tblDiscoveryRequest.ActiveFlag = 1
			Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName, tblDiscoveryRequest.PhaseChangeDate, tblDiscoveryRequest.CloseReason
			Order by tblOnboardingPhase.SortValue, tblDiscoveryRequest.TargetGoLive desc, tblDiscoveryRequest.CurrentGoLive desc, tblDiscoveryRequest.CustomerName						
										
				For XML PATH('tr'), TYPE ) AS NVARCHAR(MAX));

			Print @HTML_Body3;

		--Fourth Query
		DECLARE @HTML_Body4 VARCHAR(MAX) ;
		SET @HTML_Body4 =
		'<tr><th bgcolor=#395f93 colspan=5>All Active Implementations</th>' +
		'<tr><th bgcolor=#395f93>Target GoLive</th><th bgcolor=#395f93>Current GoLive</th><th bgcolor=#395f93>Actual GoLive</th><th bgcolor=#395f93>IT Stage</th><th bgcolor=#395f93>Customer</th><th bgcolor=#395f93>Shipping Channel</th><th bgcolor=#395f93>Projected Revenue</th><th bgcolor=#395f93>IT BA</th><th bgcolor=#395f93>Sales Rep</th><th bgcolor=#395f93>Time Spent</th><th></th><th></th></tr>'+
		CAST ((	SELECT 
		        td=Case WHen TargetGoLive is null Then '' Else FORMAT(TargetGoLive,'MM/dd/yy') END,'',
				td=Case When CurrentGoLive is null Then '' Else FORMAT(CurrentGoLive,'MM/dd/yy') END,'',
				td=Case When ActualGoLive is null THen '' Else FORMAT( ActualGoLive,'MM/dd/yy') END,'',
				td=CONVERT(varchar,(tblOnboardingPhase.SortValue/10 - 1 )) + ' - ' + tblOnboardingPhase.OnboardingPhase,'',
				td=CustomerName,'',
                td=Case When ShippingChannel is null Then '' Else ShippingChannel END,'',					
				td='$' + Replace(convert(varchar,convert(money, tblDiscoveryRequest.ProjectedRevenue),1), '.00',''),'',				
				td=Case When tblITBA.login is null Then '' Else tblITBA.login END,'',
				td=SalesRepName,'',
				td=CASE WHEN sum(tblDiscoveryRequestNotes.timeSpent) is null Then '' Else CONVERT(VARCHAR(10),ROUND(sum(tblDiscoveryRequestNotes.timeSpent)/60,0)) + 'Hrs ' + CONVERT(VARCHAR(10),CEILING(sum(tblDiscoveryRequestNotes.timeSpent)%60)) + 'mins' END,'',
				td='','',
				td='',''
				FROM PuroTouchDB.dbo.tblDiscoveryRequest 
				LEFT JOIN PuroTouchDB.dbo.tblOnboardingPhase	ON tblDiscoveryRequest.idOnboardingPhase	= tblOnboardingPhase.idOnboardingPhase
				LEFT JOIN PuroTouchDB.dbo.tblShippingChannel	ON tblDiscoveryRequest.idShippingChannel	= tblShippingChannel.idShippingChannel
				LEFT JOIN PuroTouchDB.dbo.tblITBA				ON tblDiscoveryRequest.idITBA				= tblITBA.idITBA
				LEFT JOIN tblDiscoveryRequestNotes				ON tblDiscoveryRequestNotes.idRequest		= tblDiscoveryRequest.idRequest
				WHERE 1=1
				and tblDiscoveryRequestNotes.timeSpent is not null
				and tblOnboardingPhase.SortValue not in ( 70, 80, 90, 100 ) -- filert out Stabilization, onHold, OnClose, Unassigned				
				and tblDiscoveryRequest.ActiveFlag = 1
				Group by tblDiscoveryRequest.idRequest,TargetGoLive,CurrentGoLive,ActualGoLive,tblOnboardingPhase.OnboardingPhase,tblOnboardingPhase.SortValue, tblDiscoveryRequest.CustomerName,tblShippingChannel.ShippingChannel,tblDiscoveryRequest.ProjectedRevenue,tblITBA.login,tblDiscoveryRequest.SalesRepName
				Order by tblOnboardingPhase.SortValue, TargetGoLive						
										
				For XML PATH('tr'), TYPE ) AS NVARCHAR(MAX));

			print @HTML_Body4;
	
	SET @HTML_Body=@HTML_Body + ISNULL(@HTML_Body1,'null') + ISNULL(@HTML_Body2,'null') + ISNULL(@HTML_Body3,'null') + ISNULL(@HTML_Body4,'null');

	SET @HTML_Body=@HTML_Body + '</table>';

	--print @HTML_Body;

	--END BODY
	
	DECLARE @HTML_EMAIL VARCHAR(MAX);
	Set @HTML_EMAIL = @HTML_Header + ISNULL(@HTML_Body,'null') + @HTML_Footer
	print @HTML_EMAIL;
	select @HTML_EMAIL

	DECLARE @subj VARCHAR(50);
	SET @subj = 'Onboarding Snapshot ' + FORMAT(GETDATE(),'MM/dd/yy');

IF ( @HTML_EMAIL is not null ) 
EXEC msdb.dbo.sp_send_dbmail 
	@profile_name = 'DB Mail',
	@recipients='Michele.Kennedy@purolator.com',
	--@recipients='Jim.Kardiasmenos@purolator.com;Allie.Carson@purolator.com;Karen.Arias@purolator.com;Michele.Kennedy@purolator.com',
    @subject = @subj,
    @body = @HTML_EMAIL,
    @body_format = 'HTML';

END
GO


