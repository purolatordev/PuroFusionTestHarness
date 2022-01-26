--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO
SET IDENTITY_INSERT [dbo].[tblCommunicationMethod] ON 
GO
INSERT [dbo].[tblCommunicationMethod] ([idCommunicationMethod], [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, N'None', NULL, NULL, N'Scott.Cardinale', CAST(N'2021-04-16T10:51:55.257' AS DateTime), 0)
GO
INSERT [dbo].[tblCommunicationMethod] ([idCommunicationMethod], [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'FTP Internal', N'Admin.ITManager', CAST(N'2017-11-08T11:40:52.970' AS DateTime), N'Scott.Cardinale', CAST(N'2021-04-16T10:51:55.303' AS DateTime), 1)
GO
INSERT [dbo].[tblCommunicationMethod] ([idCommunicationMethod], [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'FTP External', N'Admin.ITManager', CAST(N'2017-11-08T11:40:48.827' AS DateTime), N'Scott.Cardinale', CAST(N'2021-04-16T10:51:55.360' AS DateTime), 1)
GO
INSERT [dbo].[tblCommunicationMethod] ([idCommunicationMethod], [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'Email', N'Admin.ITManager', CAST(N'2017-11-08T11:40:45.133' AS DateTime), N'Scott.Cardinale', CAST(N'2021-04-16T10:51:55.400' AS DateTime), 1)
GO
INSERT [dbo].[tblCommunicationMethod] ([idCommunicationMethod], [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'AS2', N'Admin.ITManager', CAST(N'2017-11-08T11:40:40.653' AS DateTime), N'Scott.Cardinale', CAST(N'2021-04-16T10:51:55.443' AS DateTime), 1)
GO
INSERT [dbo].[tblCommunicationMethod] ([idCommunicationMethod], [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (5, N'VAN', N'Admin.ITManager', CAST(N'2017-11-08T11:40:56.293' AS DateTime), N'Scott.Cardinale', CAST(N'2021-04-16T10:51:55.487' AS DateTime), 1)
GO


SET IDENTITY_INSERT [dbo].[tblCommunicationMethod] OFF
GO

INSERT [dbo].[tblCommunicationMethod] ( [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (N'SFTP Internal', N'Admin.ITManager', CAST(N'2017-11-08T11:40:52.970' AS DateTime), N'Scott.Cardinale', CAST(N'2021-09-20T10:47:32.237' AS DateTime), 1)
GO
INSERT [dbo].[tblCommunicationMethod] ( [CommunicationMethod], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (N'SFTP External', N'Admin.ITManager', CAST(N'2017-11-08T11:40:48.827' AS DateTime), N'Scott.Cardinale', CAST(N'2021-09-20T10:47:32.280' AS DateTime), 1)
GO
--select * from [dbo].[tblCommunicationMethod]