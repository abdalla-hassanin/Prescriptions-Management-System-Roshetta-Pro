namespace RoshettaProAPI.Data.Entities;

public class Medication
{
    public int MedicationID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SideEffects { get; set; }
    public int? MedicationFormID { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public MedicationForm MedicationForm { get; set; }
    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
}