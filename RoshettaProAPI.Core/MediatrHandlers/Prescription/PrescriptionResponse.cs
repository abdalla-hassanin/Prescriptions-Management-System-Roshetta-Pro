namespace RoshettaProAPI.Core.MediatrHandlers.Prescription;

public class PrescriptionResponse
{
    public int PrescriptionID { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public List<PrescriptionMedicationResponse> PrescriptionMedications { get; set; }
}

public class PrescriptionMedicationResponse
{
    public int PrescriptionMedicationID { get; set; }
    public int PrescriptionID { get; set; }
    public int MedicationID { get; set; }
    public int Dosage { get; set; }
    public string DosageUnit { get; set; }
    public string Frequency { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Instructions { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}