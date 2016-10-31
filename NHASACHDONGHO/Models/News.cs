namespace NHASACHDONGHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int ID { get; set; }

        public int? tID { get; set; }

        [StringLength(550)]
        public string Title { get; set; }

        [StringLength(550)]
        public string Shoutcut { get; set; }

        [StringLength(550)]
        public string IMG { get; set; }

        public string Details { get; set; }

        public int? Positions { get; set; }

        public int? Actives { get; set; }

        public DateTime? Date { get; set; }
    }
}
