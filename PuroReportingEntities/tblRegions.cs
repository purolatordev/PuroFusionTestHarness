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
    
    public partial class tblRegions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRegions()
        {
            this.tblTransactions = new HashSet<tblTransactions>();
        }
    
        public int idRegion { get; set; }
        public int idDistrict { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public Nullable<int> idSalesDepartment { get; set; }
        public int idCostCenter { get; set; }
        public string Jurisdiction { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual tblCostCenters tblCostCenters { get; set; }
        public virtual tblDistricts tblDistricts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransactions> tblTransactions { get; set; }
    }
}
