using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Update
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, ApiResponse<PatientResponse>>
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdatePatientHandler(IPatientService patientService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _patientService = patientService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<PatientResponse>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing patient entity
            var patient = await _patientService.GetByIdAsync(request.PatientID, cancellationToken);
            if (patient == null)
            {
                return _responseHandler.NotFound<PatientResponse>("patient not found.");
            }

            // Map the updated values from the request to the existing patient entity
            _mapper.Map(request, patient);
            
            // Save the updated patient entity
            await _patientService.UpdateAsync(patient, cancellationToken);

            var patientResponse = _mapper.Map<PatientResponse>(patient);
            
            return _responseHandler.Success(patientResponse, "patient updated successfully.");
        }
    }
}