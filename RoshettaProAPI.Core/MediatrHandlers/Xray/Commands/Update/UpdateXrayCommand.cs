using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Update;

public class UpdateXrayCommand : IRequest<ApiResponse<XrayResponse>>
{
    public int XrayID { get; set; }
    public int? PatientID { get; set; }
    public int? DoctorID { get; set; }
    public DateTime? DateTaken { get; set; }
    public string? XrayImageURL { get; set; }
    public string? LabName { get; set; }
    public string? XrayType { get; set; }
    public string? Notes { get; set; }}
