--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO

/****** Object:  View [dbo].[vw_ITBA]    Script Date: 8/3/2021 1:42:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vw_ITBA]
AS
SELECT        itba.idITBA, emp.FirstName + ' ' + emp.LastName AS ITBA, emp.ActiveDirectoryName, itba.ITBAemail, emp.idEmployee, itba.UpdatedBy, itba.UpdatedOn, 
                         itba.CreatedBy, itba.CreatedOn, itba.ActiveFlag, itba.ReceiveNewReqEmail, itba.login, itba.EDIFlag
FROM            dbo.tblITBA AS itba INNER JOIN
                         PurolatorReporting.dbo.tblEmployee AS emp ON emp.idEmployee = itba.idEmployee
GO

