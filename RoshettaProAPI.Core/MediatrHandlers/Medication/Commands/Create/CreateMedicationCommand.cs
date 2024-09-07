using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Create;

public class CreateMedicationCommand : IRequest<ApiResponse<MedicationResponse>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string SideEffects { get; set; }
    public MedicationForm MedicationForm { get; set; }
}