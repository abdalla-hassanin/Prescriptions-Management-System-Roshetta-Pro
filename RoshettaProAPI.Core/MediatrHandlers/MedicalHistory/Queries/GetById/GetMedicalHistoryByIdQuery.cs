using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetById;

public class GetMedicalHistoryByIdQuery :IRequest<ApiResponse<MedicalHistoryResponse>>
{
    public int MedicalHistoryID { get; set; }
}
