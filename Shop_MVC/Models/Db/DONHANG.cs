namespace Shop_MVC.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        public int ID { get; set; }

        public int? MA { get; set; }

        public int? TAIKHOANID { get; set; }

        public double? TONGTIEN { get; set; }

        public int? TRANGTHAI { get; set; }

        public string DIACHI { get; set; }

        public string SDT { get; set; }

        public string YEUCAUGIAOHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
