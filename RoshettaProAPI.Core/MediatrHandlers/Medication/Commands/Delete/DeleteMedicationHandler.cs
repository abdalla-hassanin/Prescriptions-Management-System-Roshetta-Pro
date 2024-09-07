using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Delete
{
    public class DeleteMedicationHandler : IRequestHandler<DeleteMedicationCommand, ApiResponse<MedicationResponse>>
    {
        private readonly IMedicationService _medicationService;
        private readonly ApiResponseHandler _responseHandler;

        public DeleteMedicationHandler(IMedicationService medicationService, ApiResponseHandler responseHandler)
        {
            _medicationService = medicationService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicationResponse>> Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
        {
            var medication = await _medicationService.GetByIdAsync(request.MedicationID, cancellationToken);
            if (medication == null)
            {
                return _responseHandler.NotFound<MedicationResponse>("Medication not found.");
            }

            await _medicationService.RemoveAsync(medication, cancellationToken);
            return _responseHandler.Deleted<MedicationResponse>("Medication deleted successfully.");
        }
    }
}