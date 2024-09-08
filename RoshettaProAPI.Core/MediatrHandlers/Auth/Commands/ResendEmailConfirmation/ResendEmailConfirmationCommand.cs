using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResendEmailConfirmation;

public class ResendEmailConfirmationCommand : IRequest<ApiResponse<string>>
{
    public string Email { get; set; }
}

