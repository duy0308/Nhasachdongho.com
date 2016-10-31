namespace NHASACHDONGHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATHANG")]
    public partial class MATHANG
    {
        [Key]
        public Guid MHID { get; set; }

        [StringLength(30)]
        public string MHCODE { get; set; }

        public int MHLID { get; set; }

        [StringLength(100)]
        public string MHTEN { get; set; }

        public decimal? SOLUONG { get; set; }

        public decimal? SOTONTRUOC { get; set; }

        public decimal? TONGSOLUONGNHAP { get; set; }

        public decimal? TONGSOLUONGTL { get; set; }

        [StringLength(20)]
        public string DONVI { get; set; }

        [StringLength(100)]
        public string MHKMID { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIANHAP { get; set; }

        [Column(TypeName = "money")]
        public decimal? FCGIANHAPLANCUOI { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIANHAPLANCUOI { get; set; }

        [Column(TypeName = "money")]
        public decimal? FCGIABANBINHQUAN { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABINHQUAN { get; set; }

        [Column(TypeName = "money")]
        public decimal? FCGIABANLE { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABANLE { get; set; }

        [Column(TypeName = "money")]
        public decimal? FCGIABANBUON { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABANBUON { get; set; }

        [Column(TypeName = "money")]
        public decimal? THUE { get; set; }

        [Column(TypeName = "money")]
        public decimal? FCHOAHONGBL { get; set; }

        [Column(TypeName = "money")]
        public decimal? HOAHONGBL { get; set; }

        [Column(TypeName = "money")]
        public decimal? FCHOAHONGBB { get; set; }

        [Column(TypeName = "money")]
        public decimal? HOAHONGBB { get; set; }

        [StringLength(50)]
        public string XUATXU { get; set; }

        public decimal? NGUONGNHAP { get; set; }

        public decimal? NGUONGXUAT { get; set; }

        [StringLength(500)]
        public string CAUHINH { get; set; }

        public bool? HASDETAIL { get; set; }

        [StringLength(200)]
        public string GHICHU { get; set; }

        public bool? THEODOI { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABAN1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABAN2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABAN3 { get; set; }

        public int? MHBHID { get; set; }

        [StringLength(100)]
        public string MATCHCODE { get; set; }

        public DateTime? CREATED { get; set; }

        public DateTime? UPDATED { get; set; }

        [StringLength(12)]
        public string USERID { get; set; }

        public int? Actives { get; set; }

        public int? Home { get; set; }

        public string Details { get; set; }

        public int? Postion { get; set; }

        public int? views { get; set; }

        public int? tprID { get; set; }

        [StringLength(550)]
        public string images { get; set; }

        [StringLength(550)]
        public string mhName { get; set; }

        public int? BTG { get; set; }

        public byte? MHTID { get; set; }

        public Guid? KHID { get; set; }

        public int? UNITID { get; set; }

        public virtual MATHANGLOAI MATHANGLOAI { get; set; }
    }
}
