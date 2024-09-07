using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor;

public class DoctorResponse
{
    public int DoctorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Specialization Specialization { get; set; } 
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? ImageURL { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}