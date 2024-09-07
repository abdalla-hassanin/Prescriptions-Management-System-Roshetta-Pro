using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Handler
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, ApiResponse<DoctorResponse>>
    {
        private readonly IDoctorService _doctorService;
        private readonly ApiResponseHandler _responseHandler;

        public DeleteDoctorCommandHandler(IDoctorService doctorService, ApiResponseHandler responseHandler)
        {
            _doctorService = doctorService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<DoctorResponse>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorService.GetByIdAsync(request.DoctorID, cancellationToken);
            if (doctor == null)
            {
                return _responseHandler.NotFound<DoctorResponse>("Doctor not found.");
            }

            await _doctorService.RemoveAsync(doctor, cancellationToken);
            return _responseHandler.Deleted<DoctorResponse>("Doctor deleted successfully.");
        }
    }
}