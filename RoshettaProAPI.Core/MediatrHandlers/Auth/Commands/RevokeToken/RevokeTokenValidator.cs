using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RefreshToken;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RevokeToken;

public class RevokeTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RevokeTokenValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}
