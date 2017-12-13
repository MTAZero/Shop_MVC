namespace Shop_MVC.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        public int ID { get; set; }

        public int? DONHANGID { get; set; }

        public int? MATHANGID { get; set; }

        public int? SOLUONG { get; set; }

        public double? THANHTIEN { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual MATHANG MATHANG { get; set; }
    }
}
