using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Delete;

public class DeletePrescriptionCommand : IRequest<ApiResponse<PrescriptionResponse>>
{
    public int PrescriptionID { get; set; }
}

