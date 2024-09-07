using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.RequestModels;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Handler
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, ApiResponse<PatientResponse>>
    {
        private readonly IPatientService _patientService;
        private readonly ApiResponseHandler _responseHandler;

        public DeletePatientCommandHandler(IPatientService patientService, ApiResponseHandler responseHandler)
        {
            _patientService = patientService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PatientResponse>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetByIdAsync(request.PatientID, cancellationToken);
            if (patient == null)
            {
                return _responseHandler.NotFound<PatientResponse>("Medication not found.");
            }

            await _patientService.RemoveAsync(patient, cancellationToken);
            return _responseHandler.Deleted<PatientResponse>("Medication deleted successfully.");
        }
    }
}