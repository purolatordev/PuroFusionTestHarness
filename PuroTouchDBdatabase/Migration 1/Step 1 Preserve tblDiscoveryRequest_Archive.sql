--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Table [dbo].[tblDiscoveryRequest_]    Script Date: 2021/03/15 8:43:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
BEGIN TRANSACTION
go

IF OBJECT_ID(N'dbo.tblDiscoveryRequest_Archive', N'U') IS NOT NULL
begin
	print 'Exists -- tblDiscoveryRequest_Archive table'
	IF OBJECT_ID('dbo.[PK_tblDiscoveryRequest_Archive]') IS NOT NULL 
	begin
		print 'Exists -- So drop PK_tblDiscoveryRequest_Archive CONSTRAINT'
		ALTER TABLE [dbo].tblDiscoveryRequest_Archive
			DROP CONSTRAINT [PK_tblDiscoveryRequest_Archive]
	end
end
--drop table tblDiscoveryRequest_Archive

create TABLE [dbo].[Tmp_tblDiscoveryRequest_Archive](
	[idRequest_Archive] [int] IDENTITY(1,1) NOT NULL,
	[idRequest] [int] NOT NULL,
	[TableAction] [varchar](50) NOT NULL,
	[isNewRequest] [bit] NULL,
	[SalesRepName] [varchar](255) NULL,
	[SalesRepEmail] [varchar](255) NULL,
	[idOnboardingPhase] [int] NULL,
	[District] [varchar](255) NULL,
	[CustomerName] [varchar](255) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[State] [varchar](255) NULL,
	[Zipcode] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[Commodity] [varchar](255) NULL,
	[ProjectedRevenue] [money] NULL,
	[CurrentSolution] [varchar](3000) NULL,
	[ProposedCustoms] [varchar](2000) NULL,
	[CallDate1] [datetime] NULL,
	[CallDate2] [datetime] NULL,
	[CallDate3] [datetime] NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[SalesComments] [varchar](3000) NULL,
	[idITBA] [int] NULL,
	[idShippingChannel] [int] NULL,
	[TargetGoLive] [datetime] NULL,
	[ActualGoLive] [datetime] NULL,
	[SolutionSummary] [varchar](3000) NULL,
	[CustomerWebsite] [varchar](500) NULL,
	[Branch] [nvarchar](50) NULL,
	[idVendor] [int] NULL,
	[worldpakFlag] [bit] NULL,
	[thirdpartyFlag] [bit] NULL,
	[customFlag] [bit] NULL,

	[InvoiceType] [varchar](50) NULL,
	[BilltoAccount] [varchar](50) NULL,
	[FTPUsername] [varchar](255) NULL,
	[FTPPassword] [varchar](255) NULL,
	[CustomsSupportedFlag] [bit] NULL,
	[ElinkFlag] [bit] NULL,
	[PARS] [nchar](25) NULL,
	[PASS] [nchar](25) NULL,
	[CustomsBroker] [nchar](255) NULL,
	[SupportUser] [varchar](50) NULL,
	[SupportGroup] [varchar](50) NULL,
	[Office] [varchar](50) NULL,
	[Group] [varchar](50) NULL,
	[MigrationDate] [datetime] NULL,
	[PreMigrationSolution] [varchar](3000) NULL,
	[PostMigrationSolution] [varchar](3000) NULL,
	[ControlBranch] [varchar](10) NULL,
	[ContractNumber] [varchar](25) NULL,
	[ContractStartDate] [datetime] NULL,
	[ContractEndDate] [datetime] NULL,
	[ContractCurrency] [varchar](10) NULL,
	[PaymentTerms] [varchar](255) NULL,
	[CloseReason] [varchar](255) NULL,
	[CRR] [varchar](255) NULL,
	[BrokerNumber] [varchar](50) NULL,
	[DataScrubFlag] [bit] NULL,
	[EDICustomizedFlag] [bit] NULL,
	[StrategicFlag] [bit] NULL,
	[ReturnsAcctNbr] [varchar](25) NULL,
	[ReturnsAddress] [varchar](255) NULL,
	[ReturnsCity] [varchar](255) NULL,
	[ReturnsState] [varchar](255) NULL,
	[ReturnsZip] [varchar](25) NULL,
	[ReturnsCountry] [varchar](25) NULL,
	[ReturnsDestroyFlag] [bit] NULL,
	[ReturnsCreateLabelFlag] [bit] NULL,
	[WPKSandboxUsername] [varchar](50) NULL,
	[WPKSandboxPwd] [varchar](50) NULL,
	[WPKProdUsername] [varchar](50) NULL,
	[WPKProdPwd] [varchar](50) NULL,
	[WPKCustomExportFlag] [bit] NULL,
	[WPKGhostScanFlag] [bit] NULL,
	[WPKEastWestSplitFlag] [bit] NULL,
	[WPKAddressUploadFlag] [bit] NULL,
	[WPKProductUploadFlag] [bit] NULL,
	[WPKDataEntryMethod] [varchar](50) NULL,
	[WPKEquipmentFlag] [bit] NULL,
	[EWSelectBy] [varchar](50) NULL,
	[EWSortCodeFlag] [bit] NULL,
	[EWEastSortCode] [varchar](50) NULL,
	[EWWestSortCode] [varchar](50) NULL,
	[EWSepCloseoutFlag] [bit] NULL,
	[EWSepPUFlag] [bit] NULL,
	[EWSortDetails] [varchar](max) NULL,
	[EWMissortDetails] [varchar](max) NULL,
	[CurrentGoLive] [datetime] NULL,
	[PhaseChangeDate] [datetime] NULL,
	[idRequestType] [int] NULL,
	[CurrentlyShippingFlag] [bit] NULL,
	[idShippingVendor] [int] NULL,
	[OtherVendorName] [varchar](255) NULL,
	[idBroker] [int] NULL,
	[OtherBrokerName] [varchar](255) NULL,
	[idVendorType] [int] NULL,
	[Route] [varchar](2000) NULL,
	[idSolutionType] [int] NULL,
	[FreightAuditor] [bit] NULL,
	[EDIDetails] [varchar](3000) NULL,
	[idEDISpecialist] [int] NULL,
	[idBillingSpecialist] [int] NULL,
	[idCollectionSpecialist] [int] NULL,
	[AuditorPortal] [bit] NULL,
	[AuditorURL] [varchar](255) NULL,
	[AuditorUserName] [varchar](255) NULL,
	[AuditorPassword] [varchar](255) NULL,
	[EDITargetGoLive] [datetime] NULL,
	[EDICurrentGoLive] [datetime] NULL,
	[EDIActualGoLive] [datetime] NULL,
	[idEDIOnboardingPhase] [int] not NULL,
 CONSTRAINT [PK_tblDiscoveryRequest_Archive] PRIMARY KEY CLUSTERED 
(
	[idRequest_Archive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE dbo.[Tmp_tblDiscoveryRequest_Archive] SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.[Tmp_tblDiscoveryRequest_Archive] ON
GO
IF EXISTS(SELECT * FROM dbo.[tblDiscoveryRequest_Archive])
	EXEC('INSERT INTO dbo.Tmp_tblDiscoveryRequest_Archive 
			(
				idRequest_Archive,idRequest,TableAction,
				isNewRequest,SalesRepName,SalesRepEmail,idOnboardingPhase,District,CustomerName,Address,City,State,Zipcode,Country,Commodity,ProjectedRevenue,
				CurrentSolution,ProposedCustoms,CallDate1,CallDate2,CallDate3,
				UpdatedBy,UpdatedOn,CreatedBy,CreatedOn,ActiveFlag,SalesComments,idITBA,idShippingChannel,TargetGoLive,ActualGoLive,SolutionSummary,CustomerWebsite,Branch,idVendor,worldpakFlag,
				thirdpartyFlag,customFlag,
				InvoiceType,BilltoAccount,FTPUsername,FTPPassword,CustomsSupportedFlag,ElinkFlag,PARS,PASS,CustomsBroker,SupportUser,SupportGroup,Office,[Group],MigrationDate,
				PreMigrationSolution,PostMigrationSolution,ControlBranch,ContractNumber,ContractStartDate,ContractEndDate,ContractCurrency,PaymentTerms,CloseReason,CRR,BrokerNumber,DataScrubFlag,
				EDICustomizedFlag,StrategicFlag,ReturnsAcctNbr,ReturnsAddress,ReturnsCity,ReturnsState,ReturnsZip,ReturnsCountry,ReturnsDestroyFlag,ReturnsCreateLabelFlag,WPKSandboxUsername,
				WPKSandboxPwd,WPKProdUsername,WPKProdPwd,WPKCustomExportFlag,WPKGhostScanFlag,WPKEastWestSplitFlag,WPKAddressUploadFlag,WPKProductUploadFlag,WPKDataEntryMethod,WPKEquipmentFlag,
				EWSelectBy,EWSortCodeFlag,EWEastSortCode,EWWestSortCode,EWSepCloseoutFlag,EWSepPUFlag,EWSortDetails,EWMissortDetails,CurrentGoLive,PhaseChangeDate,idRequestType,CurrentlyShippingFlag,
				idShippingVendor,OtherVendorName,idBroker,OtherBrokerName,idVendorType,Route,idSolutionType,FreightAuditor,EDIDetails,idEDISpecialist,idBillingSpecialist,idCollectionSpecialist,
				AuditorPortal,AuditorURL,AuditorUserName,AuditorPassword,EDITargetGoLive,EDICurrentGoLive,EDIActualGoLive,idEDIOnboardingPhase
			)
			SELECT  
				idRequest_Archive,idRequest,TableAction,
				isNewRequest,SalesRepName,SalesRepEmail,idOnboardingPhase,District,CustomerName,Address,City,State,Zipcode,Country,Commodity,ProjectedRevenue,
				CurrentSolution,ProposedCustoms,CallDate1,CallDate2,CallDate3,
				UpdatedBy,UpdatedOn,CreatedBy,CreatedOn,ActiveFlag,SalesComments,idITBA,idShippingChannel,TargetGoLive,ActualGoLive,SolutionSummary,CustomerWebsite,Branch,idVendor,worldpakFlag,
				thirdpartyFlag,customFlag,
				null,null,null,null,null,null,null,null,null,null,null,null,null,null,
				null,null,null,null,null,null,null,null,CloseReason,null,null,DataScrubFlag,
				null,StrategicFlag,null,null,null,null,null,null,null,null,null,
				null,null,null,null,null,null,null,null,null,null,
				null,null,null,null,null,null,null,null,CurrentGoLive,null,null,null,
				null,null,null,null,null,null,null,null,null,null,null,null,
				null,null,null,null,null,null,null,0
			FROM dbo.[tblDiscoveryRequest_Archive] WITH (HOLDLOCK TABLOCKX)'
		)
GO
SET IDENTITY_INSERT dbo.[Tmp_tblDiscoveryRequest_Archive] OFF
GO
DROP TABLE dbo.tblDiscoveryRequest_Archive
GO
EXECUTE sp_rename N'dbo.[Tmp_tblDiscoveryRequest_Archive]', N'tblDiscoveryRequest_Archive', 'OBJECT' 
GO

--ALTER TABLE [tblDiscoveryRequest_Archive]
--	ADD CONSTRAINT [PK_tblDiscoveryRequest_Archive] PRIMARY KEY ([idRequest_Archive]);


--select * from tblDiscoveryRequest_Archive
-- 161
--select idRequest_Archive,CloseReason,DataScrubFlag,StrategicFlag,CurrentGoLive from tblDiscoveryRequest_Archive where CloseReason is not null or currentgolive is not null or strategicflag = 1

