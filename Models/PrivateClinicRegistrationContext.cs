using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrivateClinicRegistration.Models
{
    public partial class PrivateClinicRegistrationContext : DbContext
    {
        public PrivateClinicRegistrationContext()
        {
        }

        public PrivateClinicRegistrationContext(DbContextOptions<PrivateClinicRegistrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PrivateClinicRegistration;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateTimeStart).HasColumnType("datetime");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientFullname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PatientPhone).HasMaxLength(15);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Doctor");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Service");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Profile)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            });
        }
    }
}
