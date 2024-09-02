namespace RoshettaProAPI.Data.Entities;

public class Prescription
{
    public int PrescriptionID { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
}