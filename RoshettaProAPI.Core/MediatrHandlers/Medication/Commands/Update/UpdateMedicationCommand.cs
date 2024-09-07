using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Update;

public class UpdateMedicationCommand : IRequest<ApiResponse<MedicationResponse>>
{
    public int MedicationID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? SideEffects { get; set; }
    public MedicationForm? MedicationForm { get; set; }
    
}
