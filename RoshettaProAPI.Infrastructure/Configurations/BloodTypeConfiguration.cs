using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class BloodTypeConfiguration : IEntityTypeConfiguration<BloodType>
{
    public void Configure(EntityTypeBuilder<BloodType> builder)
    {
        builder.HasKey(b => b.BloodTypeID);

        builder.Property(b => b.BloodTypeName).IsRequired().HasMaxLength(10);

        builder.HasData(
            new BloodType { BloodTypeID = 1, BloodTypeName = "A+" },
            new BloodType { BloodTypeID = 2, BloodTypeName = "A-" },
            new BloodType { BloodTypeID = 3, BloodTypeName = "B+" },
            new BloodType { BloodTypeID = 4, BloodTypeName = "B-" },
            new BloodType { BloodTypeID = 5, BloodTypeName = "AB+" },
            new BloodType { BloodTypeID = 6, BloodTypeName = "AB-" },
            new BloodType { BloodTypeID = 7, BloodTypeName = "O+" },
            new BloodType { BloodTypeID = 8, BloodTypeName = "O-" }
        );
    }
}