using PuroReportingEntities;
using PuroTouchEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PuroFusionLib
{
    public class Counters
    {
        public int Count { get; set; }
        public string Value { get; set; }
        public int intValue { get; set; }
    }
    public class PuroReportingServiceClass
    {
        public string strConn;
        public const string strRetCodeNA = "na";
        public const string strRetCodeOK = "OK";

        public static class ConnString
        {
            public static string MetatData = @"metadata=res://*/PuroReportingModel.csdl|res://*/PuroReportingModel.ssdl|res://*/PuroReportingModel.msl;";
            public static string SqlClient = @"provider=System.Data.SqlClient;";
            public static string Provider = @"provider connection string='";
            public static string Framework = @"MultipleActiveResultSets=True;App=EntityFramework';";
            public static string PatientLocal = @"data source=VIRTUALONE\WIN10DEV2019;initial catalog=PurolatorReporting;integrated security=True;";
            public static string PatientLocal2 = @"data source=PI-DEV-SQL;initial catalog=PurolatorReporting;integrated security=True;";
            public static string PatientLocal3 = @"data source=DESKTOP-OHSBG8J\SQL2019;initial catalog=PurolatorReporting;integrated security=True;";

            public static string FullPatientLocal3 = MetatData + SqlClient + Provider + PatientLocal3 + Framework; 
            public static string FullPatientLocal2 = MetatData + SqlClient + Provider + PatientLocal2 + Framework;
            public static string FullPatientLocal = MetatData + SqlClient + Provider + PatientLocal + Framework;
        }
        public PuroReportingServiceClass()
        {
            strConn = ConnString.FullPatientLocal;
        }
        public PuroReportingServiceClass(string Conn)
        {
            strConn = Conn;
        }
        public static string getConnectionString()
        {
            return @"Data Source=PI-DEV-SQL;Initial Catalog=PURO_APPS;User ID=PuroIT;Password=puro@123;";
        }
        public string TestConn()
        {
            string strRetVal = strRetCodeNA;
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                int iCount = o.tblAccounts.Count();
                iCount++;
                strRetVal = strRetCodeOK;
            }
            catch (System.Exception ex)
            {
                strRetVal = ex.ToString();
            }
            return strRetVal;
        }
        #region dtotblPI_Applications
        public IList<dtotblPI_Applications> GetPI_Applications()
        {
            IList<dtotblPI_Applications> qtblPI_Applications = new List<dtotblPI_Applications>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qtblPI_Applications = (from p in o.tblPI_Applications
                              select new dtotblPI_Applications() { idPI_Application = p.idPI_Application, ApplicationName = p.ApplicationName ,UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn }).ToList();

            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblPI_Applications;
        }
        public IList<dtotblPI_Applications> GetPI_ApplicationsGroupByName()
        {
            IList<dtotblPI_Applications> qReuturn = new List<dtotblPI_Applications>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                IList<dtotblPI_Applications> qtblPI_Applications =  o.tblPI_Applications
                 .Select(p => new dtotblPI_Applications() { idPI_Application = p.idPI_Application, ApplicationName = p.ApplicationName, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                 .ToList();
                IList<Counters>qtheCount = qtblPI_Applications
                    .GroupBy(p => p.ApplicationName)
                    .Select(p => new Counters() { Count = p.Count(), Value = p.Key })
                    .ToList();
                foreach(Counters c in qtheCount)
                {
                    dtotblPI_Applications item = qtblPI_Applications.Where(f => f.ApplicationName.Contains(c.Value)).FirstOrDefault();
                    qReuturn.Add(item);
                }
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qReuturn;
        }
        #endregion
        #region dtotblEmployee
        public IList<dtotblEmployee> GettblEmployee()
        {
            IList<dtotblEmployee> qtblEmployee = new List<dtotblEmployee>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qtblEmployee = o.tblEmployee
                 .Select(p => new dtotblEmployee() { ActiveDirectoryName = p.ActiveDirectoryName,PI_EmployeeId = p.PI_EmployeeId, idEmployee = p.idEmployee, idEmployeeFunction = p.idEmployeeFunction, FirstName = p.FirstName, LastName = p.LastName, Title = p.Title,  DateHired = p.DateHired, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblEmployee;
        }
        #endregion
        #region PI_ApplicationUser
        public IList<tblPI_ApplicationUser> GetPI_ApplicationUser()
        {
            IList<tblPI_ApplicationUser> qPI_ApplicationUser = new List<tblPI_ApplicationUser>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qPI_ApplicationUser = o.tblPI_ApplicationUser
                 .Select(p => new tblPI_ApplicationUser() { idPI_ApplicationUser = p.idPI_ApplicationUser, idPI_Application = p.idPI_Application, idEmployee = p.idEmployee, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, EncryptedPassword = p.EncryptedPassword, Password = p.Password })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qPI_ApplicationUser;
        }
        public class MyUsers
        {
            public string ApplicationName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int idEmployee { get; set; }
        }
        public IList<dtoPuroTouchUsers> GetPuroTouchUsers()
        {
            IList<dtoPuroTouchUsers> qPI_ApplicationUser = new List<dtoPuroTouchUsers>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qPI_ApplicationUser = (from appU in o.tblPI_ApplicationUser
                        join emp in o.tblEmployee on appU.idEmployee equals emp.idEmployee
                        join app in o.tblPI_Applications on appU.idPI_Application equals app.idPI_Application
                        join appURole in o.tblPI_ApplicationUserRole on appU.idPI_ApplicationUser equals appURole.idPI_ApplicationUser
                        join appRole in o.tblPI_ApplicationRoles on appURole.idPI_ApplicationRole equals appRole.idPI_ApplicationRole
                        where appU.idPI_Application == 1018
                        select new dtoPuroTouchUsers() { idEmployee = appU.idEmployee, FirstName = emp.FirstName, LastName = emp.LastName, ApplicationName = app.ApplicationName,RoleName = appRole.RoleName, idPI_Application = appU.idPI_Application, idPI_ApplicationUser = appU.idPI_ApplicationUser, idPI_ApplicationUserRole = appURole.idPI_ApplicationUserRole, idPI_ApplicationRole = appURole.idPI_ApplicationRole })
                        .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qPI_ApplicationUser;
        }
        public IList<dtoPuroTouchUsers> GetPuroTouchUsersLambda()
        {
            IList<dtoPuroTouchUsers> qPI_ApplicationUser = new List<dtoPuroTouchUsers>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qPI_ApplicationUser = (from appU in o.tblPI_ApplicationUser
                                       join emp in o.tblEmployee on appU.idEmployee equals emp.idEmployee
                                       join app in o.tblPI_Applications on appU.idPI_Application equals app.idPI_Application
                                       join appURole in o.tblPI_ApplicationUserRole on appU.idPI_ApplicationUser equals appURole.idPI_ApplicationUser
                                       join appRole in o.tblPI_ApplicationRoles on appURole.idPI_ApplicationRole equals appRole.idPI_ApplicationRole
                                       where appU.idPI_Application == 1018
                                       select new dtoPuroTouchUsers() { idEmployee = appU.idEmployee, FirstName = emp.FirstName, LastName = emp.LastName, ApplicationName = app.ApplicationName, RoleName = appRole.RoleName, idPI_Application = appU.idPI_Application, idPI_ApplicationUser = appU.idPI_ApplicationUser, idPI_ApplicationUserRole = appURole.idPI_ApplicationUserRole, idPI_ApplicationRole = appURole.idPI_ApplicationRole })
                        .ToList();

                qPI_ApplicationUser = o.tblPI_ApplicationUser
                                .Join(o.tblEmployee, appU => appU.idEmployee, emp => emp.idEmployee, (appU, emp) => new dtoPuroTouchUsers() { idEmployee = emp.idEmployee, FirstName = emp.FirstName, idPI_Application = appU.idPI_Application })
                                .Where(p => p.idPI_Application == 1018)
                                .ToList();
                int er = 0;
                er++;
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qPI_ApplicationUser;
        }
        #endregion
        #region dtotblPI_ApplicationUserRole
        public IList<dtotblPI_ApplicationUserRole> GettblPI_ApplicationUserRole()
        {
            IList<dtotblPI_ApplicationUserRole> qtblPI_ApplicationUserRole = new List<dtotblPI_ApplicationUserRole>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qtblPI_ApplicationUserRole = o.tblPI_ApplicationUserRole
                 .Select(p => new dtotblPI_ApplicationUserRole() { idPI_ApplicationUser = p.idPI_ApplicationUser,  idPI_ApplicationRole = p.idPI_ApplicationRole,  idPI_ApplicationUserRole = p.idPI_ApplicationUserRole, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblPI_ApplicationUserRole;
        }
        public bool UpdateApplicationUserRole(dtoPuroTouchUsers PuroTouchUser, dtotblPI_ApplicationRoles appRole)
        {
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);

                tblPI_ApplicationUserRole qAppUserRole = o.tblPI_ApplicationUserRole
                                        .Where(p => p.idPI_ApplicationUserRole == PuroTouchUser.idPI_ApplicationUserRole)
                                        .FirstOrDefault();
                if (qAppUserRole != null)
                {
                    qAppUserRole.idPI_ApplicationRole = appRole.idPI_ApplicationRole;
                    o.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return true;
        }

        #endregion
        #region dtotblPI_ApplicationRoles
        public IList<dtotblPI_ApplicationRoles> GettblPI_ApplicationRoles()
        {
            IList<dtotblPI_ApplicationRoles> qtblPI_ApplicationRoles = new List<dtotblPI_ApplicationRoles>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qtblPI_ApplicationRoles = o.tblPI_ApplicationRoles
                 .Select(p => new dtotblPI_ApplicationRoles() {  idPI_Application = p.idPI_Application, idPI_ApplicationRole = p.idPI_ApplicationRole,  RoleCode = p.RoleCode, RoleName = p.RoleName ,UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblPI_ApplicationRoles;
        }
        public IList<dtotblPI_ApplicationRoles> GetPuroFusionApplicationRoles()
        {
            IList<dtotblPI_ApplicationRoles> qtblPI_ApplicationRoles = new List<dtotblPI_ApplicationRoles>();
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                qtblPI_ApplicationRoles = o.tblPI_ApplicationRoles
                    .Where(p=>p.idPI_Application == 1018)
                    .Select(p => new dtotblPI_ApplicationRoles() { idPI_Application = p.idPI_Application, idPI_ApplicationRole = p.idPI_ApplicationRole, RoleCode = p.RoleCode, RoleName = p.RoleName, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                    .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblPI_ApplicationRoles;
        }
        #endregion

    }
    
    public class PuroTouchServiceClass
    {
        public string strConn;
        public static class ConnString
        {
            public static string MetatData = @"metadata=res://*/PuroTouchModel.csdl|res://*/PuroTouchModel.ssdl|res://*/PuroTouchModel.msl;";
            public static string SqlClient = @"provider=System.Data.SqlClient;";
            public static string Provider = @"provider connection string='";
            public static string Framework = @"MultipleActiveResultSets=True;App=EntityFramework';";
            public static string PatientLocal2 = @"data source=PI-DEV-SQL;initial catalog=PuroTouchDB;integrated security=True;";
            public static string PatientLocal = @"data source=VIRTUALONE\WIN10DEV2019;initial catalog=PuroTouchDB;integrated security=True;";
            public static string PatientLocal3 = @"data source=DESKTOP-OHSBG8J\SQL2019;initial catalog=PuroTouchDB;integrated security=True;";
            public static string PatientLocalA = @"data source=VIRTUALONE\WIN10DEV2019;initial catalog=PuroTouchDB_Prod;integrated security=True;";
            
            public static string CombineDataSource = @"data source=";
            public static string CombineDataSourceCatalog = @";initial catalog=";
            public static string CombineDataSourceSecurity = @";integrated security=True;";

            public static string FullPatientLocal = MetatData + SqlClient + Provider + PatientLocal + Framework;
            public static string FullPatientLocal2 = MetatData + SqlClient + Provider + PatientLocal2 + Framework;
            public static string FullPatientLocal3 = MetatData + SqlClient + Provider + PatientLocal3 + Framework;
            public static string FullPatientLocalA = MetatData + SqlClient + Provider + PatientLocalA + Framework;
            public static string FullCombinedAddMachine = MetatData + SqlClient + Provider + CombineDataSource; // add machine name

        }
        public PuroTouchServiceClass()
        {
            strConn = ConnString.FullPatientLocal;
        }
        public PuroTouchServiceClass(string Conn)
        {
            strConn = Conn;
        }
        public static string getConnectionString()
        {
            return @"Data Source=PI-DEV-SQL;Initial Catalog=PURO_APPS;User ID=PuroIT;Password=puro@123;";
        }
        public void SetConnString(string MachineName, string Catolog)
        {
            strConn = ConnString.FullCombinedAddMachine + MachineName + ConnString.CombineDataSourceCatalog + Catolog + ConnString.CombineDataSourceSecurity + ConnString.Framework;
            string temp = ConnString.FullPatientLocal;
            int er = 0;
            er++;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }
        public string TestConn()
        {
            string strRetVal = "na";
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                int iCount = o.tblSolutionType.Count();
                iCount++;
                //strRetVal = OK;
            }
            catch (System.Exception ex)
            {
                strRetVal = ex.ToString();
            }
            return strRetVal;
        }
        #region tblDiscoveryRequest
        public IList<dtotblDiscoveryRequest> GettblDiscoveryRequest()
        {
            IList<dtotblDiscoveryRequest> qDiscoveryRequest = new List<dtotblDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, FreightAuditor = p.FreightAuditor, EDIDetails = p.EDIDetails.Remove(10), idEDISpecialist = p.idEDISpecialist, idBillingSpecialist = p.idBillingSpecialist, idCollectionSpecialist = p.idCollectionSpecialist, AuditorPortal = p.AuditorPortal, AuditorURL = p.AuditorURL, AuditorUserName = p.AuditorUserName, AuditorPassword = p.AuditorPassword, EDITargetGoLive = p.EDITargetGoLive, EDICurrentGoLive = p.EDICurrentGoLive, EDIActualGoLive = p.EDIActualGoLive, idEDIOnboardingPhase = p.idEDIOnboardingPhase, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn })
                 .ToList();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }
            return qDiscoveryRequest;
        }
        public dtotblDiscoveryRequest GetDiscoveryRequestByID(int idRequest)
        {
            dtotblDiscoveryRequest qDiscoveryRequest = new dtotblDiscoveryRequest ();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest
                 .Where(p=>p.idRequest == idRequest)
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, FreightAuditor = p.FreightAuditor, EDIDetails = p.EDIDetails.Remove(10), idEDISpecialist = p.idEDISpecialist, idBillingSpecialist = p.idBillingSpecialist, idCollectionSpecialist = p.idCollectionSpecialist, AuditorPortal = p.AuditorPortal, AuditorURL = p.AuditorURL, AuditorUserName = p.AuditorUserName, AuditorPassword = p.AuditorPassword, EDITargetGoLive = p.EDITargetGoLive, EDICurrentGoLive = p.EDICurrentGoLive, EDIActualGoLive = p.EDIActualGoLive, idEDIOnboardingPhase = p.idEDIOnboardingPhase, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn })
                 .FirstOrDefault();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }
            return qDiscoveryRequest;
        }

        public int InsertDiscoveryRequest(dtotblDiscoveryRequest data)
        {
            IList<dtotblDiscoveryRequest> qDiscoveryRequest = new List<dtotblDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                var q = o.tblDiscoveryRequest.Where(f => f.idRequest == data.idRequest).FirstOrDefault();
                if (q == null)
                {
                    tblDiscoveryRequest rec = new tblDiscoveryRequest()
                    {
                        isNewRequest = data.isNewRequest,
                        SalesRepName = data.SalesRepName,
                        SalesRepEmail = data.SalesRepEmail,
                        idOnboardingPhase = (int?)data.idOnboardingPhase,
                        District = data.District,
                        CustomerName = data.CustomerName,
                        Address = data.Address,
                        City = data.City,
                        State = data.State,
                        Zipcode = data.Zipcode,
                        Country = data.Country,
                        Commodity = data.Commodity,
                        ProjectedRevenue = (decimal)data.ProjectedRevenue,
                        CurrentSolution = data.CurrentSolution,
                        ProposedCustoms = data.ProposedCustoms,
                        CallDate1 = (DateTime?)data.CallDate1,
                        CallDate2 = (DateTime?)data.CallDate2,
                        CallDate3 = (DateTime?)data.CallDate3,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                        UpdatedBy = data.CreatedBy,
                        ActiveFlag = data.ActiveFlag,
                        SalesComments = data.SalesComments,
                        idITBA = (int?)data.idITBA,
                        idShippingChannel = (int?)data.idShippingChannel,
                        SolutionSummary = data.SolutionSummary,
                        CustomerWebsite = data.CustomerWebsite,
                        Branch = data.Branch,
                        idVendor = (int?)data.idVendor,
                        worldpakFlag = (bool?)data.worldpakFlag,
                        thirdpartyFlag = (bool?)data.thirdpartyFlag,
                        customFlag = (bool?)data.customFlag,
                        DataScrubFlag = (Boolean)data.DataScrubFlag,
                        InvoiceType = data.InvoiceType,
                        BilltoAccount = data.BilltoAccount,
                        FTPUsername = data.FTPUsername,
                        FTPPassword = data.FTPPassword,
                        CustomsSupportedFlag = data.CustomsSupportedFlag,
                        ElinkFlag = data.ElinkFlag,
                        PARS = data.PARS,
                        PASS = data.PASS,
                        CustomsBroker = data.CustomsBroker,
                        BrokerNumber = data.BrokerNumber,
                        SupportUser = data.SupportUser,
                        SupportGroup = data.SupportGroup,
                        Office = data.Office,
                        Group = data.Group,
                        MigrationDate = (DateTime?)data.MigrationDate,
                        PreMigrationSolution = data.PreMigrationSolution,
                        PostMigrationSolution = data.PostMigrationSolution,
                        ControlBranch = data.ControlBranch,
                        ContractNumber = data.ContractNumber,
                        ContractStartDate = (DateTime?)data.ContractStartDate,
                        ContractEndDate = (DateTime?)data.ContractEndDate,
                        ContractCurrency = data.ContractCurrency,
                        PaymentTerms = data.PaymentTerms,
                        CloseReason = data.CloseReason,
                        CRR = data.CRR,
                        EDICustomizedFlag = data.EDICustomizedFlag,
                        StrategicFlag = data.StrategicFlag,
                        ReturnsAcctNbr = data.ReturnsAcctNbr,
                        ReturnsAddress = data.ReturnsAddress,
                        ReturnsCity = data.ReturnsCity,
                        ReturnsState = data.ReturnsState,
                        ReturnsZip = data.ReturnsZip,
                        ReturnsCountry = data.ReturnsCountry,
                        ReturnsDestroyFlag = (bool?)data.ReturnsDestroyFlag,
                        ReturnsCreateLabelFlag = (bool?)data.ReturnsCreateLabelFlag,
                        WPKSandboxUsername = data.WPKSandboxUsername,
                        WPKSandboxPwd = data.WPKSandboxPwd,
                        WPKProdUsername = data.WPKProdUsername,
                        WPKProdPwd = data.WPKProdPwd,
                        WPKCustomExportFlag = (bool?)data.WPKCustomExportFlag,
                        WPKGhostScanFlag = (bool?)data.WPKGhostScanFlag,
                        WPKEastWestSplitFlag = (bool?)data.WPKEastWestSplitFlag,
                        WPKAddressUploadFlag = (bool?)data.WPKAddressUploadFlag,
                        WPKProductUploadFlag = (bool?)data.WPKProductUploadFlag,
                        WPKEquipmentFlag = (bool?)data.WPKEquipmentFlag,
                        WPKDataEntryMethod = data.WPKDataEntryMethod,
                        EWSelectBy = data.EWSelectBy,
                        EWSortCodeFlag = (bool?)data.EWSortCodeFlag,
                        EWEastSortCode = data.EWEastSortCode,
                        EWWestSortCode = data.EWWestSortCode,
                        EWSepCloseoutFlag = data.EWSepCloseoutFlag,
                        EWSepPUFlag = data.EWSepPUFlag,
                        EWSortDetails = data.EWSortDetails,
                        EWMissortDetails = data.EWMissortDetails,
                        CurrentGoLive = (DateTime?)data.CurrentGoLive,
                        PhaseChangeDate = (DateTime?)data.PhaseChangeDate,
                        idRequestType = (int?)data.idRequestType,
                        idSolutionType = (int)data.idSolutionType,
                        CurrentlyShippingFlag = (bool?)data.CurrentlyShippingFlag,
                        idShippingVendor = (int?)data.idShippingVendor,
                        OtherVendorName = data.OtherVendorName,
                        idBroker = (int?)data.idBroker,
                        OtherBrokerName = data.OtherBrokerName,
                        idVendorType = (int?)data.idVendorType,
                        FreightAuditor = (bool?)data.FreightAuditor,
                        Route = data.Route,
                        EDIDetails = data.EDIDetails,
                        idEDISpecialist = (int?)data.idEDISpecialist,
                        idBillingSpecialist = (int?)data.idBillingSpecialist,
                        idCollectionSpecialist = (int?)data.idCollectionSpecialist,
                        AuditorPortal = (bool?)data.AuditorPortal,
                        AuditorURL = data.AuditorURL,
                        AuditorUserName = data.AuditorUserName,
                        AuditorPassword = data.AuditorPassword,
                        EDITargetGoLive = (DateTime?)data.EDITargetGoLive,
                        EDICurrentGoLive = (DateTime?)data.EDICurrentGoLive,
                        EDIActualGoLive = (DateTime?)data.EDIActualGoLive,
                        idEDIOnboardingPhase = (int)data.idEDIOnboardingPhase

                    };
                    o.tblDiscoveryRequest.Add(rec);
                }
                else
                {
                    q.isNewRequest = data.isNewRequest;
                    q.SalesRepName = data.SalesRepName;
                    q.SalesRepEmail = data.SalesRepEmail;
                    q.idOnboardingPhase = (int?)data.idOnboardingPhase;
                    q.District = data.District;
                    q.CustomerName = data.CustomerName;
                    q.Address = data.Address;
                    q.City = data.City;
                    q.State = data.State;
                    q.Zipcode = data.Zipcode;
                    q.Country = data.Country;
                    q.Commodity = data.Commodity;
                    q.ProjectedRevenue = (decimal)data.ProjectedRevenue;
                    q.CurrentSolution = data.CurrentSolution;
                    q.ProposedCustoms = data.ProposedCustoms;
                    q.CallDate1 = (DateTime?)data.CallDate1;
                    q.CallDate2 = (DateTime?)data.CallDate2;
                    q.CallDate3 = (DateTime?)data.CallDate3;
                    q.CreatedBy = data.CreatedBy;
                    q.CreatedOn = (DateTime?)data.CreatedOn;
                    q.ActiveFlag = data.ActiveFlag;
                    q.SalesComments = data.SalesComments;
                    q.idITBA = (int?)data.idITBA;
                    q.idShippingChannel = (int?)data.idShippingChannel;
                    q.SolutionSummary = data.SolutionSummary;
                    q.CustomerWebsite = data.CustomerWebsite;
                    q.Branch = data.Branch;
                    q.idVendor = (int?)data.idVendor;
                    q.worldpakFlag = (bool?)data.worldpakFlag;
                    q.thirdpartyFlag = (bool?)data.thirdpartyFlag;
                    q.customFlag = (bool?)data.customFlag;
                    q.DataScrubFlag = (Boolean)data.DataScrubFlag;
                    q.InvoiceType = data.InvoiceType;
                    q.BilltoAccount = data.BilltoAccount;
                    q.FTPUsername = data.FTPUsername;
                    q.FTPPassword = data.FTPPassword;
                    q.CustomsSupportedFlag = data.CustomsSupportedFlag;
                    q.ElinkFlag = data.ElinkFlag;
                    q.PARS = data.PARS;
                    q.PASS = data.PASS;
                    q.CustomsBroker = data.CustomsBroker;
                    q.BrokerNumber = data.BrokerNumber;
                    q.SupportUser = data.SupportUser;
                    q.SupportGroup = data.SupportGroup;
                    q.Office = data.Office;
                    q.Group = data.Group;
                    q.MigrationDate = (DateTime?)data.MigrationDate;
                    q.PreMigrationSolution = data.PreMigrationSolution;
                    q.PostMigrationSolution = data.PostMigrationSolution;
                    q.ControlBranch = data.ControlBranch;
                    q.ContractNumber = data.ContractNumber;
                    q.ContractStartDate = (DateTime?)data.ContractStartDate;
                    q.ContractEndDate = (DateTime?)data.ContractEndDate;
                    q.ContractCurrency = data.ContractCurrency;
                    q.PaymentTerms = data.PaymentTerms;
                    q.CloseReason = data.CloseReason;
                    q.CRR = data.CRR;
                    q.EDICustomizedFlag = data.EDICustomizedFlag;
                    q.StrategicFlag = data.StrategicFlag;
                    q.ReturnsAcctNbr = data.ReturnsAcctNbr;
                    q.ReturnsAddress = data.ReturnsAddress;
                    q.ReturnsCity = data.ReturnsCity;
                    q.ReturnsState = data.ReturnsState;
                    q.ReturnsZip = data.ReturnsZip;
                    q.ReturnsCountry = data.ReturnsCountry;
                    q.ReturnsDestroyFlag = (bool?)data.ReturnsDestroyFlag;
                    q.ReturnsCreateLabelFlag = (bool?)data.ReturnsCreateLabelFlag;
                    q.WPKSandboxUsername = data.WPKSandboxUsername;
                    q.WPKSandboxPwd = data.WPKSandboxPwd;
                    q.WPKProdUsername = data.WPKProdUsername;
                    q.WPKProdPwd = data.WPKProdPwd;
                    q.WPKCustomExportFlag = (bool?)data.WPKCustomExportFlag;
                    q.WPKGhostScanFlag = (bool?)data.WPKGhostScanFlag;
                    q.WPKEastWestSplitFlag = (bool?)data.WPKEastWestSplitFlag;
                    q.WPKAddressUploadFlag = (bool?)data.WPKAddressUploadFlag;
                    q.WPKProductUploadFlag = (bool?)data.WPKProductUploadFlag;
                    q.WPKEquipmentFlag = (bool?)data.WPKEquipmentFlag;
                    q.WPKDataEntryMethod = data.WPKDataEntryMethod;
                    q.EWSelectBy = data.EWSelectBy;
                    q.EWSortCodeFlag = (bool?)data.EWSortCodeFlag;
                    q.EWEastSortCode = data.EWEastSortCode;
                    q.EWWestSortCode = data.EWWestSortCode;
                    q.EWSepCloseoutFlag = data.EWSepCloseoutFlag;
                    q.EWSepPUFlag = data.EWSepPUFlag;
                    q.EWSortDetails = data.EWSortDetails;
                    q.EWMissortDetails = data.EWMissortDetails;
                    q.CurrentGoLive = (DateTime?)data.CurrentGoLive;
                    q.PhaseChangeDate = (DateTime?)data.PhaseChangeDate;
                    q.idRequestType = (int?)data.idRequestType;
                    q.idSolutionType = (int)data.idSolutionType;
                    q.CurrentlyShippingFlag = (bool?)data.CurrentlyShippingFlag;
                    q.idShippingVendor = (int?)data.idShippingVendor;
                    q.OtherVendorName = data.OtherVendorName;
                    q.idBroker = (int?)data.idBroker;
                    q.OtherBrokerName = data.OtherBrokerName;
                    q.idVendorType = (int?)data.idVendorType;
                    q.FreightAuditor = (bool?)data.FreightAuditor;
                    q.Route = data.Route;
                    q.EDIDetails = data.EDIDetails;
                    q.idEDISpecialist = (int?)data.idEDISpecialist;
                    q.idBillingSpecialist = (int?)data.idBillingSpecialist;
                    q.idCollectionSpecialist = (int?)data.idCollectionSpecialist;
                    q.AuditorPortal = (bool?)data.AuditorPortal;
                    q.AuditorURL = data.AuditorURL;
                    q.AuditorUserName = data.AuditorUserName;
                    q.AuditorPassword = data.AuditorPassword;
                    q.EDITargetGoLive = (DateTime?)data.EDITargetGoLive;
                    q.EDICurrentGoLive = (DateTime?)data.EDICurrentGoLive;
                    q.EDIActualGoLive = (DateTime?)data.EDIActualGoLive;
                    q.idEDIOnboardingPhase = (int)data.idEDIOnboardingPhase;
                }
                o.SaveChanges();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }
            return 0;
        }
        
        private string Testsql = @"INSERT[dbo].[tblDiscoveryRequest]( [isNewRequest], [SalesRepName], [SalesRepEmail], [idOnboardingPhase], [District], [CustomerName], [Address], [City], [State], [Zipcode], [Country], [Commodity], [ProjectedRevenue], [CurrentSolution], [ProposedCustoms], [CallDate1], [CallDate2], [CallDate3], [UpdatedBy], [UpdatedOn], [CreatedBy], [CreatedOn], [ActiveFlag], [SalesComments], [idITBA], [idShippingChannel], [TargetGoLive], [ActualGoLive], [SolutionSummary], [CustomerWebsite], [Branch], [idVendor], [worldpakFlag], [thirdpartyFlag], [customFlag], [InvoiceType], [BilltoAccount], [FTPUsername], [FTPPassword], [CustomsSupportedFlag], [ElinkFlag], [PARS], [PASS], [CustomsBroker], [SupportUser], [SupportGroup], [Office], [Group], [MigrationDate], [PreMigrationSolution], [PostMigrationSolution], [ControlBranch], [ContractNumber], [ContractStartDate], [ContractEndDate], [ContractCurrency], [PaymentTerms], [CloseReason], [CRR], [BrokerNumber], [DataScrubFlag], [EDICustomizedFlag], [StrategicFlag], [ReturnsAcctNbr], [ReturnsAddress], [ReturnsCity], [ReturnsState], [ReturnsZip], [ReturnsCountry], [ReturnsDestroyFlag], [ReturnsCreateLabelFlag], [WPKSandboxUsername], [WPKSandboxPwd], [WPKProdUsername], [WPKProdPwd], [WPKCustomExportFlag], [WPKGhostScanFlag], [WPKEastWestSplitFlag], [WPKAddressUploadFlag], [WPKProductUploadFlag], [WPKDataEntryMethod], [WPKEquipmentFlag], [EWSelectBy], [EWSortCodeFlag], [EWEastSortCode], [EWWestSortCode], [EWSepCloseoutFlag], [EWSepPUFlag], [EWSortDetails], [EWMissortDetails], [CurrentGoLive], [PhaseChangeDate], [idRequestType], [CurrentlyShippingFlag], [idShippingVendor], [OtherVendorName], [idBroker], [OtherBrokerName], [idVendorType], [Route], [idSolutionType], [FreightAuditor], [EDIDetails], [idEDISpecialist], [idBillingSpecialist], [idCollectionSpecialist], [AuditorPortal], [AuditorURL], [AuditorUserName], [AuditorPassword], [EDITargetGoLive], [EDICurrentGoLive], [EDIActualGoLive], [idEDIOnboardingPhase]) " +
                "VALUES(1, N'Joe Murphy', N'Joe.Murphy@purolator.com', 8, N'EASTERN', N'Both Test 2', N'Both Address 2', N'BAY SHORE', N'NY', N'12 street', N'United States', N'Cheese', 9999.2200, N'sadgfagv', N'PARS & PASS', NULL, NULL, NULL, N'scott.cardinale', CAST(N'2021-06-04T15:15:28.137' AS DateTime), N'scott.cardinale', CAST(N'2021-06-04T15:15:28.137' AS DateTime), 1, N'aswdefw', NULL, NULL, NULL, NULL, N'', N'', N'BUF', NULL, 0, 0, 0, N'', N'', N'', N'', 1, 0, N'                         ', N'                         ', N'                                                                                                                                                                                                                                                               ', N'', N'', N'', N'', NULL, N'', N'', N'', N'', NULL, NULL, N'', N'', NULL, N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', 0, 0, N'', N'', N'', N'', 0, 0, 0, 0, 0, N'', 0, N'', 0, N'', N'', 0, 0, N'', N'', NULL, CAST(N'2021-04-23T15:04:57.723' AS DateTime), 3, 1, NULL, N'', 4, N'', NULL, N'', 3, 1, N'', NULL, NULL, NULL, 0, N'', N'', N'', NULL, NULL, NULL, 0)";
        public void InsertTestDiscoveryRequestRecord(string sql)
        {
            SqlConnection cnn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            cnn.Close();
            return;
        }
        public IList<dtotblDiscoveryRequest> GettblDiscoveryRequestDesc()
        {
            IList<dtotblDiscoveryRequest> qDiscoveryRequest = new List<dtotblDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, FreightAuditor = p.FreightAuditor, EDIDetails = p.EDIDetails.Remove(10), idEDISpecialist = p.idEDISpecialist, idBillingSpecialist = p.idBillingSpecialist, idCollectionSpecialist = p.idCollectionSpecialist, AuditorPortal = p.AuditorPortal, AuditorURL = p.AuditorURL, AuditorUserName = p.AuditorUserName, AuditorPassword = p.AuditorPassword, EDITargetGoLive = p.EDITargetGoLive, EDICurrentGoLive = p.EDICurrentGoLive, EDIActualGoLive = p.EDIActualGoLive, idEDIOnboardingPhase = p.idEDIOnboardingPhase, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, CreatedBy = p.CreatedBy,CreatedOn = p.CreatedOn })
                 .OrderByDescending(p=>p.idRequest)
                 .ToList();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }
            return qDiscoveryRequest;
        }
        public IList<dtotblDiscoveryRequest> GettblDiscoveryRequestDesc2()
        {
            IList<dtotblDiscoveryRequest> qDiscoveryRequest = new List<dtotblDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, FreightAuditor = p.FreightAuditor, EDIDetails = p.EDIDetails.Remove(10), idEDISpecialist = p.idEDISpecialist, idBillingSpecialist = p.idBillingSpecialist, idCollectionSpecialist = p.idCollectionSpecialist, AuditorPortal = p.AuditorPortal, AuditorURL = p.AuditorURL, AuditorUserName = p.AuditorUserName, AuditorPassword = p.AuditorPassword, EDITargetGoLive = p.EDITargetGoLive, EDICurrentGoLive = p.EDICurrentGoLive, EDIActualGoLive = p.EDIActualGoLive, idEDIOnboardingPhase = p.idEDIOnboardingPhase, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn })
                 .OrderByDescending(p => p.CreatedOn)
                 .ToList();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }
            return qDiscoveryRequest;
        }
        //public IList<dtoPartialDiscoveryRequest> GetPartialDiscoveryRequest()
        //{
        //    IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = new List<dtoPartialDiscoveryRequest>();
        //    try
        //    {
        //        PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
        //        qDiscoveryRequest = o.tblDiscoveryRequest_
        //         .Select(p => new dtoPartialDiscoveryRequest() { idRequest = p.idRequest, CustomerBusContact = p.CustomerBusContact.Substring(0, 20), CustomerBusTitle = p.CustomerBusTitle.Substring(0, 20), CustomerBusEmail = p.CustomerBusEmail.Substring(0, 20), CustomerBusPhone = p.CustomerBusPhone.Substring(0, 20), CustomerITContact = p.CustomerITContact.Substring(0, 20), CustomerITTitle = p.CustomerITTitle.Substring(0, 20), CustomerITEmail = p.CustomerITEmail.Substring(0, 20), CustomerITPhone = p.CustomerITPhone.Substring(0, 20), ActiveFlag = p.ActiveFlag })
        //         .Where(f => f.ActiveFlag == true)
        //         .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        //retValue = ex.ToString();ProgramSubdiv
        //    }
        //    return qDiscoveryRequest;
        //}
        //public IList<dtoPartialDiscoveryRequest> GetDiscoveryRequestBusContacts()
        //{
        //    IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = new List<dtoPartialDiscoveryRequest>();
        //    try
        //    {
        //        PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
        //        qDiscoveryRequest = o.tblDiscoveryRequest_
        //         .Select(p => new dtoPartialDiscoveryRequest() { idRequest = p.idRequest, CustomerBusContact = p.CustomerBusContact.Substring(0, 20), CustomerBusTitle = p.CustomerBusTitle.Substring(0, 20), CustomerBusEmail = p.CustomerBusEmail.Substring(0, 20), CustomerBusPhone = p.CustomerBusPhone.Substring(0, 20), CustomerITContact = p.CustomerITContact.Substring(0, 20), CustomerITTitle = p.CustomerITTitle.Substring(0, 20), CustomerITEmail = p.CustomerITEmail.Substring(0, 20), CustomerITPhone = p.CustomerITPhone.Substring(0, 20), ActiveFlag = p.ActiveFlag })
        //         .Where(f => f.ActiveFlag == true && !String.IsNullOrEmpty(f.CustomerBusContact))
        //         .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        //retValue = ex.ToString();ProgramSubdiv
        //    }
        //    return qDiscoveryRequest;
        //}
        //public IList<dtoPartialDiscoveryRequest> GetDiscoveryRequestITContacts()
        //{
        //    IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = new List<dtoPartialDiscoveryRequest>();
        //    try
        //    {
        //        PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
        //        qDiscoveryRequest = o.tblDiscoveryRequest_
        //         .Select(p => new dtoPartialDiscoveryRequest() { idRequest = p.idRequest, CustomerBusContact = p.CustomerBusContact.Substring(0, 20), CustomerBusTitle = p.CustomerBusTitle.Substring(0, 20), CustomerBusEmail = p.CustomerBusEmail.Substring(0, 20), CustomerBusPhone = p.CustomerBusPhone.Substring(0, 20), CustomerITContact = p.CustomerITContact.Substring(0, 20), CustomerITTitle = p.CustomerITTitle.Substring(0, 20), CustomerITEmail = p.CustomerITEmail.Substring(0, 20), CustomerITPhone = p.CustomerITPhone.Substring(0, 20), ActiveFlag = p.ActiveFlag })
        //         .Where(f => f.ActiveFlag == true && !String.IsNullOrEmpty(f.CustomerITContact))
        //         .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        //retValue = ex.ToString();ProgramSubdiv
        //    }
        //    return qDiscoveryRequest;
        //}
        #endregion
        #region tblContactType
        public IList<dtotblContactType> GettblContactType()
        {
            IList<dtotblContactType> qtblContactType = new List<dtotblContactType>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qtblContactType = o.tblContactType
                 .Select(p => new dtotblContactType() { idContactType = p.idContactType, ContactType = p.ContactType, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblContactType;
        }
        #endregion
        #region tblContact
        public IList<dtotblContact> GettblContact()
        {
            IList<dtotblContact> qtblContact = new List<dtotblContact>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qtblContact = o.tblContact
                 .Select(p => new dtotblContact() { idContact = p.idContact, idRequest = p.idRequest, idContactType = p.idContactType, Email = p.Email, Name = p.Name, Phone = p.Phone.Substring(0, 20), Title = p.Title,  UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn,  CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, ActiveFlag = p.ActiveFlag })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtblContact;
        }
        public IList<Counters> GettblContactGroupBy()
        {
            IList<dtotblContact> qtblContact = new List<dtotblContact>();
            IList<Counters> qtheCount = new List<Counters>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qtblContact = o.tblContact
                 .Select(p => new dtotblContact() { idContact = p.idContact, idRequest = p.idRequest, idContactType = p.idContactType, Email = p.Email, Name = p.Name, Phone = p.Phone.Substring(0, 20), Title = p.Title, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, ActiveFlag = p.ActiveFlag })
                 .ToList();
                qtheCount = qtblContact
                    .GroupBy(p => p.idRequest)
                    .Where(f => f.Count() > 1)
                    .Select(p => new Counters() { Count = p.Count(), intValue = p.Key })
                    .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qtheCount;
        }
        public List<dtotblContact> GetContactsByRequestID(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<dtotblContact> qtblContact = o.tblContact
                                           .Where(p=>p.idRequest == idRequest)
                                         .Select(p => new dtotblContact() { idContact = p.idContact, idRequest = p.idRequest, idContactType = p.idContactType, Email = p.Email, Name = p.Name, Phone = p.Phone.Substring(0, 20), Title = p.Title, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, ActiveFlag = p.ActiveFlag })
                                         .ToList();
            return qtblContact;
        }
        public string InsertContact(dtotblContact data)
        {
            string errMsg = "";
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            try
            {
                var contact = o.tblContact.Where(p => p.idRequest == data.idRequest && p.idContactType == data.idContactType).FirstOrDefault();
                if (contact == null)
                {
                    tblContact oNewRow = new tblContact()
                    {
                        idRequest = data.idRequest,
                        idContactType = data.idContactType,
                        Name = data.Name,
                        Title = data.Title,
                        Phone = data.Phone,
                        Email = data.Email,
                        CreatedBy = data.CreatedBy,
                        CreatedOn = data.CreatedOn,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = DateTime.Now,
                        ActiveFlag = data.ActiveFlag
                    };
                    o.tblContact.Add(oNewRow);
                }
                else
                {
                    contact.Name = data.Name;
                    contact.Title = data.Title;
                    contact.Phone = data.Phone;
                    contact.Email = data.Email;
                    contact.CreatedBy = data.CreatedBy;
                    contact.CreatedOn = data.CreatedOn;
                    contact.UpdatedBy = data.UpdatedBy;
                    contact.UpdatedOn = DateTime.Now;
                    contact.ActiveFlag = data.ActiveFlag;
                }
                o.SaveChanges();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            return errMsg;
        }
        #endregion
        #region tblITBA
        public List<dtotblITBA> GetITBAs()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<dtotblITBA> qITBAs = o.tblITBA
                                                .Select(p => new dtotblITBA() { idITBA = p.idITBA, idEmployee = p.idEmployee, ITBAemail = p.ITBAemail, login = p.login, ReceiveNewReqEmail = p.ReceiveNewReqEmail, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                                .ToList();

            return qITBAs;
        }
        #endregion

        #region tblEDIAccount
        public List<clsEDIAccount> GetEDIAccounts()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<clsEDIAccount> qEDIAccounts = o.tblEDIAccounts
                                        //.Where(p => p.idRequest == idRequest)
                                        .Select(p => new clsEDIAccount() { idEDIAccount = p.idEDIAccount, idEDITranscation = p.idEDITranscation, AccountNumber = p.AccountNumber, idRequest = p.idRequest, EDITranscationType = p.EDITranscationType, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                        .ToList();
            return qEDIAccounts;
        }
        public List<clsEDIAccount> GetEDIAccountByidRequest(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<clsEDIAccount> qEDIAccounts = o.tblEDIAccounts
                                                .Where(p => p.idRequest == idRequest)
                                                .Select(p => new clsEDIAccount() { idEDIAccount = p.idEDIAccount, idEDITranscation = p.idEDITranscation, AccountNumber = p.AccountNumber, idRequest = p.idRequest, EDITranscationType = p.EDITranscationType, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                                .ToList();
            return qEDIAccounts;
        }
        public List<clsEDIAccount> GetEDIAccountByidEDITranscation(int idEDITranscation)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<clsEDIAccount> qEDIAccounts = o.tblEDIAccounts
                                                .Where(p => p.idEDITranscation == idEDITranscation)
                                                .Select(p => new clsEDIAccount() { idEDIAccount = p.idEDIAccount, idEDITranscation = p.idEDITranscation, AccountNumber = p.AccountNumber, idRequest = p.idRequest, EDITranscationType = p.EDITranscationType, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                                .ToList();
            return qEDIAccounts;
        }
        #endregion
        #region tblEDITranscations
        public List<dtotblEDITranscations> GetEDITransactions()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<dtotblEDITranscations> qEDITrans = new List<dtotblEDITranscations>();
            try
            {
                qEDITrans = o.tblEDITranscations
                            .Select(p => new dtotblEDITranscations() { idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, EDITranscationType = p.tblEDITranscationType.EDITranscationType, idEDITranscationType = p.idEDITranscationType, TotalRequests = p.TotalRequests, BatchInvoices = p.BatchInvoices, CombinePayer = p.CombinePayer,SFTPFolder = p.SFTPFolder, TestEnvironment = p.TestEnvironment, TestSentMethod = p.TestSentMethod ,ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                            .ToList();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }

            return qEDITrans;
        }
        public List<dtotblEDITranscations> GetEDITransactionsByidRequest(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<dtotblEDITranscations> qEDITrans = new List<dtotblEDITranscations>();
            try
            {
                qEDITrans = o.tblEDITranscations
                            .Where(p => p.idRequest == idRequest && p.tblEDITranscationType.CategoryID == 0)
                            .Select(p => new dtotblEDITranscations() { idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, EDITranscationType = p.tblEDITranscationType.EDITranscationType, idEDITranscationType = p.idEDITranscationType, TotalRequests = p.TotalRequests, BatchInvoices = p.BatchInvoices, CombinePayer = p.CombinePayer, SFTPFolder = p.SFTPFolder, TestEnvironment = p.TestEnvironment, TestSentMethod = p.TestSentMethod, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                            .ToList();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }

            return qEDITrans;
        }
        public List<dtotblEDITranscations> GetEDITransactionsByidRequestW_OCategory(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<dtotblEDITranscations> qEDITrans = new List<dtotblEDITranscations>();
            try
            {
                qEDITrans = o.tblEDITranscations
                             .Where(p => p.idRequest == idRequest && p.ActiveFlag == true)
                            .Select(p => new dtotblEDITranscations() { idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, EDITranscationType = p.tblEDITranscationType.EDITranscationType, idEDITranscationType = p.idEDITranscationType, TotalRequests = p.TotalRequests, BatchInvoices = p.BatchInvoices, CombinePayer = p.CombinePayer, SFTPFolder = p.SFTPFolder, TestEnvironment = p.TestEnvironment, TestSentMethod = p.TestSentMethod, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                            .ToList();
            }
            catch (Exception ex)
            {
                long lnewID = 0;
                clsExceptionLogging error = new clsExceptionLogging() { Method = GetCurrentMethod(), ExceptionMsg = ex.Message.ToString(), ExceptionType = ex.GetType().Name.ToString(), ExceptionSource = ex.StackTrace.ToString(), CreatedOn = DateTime.Now };
                InsertErrorIntoDB(error, out lnewID);
            }
            return qEDITrans;
        }
        #endregion
        #region tblEDITranscationType
        public List<clsEDITransactionType> GetEDITransactionTypes()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<clsEDITransactionType> qTransType = o.tblEDITranscationType
                                                .Select(p => new clsEDITransactionType() { idEDITranscationType = p.idEDITranscationType, EDITranscationType = p.EDITranscationType, Category = p.Category, CategoryID = p.CategoryID, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                                //.Where(f => f.ActiveFlag == true)
                                                .ToList();
            return qTransType;
        }
        #endregion
        #region tblEDIShipMethod
        public List<dtotblEDIShipMethods> GetEDIShipMethodTypesByidRequest(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtotblEDIShipMethods> qShipMeth = o.tblEDIShipMethods
                                    .Where(p => p.idRequest == idRequest)
                                    .Select(p => new dtotblEDIShipMethods() { idEDIShipMethod = p.idEDIShipMethod, idRequest = p.idRequest, MethodType = p.tblEDIShipMethodTypes.MethodType, idEDIShipMethodType = p.idEDIShipMethodType, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qShipMeth;
        }
        #endregion
        #region tblEDIRecipReq
        public List<dtotblEDIRecipReqs> GetEDIRecipReqs()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtotblEDIRecipReqs> qEDIRecipReqs = o.tblEDIRecipReqs
                                    //.Where(p => p.idEDIRecipReqs == idEDIRecipReqs)
                                    .Select(p => new dtotblEDIRecipReqs() { idEDIRecipReqs = p.idEDIRecipReqs, RecipReqNum = p.RecipReqNum, PanelTitle = p.PanelTitle, idFileType = p.idFileType, X12_GS = p.X12_GS, X12_ISA = p.X12_ISA, X12_Qualifier = p.X12_Qualifier, idCommunicationMethod = p.idCommunicationMethod, FTPAddress = p.FTPAddress, UserName = p.UserName, Password = p.Password, FolderPath = p.FolderPath, Email = p.Email, idTriggerMechanism = p.idTriggerMechanism, idTiming = p.idTiming, TimeOfFile = p.TimeOfFile, idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, idEDITranscationType = p.tblEDITranscations.idEDITranscationType, EDITranscationType = p.EDITranscationType, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qEDIRecipReqs;
        }
        public List<dtotblEDIRecipReqs> GetEDIRecipReqsByRequesID(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtotblEDIRecipReqs> qEDIRecipReqs = o.tblEDIRecipReqs
                                    .Where(p => p.idRequest == idRequest)
                                    .Select(p => new dtotblEDIRecipReqs() { idEDIRecipReqs = p.idEDIRecipReqs, RecipReqNum = p.RecipReqNum, PanelTitle = p.PanelTitle, idFileType = p.idFileType, X12_GS = p.X12_GS, X12_ISA = p.X12_ISA, X12_Qualifier = p.X12_Qualifier, idCommunicationMethod = p.idCommunicationMethod, FTPAddress = p.FTPAddress, UserName = p.UserName, Password = p.Password, FolderPath = p.FolderPath, Email = p.Email, idTriggerMechanism = p.idTriggerMechanism, idTiming = p.idTiming, TimeOfFile = p.TimeOfFile, idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, idEDITranscationType = p.tblEDITranscations.idEDITranscationType, EDITranscationType = p.EDITranscationType, Category = p.Category ,ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qEDIRecipReqs;
        }
        public List<dtotblEDIRecipReqs> GetEDIRecipReqsByID(int idEDITranscation)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtotblEDIRecipReqs> qEDIRecipReqs = o.tblEDIRecipReqs
                                    .Where(p => p.idEDITranscation == idEDITranscation)
                                    .Select(p => new dtotblEDIRecipReqs() { idEDIRecipReqs = p.idEDIRecipReqs, RecipReqNum = p.RecipReqNum, PanelTitle = p.PanelTitle, idFileType = p.idFileType, X12_GS = p.X12_GS, X12_ISA = p.X12_ISA, X12_Qualifier = p.X12_Qualifier, idCommunicationMethod = p.idCommunicationMethod, FTPAddress = p.FTPAddress, UserName = p.UserName, Password = p.Password, FolderPath = p.FolderPath, Email = p.Email, idTriggerMechanism = p.idTriggerMechanism, idTiming = p.idTiming, TimeOfFile = p.TimeOfFile, idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, idEDITranscationType = p.tblEDITranscations.idEDITranscationType, EDITranscationType = p.EDITranscationType, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qEDIRecipReqs;
        }
        #endregion
        #region tblSolutionType
        public List<dtotblSolutionType> GetSolutionTypes()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<dtotblSolutionType> qSolutionTypes = o.tblSolutionType
                    .Where(p => p.ActiveFlag == true)
                    .Select(p => new dtotblSolutionType() { idSolutionType = p.idSolutionType, SolutionType = p.SolutionType, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                    .ToList();

            return qSolutionTypes;
        }
        public dtotblSolutionType GetSolutionType(int idSolutionType)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            dtotblSolutionType qSolutionType = o.tblSolutionType
                    .Where(p => p.ActiveFlag == true && p.idSolutionType == idSolutionType)
                    .Select(p => new dtotblSolutionType() { idSolutionType = p.idSolutionType, SolutionType = p.SolutionType, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                    .FirstOrDefault();

            return qSolutionType;
        }
        #endregion

        #region tblFileType
        public List<ClsFileType> GetFileTypes()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<ClsFileType> qFileTypes = o.tblFileType
                                                //.Where(p => p.ActiveFlag == true)
                                                .Select(p => new ClsFileType() { idFileType = p.idFileType, FileType = p.FileType, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                                .ToList();

            return qFileTypes;
        }
        #endregion
        #region tblCommunicationMethod
        public List<ClsCommunicationMethod> GetCommunicationMethods()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<ClsCommunicationMethod> qCommMeth = o.tblCommunicationMethod
                                                //.Where(p => p.ActiveFlag == true)
                                                .Select(p => new ClsCommunicationMethod() { idCommunicationMethod = p.idCommunicationMethod, CommunicationMethod = p.CommunicationMethod, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                                .ToList();
            return qCommMeth;
        }
        #endregion
        #region tblTriggerMechanism
        public List<clsTriggerMechanism> GetTriggerMechanisms()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            List<clsTriggerMechanism> qTrigMeth = o.tblTriggerMechanism
                                            //.Where(p => p.ActiveFlag == true)
                                            .Select(p => new clsTriggerMechanism() { idTriggerMechanism = p.idTriggerMechanism, TriggerMechanism = p.TriggerMechanism, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                             .ToList();
            return qTrigMeth;
        }
        #endregion
        #region tblExceptionLogging
        public List<clsExceptionLogging> GetExceptionLogging()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<clsExceptionLogging> qErrors = o.tblExceptionLogging
                                    .Select(p => new clsExceptionLogging() {Logid = p.Logid ,ExceptionMsg = p.ExceptionMsg, Method = p.Method, ExceptionType = p.ExceptionType, ExceptionSource = p.ExceptionSource, ExceptionURL = p.ExceptionURL, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn })
                                    .ToList();
            return qErrors;
        }
        public string InsertErrorIntoDB(clsExceptionLogging data, out long newID)
        {
            string errMsg = "";
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            newID = -1;
            try
            {
                tblExceptionLogging oNewRow = new tblExceptionLogging()
                {
                    ExceptionMsg = data.ExceptionMsg,
                    Method = data.Method,
                    ExceptionType = data.ExceptionType,
                    ExceptionSource = data.ExceptionSource,
                    ExceptionURL = data.ExceptionURL,
                    CreatedBy = data.CreatedBy,
                    CreatedOn = data.CreatedOn,
                };
                o.tblExceptionLogging.Add(oNewRow);
                o.SaveChanges();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            return errMsg;
        }
        public bool RemoveAllExceptionLogs()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<tblExceptionLogging> qErrors = o.tblExceptionLogging.ToList();
            foreach(tblExceptionLogging e in qErrors)
            {
                o.tblExceptionLogging.Remove(e);
                o.SaveChanges();
            }
            return true;
        }
        #endregion
        #region AutomatedTesting
        public List<dtoAutomatedTesting> GetAutoTest()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtoAutomatedTesting> qErrors = o.AutomatedTesting
                                    .Select(p => new dtoAutomatedTesting() { ID = p.ID, Category = p.Category, Pass = p.Pass, RunDate = p.RunDate,  Step = p.Step,  TestName = p.TestName })
                                    .ToList();
            return qErrors;
        }
        public string InsertAutoTestIntoDB(dtoAutomatedTesting data)
        {
            string errMsg = "";
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
            try
            {
                AutomatedTesting oNewRow = new AutomatedTesting()
                {
                    Category = data.Category,
                    Pass = data.Pass,
                    RunDate = DateTime.Now,
                    Step = data.Step,
                    TestName = data.TestName
                };
                o.AutomatedTesting.Add(oNewRow);
                o.SaveChanges();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            return errMsg;
        }

        #endregion
        #region tmp_tblDiscoveryRequestCustomerInfo
        public void UpdateCustomerInfo()
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<tmp_tblDiscoveryRequestCustomerInfo> qCustomerInfo = o.tmp_tblDiscoveryRequestCustomerInfo.ToList();
            foreach(tmp_tblDiscoveryRequestCustomerInfo cust in qCustomerInfo)
            {
                if( !String.IsNullOrEmpty(cust.CustomerBusContact))
                {
                    dtotblContact data = new dtotblContact() { idRequest = cust.idRequest, idContactType = 1 ,Name = cust.CustomerBusContact, ActiveFlag = true, CreatedBy = "Scott.Cardinale", CreatedOn = DateTime.Now, Email = cust.CustomerBusEmail, Title = cust.CustomerBusTitle, UpdatedBy = "Scott.Cardinale", Phone = cust.CustomerBusPhone, UpdatedOn = DateTime.Now };
                    InsertContact(data);
                }
                if(!String.IsNullOrEmpty(cust.CustomerITContact))
                {
                    dtotblContact data = new dtotblContact() { idRequest = cust.idRequest, idContactType = 2, Name = cust.CustomerITContact, ActiveFlag = true, CreatedBy = "Scott.Cardinale", CreatedOn = DateTime.Now, Email = cust.CustomerITEmail, Title = cust.CustomerITTitle, UpdatedBy = "Scott.Cardinale", Phone = cust.CustomerITPhone, UpdatedOn = DateTime.Now };
                    InsertContact(data);
                }
            }

            int er = 0;
            er++;
            return ;
        }
        #endregion
        #region Migration Strategy
        public IList<dtoTableCompare> GetDiscoveryDiff1()
        {
            IList<dtoTableCompare> qTableCompare = new List<dtoTableCompare>();
            try
            {
                string sql = "SELECT c2.table_name, c2.COLUMN_NAME FROM[INFORMATION_SCHEMA].[COLUMNS] c2 WHERE table_name = '" +
                                "tblDiscoveryRequest_' AND c2.COLUMN_NAME NOT IN" +
                                " (SELECT column_name FROM[INFORMATION_SCHEMA].[COLUMNS] WHERE table_name = 'tblDiscoveryRequest')";

                using (SqlConnection con = new SqlConnection(strConn))
                {
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        con.Open();
                        using (SqlDataReader sdr = com.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                qTableCompare.Add( new dtoTableCompare() { ColumnName = sdr["COLUMN_NAME"].ToString().Trim(), TableName = sdr["table_name"].ToString().Trim() });
                                int er = 0;
                                er++;
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qTableCompare;
        }
        public IList<dtoTableCompare> GetDiscoveryDiff1(string tbl1, string tbl2)
        {
            IList<dtoTableCompare> qTableCompare = new List<dtoTableCompare>();
            try
            {
                string sql = "SELECT c2.table_name, c2.COLUMN_NAME FROM[INFORMATION_SCHEMA].[COLUMNS] c2 WHERE table_name = '" + 
                                    tbl1 + "' AND c2.COLUMN_NAME NOT IN" +
                                    " (SELECT column_name FROM[INFORMATION_SCHEMA].[COLUMNS] WHERE table_name = '" +
                                    tbl2 + "')";

                using (SqlConnection con = new SqlConnection(strConn))
                {
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        con.Open();
                        using (SqlDataReader sdr = com.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                qTableCompare.Add(new dtoTableCompare() { ColumnName = sdr["COLUMN_NAME"].ToString().Trim(), TableName = sdr["table_name"].ToString().Trim() });
                                int er = 0;
                                er++;
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qTableCompare;
        }

        #endregion
    }

}

