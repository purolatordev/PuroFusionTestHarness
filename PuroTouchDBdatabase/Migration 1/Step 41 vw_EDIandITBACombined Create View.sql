--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv3]
GO

/****** Object:  View [dbo].[vw_EDIandITBACombined]    Script Date: 2022/01/24 11:37:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE   VIEW [dbo].[vw_EDIandITBACombined]
AS
SELECT itba.idITBA, emp.FirstName + ' ' + emp.LastName AS ITBA, emp.ActiveDirectoryName, itba.ITBAemail, emp.idEmployee, itba.UpdatedBy, itba.UpdatedOn, itba.CreatedBy, itba.CreatedOn, itba.ActiveFlag, 
       itba.ReceiveNewReqEmail, itba.login, itba.EDIFlag as EDIFlag
FROM  dbo.tblITBA AS itba INNER JOIN
      PurolatorReporting.dbo.tblEmployee AS emp ON emp.idEmployee = itba.idEmployee
union

SELECT itba.idEDISpecialist, emp.FirstName + ' ' + emp.LastName AS Name, emp.ActiveDirectoryName, itba.email, emp.idEmployee, itba.UpdatedBy, itba.UpdatedOn, itba.CreatedBy, itba.CreatedOn, itba.ActiveFlag, 
       itba.ReceiveNewReqEmail, itba.login, 1 as EDIFlag
FROM   dbo.tblEDISpecialist AS itba INNER JOIN
       PurolatorReporting.dbo.tblEmployee AS emp ON emp.idEmployee = itba.idEmployee
GO


