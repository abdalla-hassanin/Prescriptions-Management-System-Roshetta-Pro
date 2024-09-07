using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.Handler
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery,
        ApiResponse<IEnumerable<DoctorResponse>>>
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetAllDoctorsQueryHandler(IDoctorService doctorService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<IEnumerable<DoctorResponse>>> Handle(GetAllDoctorsQuery request,
            CancellationToken cancellationToken)
        {
            var doctors = await _doctorService.GetAllAsync(cancellationToken);

            var doctorResponses = _mapper.Map<IEnumerable<DoctorResponse>>(doctors);
            return _responseHandler.Success(doctorResponses);
        }
    }
}