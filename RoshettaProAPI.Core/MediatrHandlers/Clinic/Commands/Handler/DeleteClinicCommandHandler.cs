using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.Handler
{
    public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand, ApiResponse<ClinicResponseDto>>
    {
        private readonly IClinicService _clinicService;
        private readonly ApiResponseHandler _responseHandler;

        public DeleteClinicCommandHandler(IClinicService clinicService, ApiResponseHandler responseHandler)
        {
            _clinicService = clinicService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<ClinicResponseDto>> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicService.GetByIdAsync(request.ClinicID, cancellationToken);
            if (clinic == null)
            {
                return _responseHandler.NotFound<ClinicResponseDto>("Clinic not found.");
            }

            await _clinicService.RemoveAsync(clinic, cancellationToken);
            return _responseHandler.Deleted<ClinicResponseDto>("Clinic deleted successfully.");
        }
    }
}