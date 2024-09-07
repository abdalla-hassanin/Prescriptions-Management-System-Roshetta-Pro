using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Delete;

public class DeleteMedicalHistoryValidator : AbstractValidator<DeleteMedicalHistoryCommand>
{
    public DeleteMedicalHistoryValidator()
    {
        RuleFor(x => x.MedicalHistoryID)
            .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");
    }
}