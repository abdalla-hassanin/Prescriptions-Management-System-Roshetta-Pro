using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Delete;

public class DeleteMedicalHistoryCommand :IRequest<ApiResponse<MedicalHistoryResponse>>
{
    public int MedicalHistoryID { get; set; }
}