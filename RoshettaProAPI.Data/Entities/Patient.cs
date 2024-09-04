using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Data.Entities;

public class Patient
{
    public int PatientID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? ImageURL { get; set; }
    public string Address { get; set; }

    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    

    
    // Use enums for Gender and BloodType
    public Gender Gender { get; set; }
    public BloodType BloodType { get; set; }


    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }

    public ICollection<MedicalHistory> MedicalHistories { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<PatientXray> PatientXrays { get; set; }
}