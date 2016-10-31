namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1ProductInfo
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Detail { get; set; }

        public virtual M1Product M1Product { get; set; }
    }
}
