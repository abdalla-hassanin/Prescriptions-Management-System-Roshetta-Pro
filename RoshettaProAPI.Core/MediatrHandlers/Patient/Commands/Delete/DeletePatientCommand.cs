using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Delete;

public class DeletePatientCommand :IRequest<ApiResponse<PatientResponse>>
{
    public int PatientID { get; set; }
}