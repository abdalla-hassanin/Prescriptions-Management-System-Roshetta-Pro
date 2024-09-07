using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.Handler
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, ApiResponse<DoctorResponse>>
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetDoctorByIdQueryHandler(IDoctorService doctorService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<DoctorResponse>> Handle(GetDoctorByIdQuery request,
            CancellationToken cancellationToken)
        {
            var doctor = await _doctorService.GetByIdAsync(request.DoctorID, cancellationToken);
            if (doctor == null)
            {
                return _responseHandler.NotFound<DoctorResponse>("Doctor not found.");
            }

            var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
            return _responseHandler.Success(doctorResponse);
        }
    }
}