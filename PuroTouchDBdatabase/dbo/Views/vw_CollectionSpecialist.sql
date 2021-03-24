
CREATE   VIEW [dbo].[vw_CollectionSpecialist]
AS
SELECT        itba.idCollectionSpecialist, emp.FirstName + ' ' + emp.LastName AS Name, emp.ActiveDirectoryName, itba.email, emp.idEmployee, itba.UpdatedBy, itba.UpdatedOn, 
                         itba.CreatedBy, itba.CreatedOn, itba.ActiveFlag, itba.ReceiveNewReqEmail, itba.login
FROM            dbo.tblCollectionSpecialist AS itba INNER JOIN
                         PurolatorReporting.dbo.tblEmployee AS emp ON emp.idEmployee = itba.idEmployee
