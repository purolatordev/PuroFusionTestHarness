//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuroTouchEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDiscoveryRequestDetails
    {
        public int idRequestDetails { get; set; }
        public int idRequest { get; set; }
        public string CourierAcctNbr { get; set; }
        public string CourierPinPrefix { get; set; }
        public string CourierContractNbr { get; set; }
        public Nullable<int> CourierTransitDays { get; set; }
        public string CourierInductionAddress { get; set; }
        public string CourierInductionCity { get; set; }
        public string CourierInductionState { get; set; }
        public string CourierInductionZip { get; set; }
        public string CourierInductionCountry { get; set; }
        public string CourierFTPusername { get; set; }
        public string CourierFTPpwd { get; set; }
        public string CourierFTPsenderID { get; set; }
        public string LTLAcctNbr { get; set; }
        public string LTLMinProNbr { get; set; }
        public string LTLMaxProNbr { get; set; }
        public string CPCAcctNbr { get; set; }
        public string CPCSiteNbr { get; set; }
        public string CPCContractNbr { get; set; }
        public string CPCInductionNbr { get; set; }
        public string CPCUsername { get; set; }
        public string CPCpwd { get; set; }
        public string PPSTAcctNbr { get; set; }
        public Nullable<int> PPSTTransitDays { get; set; }
        public string PPSTInductionAddress { get; set; }
        public string PPSTInductionCity { get; set; }
        public string PPSTInductionState { get; set; }
        public string PPSTInductionZip { get; set; }
        public string PPSTInductionCountry { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
        public string CourierInductionDesc { get; set; }
        public string PPSTInductionDesc { get; set; }
        public string LTLPinPrefix { get; set; }
        public Nullable<bool> LTLAutomatedFlag { get; set; }
        public string CourierSandboxFTPusername { get; set; }
        public string CourierSandboxFTPpwd { get; set; }
        public Nullable<bool> CourierFTPCustOwnFlag { get; set; }
        public string PPSTRoute { get; set; }
        public string PPlusAcctNbr { get; set; }
        public Nullable<int> PPlusTransitDays { get; set; }
        public string PPlusInductionAddress { get; set; }
        public string PPlusInductionCity { get; set; }
        public string PPlusInductionState { get; set; }
        public string PPlusInductionZip { get; set; }
        public string PPlusInductionCountry { get; set; }
        public string ShipRecordType { get; set; }
        public string PPlusInductionDesc { get; set; }
    }
}
