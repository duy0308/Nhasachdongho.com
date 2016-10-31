namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1Menu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        public bool? Status { get; set; }

        public int? TypeID { get; set; }

        public virtual M1MenuType M1MenuType { get; set; }
    }
}
