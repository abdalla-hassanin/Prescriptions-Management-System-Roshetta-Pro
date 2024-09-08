using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RefreshToken;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}
