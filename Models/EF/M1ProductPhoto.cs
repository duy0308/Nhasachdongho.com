namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1ProductPhoto
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        public int? ProductID { get; set; }

        public byte? DisplayOrder { get; set; }

        public virtual M1Product M1Product { get; set; }
    }
}
