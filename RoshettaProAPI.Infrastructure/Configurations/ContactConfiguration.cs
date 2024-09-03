using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.ContactID);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.PhoneNumber).HasMaxLength(20);
        builder.Property(c => c.Email).HasMaxLength(100);
        builder.Property(c => c.Relationship).HasMaxLength(50);
        builder.Property(c => c.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(c => c.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasData(
            new Contact
            {
                ContactID = 1, Name = "Ahmed Ali", PhoneNumber = "+201000000001", Email = "ahmed.ali@example.com",
                Relationship = "Brother", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 2, Name = "Sara Ahmed", PhoneNumber = "+201000000002", Email = "sara.ahmed@example.com",
                Relationship = "Sister", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 3, Name = "Hassan Youssef", PhoneNumber = "+201000000003",
                Email = "hassan.youssef@example.com", Relationship = "Father", CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 4, Name = "Mona Khaled", PhoneNumber = "+201000000004", Email = "mona.khaled@example.com",
                Relationship = "Mother", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 5, Name = "Omar Ibrahim", PhoneNumber = "+201000000005", Email = "omar.ibrahim@example.com",
                Relationship = "Friend", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 6, Name = "Layla Nabil", PhoneNumber = "+201000000006", Email = "layla.nabil@example.com",
                Relationship = "Cousin", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 7, Name = "Ali Maher", PhoneNumber = "+201000000007", Email = "ali.maher@example.com",
                Relationship = "Uncle", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 8, Name = "Noha Saad", PhoneNumber = "+201000000008", Email = "noha.saad@example.com",
                Relationship = "Aunt", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 9, Name = "Youssef Omar", PhoneNumber = "+201000000009", Email = "youssef.omar@example.com",
                Relationship = "Nephew", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Contact
            {
                ContactID = 10, Name = "Dina Yasser", PhoneNumber = "+201000000010", Email = "dina.yasser@example.com",
                Relationship = "Niece", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}