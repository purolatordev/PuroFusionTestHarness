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
    
    public partial class tblSalesRepDefaultTarget
    {
        public int idSalesRepDefaultTarget { get; set; }
        public int idSalesRep { get; set; }
        public int TargetYear { get; set; }
        public double FirstQuarterTarget { get; set; }
        public double SecondQuarterTarget { get; set; }
        public double ThirdQuarterTarget { get; set; }
        public double FourthQuarterTarget { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual tblSalesRep tblSalesRep { get; set; }
    }
}
