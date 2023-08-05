using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TodoApp.Models
{
    public partial class dbMvcContext : DbContext
    {
        public dbMvcContext()
        {
        }

        public dbMvcContext(DbContextOptions<dbMvcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Email, "UQ__customer__AB6E6164D551CD75")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.Idescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("idescription");

                entity.Property(e => e.Iname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("iname");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__sales__DDDFDD36C1EE61B9");

                entity.ToTable("sales");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Iid).HasColumnName("iid");

                entity.Property(e => e.Sdate)
                    .HasColumnType("datetime")
                    .HasColumnName("sdate");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sales_customer");

                entity.HasOne(d => d.IidNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Iid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sales_item");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
