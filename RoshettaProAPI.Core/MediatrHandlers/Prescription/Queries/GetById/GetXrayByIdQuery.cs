using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetById;

public class GetPrescriptionByIdQuery : IRequest<ApiResponse<PrescriptionResponse>>
{
    public int PrescriptionID { get; set; }
}

