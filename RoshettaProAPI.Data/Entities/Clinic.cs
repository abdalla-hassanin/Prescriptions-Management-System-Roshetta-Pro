namespace RoshettaProAPI.Data.Entities;

public class Clinic
{
    public int ClinicID { get; set; }
    public string Name { get; set; }
    public int AddressID { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public Address Address { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}