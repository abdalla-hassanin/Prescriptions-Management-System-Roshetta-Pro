using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class PrescriptionMedicationConfiguration : IEntityTypeConfiguration<PrescriptionMedication>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedication> builder)
    {
        builder.HasKey(pm => pm.PrescriptionMedicationID);

        builder.Property(pm => pm.Dosage).IsRequired();
        builder.Property(pm => pm.DosageUnit).IsRequired().HasMaxLength(10);
        builder.Property(pm => pm.Frequency).IsRequired().HasMaxLength(50);
        builder.Property(pm => pm.Instructions).HasMaxLength(500);
        builder.Property(pm => pm.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(pm => pm.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedications)
            .HasForeignKey(pm => pm.PrescriptionID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pm => pm.Medication)
            .WithMany(m => m.PrescriptionMedications)
            .HasForeignKey(pm => pm.MedicationID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 1, PrescriptionID = 1, MedicationID = 1, Dosage = 500, DosageUnit = "mg",
                Frequency = "Twice a day", StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(10),
                Instructions = "Take with food", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 2, PrescriptionID = 2, MedicationID = 2, Dosage = 250, DosageUnit = "mg",
                Frequency = "Once a day", StartDate = DateTime.Now.AddDays(-9), EndDate = DateTime.Now.AddDays(9),
                Instructions = "Take before bed", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 3, PrescriptionID = 3, MedicationID = 3, Dosage = 100, DosageUnit = "mg",
                Frequency = "Every 8 hours", StartDate = DateTime.Now.AddDays(-8), EndDate = DateTime.Now.AddDays(8),
                Instructions = "Take every 8 hours", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 4, PrescriptionID = 4, MedicationID = 4, Dosage = 200, DosageUnit = "mg",
                Frequency = "Every morning", StartDate = DateTime.Now.AddDays(-7), EndDate = DateTime.Now.AddDays(7),
                Instructions = "Take every morning", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 5, PrescriptionID = 5, MedicationID = 5, Dosage = 150, DosageUnit = "mg",
                Frequency = "Every night", StartDate = DateTime.Now.AddDays(-6), EndDate = DateTime.Now.AddDays(6),
                Instructions = "Take every night", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 6, PrescriptionID = 6, MedicationID = 6, Dosage = 500, DosageUnit = "mg",
                Frequency = "Before meals", StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(5),
                Instructions = "Take before meals", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 7, PrescriptionID = 7, MedicationID = 7, Dosage = 100, DosageUnit = "mg",
                Frequency = "Every 12 hours", StartDate = DateTime.Now.AddDays(-4), EndDate = DateTime.Now.AddDays(4),
                Instructions = "Take every 12 hours", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 8, PrescriptionID = 8, MedicationID = 8, Dosage = 75, DosageUnit = "mg",
                Frequency = "With water", StartDate = DateTime.Now.AddDays(-3), EndDate = DateTime.Now.AddDays(3),
                Instructions = "Take with water", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 9, PrescriptionID = 9, MedicationID = 9, Dosage = 50, DosageUnit = "mg",
                Frequency = "On an empty stomach", StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(2), Instructions = "Take on an empty stomach",
                CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new PrescriptionMedication
            {
                PrescriptionMedicationID = 10, PrescriptionID = 10, MedicationID = 10, Dosage = 300, DosageUnit = "mg",
                Frequency = "Before sleeping", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(1),
                Instructions = "Take before sleeping", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}