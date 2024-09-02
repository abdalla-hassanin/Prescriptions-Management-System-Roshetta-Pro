namespace RoshettaProAPI.Data.Entities;

public class PatientXray
{
    public int XrayID { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime DateTaken { get; set; }
    public string XrayImageURL { get; set; }
    public string LabName { get; set; }
    public string XrayType { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }

    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}