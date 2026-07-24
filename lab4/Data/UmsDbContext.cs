using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using lab4.Data.Entities;

namespace lab4.Data;

public partial class UmsDbContext : DbContext
{
    public UmsDbContext()
    {
    }

    public UmsDbContext(DbContextOptions<UmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculty> Faculties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=UmsDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.ToTable("Faculty");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
