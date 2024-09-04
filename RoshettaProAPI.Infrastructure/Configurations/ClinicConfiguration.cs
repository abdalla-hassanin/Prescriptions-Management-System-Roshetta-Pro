using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.ClinicID);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.PhoneNumber).HasMaxLength(20);
        builder.Property(c => c.Email).HasMaxLength(100);
        builder.Property(c => c.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(c => c.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.Property(c => c.Address).IsRequired().HasMaxLength(255);

            builder.HasData(
                new Clinic
                {
                    ClinicID = 1, Name = "Cairo Medical Center", Address = "123 Cairo St, Cairo, Egypt",
                    PhoneNumber = "+2021234567", Email = "cairo.medical@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 2, Name = "Giza Health Clinic", Address = "456 Giza Rd, Giza, Egypt",
                    PhoneNumber = "+2027654321", Email = "giza.health@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 3, Name = "Alexandria Family Clinic", Address = "789 Alexandria Ave, Alexandria, Egypt",
                    PhoneNumber = "+2034567890", Email = "alex.family@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 4, Name = "Mansoura General Hospital", Address = "101 Mansoura Blvd, Mansoura, Egypt",
                    PhoneNumber = "+2051234567", Email = "mansoura.general@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 5, Name = "Asyut Specialist Clinic", Address = "202 Asyut Rd, Asyut, Egypt",
                    PhoneNumber = "+2081234567", Email = "asyut.specialist@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 6, Name = "Suez Healthcare", Address = "303 Suez St, Suez, Egypt",
                    PhoneNumber = "+2067654321", Email = "suez.healthcare@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 7, Name = "Fayoum Health Center", Address = "404 Fayoum Rd, Fayoum, Egypt",
                    PhoneNumber = "+2076543210", Email = "fayoum.health@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 8, Name = "Luxor Medical Clinic", Address = "505 Luxor St, Luxor, Egypt",
                    PhoneNumber = "+2091234567", Email = "luxor.medical@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 9, Name = "Aswan Care Clinic", Address = "606 Aswan Ave, Aswan, Egypt",
                    PhoneNumber = "+2097654321", Email = "aswan.care@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Clinic
                {
                    ClinicID = 10, Name = "Hurghada Wellness Center", Address = "707 Hurghada Blvd, Hurghada, Egypt",
                    PhoneNumber = "+2098765432", Email = "hurghada.wellness@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                }
            );
    }
}