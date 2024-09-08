using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;

public class CreatePrescriptionCommand : IRequest<ApiResponse<PrescriptionResponse>>
{
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string Notes { get; set; }
    public List<PrescriptionMedicationDto> PrescriptionMedications { get; set; }
}


public class PrescriptionMedicationDto
{
    public int MedicationID { get; set; }
    public int Dosage { get; set; }
    public string DosageUnit { get; set; }
    public string Frequency { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Instructions { get; set; }
}
