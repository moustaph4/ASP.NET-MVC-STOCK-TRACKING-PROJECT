﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipProjesi.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbMvcStokEntities1 : DbContext
    {
        public dbMvcStokEntities1()
            : base("name=dbMvcStokEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblKategori> tblKategori { get; set; }
        public virtual DbSet<tblMusteri> tblMusteri { get; set; }
        public virtual DbSet<tblSatis> tblSatis { get; set; }
        public virtual DbSet<tblUrun> tblUrun { get; set; }
    }
}