using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPatternApi.Models;

public partial class DbJewelsiteContext : DbContext
{
    public DbJewelsiteContext()
    {
    }

    public DbJewelsiteContext(DbContextOptions<DbJewelsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<TempUserOrder> TempUserOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserOrder> UserOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACCOUNT___3213E83FC2D5156D");

            entity.ToTable("ACCOUNT_TYPE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcStatus)
                .HasDefaultValue(true)
                .HasColumnName("ac_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ADMIN__3213E83FA1696EC0");

            entity.ToTable("ADMIN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcStatus)
                .HasDefaultValue(true)
                .HasColumnName("ac_status");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(233)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__CATEGORI__D837D05F557427F0");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.CStatus)
                .HasDefaultValue(true)
                .HasColumnName("c_status");
            entity.Property(e => e.Cname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cname");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Conid).HasName("PK__CONTACT__908D93A35742211B");

            entity.ToTable("CONTACT");

            entity.Property(e => e.Conid).HasColumnName("conid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CoStatus)
                .HasDefaultValue(true)
                .HasColumnName("co_status");
            entity.Property(e => e.Email)
                .HasMaxLength(233)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Stamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("stamp");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__PRODUCT__DD37D91AA291620E");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Cid)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("cid");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductStatus)
                .HasDefaultValue(true)
                .HasColumnName("product_status");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Cid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PRODUCT_CATEGORIES");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__REFRESH___C2B7EDE82F8107AC");

            entity.ToTable("REFRESH_TOKEN");

            entity.Property(e => e.Rid).HasColumnName("rid");
            entity.Property(e => e.Rcreatedat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("rcreatedat");
            entity.Property(e => e.RefreshToken1).HasColumnName("refresh_token");
            entity.Property(e => e.Rstatus)
                .HasDefaultValue(true)
                .HasColumnName("rstatus");
            entity.Property(e => e.Ruid).HasColumnName("ruid");

            entity.HasOne(d => d.Ru).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.Ruid)
                .HasConstraintName("FK_REFRESH_TOKEN_USER_TO_USER");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SETTING");

            entity.Property(e => e.Tax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TAX");
        });

        modelBuilder.Entity<TempUserOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TEMP_USE__3213E83F783648CA");

            entity.ToTable("TEMP_USER_ORDERS");

            entity.HasIndex(e => e.UserToken, "UQ__TEMP_USE__07CCCF36976024E0").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(233)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Orderat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("orderat");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TmStatus)
                .HasDefaultValue(true)
                .HasColumnName("tm_status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UserToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_token");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.TempUserOrders)
                .HasForeignKey(d => d.Pid)
                .HasConstraintName("FK_TEMP_USER_ORDERS_PRODUCT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__USERS__DD70126404E621F0");

            entity.ToTable("USERS");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Acid).HasColumnName("acid");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(233)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UStatus)
                .HasDefaultValue(true)
                .HasColumnName("u_status");

            entity.HasOne(d => d.Ac).WithMany(p => p.Users)
                .HasForeignKey(d => d.Acid)
                .HasConstraintName("FK_USER_ACCOUNT_TYPE");
        });

        modelBuilder.Entity<UserOrder>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PK__USER_ORD__C2FFCF13E958C5B9");

            entity.ToTable("USER_ORDERS");

            entity.Property(e => e.Oid).HasColumnName("oid");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.UserOrders)
                .HasForeignKey(d => d.Pid)
                .HasConstraintName("FK_USER_ORDERS_PRODUCT");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.UserOrders)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_USER_ORDERS_USER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
