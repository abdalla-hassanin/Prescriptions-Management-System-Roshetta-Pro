using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Handler
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, ApiResponse<DoctorResponse>>
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public CreateDoctorCommandHandler(IDoctorService doctorService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<DoctorResponse>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Data.Entities.Doctor>(request);

            await _doctorService.AddAsync(doctor, cancellationToken);

            var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
            return _responseHandler.Created(doctorResponse);
        }
    }
}