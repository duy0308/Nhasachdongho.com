namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1Tag
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string MetaTitle { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
