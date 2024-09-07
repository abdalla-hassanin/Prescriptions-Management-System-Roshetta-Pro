using Microsoft.EntityFrameworkCore;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Configurations;

namespace RoshettaProAPI.Infrustructure.Context;

public class ApplicationDbContext : DbContext
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
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new XrayConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}