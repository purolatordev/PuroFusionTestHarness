USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Table [dbo].[tblITBA]    Script Date: 8/3/2021 1:09:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
BEGIN TRANSACTION
go
IF OBJECT_ID(N'dbo.tblITBA', N'U') IS NOT NULL
begin
	print 'Exists -- tblITBA table'
	IF OBJECT_ID('dbo.[PK_tblITBA]') IS NOT NULL 
	begin
		print 'Exists -- So drop PK_tblITBA CONSTRAINT'
		ALTER TABLE [dbo].[tblITBA]
			DROP CONSTRAINT [PK_tblITBA]
	end
end


CREATE TABLE [dbo].[Tmp_tblITBA](
	[idITBA] [int] IDENTITY(1,1) NOT NULL,
	[idEmployee] [int] NOT NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[ITBAemail] [varchar](255) NULL,
	[ReceiveNewReqEmail] [bit] NULL,
	[login] [varchar](50) NULL,
 CONSTRAINT [PK_tblITBA] PRIMARY KEY CLUSTERED 
(
	[idITBA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.[Tmp_tblITBA] SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.[Tmp_tblITBA] ON
GO
IF EXISTS(SELECT * FROM dbo.[tblITBA])
	EXEC('INSERT INTO dbo.Tmp_tblITBA 
			(
				idITBA,idEmployee,
				UpdatedBy,UpdatedOn,CreatedBy,CreatedOn,ActiveFlag,
				ITBAemail,ReceiveNewReqEmail,login
			)
			SELECT  
				idITBA,idEmployee,
				UpdatedBy,UpdatedOn,CreatedBy,CreatedOn,ActiveFlag,
				ITBAemail,ReceiveNewReqEmail,login
			FROM dbo.[tblITBA] WITH (HOLDLOCK TABLOCKX)'
		)
GO
SET IDENTITY_INSERT dbo.[Tmp_tblITBA] OFF
GO
DROP TABLE dbo.tblITBA
GO
EXECUTE sp_rename N'dbo.[Tmp_tblITBA]', N'tblITBA', 'OBJECT' 
GO

COMMIT

--ALTER TABLE [tblITBA]
--	ADD CONSTRAINT [PK_tblITBA] PRIMARY KEY ([idITBA]);

--select * from tblITBA