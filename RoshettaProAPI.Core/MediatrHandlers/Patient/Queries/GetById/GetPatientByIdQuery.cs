using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.GetById;

public class GetPatientByIdQuery :IRequest<ApiResponse<PatientResponse>>
{
    public int PatientID { get; set; }
}
