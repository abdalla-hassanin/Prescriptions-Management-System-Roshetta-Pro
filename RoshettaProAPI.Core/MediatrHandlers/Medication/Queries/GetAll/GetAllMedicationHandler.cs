using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetAll
{
    public class
        GetAllMedicationHandler : IRequestHandler<GetAllMedicationQuery,
        ApiResponse<IEnumerable<MedicationResponse>>>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetAllMedicationHandler(IMedicationService medicationService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<IEnumerable<MedicationResponse>>> Handle(GetAllMedicationQuery request,
            CancellationToken cancellationToken)
        {
            var medications = await _medicationService.GetAllAsync(cancellationToken);

            var medicationResponses = _mapper.Map<IEnumerable<MedicationResponse>>(medications);
            return _responseHandler.Success(medicationResponses);
        }
    }
}