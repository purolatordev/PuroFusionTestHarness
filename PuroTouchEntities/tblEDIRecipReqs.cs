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
    
    public partial class tblEDIRecipReqs
    {
        public int idEDIRecipReqs { get; set; }
        public int RecipReqNum { get; set; }
        public int idRequest { get; set; }
        public int idEDITranscation { get; set; }
        public string PanelTitle { get; set; }
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
        public string EDITranscationType { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    
        public virtual tblCommunicationMethod tblCommunicationMethod { get; set; }
        public virtual tblFileType tblFileType { get; set; }
        public virtual tblTiming tblTiming { get; set; }
        public virtual tblEDITranscations tblEDITranscations { get; set; }
        public virtual tblTriggerMechanism tblTriggerMechanism { get; set; }
    }
}
