using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.Validator;

public class UpdateClinicCommandValidator : AbstractValidator<UpdateClinicCommand>
{
    public UpdateClinicCommandValidator()
    {
        RuleFor(x => x.ClinicID)
            .GreaterThan(0).WithMessage("ClinicID must be greater than zero.");

        RuleFor(x => x.Name)
            .MaximumLength(100).WithMessage("Name must be between 2 and 100 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Name)); // Only validate if provided

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Address must be between 2 and 500 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Address)); // Only validate if provided


        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage("PhoneNumber must be a valid phone number.")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber)); // Only validate if not empty

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email must be a valid email address.")
            .When(x => !string.IsNullOrEmpty(x.Email)); // Only validate if not empty
    }
}
