using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetAll;

public class GetAllMedicalHistoryQuery : IRequest<ApiResponse<IEnumerable<MedicalHistoryResponse>>>
{
}
