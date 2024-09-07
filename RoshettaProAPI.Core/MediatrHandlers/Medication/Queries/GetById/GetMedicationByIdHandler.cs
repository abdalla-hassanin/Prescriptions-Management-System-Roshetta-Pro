using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetById
{
    public class GetMedicationByIdHandler : IRequestHandler<GetMedicationByIdQuery, ApiResponse<MedicationResponse>>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetMedicationByIdHandler(IMedicationService medicationService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicationResponse>> Handle(GetMedicationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var medication = await _medicationService.GetByIdAsync(request.MedicationID, cancellationToken);
            if (medication == null)
            {
                return _responseHandler.NotFound<MedicationResponse>("Medication not found.");
            }

            var medicationResponse = _mapper.Map<MedicationResponse>(medication);
            return _responseHandler.Success(medicationResponse);
        }
    }
}