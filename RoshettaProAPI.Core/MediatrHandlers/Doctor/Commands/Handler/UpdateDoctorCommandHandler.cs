using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Handler
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, ApiResponse<DoctorResponse>>
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdateDoctorCommandHandler(IDoctorService doctorService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<DoctorResponse>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing doctor entity
            var doctor = await _doctorService.GetByIdAsync(request.DoctorID, cancellationToken);
            if (doctor == null)
            {
                return _responseHandler.NotFound<DoctorResponse>("Doctor not found.");
            }

            // Map the updated values from the request to the existing doctor entity
            _mapper.Map(request, doctor);
            
            // Save the updated doctor entity
            await _doctorService.UpdateAsync(doctor, cancellationToken);

            var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
            
            return _responseHandler.Success(doctorResponse, "Doctor updated successfully.");
        }
    }
}