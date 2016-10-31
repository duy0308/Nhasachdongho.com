namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M1ProductCategory()
        {
            M1Product = new HashSet<M1Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string NameWEB { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int? ParentID { get; set; }

        public int? Level { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Descriptions { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(500)]
        public string MetaDescriptions { get; set; }

        [StringLength(500)]
        public string Path { get; set; }

        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M1Product> M1Product { get; set; }
    }
}
