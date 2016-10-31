namespace NHASACHDONGHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATHANGLOAI")]
    public partial class MATHANGLOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATHANGLOAI()
        {
            MATHANGs = new HashSet<MATHANG>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? PARENTID { get; set; }

        public int? LEVEL { get; set; }

        public bool? HASPARENT { get; set; }

        [StringLength(500)]
        public string PATH { get; set; }

        [StringLength(30)]
        public string MHLCODE { get; set; }

        [StringLength(50)]
        public string MHLTEN { get; set; }

        [StringLength(200)]
        public string MOTA { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANH { get; set; }

        [StringLength(200)]
        public string GHICHU { get; set; }

        public int? STATUS { get; set; }

        [StringLength(6)]
        public string MATCHCODE { get; set; }

        public DateTime? CREATED { get; set; }

        public DateTime? UPDATED { get; set; }

        [StringLength(12)]
        public string USERID { get; set; }

        [StringLength(100)]
        public string ALIAS { get; set; }

        public int? home { get; set; }

        public int? Activate { get; set; }

        public int? Postion { get; set; }

        public int? tprID { get; set; }

        [Required]
        [StringLength(350)]
        public string TenWeb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATHANG> MATHANGs { get; set; }
    }
}
