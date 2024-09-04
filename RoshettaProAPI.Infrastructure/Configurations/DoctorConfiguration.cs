using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.DoctorID);

        builder.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(d => d.LastName).IsRequired().HasMaxLength(100);
        builder.Property(d => d.PhoneNumber).HasMaxLength(20);
        builder.Property(d => d.Email).HasMaxLength(100);
        builder.Property(d => d.ImageURL).HasMaxLength(255);
        builder.Property(d => d.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(d => d.UpdatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(d => d.Specialization)
            .HasConversion<int>(); // Store enum as integer in the database


        builder.HasOne(d => d.Clinic)
            .WithMany(c => c.Doctors)
            .HasForeignKey(d => d.ClinicID)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete Clinic

            builder.HasData(
                new Doctor
                {
                    DoctorID = 1, FirstName = "Mohamed", LastName = "Hassan", Specialization = Specialization.Cardiology,
                    PhoneNumber = "+201200000001", Email = "mohamed.hassan@example.com", ClinicID = 1,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 2, FirstName = "Alaa", LastName = "Salem", Specialization = Specialization.Dermatology,
                    PhoneNumber = "+201200000002", Email = "alaa.salem@example.com", ClinicID = 2,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 3, FirstName = "Samir", LastName = "Youssef", Specialization = Specialization.Endocrinology,
                    PhoneNumber = "+201200000003", Email = "samir.youssef@example.com", ClinicID = 3,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 4, FirstName = "Hassan", LastName = "Ibrahim", Specialization = Specialization.Gastroenterology,
                    PhoneNumber = "+201200000004", Email = "hassan.ibrahim@example.com", ClinicID = 4,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 5, FirstName = "Mona", LastName = "Nabil", Specialization = Specialization.Hematology,
                    PhoneNumber = "+201200000005", Email = "mona.nabil@example.com", ClinicID = 5,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 6, FirstName = "Ahmed", LastName = "Mahmoud", Specialization = Specialization.Neurology,
                    PhoneNumber = "+201200000006", Email = "ahmed.mahmoud@example.com", ClinicID = 6,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 7, FirstName = "Layla", LastName = "Omar", Specialization = Specialization.Oncology,
                    PhoneNumber = "+201200000007", Email = "layla.omar@example.com", ClinicID = 7,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 8, FirstName = "Youssef", LastName = "Hassan", Specialization = Specialization.Ophthalmology,
                    PhoneNumber = "+201200000008", Email = "youssef.hassan@example.com", ClinicID = 8,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 9, FirstName = "Nada", LastName = "Ali", Specialization = Specialization.Orthopedics,
                    PhoneNumber = "+201200000009", Email = "nada.ali@example.com", ClinicID = 9,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                },
                new Doctor
                {
                    DoctorID = 10, FirstName = "Hany", LastName = "Maged", Specialization = Specialization.Pediatrics,
                    PhoneNumber = "+201200000010", Email = "hany.maged@example.com", ClinicID = 10,
                    CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
                }
            );
    }
}