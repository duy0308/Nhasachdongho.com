namespace NHASACHDONGHO.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataNhasachModel : DbContext
    {
        public DataNhasachModel()
            : base("name=DataContext2")
        {
        }

        public virtual DbSet<MATHANG> MATHANGs { get; set; }
        public virtual DbSet<MATHANGLOAI> MATHANGLOAIs { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsType> NewsTypes { get; set; }
        public virtual DbSet<PicProduct> PicProducts { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MATHANG>()
                .Property(e => e.SOLUONG)
                .HasPrecision(18, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.SOTONTRUOC)
                .HasPrecision(18, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.TONGSOLUONGNHAP)
                .HasPrecision(18, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.TONGSOLUONGTL)
                .HasPrecision(18, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIANHAP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.FCGIANHAPLANCUOI)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIANHAPLANCUOI)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.FCGIABANBINHQUAN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIABINHQUAN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.FCGIABANLE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIABANLE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.FCGIABANBUON)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIABANBUON)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.THUE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.FCHOAHONGBL)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.HOAHONGBL)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.FCHOAHONGBB)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.HOAHONGBB)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.NGUONGNHAP)
                .HasPrecision(18, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.NGUONGXUAT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIABAN1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIABAN2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANG>()
                .Property(e => e.GIABAN3)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MATHANGLOAI>()
                .HasMany(e => e.MATHANGs)
                .WithRequired(e => e.MATHANGLOAI)
                .HasForeignKey(e => e.MHLID)
                .WillCascadeOnDelete(false);
        }
    }
}
