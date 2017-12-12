namespace Shop_MVC.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANXET")]
    public partial class NHANXET
    {
        public int ID { get; set; }

        public int? TAIKHOANID { get; set; }

        public int? MATHANGID { get; set; }

        public string NOIDUNG { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
