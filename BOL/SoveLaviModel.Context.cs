﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SOVELAVIDBEntities : DbContext
    {
        public SOVELAVIDBEntities()
            : base("name=SOVELAVIDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_LAYER> tbl_LAYER { get; set; }
        public virtual DbSet<tbl_LAYER_CATEGORY> tbl_LAYER_CATEGORY { get; set; }
        public virtual DbSet<tbl_LAYER_TYPE> tbl_LAYER_TYPE { get; set; }
    }
}
