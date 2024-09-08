using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.GetAll;

public class GetAllDoctorsQuery : IRequest<ApiResponse<IEnumerable<DoctorResponse>>>
{
}
