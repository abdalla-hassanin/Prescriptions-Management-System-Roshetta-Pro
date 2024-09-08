using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResendEmailConfirmation;

public class ResendEmailConfirmationValidator : AbstractValidator<ResendEmailConfirmationCommand>
{
    public ResendEmailConfirmationValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
