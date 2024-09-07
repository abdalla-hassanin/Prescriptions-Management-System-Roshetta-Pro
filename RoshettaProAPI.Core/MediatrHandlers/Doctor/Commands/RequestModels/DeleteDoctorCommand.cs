using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;

public class DeleteDoctorCommand :IRequest<ApiResponse<DoctorResponse>>
{
    public int DoctorID { get; set; }
}