//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblSatis
    {
        public int satisId { get; set; }
        public Nullable<int> urunId { get; set; }
        public Nullable<int> musteriId { get; set; }
        public Nullable<byte> adet { get; set; }
        public Nullable<decimal> fiyat { get; set; }
    
        public virtual tblMusteri tblMusteri { get; set; }
        public virtual tblUrun tblUrun { get; set; }
    }
}
