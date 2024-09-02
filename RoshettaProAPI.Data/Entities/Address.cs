namespace RoshettaProAPI.Data.Entities;

public class Address
{
    public int AddressID { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public ICollection<Patient> Patients { get; set; }
    public ICollection<Clinic> Clinics { get; set; }
}