using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasKey(g => g.GenderID);

        builder.Property(g => g.GenderName).IsRequired().HasMaxLength(50);

        builder.HasData(
            new Gender { GenderID = 1, GenderName = "Male" },
            new Gender { GenderID = 2, GenderName = "Female" },
            new Gender { GenderID = 3, GenderName = "Other" }
        );
    }
}