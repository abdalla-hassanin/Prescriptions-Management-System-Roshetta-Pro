using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.GetById;

public class GetDoctorByIdQuery :IRequest<ApiResponse<DoctorResponse>>
{
    public int DoctorID { get; set; }
}
