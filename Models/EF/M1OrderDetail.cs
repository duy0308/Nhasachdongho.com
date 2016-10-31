namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1OrderDetail
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Code { get; set; }

        public int? OrderID { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public double? Discount { get; set; }

        public virtual M1Orders M1Orders { get; set; }

        public virtual M1Product M1Product { get; set; }
    }
}
