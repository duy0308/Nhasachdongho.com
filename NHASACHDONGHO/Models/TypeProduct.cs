namespace NHASACHDONGHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeProduct")]
    public partial class TypeProduct
    {
        [Key]
        public int tprID { get; set; }

        public int? tprIDone { get; set; }

        [StringLength(550)]
        public string tprName { get; set; }

        public int? tprPosition { get; set; }

        [StringLength(550)]
        public string tprImages { get; set; }

        public int? tprType { get; set; }

        public int? tprActives { get; set; }

        [StringLength(50)]
        public string tprPositions { get; set; }
    }
}
