namespace RoshettaProAPI.Data.Entities;

public class Doctor
{
    public int DoctorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SpecializationID { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int ClinicID { get; set; }
    public string? ImageURL { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public Specialization Specialization { get; set; }
    public Clinic Clinic { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<MedicalHistory> MedicalHistories { get; set; }
    public ICollection<PatientXray> PatientXrays { get; set; }
}