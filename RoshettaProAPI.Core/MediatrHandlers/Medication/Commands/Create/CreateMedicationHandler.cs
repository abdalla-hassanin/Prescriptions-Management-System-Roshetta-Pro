using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Create
{
    public class CreateMedicationHandler : IRequestHandler<CreateMedicationCommand, ApiResponse<MedicationResponse>>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public CreateMedicationHandler(IMedicationService medicationService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicationResponse>> Handle(CreateMedicationCommand request,
            CancellationToken cancellationToken)
        {
            var medication = _mapper.Map<Data.Entities.Medication>(request);

            await _medicationService.AddAsync(medication, cancellationToken);

            var medicationResponse = _mapper.Map<MedicationResponse>(medication);
            return _responseHandler.Created(medicationResponse);
        }
    }
}