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
    
    public partial class tblProductTypeRel
    {
        public int idProductTypeRel { get; set; }
        public Nullable<int> idProductType { get; set; }
        public Nullable<int> idProduct { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Modifiedby { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
