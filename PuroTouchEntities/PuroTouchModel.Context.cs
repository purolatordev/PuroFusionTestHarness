﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PuroTouchDBEntities : DbContext
    {
        public PuroTouchDBEntities()
            : base("name=PuroTouchDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblBrokers> tblBrokers { get; set; }
        public virtual DbSet<tblCloseReason> tblCloseReason { get; set; }
        public virtual DbSet<tblCommunicationMethod> tblCommunicationMethod { get; set; }
        public virtual DbSet<tblCustomsTypes> tblCustomsTypes { get; set; }
        public virtual DbSet<tblDataEntryMethods> tblDataEntryMethods { get; set; }
        public virtual DbSet<tblDiscoveryRequest_Archive> tblDiscoveryRequest_Archive { get; set; }
        public virtual DbSet<tblDiscoveryRequestDetails> tblDiscoveryRequestDetails { get; set; }
        public virtual DbSet<tblDiscoveryRequestEDI> tblDiscoveryRequestEDI { get; set; }
        public virtual DbSet<tblDiscoveryRequestEquipment> tblDiscoveryRequestEquipment { get; set; }
        public virtual DbSet<tblDiscoveryRequestNotes> tblDiscoveryRequestNotes { get; set; }
        public virtual DbSet<tblDiscoveryRequestNotes_Archive> tblDiscoveryRequestNotes_Archive { get; set; }
        public virtual DbSet<tblDiscoveryRequestProducts> tblDiscoveryRequestProducts { get; set; }
        public virtual DbSet<tblDiscoveryRequestProducts_Archive> tblDiscoveryRequestProducts_Archive { get; set; }
        public virtual DbSet<tblDiscoveryRequestServices> tblDiscoveryRequestServices { get; set; }
        public virtual DbSet<tblDiscoveryRequestServices_Archive> tblDiscoveryRequestServices_Archive { get; set; }
        public virtual DbSet<tblDiscoveryRequestTargetDates> tblDiscoveryRequestTargetDates { get; set; }
        public virtual DbSet<tblDiscoveryRequestUploads> tblDiscoveryRequestUploads { get; set; }
        public virtual DbSet<tblDiscoveryRequestUploads_Archive> tblDiscoveryRequestUploads_Archive { get; set; }
        public virtual DbSet<tblDRContacts> tblDRContacts { get; set; }
        public virtual DbSet<tblEDISolutions> tblEDISolutions { get; set; }
        public virtual DbSet<tblEquipment> tblEquipment { get; set; }
        public virtual DbSet<tblFileType> tblFileType { get; set; }
        public virtual DbSet<tblInductionPoints> tblInductionPoints { get; set; }
        public virtual DbSet<tblInvoiceType> tblInvoiceType { get; set; }
        public virtual DbSet<tblITBA> tblITBA { get; set; }
        public virtual DbSet<tblOnboardingPhase> tblOnboardingPhase { get; set; }
        public virtual DbSet<tblRequestTypes> tblRequestTypes { get; set; }
        public virtual DbSet<tblShippingChannel> tblShippingChannel { get; set; }
        public virtual DbSet<tblShippingProducts> tblShippingProducts { get; set; }
        public virtual DbSet<tblShippingServices> tblShippingServices { get; set; }
        public virtual DbSet<tblShippingVendor> tblShippingVendor { get; set; }
        public virtual DbSet<tblTaskType> tblTaskType { get; set; }
        public virtual DbSet<tblThirdPartyVendor> tblThirdPartyVendor { get; set; }
        public virtual DbSet<tblVendorType> tblVendorType { get; set; }
        public virtual DbSet<tblBillingTypes> tblBillingTypes { get; set; }
        public virtual DbSet<tblContactType> tblContactType { get; set; }
        public virtual DbSet<tblProducts> tblProducts { get; set; }
        public virtual DbSet<tblProductTypeRel> tblProductTypeRel { get; set; }
        public virtual DbSet<tblProductTypes> tblProductTypes { get; set; }
        public virtual DbSet<tblSolutionType> tblSolutionType { get; set; }
        public virtual DbSet<ZIPCodes> ZIPCodes { get; set; }
        public virtual DbSet<tblContact> tblContact { get; set; }
        public virtual DbSet<tblDiscoveryRequest> tblDiscoveryRequest { get; set; }
        public virtual DbSet<tblDiscoveryRequest_> tblDiscoveryRequest_ { get; set; }
    }
}
