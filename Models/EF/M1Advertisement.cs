namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1Advertisement
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Banner { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public byte? DisplayOrder { get; set; }

        public byte? Location { get; set; }

        public bool? IsSpecies { get; set; }

        public bool? Status { get; set; }
    }
}
