namespace RoshettaProAPI.Data.Entities;

public class Contact
{
    public int ContactID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Relationship { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }

    public ICollection<Patient> EmergencyPatients { get; set; }
}