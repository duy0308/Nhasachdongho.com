namespace NHASACHDONGHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PicProduct")]
    public partial class PicProduct
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string MHCODE { get; set; }

        [StringLength(350)]
        public string FileName { get; set; }

        public int? Position { get; set; }
    }
}
