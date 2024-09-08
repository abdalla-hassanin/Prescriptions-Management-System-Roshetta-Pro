using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.GetAll;

public class GetAllPatientsQuery : IRequest<ApiResponse<IEnumerable<PatientResponse>>>
{
}
