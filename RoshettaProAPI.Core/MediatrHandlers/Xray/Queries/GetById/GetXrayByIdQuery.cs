using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetById;

public class GetXrayByIdQuery :IRequest<ApiResponse<XrayResponse>>
{
    public int XrayID { get; set; }
}
