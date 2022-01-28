--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv4]
GO
CREATE TABLE [dbo].[tblAccountMasterDescriptions] (
    [Column]              NVARCHAR (255) NULL,
    [Header]              NVARCHAR (255) NULL,
    [Input Type]          NVARCHAR (255) NULL,
    [Description]         NVARCHAR (255) NULL,
    [Additional Comments] NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].[tblBillingSpecialist] (
    [idBillingSpecialist] INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee]          INT           NOT NULL,
    [UpdatedBy]           VARCHAR (100) NULL,
    [UpdatedOn]           DATETIME      NULL,
    [CreatedBy]           VARCHAR (100) NULL,
    [CreatedOn]           DATETIME      NULL,
    [ActiveFlag]          BIT           NULL,
    [email]               VARCHAR (255) NULL,
    [ReceiveNewReqEmail]  BIT           NULL,
    [login]               VARCHAR (50)  NULL,
    CONSTRAINT [PK_tblBillingSpecialist] PRIMARY KEY CLUSTERED ([idBillingSpecialist] ASC)
);
GO

CREATE TABLE [dbo].[tblBillingTypeRel] (
    [idBillingTypeRel]    INT NULL,
    [idBillingType]       INT NULL,
    [idBillingTypedetail] INT NULL
);
GO

CREATE TABLE [dbo].[tblCollectionSpecialist] (
    [idCollectionSpecialist] INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee]             INT           NOT NULL,
    [UpdatedBy]              VARCHAR (100) NULL,
    [UpdatedOn]              DATETIME      NULL,
    [CreatedBy]              VARCHAR (100) NULL,
    [CreatedOn]              DATETIME      NULL,
    [ActiveFlag]             BIT           NULL,
    [email]                  VARCHAR (255) NULL,
    [ReceiveNewReqEmail]     BIT           NULL,
    [login]                  VARCHAR (50)  NULL,
    CONSTRAINT [PK_tblCollectionSpecialist] PRIMARY KEY CLUSTERED ([idCollectionSpecialist] ASC)
);
GO

CREATE TABLE [dbo].[tblContactType] (
    [idContactType] INT          IDENTITY (1, 1) NOT NULL,
    [ContactType]   VARCHAR (50) NULL,
    [UpdatedBy]     VARCHAR (50) NULL,
    [UpdatedOn]     DATETIME     NULL,
    [CreatedBy]     VARCHAR (50) NULL,
    [CreatedOn]     DATETIME     NULL,
    [ActiveFlag]    BIT          NULL,
    CONSTRAINT [PK_tblContactType] PRIMARY KEY CLUSTERED ([idContactType] ASC)
);
GO

CREATE TABLE [dbo].[tblContact] (
    [idContact]     INT            IDENTITY (1, 1) NOT NULL,
    [idRequest]     INT            NOT NULL,
    [idContactType] INT            NOT NULL,
    [Name]          NVARCHAR (255) NULL,
    [Title]         NVARCHAR (255) NULL,
    [Phone]         NVARCHAR (255) NULL,
    [Email]         NVARCHAR (255) NULL,
    [CreatedBy]     NVARCHAR (100) NULL,
    [CreatedOn]     DATETIME       NULL,
    [UpdatedBy]     NVARCHAR (100) NULL,
    [UpdatedOn]     DATETIME       NULL,
    [ActiveFlag]    BIT            NULL,
    CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED ([idContact] ASC),
    CONSTRAINT [FK_idContactType_ContactType] FOREIGN KEY ([idContactType]) REFERENCES [dbo].[tblContactType] ([idContactType])
);
GO

CREATE TABLE [dbo].[tblCustomerProfile] (
    [idCustomerProfile]        INT           NULL,
    [CompanyName]              VARCHAR (255) NULL,
    [CompanyWebsite]           VARCHAR (255) NULL,
    [PrimBusinessContact]      VARCHAR (255) NULL,
    [PrimBusinessContactPhone] VARCHAR (255) NULL,
    [PrimBusinessContactEmail] VARCHAR (255) NULL,
    [idProducttypeRel]         INT           NULL,
    [idBillingTyperel]         INT           NULL,
    [idSolutionType]           INT           NULL,
    [elink]                    VARCHAR (50)  NULL,
    [CustomsSupported]         NVARCHAR (50) NULL,
    [Brokername]               VARCHAR (50)  NULL,
    [PASSNo]                   VARCHAR (50)  NULL,
    [PARSNo]                   VARCHAR (50)  NULL,
    [CreatedBy]                VARCHAR (50)  NULL,
    [CreatedDate]              DATETIME      NULL,
    [ModifiedBy]               VARCHAR (50)  NULL,
    [ModifiedDate]             DATETIME      NULL
);
GO

CREATE TABLE [dbo].[tblCustomizedCustomersegment] (
    [Details Tab# ] NVARCHAR (255) NULL,
    [F2]            NVARCHAR (255) NULL,
    [F3]            NVARCHAR (255) NULL,
    [F4]            NVARCHAR (255) NULL,
    [F5]            NVARCHAR (255) NULL,
    [F6]            NVARCHAR (255) NULL,
    [F7]            NVARCHAR (255) NULL,
    [F8]            NVARCHAR (255) NULL,
    [F9]            NVARCHAR (255) NULL,
    [F10]           NVARCHAR (255) NULL,
    [F11]           NVARCHAR (255) NULL,
    [F12]           NVARCHAR (255) NULL,
    [F13]           NVARCHAR (255) NULL,
    [F14]           NVARCHAR (255) NULL,
    [F15]           NVARCHAR (255) NULL,
    [F16]           NVARCHAR (255) NULL,
    [F17]           NVARCHAR (255) NULL,
    [F18]           NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].[tblDRContacts] (
    [idContact]     INT           IDENTITY (1, 1) NOT NULL,
    [idRequest]     INT           NULL,
    [idContactType] INT           NULL,
    [Contact]       VARCHAR (255) NULL,
    [Title]         VARCHAR (255) NULL,
    [Email]         VARCHAR (255) NULL,
    [Phone]         VARCHAR (255) NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblDRContacts] PRIMARY KEY CLUSTERED ([idContact] ASC)
);

CREATE TABLE [dbo].[tblEDITranscationType] (
    [idEDITranscationType] INT          IDENTITY (1, 1) NOT NULL,
    [EDITranscationType]   VARCHAR (50) NULL,
    [CategoryID]           INT          NOT NULL,
    [Category]             VARCHAR (50) NOT NULL,
    [UpdatedBy]            VARCHAR (50) NULL,
    [UpdatedOn]            DATETIME     NULL,
    [CreatedBy]            VARCHAR (50) NULL,
    [CreatedOn]            DATETIME     NULL,
    [ActiveFlag]           BIT          NULL,
    CONSTRAINT [PK_tblEDITranscationType] PRIMARY KEY CLUSTERED ([idEDITranscationType] ASC)
);
GO

SET IDENTITY_INSERT [dbo].[tblEDITranscationType] ON 
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Invoice', 0, N'None', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-14T10:38:14.407' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Shipment Status', 0, N'None', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-14T10:38:14.410' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Invoice', 1, N'Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-14T10:38:14.410' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'Shipment Status', 1, N'Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-14T10:38:14.410' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'Invoice', 2, N'Non Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-14T10:38:14.410' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (6, N'Shipment Status', 2, N'Non Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-14T10:38:14.410' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (7, N'PuroPost Standard', 3, N'Non Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-26T16:56:38.973' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (8, N'Invoice Test', 2, N'Non Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-05-10T12:04:11.223' AS DateTime), 1)
GO
INSERT [dbo].[tblEDITranscationType] ([idEDITranscationType], [EDITranscationType], [CategoryID], [Category], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (9, N'Shipment Status Test', 2, N'Non Courier EDI', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-05-10T12:04:11.223' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblEDITranscationType] OFF
GO

CREATE TABLE [dbo].[tblEDITranscations] (
    [idEDITranscation]     INT            IDENTITY (1, 1) NOT NULL,
    [idRequest]            INT            NOT NULL,
    [idEDITranscationType] INT            NOT NULL,
    [TotalRequests]        INT            NOT NULL,
    [CombinePayer]         BIT            NULL,
    [BatchInvoices]        BIT            NULL,
    [SFTPFolder]           VARCHAR (255)  NULL,
    [TestEnvironment]      BIT            NULL,
    [TestSentMethod]       INT            NOT NULL,
    [CreatedBy]            NVARCHAR (100) NULL,
    [CreatedOn]            DATETIME       NULL,
    [UpdatedBy]            NVARCHAR (100) NULL,
    [UpdatedOn]            DATETIME       NULL,
    [ActiveFlag]           BIT            NULL,
    CONSTRAINT [PK_tblEDITranscationsv2] PRIMARY KEY CLUSTERED ([idEDITranscation] ASC),
    CONSTRAINT [FK_idEDITransType_EDITransType] FOREIGN KEY ([idEDITranscationType]) REFERENCES [dbo].[tblEDITranscationType] ([idEDITranscationType]),
    CONSTRAINT [FK_idReq_EDITran_DisReq] FOREIGN KEY ([idRequest]) REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
);
GO

CREATE TABLE [dbo].[tblEDIAccounts] (
    [idEDIAccount]       INT            IDENTITY (1, 1) NOT NULL,
    [AccountNumber]      VARCHAR (50)   NULL,
    [idRequest]          INT            NOT NULL,
    [idEDITranscation]   INT            NOT NULL,
    [EDITranscationType] VARCHAR (50)   NULL,
    [Category]           VARCHAR (50)   NOT NULL,
    [CreatedBy]          NVARCHAR (100) NULL,
    [CreatedOn]          DATETIME       NULL,
    [UpdatedBy]          NVARCHAR (100) NULL,
    [UpdatedOn]          DATETIME       NULL,
    [ActiveFlag]         BIT            NULL,
    CONSTRAINT [PK_tbltblEDIAccounts] PRIMARY KEY CLUSTERED ([idEDIAccount] ASC),
    CONSTRAINT [FK_idTrans_Accts_Trans] FOREIGN KEY ([idEDITranscation]) REFERENCES [dbo].[tblEDITranscations] ([idEDITranscation])
);
GO

CREATE TABLE [dbo].[tblEDIOnboardingPhase] (
    [idEDIOnboardingPhase]   INT          IDENTITY (1, 1) NOT NULL,
    [EDIOnboardingPhaseType] VARCHAR (50) NULL,
    [UpdatedBy]              VARCHAR (50) NULL,
    [UpdatedOn]              DATETIME     NULL,
    [CreatedBy]              VARCHAR (50) NULL,
    [CreatedOn]              DATETIME     NULL,
    [ActiveFlag]             BIT          NULL,
    CONSTRAINT [PK_tblEDIOnboardingPhase] PRIMARY KEY CLUSTERED ([idEDIOnboardingPhase] ASC)
);
GO

SET IDENTITY_INSERT [dbo].[tblEDIOnboardingPhase] ON 
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, NULL, NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.020' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Kickoff', NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.027' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Discovery', NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.027' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Solution Determination', NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.027' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'Development', NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.030' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'Production Monitoring', NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.030' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (6, N'Stabilization', NULL, NULL, N'Scott.cardinale', CAST(N'2021-03-29T12:35:02.030' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (7, N'Tester', NULL, NULL, NULL, CAST(N'2021-03-29T13:47:11.537' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblEDIOnboardingPhase] OFF
GO

CREATE TABLE [dbo].[tblTiming] (
    [idTiming]   INT           IDENTITY (1, 1) NOT NULL,
    [Timing]     VARCHAR (100) NULL,
    [UpdatedBy]  VARCHAR (100) NULL,
    [UpdatedOn]  DATETIME      NULL,
    [CreatedBy]  VARCHAR (100) NULL,
    [CreatedOn]  DATETIME      NULL,
    [ActiveFlag] BIT           NULL,
    CONSTRAINT [PK_tbTiming] PRIMARY KEY CLUSTERED ([idTiming] ASC)
);
GO

SET IDENTITY_INSERT [dbo].[tblTiming] ON 
GO
INSERT [dbo].[tblTiming] ([idTiming], [Timing], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, N'none', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-15T16:40:32.087' AS DateTime), 0)
GO
INSERT [dbo].[tblTiming] ([idTiming], [Timing], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Once a Day', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-15T16:40:32.143' AS DateTime), 1)
GO
INSERT [dbo].[tblTiming] ([idTiming], [Timing], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Multiple Times a Day', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-15T16:40:32.200' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblTiming] OFF
GO

CREATE TABLE [dbo].[tblTriggerMechanism] (
    [idTriggerMechanism] INT           IDENTITY (1, 1) NOT NULL,
    [TriggerMechanism]   VARCHAR (100) NULL,
    [UpdatedBy]          VARCHAR (100) NULL,
    [UpdatedOn]          DATETIME      NULL,
    [CreatedBy]          VARCHAR (100) NULL,
    [CreatedOn]          DATETIME      NULL,
    [ActiveFlag]         BIT           NULL,
    CONSTRAINT [PK_tblTriggerMechanism] PRIMARY KEY CLUSTERED ([idTriggerMechanism] ASC)
);
GO

SET IDENTITY_INSERT [dbo].[tblTriggerMechanism] ON 
GO
INSERT [dbo].[tblTriggerMechanism] ([idTriggerMechanism], [TriggerMechanism], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, N'none', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-15T16:41:01.590' AS DateTime), 0)
GO
INSERT [dbo].[tblTriggerMechanism] ([idTriggerMechanism], [TriggerMechanism], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Manifest', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-15T16:41:01.640' AS DateTime), 1)
GO
INSERT [dbo].[tblTriggerMechanism] ([idTriggerMechanism], [TriggerMechanism], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Invoice', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-15T16:41:01.687' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblTriggerMechanism] OFF
GO

CREATE TABLE [dbo].[tblEDIRecipReqs] (
    [idEDIRecipReqs]        INT            IDENTITY (1, 1) NOT NULL,
    [RecipReqNum]           INT            NOT NULL,
    [idRequest]             INT            NOT NULL,
    [idEDITranscation]      INT            NOT NULL,
    [PanelTitle]            VARCHAR (50)   NULL,
    [idFileType]            INT            NOT NULL,
    [X12_ISA]               VARCHAR (50)   NULL,
    [X12_GS]                VARCHAR (50)   NULL,
    [X12_Qualifier]         VARCHAR (50)   NULL,
    [idCommunicationMethod] INT            NOT NULL,
    [FTPAddress]            NVARCHAR (100) NULL,
    [UserName]              VARCHAR (50)   NULL,
    [Password]              VARCHAR (50)   NULL,
    [FolderPath]            NVARCHAR (100) NULL,
    [Email]                 NVARCHAR (100) NULL,
    [idTriggerMechanism]    INT            NOT NULL,
    [idTiming]              INT            NOT NULL,
    [TimeOfFile]            DATETIME       NULL,
    [EDITranscationType]    VARCHAR (50)   NULL,
    [Category]              VARCHAR (50)   NOT NULL,
    [CreatedBy]             NVARCHAR (100) NULL,
    [CreatedOn]             DATETIME       NULL,
    [UpdatedBy]             NVARCHAR (100) NULL,
    [UpdatedOn]             DATETIME       NULL,
    [ActiveFlag]            BIT            NULL,
    CONSTRAINT [PK_tblEDIRecipReq] PRIMARY KEY CLUSTERED ([idEDIRecipReqs] ASC),
    CONSTRAINT [FK_idComMeth_EDIRecipReqs_ComMeth] FOREIGN KEY ([idCommunicationMethod]) REFERENCES [dbo].[tblCommunicationMethod] ([idCommunicationMethod]),
    CONSTRAINT [FK_idFileType_EDIRecipReqs_FileType] FOREIGN KEY ([idFileType]) REFERENCES [dbo].[tblFileType] ([idFileType]),
    CONSTRAINT [FK_idTime_EDIRecipReqs_Timing] FOREIGN KEY ([idTiming]) REFERENCES [dbo].[tblTiming] ([idTiming]),
    CONSTRAINT [FK_idTrans_RecipReqs_Trans] FOREIGN KEY ([idEDITranscation]) REFERENCES [dbo].[tblEDITranscations] ([idEDITranscation]),
    CONSTRAINT [FK_idTrig_EDIRecipReqs_TrigMech] FOREIGN KEY ([idTriggerMechanism]) REFERENCES [dbo].[tblTriggerMechanism] ([idTriggerMechanism])
);
GO

CREATE TABLE [dbo].[tblEDIShipMethodTypes] (
    [idEDIShipMethodTypes] INT          IDENTITY (1, 1) NOT NULL,
    [MethodType]           VARCHAR (50) NULL,
    [UpdatedBy]            VARCHAR (50) NULL,
    [UpdatedOn]            DATETIME     NULL,
    [CreatedBy]            VARCHAR (50) NULL,
    [CreatedOn]            DATETIME     NULL,
    [ActiveFlag]           BIT          NULL,
    CONSTRAINT [PK_tblEDIShipMethodTypes] PRIMARY KEY CLUSTERED ([idEDIShipMethodTypes] ASC)
);
GO

SET IDENTITY_INSERT [dbo].[tblEDIShipMethodTypes] ON 
GO
INSERT [dbo].[tblEDIShipMethodTypes] ([idEDIShipMethodTypes], [MethodType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Courier', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-03-17T08:47:07.083' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIShipMethodTypes] ([idEDIShipMethodTypes], [MethodType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'PuroPost', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-03-17T08:47:07.087' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIShipMethodTypes] ([idEDIShipMethodTypes], [MethodType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Freight', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-03-17T08:47:07.087' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblEDIShipMethodTypes] OFF
GO

CREATE TABLE [dbo].[tblExceptionLogging] (
    [Logid]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Method]          VARCHAR (100)  NULL,
    [ExceptionMsg]    NVARCHAR (MAX) NULL,
    [ExceptionType]   VARCHAR (100)  NULL,
    [ExceptionSource] NVARCHAR (MAX) NULL,
    [ExceptionURL]    VARCHAR (100)  NULL,
    [CreatedBy]       NVARCHAR (100) NULL,
    [CreatedOn]       DATETIME       NULL,
    CONSTRAINT [PK_tblExceptionLogging] PRIMARY KEY CLUSTERED ([Logid] ASC)
);
GO

CREATE TABLE [dbo].[tblFreightAuditors] (
    [idFreightAuditor] INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]      VARCHAR (255) NULL,
    [UpdatedBy]        VARCHAR (100) NULL,
    [UpdatedOn]        DATETIME      NULL,
    [CreatedBy]        VARCHAR (100) NULL,
    [CreatedOn]        DATETIME      NULL,
    [ActiveFlag]       BIT           NULL,
    CONSTRAINT [PK_tblFreightAuditors] PRIMARY KEY CLUSTERED ([idFreightAuditor] ASC)
);
GO

CREATE TABLE [dbo].[tblFreightAuditorsDiscReq] (
    [idFreightAuditorDiscReq] INT           IDENTITY (1, 1) NOT NULL,
    [idFreightAuditor]        INT           NOT NULL,
    [idRequest]               INT           NOT NULL,
    [UpdatedBy]               VARCHAR (100) NULL,
    [UpdatedOn]               DATETIME      NULL,
    [CreatedBy]               VARCHAR (100) NULL,
    [CreatedOn]               DATETIME      NULL,
    [ActiveFlag]              BIT           NULL,
    CONSTRAINT [PK_tblFreightAuditorsDiscReq] PRIMARY KEY CLUSTERED ([idFreightAuditorDiscReq] ASC),
    CONSTRAINT [FK_idFreightAuditor_tblFreightAuditor] FOREIGN KEY ([idFreightAuditor]) REFERENCES [dbo].[tblFreightAuditors] ([idFreightAuditor]),
    CONSTRAINT [FK_idRequest_tblFreightAuditorsDiscReq] FOREIGN KEY ([idRequest]) REFERENCES [dbo].[tblDiscoveryRequest] ([idRequest])
);
GO

CREATE TABLE [dbo].[tblITRequestTracker] (
    [TIME]             FLOAT (53)     NULL,
    [Date]             DATETIME       NULL,
    [Type]             NVARCHAR (255) NULL,
    [Name]             NVARCHAR (255) NULL,
    [Customer Name]    NVARCHAR (255) NULL,
    [Target Go-Live]   NVARCHAR (255) NULL,
    [Actual Go-Live]   DATETIME       NULL,
    [Onboarding Phase] NVARCHAR (255) NULL,
    [Shipping Channel] NVARCHAR (255) NULL,
    [Proj Revenue]     FLOAT (53)     NULL,
    [Solution Summary] NVARCHAR (255) NULL,
    [Int Kickoff Call] DATETIME       NULL,
    [Disc Call]        DATETIME       NULL,
    [F14]              NVARCHAR (255) NULL,
    [2/20/17]          NVARCHAR (255) NULL,
    [2/27/17]          FLOAT (53)     NULL,
    [3/6/17]           FLOAT (53)     NULL,
    [3/13/17]          FLOAT (53)     NULL,
    [3/20/17]          NVARCHAR (255) NULL,
    [3/27/17]          NVARCHAR (255) NULL,
    [4/3/17]           NVARCHAR (255) NULL,
    [4/10/17]          NVARCHAR (255) NULL,
    [4/17/17]          NVARCHAR (255) NULL,
    [4/24/17]          NVARCHAR (255) NULL,
    [5/1/17]           NVARCHAR (255) NULL,
    [5/8/17]           NVARCHAR (255) NULL,
    [5/15/17]          NVARCHAR (255) NULL,
    [5/22/17]          NVARCHAR (255) NULL,
    [5/29/17]          NVARCHAR (255) NULL,
    [6/5/17]           NVARCHAR (255) NULL,
    [6/12/17]          NVARCHAR (255) NULL,
    [6/19/17]          NVARCHAR (255) NULL,
    [6/26/17]          NVARCHAR (255) NULL,
    [7/3/17]           NVARCHAR (255) NULL,
    [7/10/17]          NVARCHAR (255) NULL,
    [7/17/17]          NVARCHAR (255) NULL,
    [7/24/17]          NVARCHAR (255) NULL,
    [7/31/17]          NVARCHAR (255) NULL,
    [8/7/17]           NVARCHAR (255) NULL,
    [8/14/17]          NVARCHAR (255) NULL,
    [8/21/17]          NVARCHAR (255) NULL,
    [8/28/17]          NVARCHAR (255) NULL,
    [9/4/17]           NVARCHAR (255) NULL,
    [9/11/17]          NVARCHAR (255) NULL,
    [9/18/17]          NVARCHAR (255) NULL,
    [9/25/17]          NVARCHAR (255) NULL,
    [10/2/17]          NVARCHAR (255) NULL,
    [10/9/17]          NVARCHAR (255) NULL,
    [10/16/17]         NVARCHAR (255) NULL,
    [10/23/17]         NVARCHAR (255) NULL,
    [10/30/17]         NVARCHAR (255) NULL,
    [11/6/17]          NVARCHAR (255) NULL,
    [11/13/17]         NVARCHAR (255) NULL,
    [11/20/17]         NVARCHAR (255) NULL,
    [11/27/17]         NVARCHAR (255) NULL,
    [12/4/17]          NVARCHAR (255) NULL,
    [12/11/17]         NVARCHAR (255) NULL,
    [12/18/17]         NVARCHAR (255) NULL,
    [12/25/17]         NVARCHAR (255) NULL,
    [F60]              NVARCHAR (255) NULL,
    [F61]              NVARCHAR (255) NULL,
    [F62]              NVARCHAR (255) NULL,
    [F63]              NVARCHAR (255) NULL,
    [F64]              NVARCHAR (255) NULL,
    [F65]              NVARCHAR (255) NULL,
    [F66]              NVARCHAR (255) NULL,
    [F67]              NVARCHAR (255) NULL,
    [F68]              NVARCHAR (255) NULL,
    [F69]              NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].[tblNon-CourierContracts] (
    [Key Activity]             NVARCHAR (255) NULL,
    [F2]                       NVARCHAR (255) NULL,
    [F3]                       FLOAT (53)     NULL,
    [F4]                       NVARCHAR (255) NULL,
    [F5]                       FLOAT (53)     NULL,
    [F6]                       DATETIME       NULL,
    [F7]                       FLOAT (53)     NULL,
    [Migration]                DATETIME       NULL,
    [F9]                       NVARCHAR (255) NULL,
    [Active or Closed Account] NVARCHAR (255) NULL,
    [Notes]                    NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].[tblProducts] (
    [idProduct]    INT           IDENTITY (1, 1) NOT NULL,
    [Product]      VARCHAR (50)  NULL,
    [Description]  VARCHAR (255) NULL,
    [Createdby]    VARCHAR (50)  NULL,
    [Createddate]  DATETIME      NULL,
    [ModifiedBy]   VARCHAR (50)  NULL,
    [Modifieddate] DATETIME      NULL
);
GO

CREATE TABLE [dbo].[tblProductTypeRel] (
    [idProductTypeRel] INT          IDENTITY (1, 1) NOT NULL,
    [idProductType]    INT          NULL,
    [idProduct]        INT          NULL,
    [CreatedBy]        VARCHAR (50) NULL,
    [CreatedDate]      DATETIME     NULL,
    [Modifiedby]       VARCHAR (50) NULL,
    [ModifiedDate]     DATETIME     NULL
);
GO

CREATE TABLE [dbo].[tblProductTypes] (
    [idProductType] INT           IDENTITY (1, 1) NOT NULL,
    [ProductType]   VARCHAR (100) NOT NULL,
    [Description]   VARCHAR (255) NULL,
    [CreatedBy]     VARCHAR (50)  NULL,
    [Createddate]   DATETIME      NULL,
    [ModifiedBy]    VARCHAR (50)  NULL,
    [ModifiedDate]  DATETIME      NULL
);
GO

CREATE TABLE [dbo].[tblShippingChannelAccount] (
    [Cust_Number]                                                      NVARCHAR (255) NULL,
    [Customer (Account Name)]                                          NVARCHAR (255) NULL,
    [Migration Specialist]                                             NVARCHAR (255) NULL,
    [Technical Consultant]                                             NVARCHAR (255) NULL,
    [Segment]                                                          NVARCHAR (255) NULL,
    [Account#]                                                         FLOAT (53)     NULL,
    [Account Type]                                                     NVARCHAR (255) NULL,
    [Current Shipping Channel]                                         NVARCHAR (255) NULL,
    [Current Platform]                                                 NVARCHAR (255) NULL,
    [Future Shipping Channel]                                          NVARCHAR (255) NULL,
    [Future Platform]                                                  NVARCHAR (255) NULL,
    [Planned Start Date]                                               DATETIME       NULL,
    [Planned Customer Approval Date]                                   DATETIME       NULL,
    [Planned Migration Target Date]                                    DATETIME       NULL,
    [Scheduled Migration Date]                                         DATETIME       NULL,
    [Legacy Contract]                                                  FLOAT (53)     NULL,
    [SAP Contract]                                                     FLOAT (53)     NULL,
    [Future Migrate Date]                                              DATETIME       NULL,
    [Data Distribution Available Date]                                 DATETIME       NULL,
    [Configure OLS3 production profile (Y/N]                           NVARCHAR (255) NULL,
    [Address Book]                                                     NVARCHAR (255) NULL,
    [Customs Items]                                                    NVARCHAR (255) NULL,
    [Custom Dimensions]                                                NVARCHAR (255) NULL,
    [Custom Export File]                                               NVARCHAR (255) NULL,
    [Ghost Scan]                                                       NVARCHAR (255) NULL,
    [Customs Clearance Type ((PASS, PARS , N/A)]                       NVARCHAR (255) NULL,
    [Old Pin Prefix]                                                   NVARCHAR (255) NULL,
    [New Pin Prefix]                                                   NVARCHAR (255) NULL,
    [OLS2 Acct #]                                                      FLOAT (53)     NULL,
    [OLS3 Acct #]                                                      FLOAT (53)     NULL,
    [Implementation File Created Y/N]                                  NVARCHAR (255) NULL,
    [EDI Y/N]                                                          NVARCHAR (255) NULL,
    [EDI Shipment Status]                                              NVARCHAR (255) NULL,
    [EDI Shipment Inquiry]                                             NVARCHAR (255) NULL,
    [US Intransit Scan Required]                                       NVARCHAR (255) NULL,
    [Technical Call - Solution Selection (Date)]                       NVARCHAR (255) NULL,
    [New World EDI specs provided to customer EDI contact (Date)]      NVARCHAR (255) NULL,
    [Gain approval from customer (Date)]                               NVARCHAR (255) NULL,
    [Technical Solution Implementation / Production Readiness Confirm] NVARCHAR (255) NULL,
    [Future migrate accounts in SAP (set Acct_at_Cust date to M minus] DATETIME       NULL,
    [Create technical setup EDI documents (Shipment status, electroni] NVARCHAR (255) NULL,
    [Host customer training (Date)]                                    NVARCHAR (255) NULL,
    [Migration (Date)]                                                 DATETIME       NULL,
    [Production Compliance -Landing Test (Date)]                       NVARCHAR (255) NULL,
    [Deactivate Legacy setup - 30 days (Date)]                         NVARCHAR (255) NULL,
    [Inactivate OLS2 customer profile]                                 NVARCHAR (255) NULL,
    [Finish Line - Migration Complete (Date)]                          DATETIME       NULL,
    [Active or Closed (in SAP) Account]                                NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].[tblShippingChannelAccounts] (
    [photos]                                     NVARCHAR (255) NULL,
    [Customer (Account Name)]                    NVARCHAR (255) NULL,
    [Migration Specialist]                       NVARCHAR (255) NULL,
    [Segment]                                    NVARCHAR (255) NULL,
    [Status]                                     NVARCHAR (255) NULL,
    [Account#]                                   FLOAT (53)     NULL,
    [Account Type]                               NVARCHAR (255) NULL,
    [Current Shipping Channel]                   NVARCHAR (255) NULL,
    [Current Platform]                           NVARCHAR (255) NULL,
    [Future Shipping Channel]                    NVARCHAR (255) NULL,
    [Future Platform]                            NVARCHAR (255) NULL,
    [Target Date]                                NVARCHAR (255) NULL,
    [Scheduled Date]                             NVARCHAR (255) NULL,
    [Legacy Contract]                            FLOAT (53)     NULL,
    [SAP Contract]                               NVARCHAR (255) NULL,
    [Configure OLS3 production profile (Y/N]     NVARCHAR (255) NULL,
    [Address Book]                               NVARCHAR (255) NULL,
    [Customs Items]                              NVARCHAR (255) NULL,
    [Custom Dimensions]                          NVARCHAR (255) NULL,
    [Custom Export File]                         NVARCHAR (255) NULL,
    [Ghost Scan]                                 NVARCHAR (255) NULL,
    [Customs Clearance Type ((PASS, PARS , N/A)] NVARCHAR (255) NULL,
    [Old Pin Prefix]                             NVARCHAR (255) NULL,
    [New Pin Prefix]                             NVARCHAR (255) NULL,
    [OLS2 Acct #]                                FLOAT (53)     NULL,
    [OLS3 Acct #]                                FLOAT (53)     NULL,
    [EDI Y/N]                                    NVARCHAR (255) NULL,
    [Inactivate OLS2 customer profile]           NVARCHAR (255) NULL,
    [Active or Closed (in SAP) Account]          NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].[tblStatusCodes] (
    [idStatusCodes] INT           IDENTITY (1, 1) NOT NULL,
    [StatusCode]    VARCHAR (100) NULL,
    [UpdatedBy]     VARCHAR (100) NULL,
    [UpdatedOn]     DATETIME      NULL,
    [CreatedBy]     VARCHAR (100) NULL,
    [CreatedOn]     DATETIME      NULL,
    [ActiveFlag]    BIT           NULL,
    CONSTRAINT [PK_tblStatusCodes] PRIMARY KEY CLUSTERED ([idStatusCodes] ASC)
);
GO
CREATE TABLE [dbo].[tblStatusCodesAll] (
    [idStatusCodesAll]     INT           IDENTITY (1, 1) NOT NULL,
    [idEDIRecipReqs]       INT           NOT NULL,
    [idStatusCodes]        INT           NOT NULL,
    [StatusCode]           VARCHAR (50)  NULL,
    [idEDITranscationType] INT           NOT NULL,
    [EDITranscationType]   VARCHAR (50)  NULL,
    [CategoryID]           INT           NOT NULL,
    [Category]             VARCHAR (50)  NOT NULL,
    [UpdatedBy]            VARCHAR (100) NULL,
    [UpdatedOn]            DATETIME      NULL,
    [CreatedBy]            VARCHAR (100) NULL,
    [CreatedOn]            DATETIME      NULL,
    [ActiveFlag]           BIT           NULL,
    CONSTRAINT [PK_tblStatusCodesAll] PRIMARY KEY CLUSTERED ([idStatusCodesAll] ASC),
    CONSTRAINT [FK_idEDIRecipReqs_tatusCodesAll_EDIRecipReqs] FOREIGN KEY ([idEDIRecipReqs]) REFERENCES [dbo].[tblEDIRecipReqs] ([idEDIRecipReqs]),
    CONSTRAINT [FK_idEDITransType_StatCodesAll_EDITransType] FOREIGN KEY ([idEDITranscationType]) REFERENCES [dbo].[tblEDITranscationType] ([idEDITranscationType])
);
GO
CREATE TABLE [dbo].[tblStatusCodesCourierEDI] (
    [idStatusCodesCourierEDI] INT           IDENTITY (1, 1) NOT NULL,
    [StatusCode]              VARCHAR (100) NULL,
    [UpdatedBy]               VARCHAR (100) NULL,
    [UpdatedOn]               DATETIME      NULL,
    [CreatedBy]               VARCHAR (100) NULL,
    [CreatedOn]               DATETIME      NULL,
    [ActiveFlag]              BIT           NULL,
    CONSTRAINT [PK_tblStatusCodesCourierEDI] PRIMARY KEY CLUSTERED ([idStatusCodesCourierEDI] ASC)
);
GO
CREATE TABLE [dbo].[tblStatusCodesNonCourierEDI] (
    [idStatusCodesNonCourierEDI] INT           IDENTITY (1, 1) NOT NULL,
    [StatusCode]                 VARCHAR (100) NULL,
    [UpdatedBy]                  VARCHAR (100) NULL,
    [UpdatedOn]                  DATETIME      NULL,
    [CreatedBy]                  VARCHAR (100) NULL,
    [CreatedOn]                  DATETIME      NULL,
    [ActiveFlag]                 BIT           NULL,
    CONSTRAINT [PK_tblStatusCodesNonCourierEDI] PRIMARY KEY CLUSTERED ([idStatusCodesNonCourierEDI] ASC)
);
GO
CREATE TABLE [dbo].[tblWP_LIST] (
    [F1]                                                               NVARCHAR (255) NULL,
    [Customer (Account Name)]                                          NVARCHAR (255) NULL,
    [Migration Specialist]                                             NVARCHAR (255) NULL,
    [Technical Consultant]                                             NVARCHAR (255) NULL,
    [Segment]                                                          NVARCHAR (255) NULL,
    [Account#]                                                         FLOAT (53)     NULL,
    [Account Type]                                                     NVARCHAR (255) NULL,
    [Current Shipping Channel]                                         NVARCHAR (255) NULL,
    [Current Platform]                                                 NVARCHAR (255) NULL,
    [Future Shipping Channel]                                          NVARCHAR (255) NULL,
    [Future Platform]                                                  NVARCHAR (255) NULL,
    [Planned Start Date]                                               DATETIME       NULL,
    [Planned Customer Approval Date]                                   DATETIME       NULL,
    [Planned Migration Target Date]                                    DATETIME       NULL,
    [Scheduled Migration Date]                                         DATETIME       NULL,
    [Legacy Contract]                                                  FLOAT (53)     NULL,
    [SAP Contract]                                                     FLOAT (53)     NULL,
    [Future Migrate Date]                                              DATETIME       NULL,
    [Data Distribution Available Date]                                 DATETIME       NULL,
    [Configure OLS3 production profile (Y/N]                           NVARCHAR (255) NULL,
    [Address Book]                                                     NVARCHAR (255) NULL,
    [Customs Items]                                                    NVARCHAR (255) NULL,
    [Custom Dimensions]                                                NVARCHAR (255) NULL,
    [Custom Export File]                                               NVARCHAR (255) NULL,
    [Ghost Scan]                                                       NVARCHAR (255) NULL,
    [Customs Clearance Type ((PASS, PARS , N/A)]                       NVARCHAR (255) NULL,
    [Old Pin Prefix]                                                   NVARCHAR (255) NULL,
    [New Pin Prefix]                                                   NVARCHAR (255) NULL,
    [OLS2 Acct #]                                                      FLOAT (53)     NULL,
    [OLS3 Acct #]                                                      FLOAT (53)     NULL,
    [Implementation File Created Y/N]                                  NVARCHAR (255) NULL,
    [EDI Invoice]                                                      NVARCHAR (255) NULL,
    [EDI Shipment Status]                                              NVARCHAR (255) NULL,
    [EDI Shipment Inquiry]                                             NVARCHAR (255) NULL,
    [US Intransit Scan Required]                                       NVARCHAR (255) NULL,
    [Technical Call - Solution Selection (Date)]                       DATETIME       NULL,
    [New World EDI specs provided to customer EDI contact (Date)]      NVARCHAR (255) NULL,
    [Gain approval from customer (Date)]                               DATETIME       NULL,
    [Technical Solution Implementation / Production Readiness Confirm] DATETIME       NULL,
    [Future migrate accounts in SAP (set Acct_at_Cust date to M minus] DATETIME       NULL,
    [Create technical setup EDI documents (Shipment status, electroni] NVARCHAR (255) NULL,
    [Host customer training (Date)]                                    NVARCHAR (255) NULL,
    [Migration (Date)]                                                 NVARCHAR (255) NULL,
    [Production Compliance -Landing Test (Date)]                       NVARCHAR (255) NULL,
    [Deactivate Legacy setup - 30 days (Date)]                         NVARCHAR (255) NULL,
    [Inactivate OLS2 customer profile]                                 NVARCHAR (255) NULL,
    [Finish Line - Migration Complete (Date)]                          NVARCHAR (255) NULL,
    [Active or Closed (in SAP) Account]                                NVARCHAR (255) NULL
);
GO

CREATE TABLE [dbo].['Worldpak Team Support$'] (
    [WP Team Support ] NVARCHAR (255) NULL,
    [Team Support]     NVARCHAR (255) NULL,
    [Field Type ]      NVARCHAR (255) NULL,
    [Comments]         NVARCHAR (255) NULL,
    [F5]               NVARCHAR (255) NULL,
    [F6]               NVARCHAR (255) NULL
);
GO

