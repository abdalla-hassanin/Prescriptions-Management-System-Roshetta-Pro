using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetAll;

public class GetAllPrescriptionQuery : IRequest<ApiResponse<IEnumerable<PrescriptionResponse>>> { }
