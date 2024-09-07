using FluentValidation;
namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Delete;

public class DeleteXrayValidator : AbstractValidator<DeleteXrayCommand>
{
    public DeleteXrayValidator()
    {
        RuleFor(x => x.XrayID)
            .GreaterThan(0).WithMessage("Xray ID must be greater than 0.");
    }
}