using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Configurations;

namespace RoshettaProAPI.Infrustructure.Context;

public class ApplicationDbContext :IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    public DbSet<Xray> PatientXrays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        // Apply custom entity configurations
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new XrayConfiguration());

        // Seed roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "Doctor", NormalizedName = "DOCTOR" },
            new IdentityRole { Name = "Patient", NormalizedName = "PATIENT" }
        );
    }
}