using Microsoft.EntityFrameworkCore;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Enumerations;
using PrintMersion.Core.Interfaces;
using System;

namespace PrintMersion.Infrastructure.Data
{
    public partial class PrintMersionDBContext : DbContext, IDBContextModel
    {
        public PrintMersionDBContext()
        {
        
        }

        public PrintMersionDBContext(DbContextOptions<PrintMersionDBContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersPictures> UsersPictures { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<CatalogsPictures> CatalogsPictures { get; set; }
        public virtual DbSet<CatalogsProducts> CatalogsProducts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersPictures> CustomersPictures { get; set; }
        public virtual DbSet<LogsTools> LogsTools { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsPictures> ProductsPictures { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<ToolsPictures> ToolsPictures { get; set; }
        public virtual DbSet<BotCustomer> BotCustomers { get; set; }
      
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

          
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Data Source=SATELLITE-ALEXI\\SQLEXPRESS;Initial Catalog=PrintMersionDB;Integrated Security=True");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Address__3214EC0650DF4974")
                    .IsUnique();

               

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExteriorNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.InteriorNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                .HasMaxLength(32)
                .IsUnicode();
                entity.Property(e => e.Latitude)
                .HasMaxLength(32)
                .IsUnicode();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Administ__3214EC06F23652DC")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.Role)
                  .HasColumnName("Role")
                  .HasMaxLength(15)
                  .IsRequired()
                  .HasConversion(
                   x => x.ToString(),
                   x => (RoleType)Enum.Parse(typeof(RoleType), x)
                   );
              

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPicture)
                    .HasConstraintName("fk_User_Picture");

            });

            modelBuilder.Entity<UsersPictures>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

               

                entity.Property(e => e.IdUser).HasColumnName("IdUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Pictures_Users");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPicture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Pictures_Pictures");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Catalogs__3214EC069D79A489")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogsPictures>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();


                entity.ToTable("Catalogs_Pictures");

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogs_Pictures_Catalogs");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPicture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogs_Pictures_Pictures");
            });

            modelBuilder.Entity<CatalogsProducts>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Catalogs_Products");

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCatalog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogs_Products_Catalogs");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Catalogs_Products_Products");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Customer__3214EC06F6258619")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("fk_Customers_Address");
            });

            modelBuilder.Entity<CustomersPictures>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Customers_Pictures");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Customers_Pictures_Customers");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPicture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Customers_Pictures_Pictures");
            });

            modelBuilder.Entity<LogsTools>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__LogsTool__3214EC06BB600FAA")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.EndUse).HasColumnType("datetime");

                entity.Property(e => e.StartUse).HasColumnType("datetime");

                entity.HasOne(d => d.IdAdministerNavigation)
                    .WithMany(p => p.LogsTools)
                    .HasForeignKey(d => d.IdAdminister)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LogsTools_Administers");

                entity.HasOne(d => d.IdToolNavigation)
                    .WithMany(p => p.LogsTools)
                    .HasForeignKey(d => d.IdTool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LogsTools_Tool");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Orders__3214EC068F9DCEBA")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryMethod)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DetailedInformation).IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Tracking).HasColumnType("char")
                .HasMaxLength(36)
                .IsUnicode(false).HasValueGenerator<GuidGenerator>().ValueGeneratedOnAdd();
               

                entity.HasOne(d => d.IdAdministerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdAdminister)
                    .HasConstraintName("fk_Orders_Users");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Orders_Customers");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Pictures__3214EC069D4153E6")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DataRaw)
                    .IsUnicode(false).HasColumnType("LONGBLOB");

                entity.Property(e => e.Metadata).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Products__3214EC0658BFAAF7")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductsPictures>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Products_Pictures");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPicture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Products_Pictures_Pictures");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Products_Pictures_Products");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Tools__3214EC06EEF22EC7")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToolsPictures>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.ToTable("Tools_Pictures");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPicture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tools_Pictures_Pictures");

                entity.HasOne(d => d.IdToolsNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTools)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tools_Pictures_Tools");
            });

            modelBuilder.Entity<BotCustomer>(entity => {

                entity.HasIndex(e => e.Id)
                        
                        .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);




                entity.Property(e => e.MessengerUserId)
               .HasMaxLength(32)
               .IsUnicode();

                entity.Property(e => e.Gender)
                .HasMaxLength(32)
              .IsUnicode();

                entity.Property(e => e.ProfilePicUrl)
                 .HasMaxLength(128)
              .IsUnicode();

                entity.Property(e => e.TimeZone)
                .HasMaxLength(32)
             .IsUnicode();

                entity.Property(e => e.Locale)
                .HasMaxLength(32)
             .IsUnicode();
                entity.Property(e => e.Source)
                .HasMaxLength(32)
             .IsUnicode();
                entity.Property(e => e.LastSeen)
                .HasMaxLength(32)
             .IsUnicode();

                entity.Property(e => e.SignedUp)
                .HasMaxLength(32)
             .IsUnicode();
                entity.Property(e => e.Sessions)
                .HasMaxLength(32)
             .IsUnicode();
                entity.Property(e => e.LastVisitedBlockName)
                .HasMaxLength(32)
             .IsUnicode();
                entity.Property(e => e.LastVisitedBlockId)
                .HasMaxLength(32)
             .IsUnicode();
                entity.Property(e => e.LastClickedButtonName)
                .HasMaxLength(32)
             .IsUnicode();

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.BotCustomers)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("fk_BotCustomers_Address");



            }
            );
         
           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
