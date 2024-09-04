using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.Validator;

public class DeleteClinicCommandValidator : AbstractValidator<DeleteClinicCommand>
{
    public DeleteClinicCommandValidator()
    {
        RuleFor(x => x.ClinicID)
            .GreaterThan(0).WithMessage("ClinicID must be greater than zero.");
    }
}
