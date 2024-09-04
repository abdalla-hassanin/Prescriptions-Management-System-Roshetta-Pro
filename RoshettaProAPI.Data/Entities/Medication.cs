using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Data.Entities;

public class Medication
{
    public int MedicationID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SideEffects { get; set; }
    public MedicationForm MedicationForm { get; set; } 
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }

    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
}