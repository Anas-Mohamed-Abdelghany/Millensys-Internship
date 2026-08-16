using HospitalAPI.Person;
using HospitalAPI.Patient;
using HospitalAPI.Doctor;
using HospitalAPI.Study;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<StudyModel> Studies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonModel>(entity =>
            {
                entity.HasKey(e => e.PersonId);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<PatientModel>(entity =>
            {
                entity.HasKey(e => e.PatientId);
                entity.HasOne(e => e.Person)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<PatientModel>(e => e.PersonId);
                entity.Property(e => e.MRN).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(20);
            });

            modelBuilder.Entity<DoctorModel>(entity =>
            {
                entity.HasKey(e => e.DoctorId);
                entity.HasOne(e => e.Person)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<DoctorModel>(e => e.PersonId);
                entity.Property(e => e.Specialty).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<StudyModel>(entity =>
            {
                entity.HasKey(e => e.StudyId);
                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Studies)
                    .HasForeignKey(e => e.PatientId);
                entity.HasOne(e => e.Doctor)
                    .WithMany(d => d.Studies)
                    .HasForeignKey(e => e.DoctorId);
                entity.Property(e => e.Modality).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(20);
            });
        }
    }
}
