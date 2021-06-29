using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuroFusionLib
{
    public class dtotblDiscoveryRequest
    {
        public int idRequest { get; set; }
        public Nullable<bool> isNewRequest { get; set; }
        public string SalesRepName { get; set; }
        public string SalesRepEmail { get; set; }
        public Nullable<int> idOnboardingPhase { get; set; }
        public string District { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Commodity { get; set; }
        public Nullable<decimal> ProjectedRevenue { get; set; }
        public string CurrentSolution { get; set; }
        public string ProposedCustoms { get; set; }
        public Nullable<System.DateTime> CallDate1 { get; set; }
        public Nullable<System.DateTime> CallDate2 { get; set; }
        public Nullable<System.DateTime> CallDate3 { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
        public string SalesComments { get; set; }
        public Nullable<int> idITBA { get; set; }
        public Nullable<int> idShippingChannel { get; set; }
        public Nullable<System.DateTime> TargetGoLive { get; set; }
        public Nullable<System.DateTime> ActualGoLive { get; set; }
        public string SolutionSummary { get; set; }
        public string CustomerWebsite { get; set; }
        public string Branch { get; set; }
        public Nullable<int> idVendor { get; set; }
        public Nullable<bool> worldpakFlag { get; set; }
        public Nullable<bool> thirdpartyFlag { get; set; }
        public Nullable<bool> customFlag { get; set; }
        public string InvoiceType { get; set; }
        public string BilltoAccount { get; set; }
        public string FTPUsername { get; set; }
        public string FTPPassword { get; set; }
        public Nullable<bool> CustomsSupportedFlag { get; set; }
        public Nullable<bool> ElinkFlag { get; set; }
        public string PARS { get; set; }
        public string PASS { get; set; }
        public string CustomsBroker { get; set; }
        public string SupportUser { get; set; }
        public string SupportGroup { get; set; }
        public string Office { get; set; }
        public string Group { get; set; }
        public Nullable<System.DateTime> MigrationDate { get; set; }
        public string PreMigrationSolution { get; set; }
        public string PostMigrationSolution { get; set; }
        public string ControlBranch { get; set; }
        public string ContractNumber { get; set; }
        public Nullable<System.DateTime> ContractStartDate { get; set; }
        public Nullable<System.DateTime> ContractEndDate { get; set; }
        public string ContractCurrency { get; set; }
        public string PaymentTerms { get; set; }
        public string CloseReason { get; set; }
        public string CRR { get; set; }
        public string BrokerNumber { get; set; }
        public Nullable<bool> DataScrubFlag { get; set; }
        public Nullable<bool> EDICustomizedFlag { get; set; }
        public Nullable<bool> StrategicFlag { get; set; }
        public string ReturnsAcctNbr { get; set; }
        public string ReturnsAddress { get; set; }
        public string ReturnsCity { get; set; }
        public string ReturnsState { get; set; }
        public string ReturnsZip { get; set; }
        public string ReturnsCountry { get; set; }
        public Nullable<bool> ReturnsDestroyFlag { get; set; }
        public Nullable<bool> ReturnsCreateLabelFlag { get; set; }
        public string WPKSandboxUsername { get; set; }
        public string WPKSandboxPwd { get; set; }
        public string WPKProdUsername { get; set; }
        public string WPKProdPwd { get; set; }
        public Nullable<bool> WPKCustomExportFlag { get; set; }
        public Nullable<bool> WPKGhostScanFlag { get; set; }
        public Nullable<bool> WPKEastWestSplitFlag { get; set; }
        public Nullable<bool> WPKAddressUploadFlag { get; set; }
        public Nullable<bool> WPKProductUploadFlag { get; set; }
        public string WPKDataEntryMethod { get; set; }
        public Nullable<bool> WPKEquipmentFlag { get; set; }
        public string EWSelectBy { get; set; }
        public Nullable<bool> EWSortCodeFlag { get; set; }
        public string EWEastSortCode { get; set; }
        public string EWWestSortCode { get; set; }
        public Nullable<bool> EWSepCloseoutFlag { get; set; }
        public Nullable<bool> EWSepPUFlag { get; set; }
        public string EWSortDetails { get; set; }
        public string EWMissortDetails { get; set; }
        public Nullable<System.DateTime> CurrentGoLive { get; set; }
        public Nullable<System.DateTime> PhaseChangeDate { get; set; }
        public Nullable<int> idRequestType { get; set; }
        public Nullable<bool> CurrentlyShippingFlag { get; set; }
        public Nullable<int> idShippingVendor { get; set; }
        public string OtherVendorName { get; set; }
        public Nullable<int> idBroker { get; set; }
        public string OtherBrokerName { get; set; }
        public Nullable<int> idVendorType { get; set; }
        public string Route { get; set; }
        public Nullable<int> idSolutionType { get; set; }
        public Nullable<bool> FreightAuditor { get; set; }
        public string EDIDetails { get; set; }
        public Nullable<int> idEDISpecialist { get; set; }
        public Nullable<int> idBillingSpecialist { get; set; }
        public Nullable<int> idCollectionSpecialist { get; set; }
        public Nullable<bool> AuditorPortal { get; set; }
        public string AuditorURL { get; set; }
        public string AuditorUserName { get; set; }
        public string AuditorPassword { get; set; }
        public Nullable<System.DateTime> EDITargetGoLive { get; set; }
        public Nullable<System.DateTime> EDICurrentGoLive { get; set; }
        public Nullable<System.DateTime> EDIActualGoLive { get; set; }
        public int idEDIOnboardingPhase { get; set; }
    }
    public class dtotblDiscoveryRequest_
    {
        public int idRequest { get; set; }
        public Nullable<bool> isNewRequest { get; set; }
        public string SalesRepName { get; set; }
        public string SalesRepEmail { get; set; }
        public Nullable<int> idOnboardingPhase { get; set; }
        public string District { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Commodity { get; set; }
        public Nullable<decimal> ProjectedRevenue { get; set; }
        public string CustomerBusContact { get; set; }
        public string CustomerBusTitle { get; set; }
        public string CustomerBusEmail { get; set; }
        public string CustomerBusPhone { get; set; }
        public string CustomerITContact { get; set; }
        public string CustomerITTitle { get; set; }
        public string CustomerITEmail { get; set; }
        public string CustomerITPhone { get; set; }
        public string CurrentSolution { get; set; }
        public string ProposedCustoms { get; set; }
        public Nullable<System.DateTime> CallDate1 { get; set; }
        public Nullable<System.DateTime> CallDate2 { get; set; }
        public Nullable<System.DateTime> CallDate3 { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
        public string SalesComments { get; set; }
        public Nullable<int> idITBA { get; set; }
        public Nullable<int> idShippingChannel { get; set; }
        public Nullable<System.DateTime> TargetGoLive { get; set; }
        public Nullable<System.DateTime> ActualGoLive { get; set; }
        public string SolutionSummary { get; set; }
        public string CustomerWebsite { get; set; }
        public string Branch { get; set; }
        public Nullable<int> idVendor { get; set; }
        public Nullable<bool> worldpakFlag { get; set; }
        public Nullable<bool> thirdpartyFlag { get; set; }
        public Nullable<bool> customFlag { get; set; }
        public string InvoiceType { get; set; }
        public string BilltoAccount { get; set; }
        public string FTPUsername { get; set; }
        public string FTPPassword { get; set; }
        public Nullable<bool> CustomsSupportedFlag { get; set; }
        public Nullable<bool> ElinkFlag { get; set; }
        public string PARS { get; set; }
        public string PASS { get; set; }
        public string CustomsBroker { get; set; }
        public string SupportUser { get; set; }
        public string SupportGroup { get; set; }
        public string Office { get; set; }
        public string Group { get; set; }
        public Nullable<System.DateTime> MigrationDate { get; set; }
        public string PreMigrationSolution { get; set; }
        public string PostMigrationSolution { get; set; }
        public string ControlBranch { get; set; }
        public string ContractNumber { get; set; }
        public Nullable<System.DateTime> ContractStartDate { get; set; }
        public Nullable<System.DateTime> ContractEndDate { get; set; }
        public string ContractCurrency { get; set; }
        public string PaymentTerms { get; set; }
        public string CloseReason { get; set; }
        public string CRR { get; set; }
        public string BrokerNumber { get; set; }
        public Nullable<bool> DataScrubFlag { get; set; }
        public Nullable<bool> EDICustomizedFlag { get; set; }
        public Nullable<bool> StrategicFlag { get; set; }
        public string ReturnsAcctNbr { get; set; }
        public string ReturnsAddress { get; set; }
        public string ReturnsCity { get; set; }
        public string ReturnsState { get; set; }
        public string ReturnsZip { get; set; }
        public string ReturnsCountry { get; set; }
        public Nullable<bool> ReturnsDestroyFlag { get; set; }
        public Nullable<bool> ReturnsCreateLabelFlag { get; set; }
        public string WPKSandboxUsername { get; set; }
        public string WPKSandboxPwd { get; set; }
        public string WPKProdUsername { get; set; }
        public string WPKProdPwd { get; set; }
        public Nullable<bool> WPKCustomExportFlag { get; set; }
        public Nullable<bool> WPKGhostScanFlag { get; set; }
        public Nullable<bool> WPKEastWestSplitFlag { get; set; }
        public Nullable<bool> WPKAddressUploadFlag { get; set; }
        public Nullable<bool> WPKProductUploadFlag { get; set; }
        public string WPKDataEntryMethod { get; set; }
        public Nullable<bool> WPKEquipmentFlag { get; set; }
        public string EWSelectBy { get; set; }
        public Nullable<bool> EWSortCodeFlag { get; set; }
        public string EWEastSortCode { get; set; }
        public string EWWestSortCode { get; set; }
        public Nullable<bool> EWSepCloseoutFlag { get; set; }
        public Nullable<bool> EWSepPUFlag { get; set; }
        public string EWSortDetails { get; set; }
        public string EWMissortDetails { get; set; }
        public Nullable<System.DateTime> CurrentGoLive { get; set; }
        public Nullable<System.DateTime> PhaseChangeDate { get; set; }
        public Nullable<int> idRequestType { get; set; }
        public Nullable<bool> CurrentlyShippingFlag { get; set; }
        public Nullable<int> idShippingVendor { get; set; }
        public string OtherVendorName { get; set; }
        public Nullable<int> idBroker { get; set; }
        public string OtherBrokerName { get; set; }
        public Nullable<int> idVendorType { get; set; }
        public string Route { get; set; }
        public Nullable<int> idSolutionType { get; set; }
    }

    public class dtoPartialDiscoveryRequest
    {
        public int idRequest { get; set; }
        //public Nullable<bool> isNewRequest { get; set; }
        public string CustomerBusContact { get; set; }
        public string CustomerBusTitle { get; set; }
        public string CustomerBusEmail { get; set; }
        public string CustomerBusPhone { get; set; }
        public string CustomerITContact { get; set; }
        public string CustomerITTitle { get; set; }
        public string CustomerITEmail { get; set; }
        public string CustomerITPhone { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }

    public class dtotblContactType
    {
        public int idContactType { get; set; }
        public string ContactType { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public class dtotblContact
    {
        public int idContact { get; set; }
        public int idRequest { get; set; }
        public int idContactType { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public class dtoTableCompare
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
    }
    public class dtotblEDITranscations
    {
        public int idEDITranscation { get; set; }
        public int idRequest { get; set; }
        public int idEDITranscationType { get; set; }
        public string EDITranscationType { get; set; }
        public int TotalRequests { get; set; }
        public Nullable<bool> CombinePayer { get; set; }
        public Nullable<bool> BatchInvoices { get; set; }
        public string SFTPFolder { get; set; }
        public Nullable<bool> TestEnvironment { get; set; }
        public int TestSentMethod { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public class dtotblEDIShipMethods
    {
        public int idEDIShipMethod { get; set; }
        public int idRequest { get; set; }
        public int idEDIShipMethodType { get; set; }
        public string MethodType { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public class dtotblEDIRecipReqs
    {
        public int idEDIRecipReqs { get; set; }
        public int RecipReqNum { get; set; }
        public int idRequest { get; set; }
        public string PanelTitle { get; set; }

        public int idEDITranscation { get; set; }
        public int idFileType { get; set; }
        public string X12_ISA { get; set; }
        public string X12_GS { get; set; }
        public string X12_Qualifier { get; set; }
        public int idCommunicationMethod { get; set; }
        public string FTPAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FolderPath { get; set; }
        public string Email { get; set; }
        public int idTriggerMechanism { get; set; }
        public int idTiming { get; set; }
        public Nullable<System.DateTime> TimeOfFile { get; set; }
        public int idStatusCodes { get; set; }
        public string EDITranscationType { get; set; }
        public int idEDITranscationType { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public class clsExceptionLogging
    {
        public long Logid { get; set; }
        public string Method { get; set; }
        public string ExceptionMsg { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionURL { get; set; }
        public string CreatedBy { get; set; }
        public System.Nullable<System.DateTime> CreatedOn { get; set; }

    }
    public class clsEDITransactionType
    {
        public int idEDITranscationType { get; set; }

        public string EDITranscationType { get; set; }
        public int CategoryID { get; set; }

        public string Category { get; set; }

        public string CreatedBy { get; set; }

        public System.Nullable<System.DateTime> CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public System.Nullable<System.DateTime> UpdatedOn { get; set; }

        public System.Nullable<bool> ActiveFlag { get; set; }
    }
    public class ClsFileType
    {
        public int idFileType { get; set; }
        public string FileType { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? ActiveFlag { get; set; }
    }
    public class ClsCommunicationMethod
    {
        public int idCommunicationMethod { get; set; }
        public string CommunicationMethod { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? ActiveFlag { get; set; }
    }
    public class clsTriggerMechanism
    {
        public int idTriggerMechanism { get; set; }
        public string TriggerMechanism { get; set; }

        public string CreatedBy { get; set; }

        public System.Nullable<System.DateTime> CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public System.Nullable<System.DateTime> UpdatedOn { get; set; }

        public System.Nullable<bool> ActiveFlag { get; set; }
    }
    public class clsEDIAccount
    {
        public int idEDIAccount { get; set; }
        public string AccountNumber { get; set; }

        public int idEDITranscation { get; set; }
        public int idRequest { get; set; }
        public int idEDITranscationType { get; set; }
        public string EDITranscationType { get; set; }

        public string Category { get; set; }

        public string CreatedBy { get; set; }

        public System.Nullable<System.DateTime> CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public System.Nullable<System.DateTime> UpdatedOn { get; set; }

        public System.Nullable<bool> ActiveFlag { get; set; }
    }
    public class dtotblITBA
    {
        public int idITBA { get; set; }
        public int idEmployee { get; set; }
        public string ITBAemail { get; set; }
        public Nullable<bool> ReceiveNewReqEmail { get; set; }
        public string login { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public partial class dtotblSolutionType
    {
        public int idSolutionType { get; set; }
        public string SolutionType { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    }
    public class dtoAutomatedTesting
    {
        public long ID { get; set; }
        public string TestName { get; set; }
        public string Category { get; set; }
        public string Step { get; set; }
        public bool Pass { get; set; }
        public System.DateTime RunDate { get; set; }
    }

}
