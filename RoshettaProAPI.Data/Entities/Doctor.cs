using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Data.Entities;

public class Doctor
{
    public int DoctorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Specialization Specialization { get; set; } // Use the enum instead of foreign key
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? ImageURL { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<MedicalHistory> MedicalHistories { get; set; }
    public ICollection<Xray> PatientXrays { get; set; }
}