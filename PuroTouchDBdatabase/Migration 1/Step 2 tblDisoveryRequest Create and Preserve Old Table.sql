--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv4]
GO

/****** Object:  Table [dbo].[tblDiscoveryRequest_]    Script Date: 2021/03/15 8:43:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
BEGIN TRANSACTION
go

IF OBJECT_ID(N'dbo.tblEDIShipMethods', N'U') IS NOT NULL
begin
	print 'Exists -- tblEDIShipMethods table'
	IF OBJECT_ID('dbo.[FK_idRequest_DiscoveryRequest]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idRequest_DiscoveryRequest CONSTRAINT'
		ALTER TABLE [dbo].[tblEDIShipMethods]
			DROP CONSTRAINT [FK_idRequest_DiscoveryRequest]
	end
end
go 

IF OBJECT_ID(N'dbo.tblEDITranscations', N'U') IS NOT NULL
begin
	print 'Exists -- tblEDITranscations table'
	IF OBJECT_ID('dbo.[FK_idReq_EDITran_DisReq]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idReq_EDITran_DisReq CONSTRAINT'
		ALTER TABLE [dbo].[tblEDITranscations]
			DROP CONSTRAINT [FK_idReq_EDITran_DisReq]
	end
end
go

IF OBJECT_ID(N'dbo.tblFreightAuditorsDiscReq', N'U') IS NOT NULL
begin
	print 'Exists -- tblFreightAuditorsDiscReq table'
	IF OBJECT_ID('dbo.[FK_idRequest_tblFreightAuditorsDiscReq]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idRequest_tblFreightAuditorsDiscReq CONSTRAINT'
		ALTER TABLE [dbo].[tblFreightAuditorsDiscReq]
			DROP CONSTRAINT [FK_idRequest_tblFreightAuditorsDiscReq]
	end
end
go

IF OBJECT_ID(N'dbo.tblEDITranscations', N'U') IS NOT NULL
begin
	print 'Exists -- tblEDITranscations table'
	IF OBJECT_ID('dbo.[FK_idReq_EDITran_DisReq]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idReq_EDITran_DisReq CONSTRAINT'
		ALTER TABLE [dbo].[tblEDITranscations]
			DROP CONSTRAINT [FK_idReq_EDITran_DisReq]
	end
end
go

IF OBJECT_ID(N'dbo.tblEDIShipMethods', N'U') IS NOT NULL
begin
	print 'Exists -- tblEDIShipMethods table'
	IF OBJECT_ID('dbo.[FK_idRequest_DiscoveryRequest]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idRequest_DiscoveryRequest CONSTRAINT'
		ALTER TABLE [dbo].[tblEDIShipMethods]
			DROP CONSTRAINT [FK_idRequest_DiscoveryRequest]
	end
end
go

IF OBJECT_ID(N'dbo.tblDiscoveryRequest', N'U') IS NOT NULL
begin
	print 'Exists -- tblDiscoveryRequest table'
	IF OBJECT_ID('dbo.[PK_tblDiscoveryRequest]') IS NOT NULL 
	begin
		print 'Exists -- So drop PK_tblDiscoveryRequest CONSTRAINT'
		ALTER TABLE [dbo].[tblDiscoveryRequest]
			DROP CONSTRAINT [PK_tblDiscoveryRequest]
	end
end
go

IF OBJECT_ID(N'dbo.tblDiscoveryRequest', N'U') IS NOT NULL
begin
	print 'Exists -- tblDiscoveryRequest table'
	IF OBJECT_ID('dbo.[FK_idOnBPh_OnboardPhase]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idOnBPh_OnboardPhase CONSTRAINT'
		ALTER TABLE [dbo].[tblDiscoveryRequest]
			DROP CONSTRAINT [FK_idOnBPh_OnboardPhase]
	end
end
go

IF OBJECT_ID(N'dbo.tblDiscoveryRequest', N'U') IS NOT NULL
begin
	print 'Exists -- tblDiscoveryRequest table'
	IF OBJECT_ID('dbo.[FK_idEDIOnboard_Disc_EDIOnB]') IS NOT NULL 
	begin
		print 'Exists -- So drop FK_idEDIOnboard_Disc_EDIOnB CONSTRAINT'
		ALTER TABLE [dbo].[tblDiscoveryRequest]
			DROP CONSTRAINT [FK_idEDIOnboard_Disc_EDIOnB]
	end
end
go

create TABLE [dbo].[Tmp_tblDiscoveryRequest](
	[idRequest] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_tblDiscoveryRequest] PRIMARY KEY CLUSTERED 
(
	[idRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE dbo.[Tmp_tblDiscoveryRequest] SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.[Tmp_tblDiscoveryRequest] ON
GO
IF EXISTS(SELECT * FROM dbo.[tblDiscoveryRequest])
	EXEC('INSERT INTO dbo.Tmp_tblDiscoveryRequest 
			(
				idRequest,isNewRequest,SalesRepName,SalesRepEmail,idOnboardingPhase,District,CustomerName,Address,City,State,Zipcode,Country,Commodity,ProjectedRevenue,
				CurrentSolution,ProposedCustoms,CallDate1,CallDate2,CallDate3,
				UpdatedBy,UpdatedOn,CreatedBy,CreatedOn,ActiveFlag,SalesComments,idITBA,idShippingChannel,TargetGoLive,ActualGoLive,SolutionSummary,CustomerWebsite,Branch,idVendor,worldpakFlag,
				thirdpartyFlag,customFlag,InvoiceType,BilltoAccount,FTPUsername,FTPPassword,CustomsSupportedFlag,ElinkFlag,PARS,PASS,CustomsBroker,SupportUser,SupportGroup,Office,[Group],MigrationDate,
				PreMigrationSolution,PostMigrationSolution,ControlBranch,ContractNumber,ContractStartDate,ContractEndDate,ContractCurrency,PaymentTerms,CloseReason,CRR,BrokerNumber,DataScrubFlag,
				EDICustomizedFlag,StrategicFlag,ReturnsAcctNbr,ReturnsAddress,ReturnsCity,ReturnsState,ReturnsZip,ReturnsCountry,ReturnsDestroyFlag,ReturnsCreateLabelFlag,WPKSandboxUsername,
				WPKSandboxPwd,WPKProdUsername,WPKProdPwd,WPKCustomExportFlag,WPKGhostScanFlag,WPKEastWestSplitFlag,WPKAddressUploadFlag,WPKProductUploadFlag,WPKDataEntryMethod,WPKEquipmentFlag,
				EWSelectBy,EWSortCodeFlag,EWEastSortCode,EWWestSortCode,EWSepCloseoutFlag,EWSepPUFlag,EWSortDetails,EWMissortDetails,CurrentGoLive,PhaseChangeDate,idRequestType,CurrentlyShippingFlag,
				idShippingVendor,OtherVendorName,idBroker,OtherBrokerName,idVendorType,Route,idSolutionType,FreightAuditor,EDIDetails,idEDISpecialist,idBillingSpecialist,idCollectionSpecialist,
				AuditorPortal,AuditorURL,AuditorUserName,AuditorPassword,EDITargetGoLive,EDICurrentGoLive,EDIActualGoLive,idEDIOnboardingPhase
			)
			SELECT  
				idRequest,isNewRequest,SalesRepName,SalesRepEmail,idOnboardingPhase,District,CustomerName,Address,City,State,Zipcode,Country,Commodity,ProjectedRevenue,
				CurrentSolution,ProposedCustoms,CallDate1,CallDate2,CallDate3,
				UpdatedBy,UpdatedOn,CreatedBy,CreatedOn,ActiveFlag,SalesComments,idITBA,idShippingChannel,TargetGoLive,ActualGoLive,SolutionSummary,CustomerWebsite,Branch,idVendor,worldpakFlag,
				thirdpartyFlag,customFlag,InvoiceType,BilltoAccount,FTPUsername,FTPPassword,CustomsSupportedFlag,ElinkFlag,PARS,PASS,CustomsBroker,SupportUser,SupportGroup,Office,[Group],MigrationDate,
				PreMigrationSolution,PostMigrationSolution,ControlBranch,ContractNumber,ContractStartDate,ContractEndDate,ContractCurrency,PaymentTerms,CloseReason,CRR,BrokerNumber,DataScrubFlag,
				EDICustomizedFlag,StrategicFlag,ReturnsAcctNbr,ReturnsAddress,ReturnsCity,ReturnsState,ReturnsZip,ReturnsCountry,ReturnsDestroyFlag,ReturnsCreateLabelFlag,WPKSandboxUsername,
				WPKSandboxPwd,WPKProdUsername,WPKProdPwd,WPKCustomExportFlag,WPKGhostScanFlag,WPKEastWestSplitFlag,WPKAddressUploadFlag,WPKProductUploadFlag,WPKDataEntryMethod,WPKEquipmentFlag,
				EWSelectBy,EWSortCodeFlag,EWEastSortCode,EWWestSortCode,EWSepCloseoutFlag,EWSepPUFlag,EWSortDetails,EWMissortDetails,CurrentGoLive,PhaseChangeDate,idRequestType,currentlyShippingFlag,
				idShippingVendor,OtherVendorName,idBroker,OtherBrokerName,idVendorType,Route,idSolutionType,0,null,null,null,null,
				0,null,null,null,null,null,null,0
			FROM dbo.[tblDiscoveryRequest] WITH (HOLDLOCK TABLOCKX)'
		)
GO
SET IDENTITY_INSERT dbo.[Tmp_tblDiscoveryRequest] OFF
GO
DROP TABLE dbo.tblDiscoveryRequest
GO
EXECUTE sp_rename N'dbo.[Tmp_tblDiscoveryRequest]', N'tblDiscoveryRequest', 'OBJECT' 
GO
COMMIT

--ALTER TABLE [dbo].[tblDiscoveryRequest]  WITH CHECK ADD  CONSTRAINT [FK_idOnBPh_OnboardPhase] FOREIGN KEY([idOnboardingPhase])
--REFERENCES [dbo].[tblOnboardingPhase] ([idOnboardingPhase])
--GO

--ALTER TABLE [dbo].[tblDiscoveryRequest] WITH CHECK ADD  CONSTRAINT [FK_idEDIOnboard_Disc_EDIOnB] FOREIGN KEY([idEDIOnboardingPhase])
--REFERENCES [dbo].[tblEDIOnboardingPhase]  ([idEDIOnboardingPhase])
--GO

--ALTER TABLE [tblDiscoveryRequest]
--	ADD CONSTRAINT [PK_tblDiscoveryRequest] PRIMARY KEY ([idRequest]);

--ALTER TABLE [dbo].[tblFreightAuditorsDiscReq]  WITH CHECK ADD  CONSTRAINT [FK_idRequest_tblFreightAuditorsDiscReq] FOREIGN KEY([idRequest])
--REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
--GO
--ALTER TABLE [dbo].[tblEDITranscations]  WITH CHECK ADD  CONSTRAINT [FK_idReq_EDITran_DisReq] FOREIGN KEY([idRequest])
--REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
--GO
--ALTER TABLE [dbo].[tblEDIShipMethods]  WITH CHECK ADD  CONSTRAINT [FK_idRequest_DiscoveryRequest] FOREIGN KEY([idRequest])
--REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
--GO



--select * from [Tmp_tblDiscoveryRequest]
--select * from [tblDiscoveryRequest]
--select CurrentlyShippingFlag,* from tblDiscoveryRequest

