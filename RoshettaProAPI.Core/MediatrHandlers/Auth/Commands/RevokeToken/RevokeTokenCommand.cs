using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RevokeToken;

public class RevokeTokenCommand: IRequest<ApiResponse<string>>
{
    public string Token { get; set; }
}
