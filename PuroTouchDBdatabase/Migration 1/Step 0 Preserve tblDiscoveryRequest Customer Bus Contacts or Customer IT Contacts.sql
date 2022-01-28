--USE [PuroTouchDB_Prod]
USE [PuroTouchDBv4]
GO


/****** Object:  Table [dbo].[tblDiscoveryRequest]    Script Date: 8/2/2021 5:20:31 PM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

IF OBJECT_ID(N'dbo.tmp_tblDiscoveryRequestCustomerInfo', N'U') IS NOT NULL
begin
	print 'Exists -- So drop tmp_tblDiscoveryRequestCustomerInfo table'
	drop table [tmp_tblDiscoveryRequestCustomerInfo]
end
IF OBJECT_ID(N'dbo.tmp_tblDiscoveryRequestCustomerInfo', N'U') IS NULL
begin
	print 'Does not exists -- So create tmp_tblDiscoveryRequestCustomerInfo table'

	CREATE TABLE dbo.tmp_tblDiscoveryRequestCustomerInfo (
	[idRequest] [int]  NOT NULL,
	[CustomerBusContact] [varchar](255) NULL,
	[CustomerBusTitle] [varchar](255) NULL,
	[CustomerBusEmail] [varchar](255) NULL,
	[CustomerBusPhone] [varchar](255) NULL,
	[CustomerITContact] [varchar](255) NULL,
	[CustomerITTitle] [varchar](255) NULL,
	[CustomerITEmail] [varchar](255) NULL,
	[CustomerITPhone] [varchar](255) NULL,
	)

	INSERT INTO dbo.tmp_tblDiscoveryRequestCustomerInfo 
	(
		idRequest,
		CustomerBusContact,CustomerBusTitle,CustomerBusEmail,CustomerBusPhone,
		CustomerITContact,CustomerITTitle,CustomerITEmail,CustomerITPhone			
	)
	SELECT  
		idRequest,
		CustomerBusContact,CustomerBusTitle,CustomerBusEmail,CustomerBusPhone,
		CustomerITContact,CustomerITTitle,CustomerITEmail,CustomerITPhone			
	FROM dbo.[tblDiscoveryRequest] 

end


--select * from tmp_tblDiscoveryRequestCustomerInfo
--select * from tblDiscoveryRequest
--drop table [tmp_tblDiscoveryRequestCustomerInfo]

--select [idRequest],[CustomerBusContact],[CustomerBusTitle],[CustomerBusEmail],[CustomerBusPhone],
--CustomerITContact,[CustomerITTitle],[CustomerITEmail],[CustomerITPhone] 
--from tblDiscoveryRequest 
--where  CustomerBusContact is not null or CustomerITContact is not null