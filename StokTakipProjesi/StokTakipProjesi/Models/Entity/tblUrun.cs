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

    public partial class tblUrun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUrun()
        {
            this.tblSatis = new HashSet<tblSatis>();
        }
    
        public int urunId { get; set; }

        public string urunAd { get; set; }

        public string urunMarka { get; set; }

        public Nullable<short> urunKategori { get; set; }

        public Nullable<decimal> urunFiyat { get; set; }

        public Nullable<byte> urunStok { get; set; }
    
        public virtual tblKategori tblKategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSatis> tblSatis { get; set; }
    }
}
