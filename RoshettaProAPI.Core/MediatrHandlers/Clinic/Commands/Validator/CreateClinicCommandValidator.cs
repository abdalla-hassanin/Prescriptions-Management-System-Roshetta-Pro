using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.Validator;

public class CreateClinicCommandValidator : AbstractValidator<CreateClinicCommand>
{
    public CreateClinicCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(2, 500).WithMessage("Address must be between 2 and 500 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("PhoneNumber must be a valid phone number.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");
    }
}
