using FluentValidation;
namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Delete;

public class DeleteMedicationValidator : AbstractValidator<DeleteMedicationCommand>
{
    public DeleteMedicationValidator()
    {
        RuleFor(x => x.MedicationID)
            .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");
    }
}