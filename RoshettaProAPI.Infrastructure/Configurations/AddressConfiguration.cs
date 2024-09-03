using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.AddressID);

        builder.Property(a => a.AddressLine1).IsRequired().HasMaxLength(200);
        builder.Property(a => a.AddressLine2).HasMaxLength(200);
        builder.Property(a => a.City).IsRequired().HasMaxLength(100);
        builder.Property(a => a.State).HasMaxLength(100);
        builder.Property(a => a.PostalCode).HasMaxLength(20);
        builder.Property(a => a.Country).IsRequired().HasMaxLength(100);
        builder.Property(a => a.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(a => a.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasData(
            new Address
            {
                AddressID = 1, AddressLine1 = "123 Main St", City = "Cairo", State = "Cairo", PostalCode = "11511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 2, AddressLine1 = "456 Elm St", City = "Giza", State = "Giza", PostalCode = "12511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 3, AddressLine1 = "789 Pine St", City = "Alexandria", State = "Alexandria",
                PostalCode = "21521", Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 4, AddressLine1 = "101 Maple St", City = "Mansoura", State = "Dakahlia",
                PostalCode = "35511", Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 5, AddressLine1 = "202 Cedar St", City = "Asyut", State = "Asyut", PostalCode = "71511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 6, AddressLine1 = "303 Oak St", City = "Suez", State = "Suez", PostalCode = "43511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 7, AddressLine1 = "404 Birch St", City = "Fayoum", State = "Fayoum", PostalCode = "63511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 8, AddressLine1 = "505 Willow St", City = "Luxor", State = "Luxor", PostalCode = "85511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 9, AddressLine1 = "606 Cherry St", City = "Aswan", State = "Aswan", PostalCode = "81511",
                Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Address
            {
                AddressID = 10, AddressLine1 = "707 Palm St", City = "Hurghada", State = "Red Sea",
                PostalCode = "84511", Country = "Egypt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}