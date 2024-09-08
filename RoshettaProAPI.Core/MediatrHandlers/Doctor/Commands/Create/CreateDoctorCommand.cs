using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Create;

public class CreateDoctorCommand : IRequest<ApiResponse<DoctorResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Specialization Specialization { get; set; } 
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? ImageURL { get; set; }
    public string Password { get; set; }
    
}