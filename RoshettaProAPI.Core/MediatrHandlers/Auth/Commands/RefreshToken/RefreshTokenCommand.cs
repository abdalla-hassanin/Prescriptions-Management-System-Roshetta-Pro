using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RefreshToken;

public class RefreshTokenCommand: IRequest<ApiResponse<string>>
{
    public string Token { get; set; }
}
