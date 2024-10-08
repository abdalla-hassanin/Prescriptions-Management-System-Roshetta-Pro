using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.GetAll
{
    public class
        GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery,
        ApiResponse<IEnumerable<PatientResponse>>>
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetAllPatientsHandler(IPatientService patientService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _patientService = patientService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<IEnumerable<PatientResponse>>> Handle(GetAllPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _patientService.GetAllAsync(cancellationToken);
            
            var patientResponses = _mapper.Map<IEnumerable<PatientResponse>>(patients);
            return _responseHandler.Success(patientResponses);
        }
    }
}