using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Logout;

public class LogoutCommand: IRequest<ApiResponse<string>>
{
}
