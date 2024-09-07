using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Delete
{
    public class DeleteMedicalHistoryHandler : IRequestHandler<DeleteMedicalHistoryCommand, ApiResponse<MedicalHistoryResponse>>
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly ApiResponseHandler _responseHandler;

        public DeleteMedicalHistoryHandler(IMedicalHistoryService medicalHistoryService, ApiResponseHandler responseHandler)
        {
            _medicalHistoryService = medicalHistoryService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicalHistoryResponse>> Handle(DeleteMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            var medicalHistory = await _medicalHistoryService.GetByIdAsync(request.MedicalHistoryID, cancellationToken);
            if (medicalHistory == null)
            {
                return _responseHandler.NotFound<MedicalHistoryResponse>("Medication not found.");
            }

            await _medicalHistoryService.RemoveAsync(medicalHistory, cancellationToken);
            return _responseHandler.Deleted<MedicalHistoryResponse>("Medication deleted successfully.");
        }
    }
}