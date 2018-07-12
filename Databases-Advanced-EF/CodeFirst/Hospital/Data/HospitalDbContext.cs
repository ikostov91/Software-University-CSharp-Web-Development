using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public HospitalDbContext()
        {
            
        }

        public HospitalDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(d =>
            {
                d.HasKey(k => k.DiagnoseId);

                d.Property(n => n.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                d.Property(c => c.Comments)
                    .IsUnicode()
                    .HasMaxLength(250);

                d.HasOne(p => p.Patient)
                    .WithMany(x => x.Diagnoses)
                    .HasForeignKey(e => e.PatientId);
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(k => k.MedicamentId);

                m.Property(n => n.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(x => x.PatientId);

                p.Property(f => f.FirstName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                p.Property(l => l.LastName)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                p.Property(a => a.Address)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(250);

                p.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(80);

                p.Property(h => h.HasInsurance)
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<Visitation>(v =>
            {
                v.HasKey(k => k.VisitationId);

                v.Property(dt => dt.Date)
                    .IsRequired()
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()");

                v.Property(c => c.Comments)
                    .IsUnicode()
                    .HasMaxLength(250);

                v.HasOne(p => p.Patient)
                    .WithMany(x => x.Visitations)
                    .HasForeignKey(p => p.PatientId);
            });

            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(x => new {x.PatientId, x.MedicamentId});

                pm.HasOne(p => p.Patient)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(x => x.PatientId);

                pm.HasOne(m => m.Medicament)
                    .WithMany(p => p.Presciptions)
                    .HasForeignKey(x => x.MedicamentId);
            });
        }
    }
}
