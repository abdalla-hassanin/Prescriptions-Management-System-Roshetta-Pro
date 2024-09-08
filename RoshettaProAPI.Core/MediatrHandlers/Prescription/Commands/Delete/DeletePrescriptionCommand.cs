using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Delete;

public class DeletePrescriptionCommand : IRequest<ApiResponse<PrescriptionResponse>>
{
    public int PrescriptionID { get; set; }
}

