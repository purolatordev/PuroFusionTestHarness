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
    
    public partial class tblContractContactType
    {
        public int idContractContactType { get; set; }
        public int idContract { get; set; }
        public int idClientContact { get; set; }
        public int idContactType { get; set; }
        public bool IsPrimary { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual tblClientContacts tblClientContacts { get; set; }
        public virtual tblContactType tblContactType { get; set; }
        public virtual tblContracts tblContracts { get; set; }
    }
}
