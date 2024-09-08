using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Update;

public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientValidator()
    {
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");

        RuleFor(x => x.FirstName)
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.FirstName));

        RuleFor(x => x.LastName)
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.")
            .When(x => !string.IsNullOrEmpty(x.LastName));

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.")
            .When(x => x.DateOfBirth.HasValue);

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number is not valid.")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email format is invalid.")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Invalid gender value.")
            .When(x => x.Gender.HasValue);

        RuleFor(x => x.BloodType)
            .IsInEnum().WithMessage("Invalid blood type value.")
            .When(x => x.BloodType.HasValue);

        RuleFor(x => x.EmergencyContactPhone)
            .Matches(@"^\+?\d{10,15}$").WithMessage("Emergency contact phone number is not valid.")
            .When(x => !string.IsNullOrEmpty(x.EmergencyContactPhone));
    }
}