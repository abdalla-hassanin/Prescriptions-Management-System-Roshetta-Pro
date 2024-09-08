using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetById
{
    public class GetPrescriptionByIdHandler : IRequestHandler<GetPrescriptionByIdQuery, ApiResponse<PrescriptionResponse>>
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetPrescriptionByIdHandler(IPrescriptionService prescriptionService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _prescriptionService = prescriptionService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PrescriptionResponse>> Handle(GetPrescriptionByIdQuery request,
            CancellationToken cancellationToken)
        {
            var prescription = await _prescriptionService.GetByIdAsync(request.PrescriptionID, cancellationToken);
            if (prescription == null)
            {
                return _responseHandler.NotFound<PrescriptionResponse>("Prescription not found.");
            }

            var prescriptionResponse = _mapper.Map<PrescriptionResponse>(prescription);
            return _responseHandler.Success(prescriptionResponse);
        }
    }
}