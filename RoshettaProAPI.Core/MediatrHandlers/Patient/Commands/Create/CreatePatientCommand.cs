using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Create;

public class CreatePatientCommand : IRequest<ApiResponse<PatientResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? ImageURL { get; set; }
    public string Address { get; set; }

    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }

    // Use enums for Gender and BloodType
    public Gender Gender { get; set; }
    public BloodType BloodType { get; set; }
    
    public string Password { get; set; }

}