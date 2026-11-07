using System;
using System.Collections.Generic;
using AcademyGraduationSupply.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AcademyGraduationSupply.Data;

public partial class AcademyGraduationPreparationContext : DbContext
{
    public AcademyGraduationPreparationContext(DbContextOptions<AcademyGraduationPreparationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BAE867913");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PK__Offers__8EBCF091E141EDA0");

            entity.HasIndex(e => e.SupplierId, "UQ__Offers__4BE666B536A27872").IsUnique();

            entity.Property(e => e.OfferName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Supplier).WithOne(p => p.Offer)
                .HasForeignKey<Offer>(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offers__Supplier__5070F446");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B470EC6F61");

            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Suppliers_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
