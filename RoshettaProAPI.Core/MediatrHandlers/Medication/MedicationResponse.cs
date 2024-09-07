using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication;

public class MedicationResponse
{
    public int MedicationID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SideEffects { get; set; }
    public MedicationForm MedicationForm { get; set; } 
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}