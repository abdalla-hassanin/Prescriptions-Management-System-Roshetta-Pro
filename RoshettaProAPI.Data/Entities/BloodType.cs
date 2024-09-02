namespace RoshettaProAPI.Data.Entities;

public class BloodType
{
    public int BloodTypeID { get; set; }
    public string BloodTypeName { get; set; }

    public ICollection<Patient> Patients { get; set; }
}