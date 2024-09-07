using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Xray;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Update;

public class UpdatePrescriptionCommand : IRequest<ApiResponse<PrescriptionResponse>>
{
    public int PrescriptionID { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string Notes { get; set; }
    public List<PrescriptionMedicationDto> PrescriptionMedications { get; set; }
}
