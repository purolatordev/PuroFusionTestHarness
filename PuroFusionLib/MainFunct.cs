using PuroReportingEntities;
using PuroTouchEntities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public static string PatientLocal = @"data source=PI-DEV-SQL;initial catalog=PurolatorReporting;integrated security=True;";

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
            public static string PatientLocal = @"data source=PI-DEV-SQL;initial catalog=PuroTouchDB;integrated security=True;";

            public static string FullPatientLocal = MetatData + SqlClient + Provider + PatientLocal + Framework;

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
                 .Select(p => new dtotblDiscoveryRequest() { idRequest = p.idRequest, isNewRequest = p.isNewRequest, SalesRepName = p.SalesRepName, SalesRepEmail = p.SalesRepEmail, idOnboardingPhase = p.idOnboardingPhase, District = p.District, CustomerName = p.CustomerName, Address = p.Address, City = p.City, State = p.State, Zipcode = p.Zipcode, Country = p.Country, Commodity = p.Commodity, ProjectedRevenue = p.ProjectedRevenue, CurrentSolution = p.CurrentSolution, ProposedCustoms = p.ProposedCustoms, CallDate1 = p.CallDate1, CallDate2 = p.CallDate2, CallDate3 = p.CallDate3, SalesComments = p.SalesComments, idITBA = p.idITBA, idShippingChannel = p.idShippingChannel, TargetGoLive = p.TargetGoLive, ActualGoLive = p.ActualGoLive, SolutionSummary = p.SolutionSummary, CustomerWebsite = p.CustomerWebsite, Branch = p.Branch, idVendor = p.idVendor, worldpakFlag = p.worldpakFlag, thirdpartyFlag = p.thirdpartyFlag, customFlag = p.customFlag, InvoiceType = p.InvoiceType, BilltoAccount = p.BilltoAccount, FTPUsername = p.FTPUsername, FTPPassword = p.FTPPassword, CustomsSupportedFlag = p.CustomsSupportedFlag, ElinkFlag = p.ElinkFlag, PARS = p.PARS, PASS = p.PASS, CustomsBroker = p.CustomsBroker, SupportUser = p.SupportUser, SupportGroup = p.SupportGroup, Office = p.Office, Group = p.Group, MigrationDate = p.MigrationDate, PreMigrationSolution = p.PreMigrationSolution, PostMigrationSolution = p.PostMigrationSolution, ControlBranch = p.ControlBranch, ContractNumber = p.ContractNumber, ContractStartDate = p.ContractStartDate, ContractEndDate = p.ContractEndDate, ContractCurrency = p.ContractCurrency, PaymentTerms = p.PaymentTerms, CloseReason = p.CloseReason, CRR = p.CRR, BrokerNumber = p.BrokerNumber, DataScrubFlag = p.DataScrubFlag, EDICustomizedFlag = p.EDICustomizedFlag, StrategicFlag = p.StrategicFlag, ReturnsAcctNbr = p.ReturnsAcctNbr, ReturnsAddress = p.ReturnsAddress, ReturnsCity = p.ReturnsCity, ReturnsState = p.ReturnsState, ReturnsZip = p.ReturnsZip, ReturnsCountry = p.ReturnsCountry, ReturnsDestroyFlag = p.ReturnsDestroyFlag, ReturnsCreateLabelFlag = p.ReturnsCreateLabelFlag, WPKSandboxUsername = p.WPKSandboxUsername, WPKSandboxPwd = p.WPKSandboxPwd, WPKProdUsername = p.WPKProdUsername, WPKProdPwd = p.WPKProdPwd, WPKCustomExportFlag = p.WPKCustomExportFlag, WPKGhostScanFlag = p.WPKGhostScanFlag, WPKEastWestSplitFlag = p.WPKEastWestSplitFlag, WPKAddressUploadFlag = p.WPKAddressUploadFlag, WPKProductUploadFlag = p.WPKProductUploadFlag, WPKDataEntryMethod = p.WPKDataEntryMethod, WPKEquipmentFlag = p.WPKEquipmentFlag, EWSelectBy = p.EWSelectBy, EWSortCodeFlag = p.EWSortCodeFlag, EWEastSortCode = p.EWEastSortCode, EWWestSortCode = p.EWWestSortCode, EWSepCloseoutFlag = p.EWSepCloseoutFlag, EWSepPUFlag = p.EWSepPUFlag, EWSortDetails = p.EWSortDetails, EWMissortDetails = p.EWMissortDetails, CurrentGoLive = p.CurrentGoLive, PhaseChangeDate = p.PhaseChangeDate, idRequestType = p.idRequestType, CurrentlyShippingFlag = p.CurrentlyShippingFlag, idShippingVendor = p.idShippingVendor, OtherVendorName = p.OtherVendorName, idBroker = p.idBroker, OtherBrokerName = p.OtherBrokerName, idVendorType = p.idVendorType, Route = p.Route, idSolutionType = p.idSolutionType, ActiveFlag = p.ActiveFlag, UpdatedBy = p.UpdatedBy, UpdatedOn = p.UpdatedOn })
                 .ToList();
            }
            catch (Exception ex)
            {
                //retValue = ex.ToString();ProgramSubdiv
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
        #endregion
    }
   
}
