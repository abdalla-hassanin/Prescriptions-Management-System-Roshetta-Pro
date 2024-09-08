using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetAll;

public class GetAllMedicationQuery : IRequest<ApiResponse<IEnumerable<MedicationResponse>>>
{
}
