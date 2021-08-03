USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
GO

/****** Object:  Table [dbo].[tblEDISpecialist]    Script Date: 8/3/2021 1:36:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEDISpecialist](
	[idEDISpecialist] [int] IDENTITY(1,1) NOT NULL,
	[idEmployee] [int] NOT NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[email] [varchar](255) NULL,
	[ReceiveNewReqEmail] [bit] NULL,
	[login] [varchar](50) NULL,
 CONSTRAINT [PK_tblEDISpecialist] PRIMARY KEY CLUSTERED 
(
	[idEDISpecialist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


