CREATE  PROCEDURE [dbo].[sp_GetProductsForSvcs]
(
@SvcList VarChar(100)
)
AS
BEGIN

DECLARE @stmt nvarchar(255);
SET @stmt = 'select * from tblShippingProducts where idShippingSvc in (' + @SvcList + ')';
print @stmt;
Execute sp_executesql @stmt;


END