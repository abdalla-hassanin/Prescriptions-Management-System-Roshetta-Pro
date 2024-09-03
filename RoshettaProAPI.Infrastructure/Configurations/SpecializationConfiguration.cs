using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(s => s.SpecializationID);

        builder.Property(s => s.SpecializationName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(s => s.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasData(
            new Specialization
            {
                SpecializationID = 1, SpecializationName = "Cardiology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 2, SpecializationName = "Dermatology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 3, SpecializationName = "Endocrinology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 4, SpecializationName = "Gastroenterology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 5, SpecializationName = "Hematology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 6, SpecializationName = "Neurology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 7, SpecializationName = "Oncology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 8, SpecializationName = "Ophthalmology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 9, SpecializationName = "Orthopedics", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 10, SpecializationName = "Pediatrics", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 11, SpecializationName = "Psychiatry", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 12, SpecializationName = "Pulmonology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 13, SpecializationName = "Radiology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 14, SpecializationName = "Rheumatology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 15, SpecializationName = "Urology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 16, SpecializationName = "Obstetrics and Gynecology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 17, SpecializationName = "Nephrology", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 18, SpecializationName = "General Surgery", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 19, SpecializationName = "Plastic Surgery", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 20, SpecializationName = "Emergency Medicine", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Specialization
            {
                SpecializationID = 21, SpecializationName = "Geriatrics", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            }
        );
    }
}