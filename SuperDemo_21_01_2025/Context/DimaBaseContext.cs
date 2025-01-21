using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SuperDemo_21_01_2025.Models;

namespace SuperDemo_21_01_2025.Context;

public partial class DimaBaseContext : DbContext
{
    public DimaBaseContext()
    {
    }

    public DimaBaseContext(DbContextOptions<DimaBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoty> Categoties { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Postavshic> Postavshics { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=dima_base;Username=dima;password=dima");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoty>(entity =>
        {
            entity.HasKey(e => e.CategotyId).HasName("categoty_pk");

            entity.ToTable("Categoty", "public_21-01-25");

            entity.Property(e => e.CategotyId)
                .ValueGeneratedNever()
                .HasColumnName("Categoty_ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("manufacturer_pk");

            entity.ToTable("Manufacturer", "public_21-01-25");

            entity.Property(e => e.ManufacturerId)
                .ValueGeneratedNever()
                .HasColumnName("Manufacturer_ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Postavshic>(entity =>
        {
            entity.HasKey(e => e.PostavshicId).HasName("postavshic_pk");

            entity.ToTable("Postavshic", "public_21-01-25");

            entity.Property(e => e.PostavshicId)
                .ValueGeneratedNever()
                .HasColumnName("Postavshic_ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.TovarId).HasName("tovars_pk");

            entity.ToTable("Tovars", "public_21-01-25");

            entity.Property(e => e.TovarId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Tovar_ID");
            entity.Property(e => e.Articгul).HasMaxLength(10);
            entity.Property(e => e.CategotyId).HasColumnName("Categoty_ID");
            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.EdIzmerenia)
                .HasMaxLength(3)
                .HasColumnName("Ed_Izmerenia");
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_ID");
            entity.Property(e => e.MaxSkidka).HasColumnName("Max_Skidka");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Picture).HasColumnType("character varying");
            entity.Property(e => e.PostavshicId).HasColumnName("Postavshic_ID");

            entity.HasOne(d => d.Categoty).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.CategotyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tovars_categoty_fk");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tovars_manufacturer_fk");

            entity.HasOne(d => d.Postavshic).WithMany(p => p.Tovars)
                .HasForeignKey(d => d.PostavshicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tovars_postavshic_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
