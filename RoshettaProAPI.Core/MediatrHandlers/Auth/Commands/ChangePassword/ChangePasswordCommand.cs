using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ChangePassword;

public class ChangePasswordCommand: IRequest<ApiResponse<string>>
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
