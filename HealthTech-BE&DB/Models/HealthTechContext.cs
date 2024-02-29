using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthTech331.Models
{
    public partial class HealthTechContext : DbContext
    {
        public HealthTechContext()
        {
        }

        public HealthTechContext(DbContextOptions<HealthTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<BusinessInterval> BusinessIntervals { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-08FV6VI\\SQLEXPRESS;Initial Catalog=HealthTech;Integrated Security=True;TrustServerCertificate=True;encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Applicat__1788CC4CA9B9A79A");

                entity.ToTable("ApplicationUser");

                entity.Property(e => e.Cnp).HasColumnName("CNP");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentId).ValueGeneratedNever();

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Appointment_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointment_Patient");
            });

            modelBuilder.Entity<BusinessInterval>(entity =>
            {
                entity.ToTable("BusinessInterval");

                entity.Property(e => e.BusinessIntervalId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Doctor__1788CC4C4892D03B");

                entity.ToTable("Doctor");

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.BusinessInterval)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.BusinessIntervalId)
                    .HasConstraintName("FK_Doctor_BusinessInterval");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_User_Speciality");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Doctor");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Patient__1788CC4C27EE35A7");

                entity.ToTable("Patient");

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Patient");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.Property(e => e.SpecialityId).ValueGeneratedNever();

                entity.Property(e => e.SpecialityDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialityName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
