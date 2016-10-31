namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M1Product()
        {
            M1OrderDetail = new HashSet<M1OrderDetail>();
            M1ProductInfo = new HashSet<M1ProductInfo>();
            M1ProductPhoto = new HashSet<M1ProductPhoto>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string NameWEB { get; set; }

        [StringLength(30)]
        public string Code { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal PromotionPrice { get; set; }

        public int Discount { get; set; }

        public bool IncludedVAT { get; set; }

        public int Quantity { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryIDS { get; set; }

        public int? SupplierID { get; set; }

        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }

        public bool Is_Stick { get; set; }

        public bool Is_special { get; set; }

        public bool Showhome { get; set; }

        public DateTime? TopHot { get; set; }

        public int ViewCount { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M1OrderDetail> M1OrderDetail { get; set; }

        public virtual M1ProductCategory M1ProductCategory { get; set; }

        public virtual M1Suppliers M1Suppliers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M1ProductInfo> M1ProductInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M1ProductPhoto> M1ProductPhoto { get; set; }
    }
}
