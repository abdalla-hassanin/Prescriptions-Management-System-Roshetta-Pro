using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class MedicalHistoryConfiguration : IEntityTypeConfiguration<MedicalHistory>
{
    public void Configure(EntityTypeBuilder<MedicalHistory> builder)
    {
        builder.HasKey(mh => mh.MedicalHistoryID);

        builder.Property(mh => mh.VisitDate).IsRequired();
        builder.Property(mh => mh.Diagnosis).HasMaxLength(500);
        builder.Property(mh => mh.Notes).HasMaxLength(500);
        builder.Property(mh => mh.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(mh => mh.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasOne(mh => mh.Patient)
            .WithMany(p => p.MedicalHistories)
            .HasForeignKey(mh => mh.PatientID)
            .OnDelete(DeleteBehavior.Cascade); // Prevent cascade delete

        builder.HasOne(mh => mh.Doctor)
            .WithMany(d => d.MedicalHistories)
            .HasForeignKey(mh => mh.DoctorID)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete
        builder.HasData(
            new MedicalHistory
            {
                MedicalHistoryID = 1, PatientID = 1, DoctorID = 1, VisitDate = new DateTime(2023, 1, 1),
                Diagnosis = "Hypertension", Notes = "Regular check-up", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 2, PatientID = 2, DoctorID = 2, VisitDate = new DateTime(2023, 2, 2),
                Diagnosis = "Diabetes", Notes = "Diet recommended", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 3, PatientID = 3, DoctorID = 3, VisitDate = new DateTime(2023, 3, 3),
                Diagnosis = "Asthma", Notes = "Inhaler prescribed", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 4, PatientID = 4, DoctorID = 4, VisitDate = new DateTime(2023, 4, 4),
                Diagnosis = "Migraine", Notes = "Painkillers prescribed", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 5, PatientID = 5, DoctorID = 5, VisitDate = new DateTime(2023, 5, 5),
                Diagnosis = "Back Pain", Notes = "Physiotherapy advised", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 6, PatientID = 6, DoctorID = 6, VisitDate = new DateTime(2023, 6, 6),
                Diagnosis = "Allergy", Notes = "Antihistamines prescribed", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 7, PatientID = 7, DoctorID = 7, VisitDate = new DateTime(2023, 7, 7),
                Diagnosis = "High Cholesterol", Notes = "Diet change advised", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 8, PatientID = 8, DoctorID = 8, VisitDate = new DateTime(2023, 8, 8),
                Diagnosis = "Anemia", Notes = "Iron supplements prescribed", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 9, PatientID = 9, DoctorID = 9, VisitDate = new DateTime(2023, 9, 9),
                Diagnosis = "Flu", Notes = "Rest and fluids advised", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new MedicalHistory
            {
                MedicalHistoryID = 10, PatientID = 10, DoctorID = 10, VisitDate = new DateTime(2023, 10, 10),
                Diagnosis = "Arthritis", Notes = "Pain management plan created", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            }
        );
    }
}