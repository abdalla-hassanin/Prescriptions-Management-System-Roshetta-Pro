using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Update
{
    public class UpdateMedicalHistoryHandler : IRequestHandler<UpdateMedicalHistoryCommand, ApiResponse<MedicalHistoryResponse>>
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdateMedicalHistoryHandler(IMedicalHistoryService medicalHistoryService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _medicalHistoryService = medicalHistoryService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicalHistoryResponse>> Handle(UpdateMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing medicalHistory entity
            var medicalHistory = await _medicalHistoryService.GetByIdAsync(request.MedicalHistoryID, cancellationToken);
            if (medicalHistory == null)
            {
                return _responseHandler.NotFound<MedicalHistoryResponse>("Medication not found.");
            }

            // Map the updated values from the request to the existing medicalHistory entity
            _mapper.Map(request, medicalHistory);
            
            // Save the updated medicalHistory entity
            await _medicalHistoryService.UpdateAsync(medicalHistory, cancellationToken);

            var medicalHistoryResponse = _mapper.Map<MedicalHistoryResponse>(medicalHistory);
            
            return _responseHandler.Success(medicalHistoryResponse, "Medication updated successfully.");
        }
    }
}