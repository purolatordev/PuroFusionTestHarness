--USE [PuroTouchDB_Prod]
--USE [PuroTouchDB]
USE [PuroTouchDBv4]
GO

/****** Object:  View [dbo].[vw_EDISpecialist]    Script Date: 8/3/2021 1:35:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   VIEW [dbo].[vw_EDISpecialist]
AS
SELECT        itba.idEDISpecialist, emp.FirstName + ' ' + emp.LastName AS Name, emp.ActiveDirectoryName, itba.email, emp.idEmployee, itba.UpdatedBy, itba.UpdatedOn, 
                         itba.CreatedBy, itba.CreatedOn, itba.ActiveFlag, itba.ReceiveNewReqEmail, itba.login
FROM            dbo.tblEDISpecialist AS itba INNER JOIN
                         PurolatorReporting.dbo.tblEmployee AS emp ON emp.idEmployee = itba.idEmployee
GO


