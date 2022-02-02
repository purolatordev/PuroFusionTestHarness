--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv6]
GO
/****** Object:  Table [dbo].[tblFileType]    Script Date: 2021/04/16 10:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID(N'dbo.tblFileType', N'U') IS NOT NULL
begin
	print 'Exists -- tblFileType table'
	IF OBJECT_ID('dbo.[PK_tblFileType]') IS NOT NULL 
	begin
		print 'Exists -- So drop PK_tblFileType CONSTRAINT'
		ALTER TABLE [dbo].[tblFileType]
			DROP CONSTRAINT [PK_tblFileType]
		drop table [tblFileType]
	end
end
go

CREATE TABLE [dbo].[tblFileType](
	[idFileType] [int] IDENTITY(1,1) NOT NULL,
	[FileType] [varchar](100) NULL,
	[NonCourierEDI] [bit] not NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
 CONSTRAINT [PK_tblFileType] PRIMARY KEY CLUSTERED 
(
	[idFileType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblFileType] ON 
GO
INSERT [dbo].[tblFileType] ([idFileType], [FileType], [NonCourierEDI], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (0, N'none', 0, NULL, NULL, N'Scott.Cardinale', GETDATE(), 0)
GO
INSERT [dbo].[tblFileType] ([idFileType], [FileType], [NonCourierEDI], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (1, N'CSV',  0, NULL, NULL, N'Scott.Cardinale', GETDATE(), 1)
GO
INSERT [dbo].[tblFileType] ([idFileType], [FileType], [NonCourierEDI], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (2, N'Flat File', 0, NULL, NULL, N'Scott.Cardinale', GETDATE(), 1)
GO
INSERT [dbo].[tblFileType] ([idFileType], [FileType], [NonCourierEDI], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (3, N'X12',  0, NULL, NULL, N'Scott.Cardinale', GETDATE(), 1)
GO
INSERT [dbo].[tblFileType] ([idFileType], [FileType], [NonCourierEDI], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag]) VALUES (4, N'Other', 1, NULL, NULL, N'Scott.Cardinale', GETDATE(), 1)
GO

SET IDENTITY_INSERT [dbo].[tblFileType] OFF
GO


--drop table [tblFileType]
--delete from [tblFileType]
--select * from [tblFileType]