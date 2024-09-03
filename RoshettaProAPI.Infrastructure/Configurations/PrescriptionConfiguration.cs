using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.PrescriptionID);

        builder.Property(p => p.DateIssued).IsRequired();
        builder.Property(p => p.Notes).HasMaxLength(500);
        builder.Property(p => p.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(p => p.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasOne(p => p.Patient)
            .WithMany(pa => pa.Prescriptions)
            .HasForeignKey(p => p.PatientID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Doctor)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.DoctorID)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.PrescriptionMedications)
            .WithOne(pm => pm.Prescription)
            .HasForeignKey(pm => pm.PrescriptionID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete PrescriptionMedication

        builder.HasData(
            new Prescription
            {
                PrescriptionID = 1, PatientID = 1, DoctorID = 1, DateIssued = DateTime.Now.AddDays(-10),
                Notes = "Take with food", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 2, PatientID = 2, DoctorID = 2, DateIssued = DateTime.Now.AddDays(-9),
                Notes = "Take before bed", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 3, PatientID = 3, DoctorID = 3, DateIssued = DateTime.Now.AddDays(-8),
                Notes = "Take every 8 hours", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 4, PatientID = 4, DoctorID = 4, DateIssued = DateTime.Now.AddDays(-7),
                Notes = "Take every morning", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 5, PatientID = 5, DoctorID = 5, DateIssued = DateTime.Now.AddDays(-6),
                Notes = "Take every night", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 6, PatientID = 6, DoctorID = 6, DateIssued = DateTime.Now.AddDays(-5),
                Notes = "Take before meals", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 7, PatientID = 7, DoctorID = 7, DateIssued = DateTime.Now.AddDays(-4),
                Notes = "Take every 12 hours", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 8, PatientID = 8, DoctorID = 8, DateIssued = DateTime.Now.AddDays(-3),
                Notes = "Take with water", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 9, PatientID = 9, DoctorID = 9, DateIssued = DateTime.Now.AddDays(-2),
                Notes = "Take on an empty stomach", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Prescription
            {
                PrescriptionID = 10, PatientID = 10, DoctorID = 10, DateIssued = DateTime.Now.AddDays(-1),
                Notes = "Take before sleeping", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}