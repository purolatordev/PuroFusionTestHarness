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
        public static class ConnString
        {
            public static string MetatData = @"metadata=res://*/PuroReportingModel.csdl|res://*/PuroReportingModel.ssdl|res://*/PuroReportingModel.msl;";
            public static string SqlClient = @"provider=System.Data.SqlClient;";
            public static string Provider = @"provider connection string='";
            public static string Framework = @"MultipleActiveResultSets=True;App=EntityFramework';";
            public static string PatientLocal = @"data source=VIRTUALONE\WIN10DEV2019;initial catalog=PurolatorReporting;integrated security=True;";
            public static string PatientLocal2 = @"data source=PI-DEV-SQL;initial catalog=PurolatorReporting;integrated security=True;";

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
            string strRetVal = "na";
            try
            {
                PurolatorReportingEntities o = new PurolatorReportingEntities(strConn);
                int iCount = o.PI_Customers.Count();
                iCount++;
                //strRetVal = OK;
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

            public static string FullPatientLocal = MetatData + SqlClient + Provider + PatientLocal + Framework;
            public static string FullPatientLocal2 = MetatData + SqlClient + Provider + PatientLocal2 + Framework;
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
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, FreightAuditor = p.FreightAuditor, EDIDetails = p.EDIDetails.Remove(10), idEDISpecialist = p.idEDISpecialist, idBillingSpecialist = p.idBillingSpecialist, idCollectionSpecialist = p.idCollectionSpecialist, AuditorPortal = p.AuditorPortal, AuditorURL = p.AuditorURL, AuditorUserName = p.AuditorUserName, AuditorPassword = p.AuditorPassword, EDITargetGoLive = p.EDITargetGoLive, EDICurrentGoLive = p.EDICurrentGoLive, EDIActualGoLive = p.EDIActualGoLive, idEDIOnboardingPhase = p.idEDIOnboardingPhase, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
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
        public IList<dtotblDiscoveryRequest> GettblDiscoveryRequestDesc()
        {
            IList<dtotblDiscoveryRequest> qDiscoveryRequest = new List<dtotblDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, FreightAuditor = p.FreightAuditor, EDIDetails = p.EDIDetails.Remove(10), idEDISpecialist = p.idEDISpecialist, idBillingSpecialist = p.idBillingSpecialist, idCollectionSpecialist = p.idCollectionSpecialist, AuditorPortal = p.AuditorPortal, AuditorURL = p.AuditorURL, AuditorUserName = p.AuditorUserName, AuditorPassword = p.AuditorPassword, EDITargetGoLive = p.EDITargetGoLive, EDICurrentGoLive = p.EDICurrentGoLive, EDIActualGoLive = p.EDIActualGoLive, idEDIOnboardingPhase = p.idEDIOnboardingPhase, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
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
        public IList<dtoPartialDiscoveryRequest> GetPartialDiscoveryRequest()
        {
            IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = new List<dtoPartialDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest_
                 .Select(p => new dtoPartialDiscoveryRequest() { idRequest = p.idRequest, CustomerBusContact = p.CustomerBusContact.Substring(0, 20), CustomerBusTitle = p.CustomerBusTitle.Substring(0, 20), CustomerBusEmail = p.CustomerBusEmail.Substring(0, 20), CustomerBusPhone = p.CustomerBusPhone.Substring(0, 20), CustomerITContact = p.CustomerITContact.Substring(0, 20), CustomerITTitle = p.CustomerITTitle.Substring(0, 20), CustomerITEmail = p.CustomerITEmail.Substring(0, 20), CustomerITPhone = p.CustomerITPhone.Substring(0, 20), ActiveFlag = p.ActiveFlag })
                 .Where(f => f.ActiveFlag == true)
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qDiscoveryRequest;
        }
        public IList<dtoPartialDiscoveryRequest> GetDiscoveryRequestBusContacts()
        {
            IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = new List<dtoPartialDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest_
                 .Select(p => new dtoPartialDiscoveryRequest() { idRequest = p.idRequest, CustomerBusContact = p.CustomerBusContact.Substring(0, 20), CustomerBusTitle = p.CustomerBusTitle.Substring(0, 20), CustomerBusEmail = p.CustomerBusEmail.Substring(0, 20), CustomerBusPhone = p.CustomerBusPhone.Substring(0, 20), CustomerITContact = p.CustomerITContact.Substring(0, 20), CustomerITTitle = p.CustomerITTitle.Substring(0, 20), CustomerITEmail = p.CustomerITEmail.Substring(0, 20), CustomerITPhone = p.CustomerITPhone.Substring(0, 20), ActiveFlag = p.ActiveFlag })
                 .Where(f => f.ActiveFlag == true && !String.IsNullOrEmpty(f.CustomerBusContact))
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qDiscoveryRequest;
        }
        public IList<dtoPartialDiscoveryRequest> GetDiscoveryRequestITContacts()
        {
            IList<dtoPartialDiscoveryRequest> qDiscoveryRequest = new List<dtoPartialDiscoveryRequest>();
            try
            {
                PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);
                qDiscoveryRequest = o.tblDiscoveryRequest_
                 .Select(p => new dtoPartialDiscoveryRequest() { idRequest = p.idRequest, CustomerBusContact = p.CustomerBusContact.Substring(0, 20), CustomerBusTitle = p.CustomerBusTitle.Substring(0, 20), CustomerBusEmail = p.CustomerBusEmail.Substring(0, 20), CustomerBusPhone = p.CustomerBusPhone.Substring(0, 20), CustomerITContact = p.CustomerITContact.Substring(0, 20), CustomerITTitle = p.CustomerITTitle.Substring(0, 20), CustomerITEmail = p.CustomerITEmail.Substring(0, 20), CustomerITPhone = p.CustomerITPhone.Substring(0, 20), ActiveFlag = p.ActiveFlag })
                 .Where(f => f.ActiveFlag == true && !String.IsNullOrEmpty(f.CustomerITContact))
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
            }
            return qDiscoveryRequest;
        }
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
                            .Select(p => new dtotblEDITranscations() { idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, EDITranscationType = p.tblEDITranscationType.EDITranscationType, idEDITranscationType = p.idEDITranscationType, TotalRequests = p.TotalRequests, BatchInvoices = p.BatchInvoices, CombinePayer = p.CombinePayer, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
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
                            .Select(p => new dtotblEDITranscations() { idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, EDITranscationType = p.tblEDITranscationType.EDITranscationType, idEDITranscationType = p.idEDITranscationType, TotalRequests = p.TotalRequests, BatchInvoices = p.BatchInvoices, CombinePayer = p.CombinePayer, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
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
                            .Select(p => new dtotblEDITranscations() { idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, EDITranscationType = p.tblEDITranscationType.EDITranscationType, idEDITranscationType = p.idEDITranscationType, TotalRequests = p.TotalRequests, BatchInvoices = p.BatchInvoices, CombinePayer = p.CombinePayer, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
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
                                    .Select(p => new dtotblEDIRecipReqs() { idEDIRecipReqs = p.idEDIRecipReqs, RecipReqNum = p.RecipReqNum, idFileType = p.idFileType, X12_GS = p.X12_GS, X12_ISA = p.X12_ISA, X12_Qualifier = p.X12_Qualifier, idCommunicationMethod = p.idCommunicationMethod, FTPAddress = p.FTPAddress, UserName = p.UserName, Password = p.Password, FolderPath = p.FolderPath, Email = p.Email, idTriggerMechanism = p.idTriggerMechanism, idTiming = p.idTiming, TimeOfFile = p.TimeOfFile, idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, idEDITranscationType = p.tblEDITranscations.idEDITranscationType, EDITranscationType = p.EDITranscationType, idStatusCodes = p.idStatusCodes, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qEDIRecipReqs;
        }
        public List<dtotblEDIRecipReqs> GetEDIRecipReqsByRequesID(int idRequest)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtotblEDIRecipReqs> qEDIRecipReqs = o.tblEDIRecipReqs
                                    .Where(p => p.idRequest == idRequest)
                                    .Select(p => new dtotblEDIRecipReqs() { idEDIRecipReqs = p.idEDIRecipReqs, RecipReqNum = p.RecipReqNum, idFileType = p.idFileType, X12_GS = p.X12_GS, X12_ISA = p.X12_ISA, X12_Qualifier = p.X12_Qualifier, idCommunicationMethod = p.idCommunicationMethod, FTPAddress = p.FTPAddress, UserName = p.UserName, Password = p.Password, FolderPath = p.FolderPath, Email = p.Email, idTriggerMechanism = p.idTriggerMechanism, idTiming = p.idTiming, TimeOfFile = p.TimeOfFile, idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, idEDITranscationType = p.tblEDITranscations.idEDITranscationType, EDITranscationType = p.EDITranscationType, idStatusCodes = p.idStatusCodes, Category = p.Category ,ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qEDIRecipReqs;
        }
        public List<dtotblEDIRecipReqs> GetEDIRecipReqsByID(int idEDITranscation)
        {
            PuroTouchDBEntities o = new PuroTouchDBEntities(strConn);

            List<dtotblEDIRecipReqs> qEDIRecipReqs = o.tblEDIRecipReqs
                                    .Where(p => p.idEDITranscation == idEDITranscation)
                                    .Select(p => new dtotblEDIRecipReqs() { idEDIRecipReqs = p.idEDIRecipReqs, RecipReqNum = p.RecipReqNum, idFileType = p.idFileType, X12_GS = p.X12_GS, X12_ISA = p.X12_ISA, X12_Qualifier = p.X12_Qualifier, idCommunicationMethod = p.idCommunicationMethod, FTPAddress = p.FTPAddress, UserName = p.UserName, Password = p.Password, FolderPath = p.FolderPath, Email = p.Email, idTriggerMechanism = p.idTriggerMechanism, idTiming = p.idTiming, TimeOfFile = p.TimeOfFile, idEDITranscation = p.idEDITranscation, idRequest = p.idRequest, idEDITranscationType = p.tblEDITranscations.idEDITranscationType, EDITranscationType = p.EDITranscationType, idStatusCodes = p.idStatusCodes, Category = p.Category, ActiveFlag = p.ActiveFlag, CreatedBy = p.CreatedBy, CreatedOn = p.CreatedOn, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                                    .ToList();
            return qEDIRecipReqs;
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
