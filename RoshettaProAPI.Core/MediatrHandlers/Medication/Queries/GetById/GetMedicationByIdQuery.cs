using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetById;

public class GetMedicationByIdQuery :IRequest<ApiResponse<MedicationResponse>>
{
    public int MedicationID { get; set; }
}
