namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1Language
    {
        [StringLength(2)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }
    }
}
