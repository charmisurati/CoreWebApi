using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Database;

public partial class ProjectDatabaseContext : DbContext
{
    public ProjectDatabaseContext()
    {
    }

    public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsDatum> ProductsData { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V9IA3FL\\MSSQLSERVER01;Database=ProjectDatabase;TrustServerCertificate=True;Persist Security Info=False;User ID=sa;Password=Charmi;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.CategoryName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductsDatum>(entity =>
        {
            entity.HasKey(e => e.ProductDataId);

            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsData)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ProductsData_Products");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__UserData__5A2040BBF99D8C62");

            entity.Property(e => e.UId).HasColumnName("U_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
