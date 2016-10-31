namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M1Orders()
        {
            M1OrderDetail = new HashSet<M1OrderDetail>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string MaDonHang { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? RequireDate { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipMobile { get; set; }

        [StringLength(50)]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal? Amount { get; set; }

        public int? Status { get; set; }

        public virtual M1Custumers M1Custumers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M1OrderDetail> M1OrderDetail { get; set; }

        public virtual M1OrderStatus M1OrderStatus { get; set; }
    }
}
