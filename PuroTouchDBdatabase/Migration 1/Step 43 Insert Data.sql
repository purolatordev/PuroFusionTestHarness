--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv6]
--delete from [dbo].[tblEDIOnboardingPhase]

update tblDiscoveryRequest set idSolutionType = 1 where idSolutionType is null
--select idSolutionType,* from tblDiscoveryRequest
go

SET IDENTITY_INSERT [dbo].[tblEDIOnboardingPhase] ON 
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (8, N'Kickoff', NULL, NULL, NULL, CAST(N'2021-12-20T15:08:58.833' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (9, N'Discovery', NULL, NULL, NULL, CAST(N'2021-12-20T15:09:06.210' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (10, N'Solution Determination', NULL, NULL, NULL, CAST(N'2021-12-20T15:09:10.813' AS DateTime), 1)
GO
INSERT [dbo].[tblEDIOnboardingPhase] ([idEDIOnboardingPhase], [EDIOnboardingPhaseType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (11, N'Development', NULL, NULL, NULL, CAST(N'2021-12-20T15:09:16.280' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblEDIOnboardingPhase] OFF
GO

--select * from [tblEDIOnboardingPhase]

GO
SET IDENTITY_INSERT [dbo].[tblStatusCodesCourierEDI] ON 
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, N'none', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:23.777' AS DateTime), 0)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'All Courier Scans', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.683' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Proof of Pickup', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.683' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Misdirect', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.683' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'On Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.687' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'Agent Transfer', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.687' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (6, N'Intl Outbound', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.687' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (7, N'U.S. Inbound', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.687' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (8, N'U.S. Outbound', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.687' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (9, N'International Inbound', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.690' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (10, N'International Outbound', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.690' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (11, N'B/L Cross Reference', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.690' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (12, N'Closed', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.690' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (13, N'Bad Address', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.690' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (14, N'Refused', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.690' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (15, N'Door Knocker', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.693' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (16, N'Appointment Required', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.693' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (17, N'Customer Req PM Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.693' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (18, N'Other', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.693' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (19, N'Held at Customs', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.693' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (20, N'Disruption', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.697' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (21, N'Mechanical Delay', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.697' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (22, N'Bump', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.697' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (23, N'In Terminal', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.697' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (24, N'Short Shipment', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.697' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (25, N'Damaged Goods', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (26, N'Mis-Sort', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (27, N'No Valid Delivery Attempt', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (28, N'LTA/Next Day Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (29, N'No Time on Route', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (30, N'Scheduled for PM Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (31, N'Redirected/PM Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.700' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (32, N'LTA/PM Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.703' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (33, N'In Transit', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.703' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (34, N'Hold for Pickup', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.703' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (35, N'U.S. In Terminal', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.703' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (36, N'U.S. In Transit', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.703' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (37, N'Held at Destination', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.707' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (38, N'Broker Notified', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.707' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (39, N'Cleared Customs', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.707' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (40, N'Held at Gateway', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.707' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (41, N'Payment Received', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.710' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (42, N'Consolidation', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.710' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (43, N'Proof of Delivery', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.710' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesCourierEDI] ([idStatusCodesCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (44, N'Claims Transaction', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:09:32.710' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblStatusCodesCourierEDI] OFF
GO

SET IDENTITY_INSERT [dbo].[tblStatusCodesNonCourierEDI] ON 
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, N'none', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:34.413' AS DateTime), 0)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Address Correction Required    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.713' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Arrived      ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.717' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Arrived at Destination Terminal   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.717' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'Arrived at Terminal Location   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.717' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'Arrived at Transfer Terminal   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.717' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (6, N'Arrived Delivery Location    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.717' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (7, N'Attempted Delivery - Customer Closed  ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.720' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (8, N'Attempted Delivery - Notification Card Left ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.720' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (9, N'Attempted Delivery - Package Refused  ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.720' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (10, N'Canceled on Arrival    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.720' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (11, N'Carrier Departed Pickup Location with Shipment', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.720' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (12, N'Cleared Customs     ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.720' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (13, N'Delivered      ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.723' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (14, N'Departed Facility     ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.723' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (15, N'Departed Terminal Location    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.723' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (16, N'Dispatch Confirmed     ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.723' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (17, N'Dispatched      ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.723' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (18, N'Exception      ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.727' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (19, N'Held for Customs    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.727' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (20, N'Held for Pick Up   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.727' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (21, N'Hold as Undeliverable    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.727' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (22, N'Hold at Customer Request   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.727' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (23, N'Hold for Address Verification   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (24, N'In Transit     ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (25, N'In Transit In Canada   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (26, N'In Transit In U.S.   ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (27, N'Item being processed - Notification Card PU', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (28, N'Item being processed at the sortation plant', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (29, N'OSD      ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.730' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (30, N'Out for Delivery    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.733' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (31, N'Picked Up at Shippers Origin Location ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.733' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (32, N'Pickup Confirmed     ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.733' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (33, N'Re addressed | Customer Request  ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.733' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (34, N'Refused      ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.733' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (35, N'Return to Sender    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.737' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (36, N'Return to Sender | Bad Address ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.737' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (37, N'Return to Sender | Proof of Age', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.737' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (38, N'Return to Sender | Undeliverable  ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.737' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (39, N'Shipment Data Received    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.740' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (40, N'Shipment in Transit    ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.740' AS DateTime), 1)
GO
INSERT [dbo].[tblStatusCodesNonCourierEDI] ([idStatusCodesNonCourierEDI], [StatusCode], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (41, N'Transit Delay     ', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-09-08T14:08:44.740' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblStatusCodesNonCourierEDI] OFF
GO

SET IDENTITY_INSERT [dbo].[tblFreightAuditors] ON 
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Freight Auditor Person 1', N'karias', CAST(N'2022-01-05T13:32:45.707' AS DateTime), N'karias', CAST(N'2022-01-05T13:32:45.690' AS DateTime), 0)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Audit Company X-123', N'karias', CAST(N'2022-01-05T13:32:54.933' AS DateTime), N'karias', CAST(N'2022-01-05T13:32:54.930' AS DateTime), 0)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Data2Logistics', N'karias', CAST(N'2022-01-05T13:27:09.610' AS DateTime), N'karias', CAST(N'2022-01-05T13:27:09.610' AS DateTime), 1)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'Cass Information Systems', N'karias', CAST(N'2022-01-05T13:28:39.200' AS DateTime), N'karias', CAST(N'2022-01-05T13:28:39.200' AS DateTime), 1)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'StrategIQ Commerce', N'karias', CAST(N'2022-01-05T13:29:01.160' AS DateTime), N'karias', CAST(N'2022-01-05T13:29:01.160' AS DateTime), 1)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (6, N'AFMS', N'karias', CAST(N'2022-01-05T13:29:45.230' AS DateTime), N'karias', CAST(N'2022-01-05T13:29:45.230' AS DateTime), 1)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (7, N'Transportation Insight', N'karias', CAST(N'2022-01-05T13:30:18.603' AS DateTime), N'karias', CAST(N'2022-01-05T13:30:18.603' AS DateTime), 1)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (8, N'Williams & Associates', N'karias', CAST(N'2022-01-05T13:31:14.240' AS DateTime), N'karias', CAST(N'2022-01-05T13:31:14.240' AS DateTime), 1)
GO
INSERT [dbo].[tblFreightAuditors] ([idFreightAuditor], [CompanyName], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (9, N'GTMS', N'karias', CAST(N'2022-01-05T13:32:39.670' AS DateTime), N'karias', CAST(N'2022-01-05T13:32:39.670' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblFreightAuditors] OFF
GO

SET IDENTITY_INSERT [dbo].[tblEDISpecialist] ON 
GO
INSERT [dbo].[tblEDISpecialist] ([idEDISpecialist], [idEmployee], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [email], [ReceiveNewReqEmail], [login]) VALUES (1, 5210, NULL, NULL, N'Michele.Kennedy', CAST(N'2021-08-06T11:27:44.900' AS DateTime), 1, N'anna.iacoviello@purolator.com', 0, N'anna.iacoviello')
GO
INSERT [dbo].[tblEDISpecialist] ([idEDISpecialist], [idEmployee], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [email], [ReceiveNewReqEmail], [login]) VALUES (2, 1480, N'Michele.Kennedy', CAST(N'2021-12-21T17:08:28.340' AS DateTime), N'Michele.Kennedy', CAST(N'2021-08-06T11:28:23.613' AS DateTime), 1, N'nicholas.rescigno@purolator.com', 0, N'nicholas.rescigno')
GO
SET IDENTITY_INSERT [dbo].[tblEDISpecialist] OFF
GO

SET IDENTITY_INSERT [dbo].[tblBillingSpecialist] ON 
GO
INSERT [dbo].[tblBillingSpecialist] ([idBillingSpecialist], [idEmployee], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [email], [ReceiveNewReqEmail], [login]) VALUES (1, 2214, NULL, NULL, N'karias', CAST(N'2021-10-04T15:55:40.870' AS DateTime), 1, N'rakhi.kaur@purolator.com', 0, N'rakhi.kaur')
GO
INSERT [dbo].[tblBillingSpecialist] ([idBillingSpecialist], [idEmployee], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [email], [ReceiveNewReqEmail], [login]) VALUES (2, 1157, NULL, NULL, N'karias', CAST(N'2022-01-24T10:37:46.250' AS DateTime), 1, N'brunda.shastri@purolator.com', 0, N'brunda.shastri')
GO
SET IDENTITY_INSERT [dbo].[tblBillingSpecialist] OFF
GO

SET IDENTITY_INSERT [dbo].[tblCollectionSpecialist] ON 
GO
INSERT [dbo].[tblCollectionSpecialist] ([idCollectionSpecialist], [idEmployee], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [email], [ReceiveNewReqEmail], [login]) VALUES (1, 1119, NULL, NULL, N'karias', CAST(N'2021-10-04T16:15:16.467' AS DateTime), 1, N'lorraine.debiase@purolator.com', 0, N'lorraine.debiase')
GO
INSERT [dbo].[tblCollectionSpecialist] ([idCollectionSpecialist], [idEmployee], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [email], [ReceiveNewReqEmail], [login]) VALUES (2, 1155, NULL, NULL, N'karias', CAST(N'2022-01-24T10:40:08.387' AS DateTime), 1, N'lynn.schuchman@purolator.com', 0, N'lynn.schuchman')
GO
SET IDENTITY_INSERT [dbo].[tblCollectionSpecialist] OFF
GO