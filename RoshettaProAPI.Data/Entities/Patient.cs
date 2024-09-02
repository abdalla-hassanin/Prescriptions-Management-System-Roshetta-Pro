namespace RoshettaProAPI.Data.Entities;

public class Patient
{
    public int PatientID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderID { get; set; }
    public int AddressID { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int? EmergencyContactID { get; set; }
    public int? BloodTypeID { get; set; }
    public string? ImageURL { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public Contact EmergencyContact { get; set; }
    public BloodType BloodType { get; set; }
    public ICollection<MedicalHistory> MedicalHistories { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<PatientXray> PatientXrays { get; set; }
}