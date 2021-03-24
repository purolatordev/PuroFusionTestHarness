CREATE PROCEDURE [dbo].[ImporHistoryFromTemp]


AS
BEGIN


   BEGIN TRY
   		   

			--START TRANSACTION BEFORE INSERT INTO PRODUCTION TABLES
			BEGIN TRANSACTION
	
		 
			/**Insert header**/
			INSERT INTO tblDiscoveryRequest (IsNewRequest,SalesRepName,SalesRepEmail,idOnboardingPhase,District,CustomerName,Address,City,State,Zipcode,Country,Commodity,ProjectedRevenue,
			CustomerITContact,CustomerITTitle,CustomerITEmail,CustomerITPhone,CurrentSolution,ProposedCustoms,CreatedOn,ActiveFlag,SalesComments,idITBA,idShippingChannel,TargetGoLive,ActualGoLive,SolutionSummary )
            SELECT IsNewRequest,SalesRepName,SalesRepEmail,idOnboardingPhase,PFDistrict,CustomerName,Address,City,State,Zipcode,Country,Commodity,ProjectedRevenue,
			CustomerITContact,CustomerITTitle,CustomerITEmail,CustomerITPhone,'N/A',ProposedCustoms,CreatedOn,ActiveFlag,SalesComments,idITBA,idShippingChannel,[Target Go-Live],[Actual Go-Live],SolutionSummary
            from  tblDiscoveryRequestImport$
			

			--GET THE IDENTITY VALUES THAT WERE GENERATED
		
			UPDATE tblDiscoveryRequestImport$
			SET tblDiscoveryRequestImport$.idDiscoveryRequest = prod.idRequest
			FROM
				 tblDiscoveryRequestImport$ import
			Right JOIN
				tblDiscoveryRequest prod ON import.CustomerName = prod.CustomerName

				
		
			 /**Insert Detail**/
			 INSERT INTO tblDiscoveryRequestDetails ( idRequest, CreatedOn, ActiveFlag )
			 SELECT idDiscoveryRequest, Convert(DateTime,CreatedOn), ActiveFlag
			 from  tblDiscoveryRequestImport$		 
			 where idDiscoveryRequest is not NULL


			   /**Insert Time into Note**/
			   --id 4 is 'other'
			 INSERT INTO tblDiscoveryRequestNotes ( idTaskType, idRequest, timeSpent, CreatedOn, ActiveFlag )
			 SELECT 4,idDiscoveryRequest,TimeSpent,CreatedOn, ActiveFlag
			 from  tblDiscoveryRequestImport$	
			 where idDiscoveryRequest is not NULL


			 -- /**Insert Default Service**/
			 -- --USE SAME DEFAULT FOR ALL
			 ----INSERT INTO tblDiscoveryRequestServices ( idRequest, idShippingSvc, volume, CreatedOn )
			 ----SELECT idDiscoveryRequest,3,1,CreatedOn
			 ----from  tblDiscoveryRequestImport$	
			 ----where idDiscoveryRequest is not NULL

						
			UPDATE tblDiscoveryRequestSvcsImport$
			SET tblDiscoveryRequestSvcsImport$.idRequest = import.idDiscoveryRequest
			FROM
				 tblDiscoveryRequestSvcsImport$ svc
			Right JOIN
				tblDiscoveryRequestImport$ import ON svc.CustomerName = import.CustomerName 

				

			 INSERT INTO tblDiscoveryRequestServices ( idRequest, idShippingSvc, volume, CreatedOn)
			 SELECT idRequest,idShippingSvc,Volume, GetDate()
			 from  tblDiscoveryRequestSvcsImport$	
			 where idRequest is not NULL

			 


		COMMIT



	END TRY
	BEGIN CATCH
	    Declare @Error Varchar(2000);
		SET @Error = ERROR_MESSAGE();
		If @@TRANCOUNT > 0
		begin
		   ROLLBACK
		   print 'ROLLBACK';
		   print @error

		 end
		  /** Save Error **/
		  --The application already updates the Exception table
		  --Insert into [PurolatorReporting].[dbo].[tblPI_ApplicationException]
		  --values (10,'',@Error,'exp_sp_ImportBeaconExpensesFromTemp','','','',@Updatedby,getdate())
	END CATCH


END 