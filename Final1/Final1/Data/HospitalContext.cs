using System;
using System.Collections.Generic;
using Final1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final1.Data;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=HospitalDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__F3993564501AFBA4");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("doctor_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Specialization)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("specialization");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__4D5CE4766B58D7E3");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Patients)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Patients__doctor__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
