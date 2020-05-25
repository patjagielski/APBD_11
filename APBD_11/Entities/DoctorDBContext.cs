using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Entities
{
    public class DoctorDBContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription_Medication> Prescription_Medications { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DoctorDBContext()
        {

        }
        public DoctorDBContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();

                entity.ToTable("Doctor");

                entity.HasMany(d => d.Prescriptions)
                      .WithOne(p => p.Doctor)
                      .HasForeignKey(p => p.IdDoctor)
                      .IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPresciption);
                entity.Property(e => e.IdPresciption).ValueGeneratedOnAdd();

                entity.ToTable("Prescription");

                entity.HasMany(d => d.Prescription_Medications)
                     .WithOne(p => p.Prescriptions)
                     .HasForeignKey(p => p.IdPrescription)
                     .IsRequired();

            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.IdPatient).ValueGeneratedOnAdd();

                entity.ToTable("Patient");

                entity.HasMany(d => d.Prescriptions)
                     .WithOne(p => p.Patient)
                     .HasForeignKey(p => p.IdPatient)
                     .IsRequired();
            });
            modelBuilder.Entity<Prescription_Medication>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });

                entity.ToTable("Prescription_Medication");

            });
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.IdMedicament).ValueGeneratedOnAdd();

                entity.ToTable("Medicament");

                entity.HasMany(d => d.Prescription_Medications)
                     .WithOne(p => p.Medicaments)
                     .HasForeignKey(p => p.IdMedicament)
                     .IsRequired();

            });
        }
    }
}
