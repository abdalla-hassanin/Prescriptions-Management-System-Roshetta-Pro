using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Create;

public class CreateMedicalHistoryCommand : IRequest<ApiResponse<MedicalHistoryResponse>>
{
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime VisitDate { get; set; }
    public string Diagnosis { get; set; }
    public string Notes { get; set; }
}