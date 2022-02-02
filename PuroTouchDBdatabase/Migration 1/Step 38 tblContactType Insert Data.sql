--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv6]
GO
SET IDENTITY_INSERT [dbo].[tblContactType] ON 
GO
INSERT [dbo].[tblContactType] ([idContactType], [ContactType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'Customer Business', N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[tblContactType] ([idContactType], [ContactType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Customer IT', N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[tblContactType] ([idContactType], [ContactType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Customer Billing', N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[tblContactType] ([idContactType], [ContactType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'Customer EDI', N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[tblContactType] ([idContactType], [ContactType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'Freight Auditor Programmer', N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[tblContactType] ([idContactType], [ContactType], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (6, N'Freight Auditor Billing', N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), N'Michele.Kennedy', CAST(N'2021-02-15T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[tblContactType] OFF
GO
