using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Validator;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number is not valid.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email format is invalid.");

        RuleFor(x => x.Specialization)
            .IsInEnum().WithMessage("Invalid specialization value.");


        RuleFor(x => x.ImageURL)
            .MaximumLength(500).WithMessage("Image URL cannot exceed 500 characters.")
            .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _)).WithMessage("Image URL is not valid.")
            .Must(x => x.StartsWith("https://") || x.StartsWith("http://"))
            .WithMessage("Image URL must start with 'https://' or 'http://'")
            .Must(x => x.EndsWith(".jpg") || x.EndsWith(".png") || x.EndsWith(".jpeg"))
            .WithMessage("Image URL must end with '.jpg', '.png' or '.jpeg'");

    }
}