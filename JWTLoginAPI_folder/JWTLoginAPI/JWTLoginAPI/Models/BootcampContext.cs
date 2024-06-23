using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JWTLoginAPI.Models;

public partial class BootcampContext : DbContext
{
    public BootcampContext()
    {
    }

    public BootcampContext(DbContextOptions<BootcampContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Register> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bootcamp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Login>(entity =>
        //{
        //    entity.HasKey(e => e.UserId).HasName("PK__Login__1788CCACF0A817AB");

        //    entity.ToTable("Login");

        //    entity.Property(e => e.UserId).HasColumnName("UserID");
        //    entity.Property(e => e.Password)
        //        .HasMaxLength(50)
        //        .HasColumnName("password");
        //    entity.Property(e => e.Email)
        //        .HasMaxLength(50)
        //        .HasColumnName("username");
        //});

        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Register__3214EC07A9527DEA");

            entity.ToTable("Register");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
