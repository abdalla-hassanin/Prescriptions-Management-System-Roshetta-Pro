using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ForgetPassword;

public class ForgetPasswordCommand : IRequest<ApiResponse<string>>
{
    public string Email { get; set; }
}