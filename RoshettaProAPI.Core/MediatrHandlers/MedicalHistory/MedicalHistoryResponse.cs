using RoshettaProAPI.Data.Enums;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory;

public class MedicalHistoryResponse
{
    public int MedicalHistoryID { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime VisitDate { get; set; }
    public string Diagnosis { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}