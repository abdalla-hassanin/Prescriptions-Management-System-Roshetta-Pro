using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetAll
{
    public class
        GetAllPrescriptionHandler : IRequestHandler<GetAllPrescriptionQuery,
        ApiResponse<IEnumerable<PrescriptionResponse>>>
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetAllPrescriptionHandler(IPrescriptionService prescriptionService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _prescriptionService = prescriptionService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<IEnumerable<PrescriptionResponse>>> Handle(GetAllPrescriptionQuery request,
            CancellationToken cancellationToken)
        {
            var prescriptions = await _prescriptionService.GetAllAsync(cancellationToken);

            var prescriptionResponses = _mapper.Map<IEnumerable<PrescriptionResponse>>(prescriptions);
            return _responseHandler.Success(prescriptionResponses);
        }
    }
}