namespace Shop_MVC.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANHSP")]
    public partial class ANHSP
    {
        public int ID { get; set; }

        public int? MATHANGID { get; set; }

        public string SRC { get; set; }

        public virtual MATHANG MATHANG { get; set; }
    }
}
