namespace NHASACHDONGHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsType")]
    public partial class NewsType
    {
        [Key]
        public int tID { get; set; }

        [StringLength(150)]
        public string tieude { get; set; }

        public int? vitri { get; set; }

        public int? trangthai { get; set; }
    }
}
