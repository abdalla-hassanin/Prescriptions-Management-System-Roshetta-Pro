namespace RoshettaProAPI.Data.Entities;

public class MedicationForm
{
    public int MedicationFormID { get; set; }
    public string FormName { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public ICollection<Medication> Medications { get; set; }
}