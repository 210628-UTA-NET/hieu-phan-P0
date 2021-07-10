using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SSDDL.Entities
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avenger> Avengers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Finger> Fingers { get; set; }
        public virtual DbSet<Heart> Hearts { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonsCourse> PersonsCourses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Avenger>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("avenger");

                entity.Property(e => e.PowerLevel).HasColumnName("power_level");

                entity.Property(e => e.RealName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("real_name");

                entity.Property(e => e.SuperheroName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("superhero_name");

                entity.Property(e => e.SuperheroPower)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("superhero_power");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("course_id");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("course_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Finger>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Finger");

                entity.Property(e => e.FingerLength).HasColumnName("finger_length");

                entity.Property(e => e.FingerType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("finger_type");

                entity.Property(e => e.PersonSsn).HasColumnName("person_SSN");

                entity.HasOne(d => d.PersonSsnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PersonSsn)
                    .HasConstraintName("foreign_key_finger");
            });

            modelBuilder.Entity<Heart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("heart");

                entity.HasIndex(e => e.PersonSsn, "UQ__heart__231869A40A030415")
                    .IsUnique();

                entity.Property(e => e.Healthy).HasColumnName("healthy");

                entity.Property(e => e.HeartSize).HasColumnName("heart_size");

                entity.Property(e => e.PersonSsn).HasColumnName("person_SSN");

                entity.HasOne(d => d.PersonSsnNavigation)
                    .WithOne()
                    .HasForeignKey<Heart>(d => d.PersonSsn)
                    .HasConstraintName("foreign_key_heart");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventories_products");

                entity.HasOne(d => d.StoreFront)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreFrontId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventories_storeFronts");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lineItems_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lineItems_products");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.StoreFront)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreFrontId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_storeFronts");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("primary_key_person");

                entity.ToTable("Person");

                entity.Property(e => e.Ssn)
                    .ValueGeneratedNever()
                    .HasColumnName("SSN");

                entity.Property(e => e.PersonAge).HasColumnName("person_age");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("person_name");
            });

            modelBuilder.Entity<PersonsCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("persons_courses");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.PersonSsn).HasColumnName("person_SSN");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__persons_c__cours__66603565");

                entity.HasOne(d => d.PersonSsnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PersonSsn)
                    .HasConstraintName("FK__persons_c__perso__656C112C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantState)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Review");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Rating).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.ReviewDescripton)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Restaurant)
                    .WithMany()
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("foreign_key");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
