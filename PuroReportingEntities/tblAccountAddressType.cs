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
    
    public partial class tblAccountAddressType
    {
        public int idAccountAddressType { get; set; }
        public int idAccount { get; set; }
        public int idClientAddress { get; set; }
        public int idAddressType { get; set; }
        public bool IsPrimary { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual tblAddressType tblAddressType { get; set; }
        public virtual tblClientAddresses tblClientAddresses { get; set; }
    }
}
