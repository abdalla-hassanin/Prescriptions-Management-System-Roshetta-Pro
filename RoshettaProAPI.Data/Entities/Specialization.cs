namespace RoshettaProAPI.Data.Entities;

public class Specialization
{
    public int SpecializationID { get; set; }
    public string SpecializationName { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public ICollection<Doctor> Doctors { get; set; }
}