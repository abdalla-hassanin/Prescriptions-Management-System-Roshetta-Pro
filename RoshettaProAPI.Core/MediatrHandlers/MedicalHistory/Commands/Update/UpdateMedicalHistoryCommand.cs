using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory;
using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Update;

public class UpdateMedicalHistoryCommand : IRequest<ApiResponse<MedicalHistoryResponse>>
{
    public int MedicalHistoryID { get; set; }
    public int? PatientID { get; set; }
    public int? DoctorID { get; set; }
    public DateTime? VisitDate { get; set; }
    public string? Diagnosis { get; set; }
    public string? Notes { get; set; }
}
