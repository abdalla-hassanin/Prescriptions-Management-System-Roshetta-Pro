using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Update;

public class UpdateMedicationCommandValidator : AbstractValidator<UpdateMedicationCommand>
{
    public UpdateMedicationCommandValidator()
    {
        // Ensure MedicationID is provided and greater than 0
        RuleFor(x => x.MedicationID)
            .GreaterThan(0).WithMessage("MedicationID must be greater than 0");

        // Ensure Name, if provided, is not empty and its length doesn't exceed 100 characters
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.Name));

        // Ensure Description, if provided, is not empty
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.Description));

        // Ensure SideEffects, if provided, is not empty
        RuleFor(x => x.SideEffects)
            .NotEmpty().WithMessage("SideEffects cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.SideEffects));

        // Ensure MedicationForm, if provided, is a valid enum value
        RuleFor(x => x.MedicationForm)
            .IsInEnum().WithMessage("MedicationForm must be a valid enum value")
            .When(x => x.MedicationForm.HasValue);
    }
}