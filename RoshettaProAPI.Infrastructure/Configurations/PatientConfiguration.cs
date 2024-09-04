using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.PatientID);

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(p => p.PhoneNumber).HasMaxLength(20);
        builder.Property(p => p.Email).HasMaxLength(100);
        builder.Property(p => p.ImageURL).HasMaxLength(255);
        builder.Property(p => p.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(p => p.UpdatedTime).HasDefaultValueSql("GETDATE()");
        // Configure the enums to be stored as integers
        builder.Property(p => p.Gender)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.BloodType)
            .IsRequired()
            .HasConversion<int>();
        builder.Property(p => p.Address).IsRequired().HasMaxLength(255);

        
        builder.HasOne(p => p.EmergencyContact)
            .WithMany(c => c.EmergencyPatients)
            .HasForeignKey(p => p.EmergencyContactID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete EmergencyContact
        
        
        // Configuring relationships that need cascading deletes
        builder.HasMany(p => p.MedicalHistories)
            .WithOne(mh => mh.Patient)
            .HasForeignKey(mh => mh.PatientID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete MedicalHistories

        builder.HasMany(p => p.Prescriptions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete Prescriptions

        builder.HasMany(p => p.PatientXrays)
            .WithOne(px => px.Patient)
            .HasForeignKey(px => px.PatientID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete PatientXrays

        
            // Seed data
            builder.HasData(
                new Patient
                {
                    PatientID = 1,
                    FirstName = "Youssef",
                    LastName = "Ahmed",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Gender = Gender.Male,
                    Address = "123 Cairo Street, Cairo",
                    PhoneNumber = "+201300000001",
                    Email = "youssef.ahmed@example.com",
                    BloodType = BloodType.APositive,
                    EmergencyContactID = 1,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 2,
                    FirstName = "Amina",
                    LastName = "Fathy",
                    DateOfBirth = new DateTime(1990, 3, 22),
                    Gender = Gender.Female,
                    Address = "456 Giza Road, Giza",
                    PhoneNumber = "+201300000002",
                    Email = "amina.fathy@example.com",
                    BloodType = BloodType.ANegative,
                    EmergencyContactID = 2,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 3,
                    FirstName = "Omar",
                    LastName = "Nabil",
                    DateOfBirth = new DateTime(1988, 8, 30),
                    Gender = Gender.Male,
                    Address = "789 Alexandria Avenue, Alexandria",
                    PhoneNumber = "+201300000003",
                    Email = "omar.nabil@example.com",
                    BloodType = BloodType.BPositive,
                    EmergencyContactID = 3,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 4,
                    FirstName = "Hassan",
                    LastName = "Mahmoud",
                    DateOfBirth = new DateTime(1985, 7, 12),
                    Gender = Gender.Male,
                    Address = "101 Mansoura Lane, Mansoura",
                    PhoneNumber = "+201300000004",
                    Email = "hassan.mahmoud@example.com",
                    BloodType = BloodType.BNegative,
                    EmergencyContactID = 4,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 5,
                    FirstName = "Layla",
                    LastName = "Omar",
                    DateOfBirth = new DateTime(1992, 1, 25),
                    Gender = Gender.Female,
                    Address = "202 Asyut Street, Asyut",
                    PhoneNumber = "+201300000005",
                    Email = "layla.omar@example.com",
                    BloodType = BloodType.ABPositive,
                    EmergencyContactID = 5,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 6,
                    FirstName = "Ahmed",
                    LastName = "Maher",
                    DateOfBirth = new DateTime(1995, 9, 10),
                    Gender = Gender.Male,
                    Address = "303 Suez Road, Suez",
                    PhoneNumber = "+201300000006",
                    Email = "ahmed.maher@example.com",
                    BloodType = BloodType.ABNegative,
                    EmergencyContactID = 6,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 7,
                    FirstName = "Nada",
                    LastName = "Ali",
                    DateOfBirth = new DateTime(1987, 4, 14),
                    Gender = Gender.Female,
                    Address = "404 Fayoum Street, Fayoum",
                    PhoneNumber = "+201300000007",
                    Email = "nada.ali@example.com",
                    BloodType = BloodType.OPositive,
                    EmergencyContactID = 7,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 8,
                    FirstName = "Mona",
                    LastName = "Yasser",
                    DateOfBirth = new DateTime(1989, 2, 5),
                    Gender = Gender.Female,
                    Address = "505 Luxor Avenue, Luxor",
                    PhoneNumber = "+201300000008",
                    Email = "mona.yasser@example.com",
                    BloodType = BloodType.ONegative,
                    EmergencyContactID = 8,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 9,
                    FirstName = "Hany",
                    LastName = "Ibrahim",
                    DateOfBirth = new DateTime(1983, 11, 20),
                    Gender = Gender.Male,
                    Address = "606 Aswan Road, Aswan",
                    PhoneNumber = "+201300000009",
                    Email = "hany.ibrahim@example.com",
                    BloodType = BloodType.APositive,
                    EmergencyContactID = 9,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Patient
                {
                    PatientID = 10,
                    FirstName = "Dina",
                    LastName = "Hassan",
                    DateOfBirth = new DateTime(1991, 6, 17),
                    Gender = Gender.Female,
                    Address = "707 Hurghada Street, Hurghada",
                    PhoneNumber = "+201300000010",
                    Email = "dina.hassan@example.com",
                    BloodType = BloodType.ABPositive,
                    EmergencyContactID = 10,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                }
            );
    }
}