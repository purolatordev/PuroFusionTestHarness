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
    
    public partial class tblCostCenters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCostCenters()
        {
            this.tblRegions = new HashSet<tblRegions>();
        }
    
        public int idCostCenter { get; set; }
        public string CostCenterCode { get; set; }
        public string Location { get; set; }
        public string Jurisdiction { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRegions> tblRegions { get; set; }
    }
}
