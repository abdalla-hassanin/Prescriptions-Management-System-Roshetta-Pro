using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.Handler
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, ApiResponse<PatientResponse>>
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetPatientByIdQueryHandler(IPatientService patientService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _patientService = patientService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PatientResponse>> Handle(GetPatientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetByIdAsync(request.PatientID, cancellationToken);
            if (patient == null)
            {
                return _responseHandler.NotFound<PatientResponse>("Medication not found.");
            }

            var patientResponse = _mapper.Map<PatientResponse>(patient);
            return _responseHandler.Success(patientResponse);
        }
    }
}