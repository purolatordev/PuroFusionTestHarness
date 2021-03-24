Create procedure sp_SPColumnChartData
As

SELECT count(*) TotalRequests, Createdby, Month(createdon) Month
from [dbo].[tblDiscoveryRequest]
 where CreatedBy = 'Admin.Sales'
 group by createdby, Month(CreatedOn)



