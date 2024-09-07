using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Update
{
    public class UpdatePrescriptionHandler : IRequestHandler<UpdatePrescriptionCommand, ApiResponse<PrescriptionResponse>>
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdatePrescriptionHandler(IPrescriptionService prescriptionService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _prescriptionService = prescriptionService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PrescriptionResponse>> Handle(UpdatePrescriptionCommand request,
            CancellationToken cancellationToken)
        {
            // Retrieve the existing prescription entity
            var prescription = await _prescriptionService.GetByIdAsync(request.PrescriptionID, cancellationToken);
            if (prescription == null)
            {
                return _responseHandler.NotFound<PrescriptionResponse>("Prescription not found.");
            }

            // Map the updated values from the request to the existing prescription entity
            _mapper.Map(request, prescription);

            // Save the updated prescription entity
            await _prescriptionService.UpdateAsync(prescription, cancellationToken);

            var prescriptionResponse = _mapper.Map<PrescriptionResponse>(prescription);

            return _responseHandler.Success(prescriptionResponse, "Prescription updated successfully.");
        }
    }
}