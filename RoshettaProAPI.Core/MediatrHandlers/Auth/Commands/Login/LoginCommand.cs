using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Login;

public class LoginCommand : IRequest<ApiResponse<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}