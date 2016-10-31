namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContextModel : DbContext
    {
        public DataContextModel()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<M1About> M1About { get; set; }
        public virtual DbSet<M1Advertisement> M1Advertisement { get; set; }
        public virtual DbSet<M1Contact> M1Contact { get; set; }
        public virtual DbSet<M1Content> M1Content { get; set; }
        public virtual DbSet<M1ContentCategory> M1ContentCategory { get; set; }
        public virtual DbSet<M1CustumerGroup> M1CustumerGroup { get; set; }
        public virtual DbSet<M1Custumers> M1Custumers { get; set; }
        public virtual DbSet<M1Feedback> M1Feedback { get; set; }
        public virtual DbSet<M1Footer> M1Footer { get; set; }
        public virtual DbSet<M1Language> M1Language { get; set; }
        public virtual DbSet<M1MasterRoles> M1MasterRoles { get; set; }
        public virtual DbSet<M1Masters> M1Masters { get; set; }
        public virtual DbSet<M1Menu> M1Menu { get; set; }
        public virtual DbSet<M1MenuType> M1MenuType { get; set; }
        public virtual DbSet<M1OrderDetail> M1OrderDetail { get; set; }
        public virtual DbSet<M1Orders> M1Orders { get; set; }
        public virtual DbSet<M1OrderStatus> M1OrderStatus { get; set; }
        public virtual DbSet<M1Product> M1Product { get; set; }
        public virtual DbSet<M1ProductCategory> M1ProductCategory { get; set; }
        public virtual DbSet<M1ProductInfo> M1ProductInfo { get; set; }
        public virtual DbSet<M1ProductPhoto> M1ProductPhoto { get; set; }
        public virtual DbSet<M1RoleActions> M1RoleActions { get; set; }
        public virtual DbSet<M1Roles> M1Roles { get; set; }
        public virtual DbSet<M1Slide> M1Slide { get; set; }
        public virtual DbSet<M1Suppliers> M1Suppliers { get; set; }
        public virtual DbSet<M1SystemConfig> M1SystemConfig { get; set; }
        public virtual DbSet<M1Tag> M1Tag { get; set; }
        public virtual DbSet<M1WebActions> M1WebActions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M1About>()
                .Property(e => e.SeoTitle)
                .IsUnicode(false);

            modelBuilder.Entity<M1About>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1About>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<M1Advertisement>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Advertisement>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Content>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<M1Content>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Content>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Content>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<M1ContentCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<M1ContentCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1ContentCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1ContentCategory>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<M1ContentCategory>()
                .HasMany(e => e.M1Content)
                .WithOptional(e => e.M1ContentCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<M1CustumerGroup>()
                .HasMany(e => e.M1Custumers)
                .WithOptional(e => e.M1CustumerGroup)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<M1Custumers>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<M1Custumers>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<M1Custumers>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Custumers>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Custumers>()
                .HasMany(e => e.M1Orders)
                .WithOptional(e => e.M1Custumers)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<M1Language>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<M1Masters>()
                .HasMany(e => e.M1MasterRoles)
                .WithRequired(e => e.M1Masters)
                .HasForeignKey(e => e.MasterId);

            modelBuilder.Entity<M1MenuType>()
                .HasMany(e => e.M1Menu)
                .WithOptional(e => e.M1MenuType)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<M1OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<M1Orders>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<M1Orders>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<M1Orders>()
                .HasMany(e => e.M1OrderDetail)
                .WithOptional(e => e.M1Orders)
                .HasForeignKey(e => e.OrderID);

            modelBuilder.Entity<M1OrderStatus>()
                .HasMany(e => e.M1Orders)
                .WithOptional(e => e.M1OrderStatus)
                .HasForeignKey(e => e.Status);

            modelBuilder.Entity<M1Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<M1Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<M1Product>()
                .HasMany(e => e.M1OrderDetail)
                .WithOptional(e => e.M1Product)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<M1Product>()
                .HasMany(e => e.M1ProductInfo)
                .WithOptional(e => e.M1Product)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<M1Product>()
                .HasMany(e => e.M1ProductPhoto)
                .WithOptional(e => e.M1Product)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<M1ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<M1ProductCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1ProductCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1ProductCategory>()
                .HasMany(e => e.M1Product)
                .WithOptional(e => e.M1ProductCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<M1ProductInfo>()
                .Property(e => e.Detail)
                .IsFixedLength();

            modelBuilder.Entity<M1Roles>()
                .HasMany(e => e.M1MasterRoles)
                .WithRequired(e => e.M1Roles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<M1Roles>()
                .HasMany(e => e.M1RoleActions)
                .WithRequired(e => e.M1Roles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<M1Slide>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Slide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<M1Suppliers>()
                .HasMany(e => e.M1Product)
                .WithOptional(e => e.M1Suppliers)
                .HasForeignKey(e => e.SupplierID);

            modelBuilder.Entity<M1Tag>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<M1WebActions>()
                .HasMany(e => e.M1RoleActions)
                .WithRequired(e => e.M1WebActions)
                .HasForeignKey(e => e.WebActionId);
        }
    }
}
