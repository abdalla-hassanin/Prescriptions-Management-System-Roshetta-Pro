using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Delete
{
    public class DeletePrescriptionHandler : IRequestHandler<DeletePrescriptionCommand, ApiResponse<PrescriptionResponse>>
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly ApiResponseHandler _responseHandler;

        public DeletePrescriptionHandler(IPrescriptionService prescriptionService, ApiResponseHandler responseHandler)
        {
            _prescriptionService = prescriptionService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PrescriptionResponse>> Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var prescription = await _prescriptionService.GetByIdAsync(request.PrescriptionID, cancellationToken);
            if (prescription == null)
            {
                return _responseHandler.NotFound<PrescriptionResponse>("Prescription not found.");
            }

            await _prescriptionService.RemoveAsync(prescription, cancellationToken);
            return _responseHandler.Deleted<PrescriptionResponse>("Prescription deleted successfully.");
        }
    }
}