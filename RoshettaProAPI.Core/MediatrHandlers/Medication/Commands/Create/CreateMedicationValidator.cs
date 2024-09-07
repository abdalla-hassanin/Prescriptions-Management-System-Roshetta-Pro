using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Create;

public class CreateMedicationCommandValidator : AbstractValidator<CreateMedicationCommand>
{
    public CreateMedicationCommandValidator()
    {

        // Ensure Name is not empty
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

        // Ensure Description is not empty
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required");

        // Ensure SideEffects is not empty
        RuleFor(x => x.SideEffects)
            .NotEmpty().WithMessage("SideEffects is required");

        // Ensure MedicationForm is a valid enum value
        RuleFor(x => x.MedicationForm)
            .IsInEnum().WithMessage("MedicationForm must be a valid enum value");
    }
}