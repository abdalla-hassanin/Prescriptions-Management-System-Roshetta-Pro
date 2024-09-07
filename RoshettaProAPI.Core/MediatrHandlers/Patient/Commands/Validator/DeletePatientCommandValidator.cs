using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Validator;

public class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");
    }
}