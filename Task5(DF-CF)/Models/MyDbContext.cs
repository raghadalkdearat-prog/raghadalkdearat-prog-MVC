using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task5_DF_CF_.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-42O6DLO;Database=CafeteriaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BFD93A3F0");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD4BD32FBC");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__4E88ABD4");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Products__Suppli__4F7CD00D");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK__Purchase__036BACA4ABABCA2F");

            entity.Property(e => e.PurchaseOrderId).ValueGeneratedNever();
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__PurchaseO__Suppl__52593CB8");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderItemId).HasName("PK__Purchase__3B33A0354B1F6064");

            entity.Property(e => e.PurchaseOrderItemId).ValueGeneratedNever();
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__PurchaseO__Produ__5629CD9C");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("FK__PurchaseO__Purch__5535A963");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B409443CD1");

            entity.Property(e => e.SupplierId).ValueGeneratedNever();
            entity.Property(e => e.SupplierEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
