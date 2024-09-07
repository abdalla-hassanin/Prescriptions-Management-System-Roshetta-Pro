using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Delete;

public class DeletePrescriptionValidator : AbstractValidator<DeletePrescriptionCommand>
{
    public DeletePrescriptionValidator()
    {
        RuleFor(x => x.PrescriptionID)
            .GreaterThan(0).WithMessage("Prescription ID must be greater than 0.");
    }
}