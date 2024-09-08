using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetAll;

public class GetAllXrayQuery : IRequest<ApiResponse<IEnumerable<XrayResponse>>>
{
}
