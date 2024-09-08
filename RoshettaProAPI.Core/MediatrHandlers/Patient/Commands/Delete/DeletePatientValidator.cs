using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Delete;

public class DeletePatientValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientValidator()
    {
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");
    }
}