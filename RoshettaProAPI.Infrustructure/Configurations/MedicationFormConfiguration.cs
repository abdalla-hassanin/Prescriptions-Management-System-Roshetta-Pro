using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class MedicationFormConfiguration : IEntityTypeConfiguration<MedicationForm>
{
    public void Configure(EntityTypeBuilder<MedicationForm> builder)
    {
        builder.HasKey(mt => mt.MedicationFormID);

        builder.Property(mt => mt.FormName).IsRequired().HasMaxLength(100);
        builder.Property(mt => mt.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(mt => mt.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasData(
            new MedicationForm
                { MedicationFormID = 1, FormName = "Tablet", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 2, FormName = "Capsule", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 3, FormName = "Syrup", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 4, FormName = "Ointment", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
            {
                MedicationFormID = 5, FormName = "Injection", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new MedicationForm
            {
                MedicationFormID = 6, FormName = "Suppository", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new MedicationForm
                { MedicationFormID = 7, FormName = "Patch", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 8, FormName = "Liquid", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 9, FormName = "Powder", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 10, FormName = "Gel", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now },
            new MedicationForm
                { MedicationFormID = 11, FormName = "Lozenge", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now }
        );
    }
}