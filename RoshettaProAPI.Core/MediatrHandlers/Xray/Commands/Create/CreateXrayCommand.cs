using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Create;

public class CreateXrayCommand : IRequest<ApiResponse<XrayResponse>>
{
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime DateTaken { get; set; }
    public string XrayImageURL { get; set; }
    public string LabName { get; set; }
    public string XrayType { get; set; }
    public string Notes { get; set; }}