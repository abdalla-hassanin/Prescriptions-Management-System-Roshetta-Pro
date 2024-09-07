using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetAll;

public class GetAllXrayQuery : IRequest<ApiResponse<IEnumerable<XrayResponse>>>
{
}
