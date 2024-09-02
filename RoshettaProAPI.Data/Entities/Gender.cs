namespace RoshettaProAPI.Data.Entities;

public class Gender
{
    public int GenderID { get; set; }
    public string GenderName { get; set; }

    public ICollection<Patient> Patients { get; set; }
}