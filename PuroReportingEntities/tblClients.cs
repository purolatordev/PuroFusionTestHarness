//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuroReportingEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblClients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClients()
        {
            this.tblClientAddresses = new HashSet<tblClientAddresses>();
            this.tblClientContacts = new HashSet<tblClientContacts>();
            this.tblContracts = new HashSet<tblContracts>();
        }
    
        public int idClient { get; set; }
        public int ClientNumber { get; set; }
        public string ClientName { get; set; }
        public Nullable<System.DateTime> ClosedOnDate { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClientAddresses> tblClientAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClientContacts> tblClientContacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblContracts> tblContracts { get; set; }
    }
}
