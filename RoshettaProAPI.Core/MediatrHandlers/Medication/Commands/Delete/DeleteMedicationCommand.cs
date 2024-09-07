using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Delete;

public class DeleteMedicationCommand :IRequest<ApiResponse<MedicationResponse>>
{
    public int MedicationID { get; set; }
}