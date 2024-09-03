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
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<MedicationForm> MedicationForms { get; set; }
    public DbSet<PrescriptionMedication> PrescriptionMedications { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    public DbSet<PatientXray> PatientXrays { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<BloodType> BloodTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new ClinicConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationFormConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new PatientXrayConfiguration());
        modelBuilder.ApplyConfiguration(new GenderConfiguration());
        modelBuilder.ApplyConfiguration(new BloodTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}