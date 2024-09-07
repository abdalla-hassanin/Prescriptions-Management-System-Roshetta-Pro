using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Update
{
    public class UpdateMedicationHandler : IRequestHandler<UpdateMedicationCommand, ApiResponse<MedicationResponse>>
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdateMedicationHandler(IMedicationService medicationService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _medicationService = medicationService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicationResponse>> Handle(UpdateMedicationCommand request,
            CancellationToken cancellationToken)
        {
            // Retrieve the existing medication entity
            var medication = await _medicationService.GetByIdAsync(request.MedicationID, cancellationToken);
            if (medication == null)
            {
                return _responseHandler.NotFound<MedicationResponse>("Medication not found.");
            }

            // Map the updated values from the request to the existing medication entity
            _mapper.Map(request, medication);

            // Save the updated medication entity
            await _medicationService.UpdateAsync(medication, cancellationToken);

            var medicationResponse = _mapper.Map<MedicationResponse>(medication);

            return _responseHandler.Success(medicationResponse, "Medication updated successfully.");
        }
    }
}