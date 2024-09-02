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

        builder.HasOne(c => c.Address)
            .WithMany(a => a.Clinics)
            .HasForeignKey(c => c.AddressID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new Clinic
            {
                ClinicID = 1, Name = "Cairo Medical Center", AddressID = 1, PhoneNumber = "+2021234567",
                Email = "cairo.medical@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 2, Name = "Giza Health Clinic", AddressID = 2, PhoneNumber = "+2027654321",
                Email = "giza.health@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 3, Name = "Alexandria Family Clinic", AddressID = 3, PhoneNumber = "+2034567890",
                Email = "alex.family@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 4, Name = "Mansoura General Hospital", AddressID = 4, PhoneNumber = "+2051234567",
                Email = "mansoura.general@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 5, Name = "Asyut Specialist Clinic", AddressID = 5, PhoneNumber = "+2081234567",
                Email = "asyut.specialist@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 6, Name = "Suez Healthcare", AddressID = 6, PhoneNumber = "+2067654321",
                Email = "suez.healthcare@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 7, Name = "Fayoum Health Center", AddressID = 7, PhoneNumber = "+2076543210",
                Email = "fayoum.health@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 8, Name = "Luxor Medical Clinic", AddressID = 8, PhoneNumber = "+2091234567",
                Email = "luxor.medical@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 9, Name = "Aswan Care Clinic", AddressID = 9, PhoneNumber = "+2097654321",
                Email = "aswan.care@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Clinic
            {
                ClinicID = 10, Name = "Hurghada Wellness Center", AddressID = 10, PhoneNumber = "+2098765432",
                Email = "hurghada.wellness@example.com", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}