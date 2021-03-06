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
    
    public partial class tblEDITranscations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEDITranscations()
        {
            this.tblEDIAccounts = new HashSet<tblEDIAccounts>();
            this.tblEDIRecipReqs = new HashSet<tblEDIRecipReqs>();
        }
    
        public int idEDITranscation { get; set; }
        public int idRequest { get; set; }
        public int idEDITranscationType { get; set; }
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
    
        public virtual tblDiscoveryRequest tblDiscoveryRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEDIAccounts> tblEDIAccounts { get; set; }
        public virtual tblEDITranscationType tblEDITranscationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEDIRecipReqs> tblEDIRecipReqs { get; set; }
    }
}
