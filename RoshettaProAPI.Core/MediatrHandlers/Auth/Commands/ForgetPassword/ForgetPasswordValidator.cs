using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ForgetPassword;

public class ForgetPasswordValidator: AbstractValidator<ForgetPasswordCommand>
{
    public ForgetPasswordValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}