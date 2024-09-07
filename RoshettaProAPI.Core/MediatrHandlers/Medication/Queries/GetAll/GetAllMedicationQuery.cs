using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Medication;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetAll;

public class GetAllMedicationQuery : IRequest<ApiResponse<IEnumerable<MedicationResponse>>>
{
}
