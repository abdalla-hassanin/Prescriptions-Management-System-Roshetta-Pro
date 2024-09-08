using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetAll;

public class GetAllPrescriptionQuery : IRequest<ApiResponse<IEnumerable<PrescriptionResponse>>> { }
