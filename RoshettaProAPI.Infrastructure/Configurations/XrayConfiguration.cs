using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Infrustructure.Configurations;

public class XrayConfiguration : IEntityTypeConfiguration<Xray>
{
    public void Configure(EntityTypeBuilder<Xray> builder)
    {
        builder.HasKey(px => px.XrayID);

        builder.Property(px => px.DateTaken).IsRequired();
        builder.Property(px => px.XrayImageURL).HasMaxLength(255);
        builder.Property(px => px.LabName).HasMaxLength(100);
        builder.Property(px => px.XrayType).HasMaxLength(50);
        builder.Property(px => px.Notes).HasMaxLength(500);
        builder.Property(px => px.CreatedTime).HasDefaultValueSql("GETDATE()");
        builder.Property(px => px.UpdatedTime).HasDefaultValueSql("GETDATE()");

        builder.HasOne(px => px.Patient)
            .WithMany(p => p.PatientXrays)
            .HasForeignKey(px => px.PatientID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(px => px.Doctor)
            .WithMany(d => d.PatientXrays)
            .HasForeignKey(px => px.DoctorID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new Xray
            {
                XrayID = 1, PatientID = 1, DoctorID = 1, DateTaken = DateTime.Now.AddDays(-15),
                XrayImageURL = "http://example.com/xray1.png", LabName = "Cairo Lab", XrayType = "Chest",
                Notes = "Possible pneumonia", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 2, PatientID = 2, DoctorID = 2, DateTaken = DateTime.Now.AddDays(-14),
                XrayImageURL = "http://example.com/xray2.png", LabName = "Alexandria Lab", XrayType = "Spine",
                Notes = "Spinal alignment check", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 3, PatientID = 3, DoctorID = 3, DateTaken = DateTime.Now.AddDays(-13),
                XrayImageURL = "http://example.com/xray3.png", LabName = "Giza Lab", XrayType = "Knee",
                Notes = "ACL injury", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 4, PatientID = 4, DoctorID = 4, DateTaken = DateTime.Now.AddDays(-12),
                XrayImageURL = "http://example.com/xray4.png", LabName = "Luxor Lab", XrayType = "Skull",
                Notes = "Head trauma", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 5, PatientID = 5, DoctorID = 5, DateTaken = DateTime.Now.AddDays(-11),
                XrayImageURL = "http://example.com/xray5.png", LabName = "Aswan Lab", XrayType = "Abdomen",
                Notes = "Abdominal pain investigation", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 6, PatientID = 6, DoctorID = 6, DateTaken = DateTime.Now.AddDays(-10),
                XrayImageURL = "http://example.com/xray6.png", LabName = "Cairo Lab", XrayType = "Chest",
                Notes = "Lung infection", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 7, PatientID = 7, DoctorID = 7, DateTaken = DateTime.Now.AddDays(-9),
                XrayImageURL = "http://example.com/xray7.png", LabName = "Alexandria Lab", XrayType = "Spine",
                Notes = "Lower back pain", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 8, PatientID = 8, DoctorID = 8, DateTaken = DateTime.Now.AddDays(-8),
                XrayImageURL = "http://example.com/xray8.png", LabName = "Giza Lab", XrayType = "Knee",
                Notes = "Post-surgery check", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 9, PatientID = 9, DoctorID = 9, DateTaken = DateTime.Now.AddDays(-7),
                XrayImageURL = "http://example.com/xray9.png", LabName = "Luxor Lab", XrayType = "Skull",
                Notes = "Concussion follow-up", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            },
            new Xray
            {
                XrayID = 10, PatientID = 10, DoctorID = 10, DateTaken = DateTime.Now.AddDays(-6),
                XrayImageURL = "http://example.com/xray10.png", LabName = "Aswan Lab", XrayType = "Abdomen",
                Notes = "Routine check", CreatedTime = DateTime.Now, UpdatedTime = DateTime.Now
            }
        );
    }
}