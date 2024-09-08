using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<ApiResponse<string>>
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
}
