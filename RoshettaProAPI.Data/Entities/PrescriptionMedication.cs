namespace RoshettaProAPI.Data.Entities;

public class PrescriptionMedication
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
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public Prescription Prescription { get; set; }
    public Medication Medication { get; set; }
}