using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Handler
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, ApiResponse<PatientResponse>>
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public CreatePatientCommandHandler(IPatientService patientService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _patientService = patientService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PatientResponse>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Data.Entities.Patient>(request);

            await _patientService.AddAsync(patient, cancellationToken);

            var patientResponse = _mapper.Map<PatientResponse>(patient);
            return _responseHandler.Created(patientResponse);
        }
    }
}