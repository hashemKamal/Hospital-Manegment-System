using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Doctor-Clinic Many-to-Many
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Clinics)
                .WithMany(c => c.Doctors)
                .UsingEntity<Dictionary<string, object>>(
                    "DoctorClinic",
                    dc => dc.HasOne<Clinic>().WithMany().HasForeignKey("ClinicId").OnDelete(DeleteBehavior.Cascade),
                    dc => dc.HasOne<Doctor>().WithMany().HasForeignKey("DoctorId").OnDelete(DeleteBehavior.Cascade),
                    dc => dc.HasKey("DoctorId", "ClinicId")
                );

            // Patient PrimaryDoctor
            modelBuilder.Entity<Patient>()
            .HasOne(p => p.PrimaryDoctor)
            .WithMany()
            .HasForeignKey(p => p.PrimaryDoctorId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>().HasIndex(d => d.Name);
            modelBuilder.Entity<Clinic>().HasIndex(c => c.Name);
        }
    }
}

