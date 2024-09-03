using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

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

        builder.HasOne(p => p.Gender)
            .WithMany(g => g.Patients)
            .HasForeignKey(p => p.GenderID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Address)
            .WithMany(a => a.Patients)
            .HasForeignKey(p => p.AddressID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete Address

        builder.HasOne(p => p.EmergencyContact)
            .WithMany(c => c.EmergencyPatients)
            .HasForeignKey(p => p.EmergencyContactID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete EmergencyContact

        builder.HasOne(p => p.BloodType)
            .WithMany(b => b.Patients)
            .HasForeignKey(p => p.BloodTypeID)
            .OnDelete(DeleteBehavior.NoAction);

        
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

        
        builder.HasData(
            new Patient
            {
                PatientID = 1, FirstName = "Youssef", LastName = "Ahmed", DateOfBirth = new DateTime(1985, 5, 15),
                GenderID = 1, AddressID = 1, PhoneNumber = "+201300000001", Email = "youssef.ahmed@example.com",
                BloodTypeID = 1, EmergencyContactID = 1, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 2, FirstName = "Amina", LastName = "Fathy", DateOfBirth = new DateTime(1990, 3, 22),
                GenderID = 2, AddressID = 2, PhoneNumber = "+201300000002", Email = "amina.fathy@example.com",
                BloodTypeID = 2, EmergencyContactID = 2, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 3, FirstName = "Omar", LastName = "Nabil", DateOfBirth = new DateTime(1988, 8, 30),
                GenderID = 1, AddressID = 3, PhoneNumber = "+201300000003", Email = "omar.nabil@example.com",
                BloodTypeID = 3, EmergencyContactID = 3, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 4, FirstName = "Hassan", LastName = "Mahmoud", DateOfBirth = new DateTime(1985, 7, 12),
                GenderID = 1, AddressID = 4, PhoneNumber = "+201300000004", Email = "hassan.mahmoud@example.com",
                BloodTypeID = 4, EmergencyContactID = 4, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 5, FirstName = "Layla", LastName = "Omar", DateOfBirth = new DateTime(1992, 1, 25),
                GenderID = 2, AddressID = 5, PhoneNumber = "+201300000005", Email = "layla.omar@example.com",
                BloodTypeID = 5, EmergencyContactID = 5, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 6, FirstName = "Ahmed", LastName = "Maher", DateOfBirth = new DateTime(1995, 9, 10),
                GenderID = 1, AddressID = 6, PhoneNumber = "+201300000006", Email = "ahmed.maher@example.com",
                BloodTypeID = 6, EmergencyContactID = 6, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 7, FirstName = "Nada", LastName = "Ali", DateOfBirth = new DateTime(1987, 4, 14),
                GenderID = 2, AddressID = 7, PhoneNumber = "+201300000007", Email = "nada.ali@example.com",
                BloodTypeID = 7, EmergencyContactID = 7, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 8, FirstName = "Mona", LastName = "Yasser", DateOfBirth = new DateTime(1989, 2, 5),
                GenderID = 2, AddressID = 8, PhoneNumber = "+201300000008", Email = "mona.yasser@example.com",
                BloodTypeID = 8, EmergencyContactID = 8, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 9, FirstName = "Hany", LastName = "Ibrahim", DateOfBirth = new DateTime(1983, 11, 20),
                GenderID = 1, AddressID = 9, PhoneNumber = "+201300000009", Email = "hany.ibrahim@example.com",
                BloodTypeID = 1, EmergencyContactID = 9, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Patient
            {
                PatientID = 10, FirstName = "Dina", LastName = "Hassan", DateOfBirth = new DateTime(1991, 6, 17),
                GenderID = 2, AddressID = 10, PhoneNumber = "+201300000010", Email = "dina.hassan@example.com",
                BloodTypeID = 5, EmergencyContactID = 10, CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}