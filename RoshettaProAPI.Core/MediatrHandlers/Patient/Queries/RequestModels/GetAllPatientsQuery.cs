using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.RequestModels;

public class GetAllPatientsQuery : IRequest<ApiResponse<IEnumerable<PatientResponse>>>
{
}
