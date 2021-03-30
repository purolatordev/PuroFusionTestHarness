﻿CREATE TABLE [dbo].[tblDiscoveryRequest] (
    [idRequest]              INT            IDENTITY (1, 1) NOT NULL,
    [isNewRequest]           BIT            NULL,
    [SalesRepName]           VARCHAR (255)  NULL,
    [SalesRepEmail]          VARCHAR (255)  NULL,
    [idOnboardingPhase]      INT            NULL,
    [District]               VARCHAR (255)  NULL,
    [CustomerName]           VARCHAR (255)  NULL,
    [Address]                VARCHAR (255)  NULL,
    [City]                   VARCHAR (255)  NULL,
    [State]                  VARCHAR (255)  NULL,
    [Zipcode]                VARCHAR (255)  NULL,
    [Country]                VARCHAR (255)  NULL,
    [Commodity]              VARCHAR (255)  NULL,
    [ProjectedRevenue]       MONEY          NULL,
    [CurrentSolution]        VARCHAR (3000) NULL,
    [ProposedCustoms]        VARCHAR (2000) NULL,
    [CallDate1]              DATETIME       NULL,
    [CallDate2]              DATETIME       NULL,
    [CallDate3]              DATETIME       NULL,
    [UpdatedBy]              VARCHAR (100)  NULL,
    [UpdatedOn]              DATETIME       NULL,
    [CreatedBy]              VARCHAR (100)  NULL,
    [CreatedOn]              DATETIME       NULL,
    [ActiveFlag]             BIT            NULL,
    [SalesComments]          VARCHAR (3000) NULL,
    [idITBA]                 INT            NULL,
    [idShippingChannel]      INT            NULL,
    [TargetGoLive]           DATETIME       NULL,
    [ActualGoLive]           DATETIME       NULL,
    [SolutionSummary]        VARCHAR (3000) NULL,
    [CustomerWebsite]        VARCHAR (500)  NULL,
    [Branch]                 NVARCHAR (50)  NULL,
    [idVendor]               INT            NULL,
    [worldpakFlag]           BIT            NULL,
    [thirdpartyFlag]         BIT            NULL,
    [customFlag]             BIT            NULL,
    [InvoiceType]            VARCHAR (50)   NULL,
    [BilltoAccount]          VARCHAR (50)   NULL,
    [FTPUsername]            VARCHAR (255)  NULL,
    [FTPPassword]            VARCHAR (255)  NULL,
    [CustomsSupportedFlag]   BIT            NULL,
    [ElinkFlag]              BIT            NULL,
    [PARS]                   NCHAR (25)     NULL,
    [PASS]                   NCHAR (25)     NULL,
    [CustomsBroker]          NCHAR (255)    NULL,
    [SupportUser]            VARCHAR (50)   NULL,
    [SupportGroup]           VARCHAR (50)   NULL,
    [Office]                 VARCHAR (50)   NULL,
    [Group]                  VARCHAR (50)   NULL,
    [MigrationDate]          DATETIME       NULL,
    [PreMigrationSolution]   VARCHAR (3000) NULL,
    [PostMigrationSolution]  VARCHAR (3000) NULL,
    [ControlBranch]          VARCHAR (10)   NULL,
    [ContractNumber]         VARCHAR (25)   NULL,
    [ContractStartDate]      DATETIME       NULL,
    [ContractEndDate]        DATETIME       NULL,
    [ContractCurrency]       VARCHAR (10)   NULL,
    [PaymentTerms]           VARCHAR (255)  NULL,
    [CloseReason]            VARCHAR (255)  NULL,
    [CRR]                    VARCHAR (255)  NULL,
    [BrokerNumber]           VARCHAR (50)   NULL,
    [DataScrubFlag]          BIT            NULL,
    [EDICustomizedFlag]      BIT            NULL,
    [StrategicFlag]          BIT            NULL,
    [ReturnsAcctNbr]         VARCHAR (25)   NULL,
    [ReturnsAddress]         VARCHAR (255)  NULL,
    [ReturnsCity]            VARCHAR (255)  NULL,
    [ReturnsState]           VARCHAR (255)  NULL,
    [ReturnsZip]             VARCHAR (25)   NULL,
    [ReturnsCountry]         VARCHAR (25)   NULL,
    [ReturnsDestroyFlag]     BIT            NULL,
    [ReturnsCreateLabelFlag] BIT            NULL,
    [WPKSandboxUsername]     VARCHAR (50)   NULL,
    [WPKSandboxPwd]          VARCHAR (50)   NULL,
    [WPKProdUsername]        VARCHAR (50)   NULL,
    [WPKProdPwd]             VARCHAR (50)   NULL,
    [WPKCustomExportFlag]    BIT            NULL,
    [WPKGhostScanFlag]       BIT            NULL,
    [WPKEastWestSplitFlag]   BIT            NULL,
    [WPKAddressUploadFlag]   BIT            NULL,
    [WPKProductUploadFlag]   BIT            NULL,
    [WPKDataEntryMethod]     VARCHAR (50)   NULL,
    [WPKEquipmentFlag]       BIT            NULL,
    [EWSelectBy]             VARCHAR (50)   NULL,
    [EWSortCodeFlag]         BIT            NULL,
    [EWEastSortCode]         VARCHAR (50)   NULL,
    [EWWestSortCode]         VARCHAR (50)   NULL,
    [EWSepCloseoutFlag]      BIT            NULL,
    [EWSepPUFlag]            BIT            NULL,
    [EWSortDetails]          VARCHAR (MAX)  NULL,
    [EWMissortDetails]       VARCHAR (MAX)  NULL,
    [CurrentGoLive]          DATETIME       NULL,
    [PhaseChangeDate]        DATETIME       NULL,
    [idRequestType]          INT            NULL,
    [CurrentlyShippingFlag]  BIT            NULL,
    [idShippingVendor]       INT            NULL,
    [OtherVendorName]        VARCHAR (255)  NULL,
    [idBroker]               INT            NULL,
    [OtherBrokerName]        VARCHAR (255)  NULL,
    [idVendorType]           INT            NULL,
    [Route]                  VARCHAR (2000) NULL,
    [idSolutionType]         INT            NULL,
    [FreightAuditor]         BIT            NULL,
    [EDIDetails]             VARCHAR (3000) NULL,
    [idEDISpecialist]        INT            NULL,
    [idBillingSpecialist]    INT            NULL,
    [idCollectionSpecialist] INT            NULL,
    [AuditorPortal]          BIT            NULL,
    [AuditorURL]             VARCHAR (255)  NULL,
    [AuditorUserName]        VARCHAR (255)  NULL,
    [AuditorPassword]        VARCHAR (255)  NULL,
    [EDITargetGoLive]        DATETIME       NULL,
    [EDICurrentGoLive]       DATETIME       NULL,
    [EDIActualGoLive]        DATETIME       NULL,
    [idEDIOnboardingPhase]   INT            NOT NULL,
    CONSTRAINT [PK_tblDiscoveryRequest] PRIMARY KEY CLUSTERED ([idRequest] ASC),
    CONSTRAINT [FK_idEDIOnboard_Disc_EDIOnB] FOREIGN KEY ([idEDIOnboardingPhase]) REFERENCES [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase]),
    CONSTRAINT [FK_idOnBPh_OnboardPhase] FOREIGN KEY ([idOnboardingPhase]) REFERENCES [dbo].[tblOnboardingPhase] ([idOnboardingPhase])
);





