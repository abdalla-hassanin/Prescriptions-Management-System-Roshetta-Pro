using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Validator;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number is not valid.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email format is invalid.");

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Invalid gender value.");

        RuleFor(x => x.BloodType)
            .IsInEnum().WithMessage("Invalid blood type value.");
        
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(x => x.EmergencyContactPhone)
            .Matches(@"^\+?\d{10,15}$").When(x => !string.IsNullOrEmpty(x.EmergencyContactPhone))
            .WithMessage("Emergency contact phone number is not valid.");
    }
}