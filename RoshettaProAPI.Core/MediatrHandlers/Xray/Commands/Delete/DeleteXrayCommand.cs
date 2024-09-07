using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Delete;

public class DeleteXrayCommand :IRequest<ApiResponse<XrayResponse>>
{
    public int XrayID { get; set; }
}