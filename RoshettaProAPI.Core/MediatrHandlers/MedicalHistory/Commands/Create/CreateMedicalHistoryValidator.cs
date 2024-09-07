using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Create;

public class CreateMedicalHistoryCommandValidator : AbstractValidator<CreateMedicalHistoryCommand>
{
    public CreateMedicalHistoryCommandValidator()
    {
        // Ensure PatientID is provided and greater than 0
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than 0");

        // Ensure DoctorID is provided and greater than 0
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than 0");

        // Ensure VisitDate is provided and a valid date
        RuleFor(x => x.VisitDate)
            .NotEmpty().WithMessage("VisitDate is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("VisitDate cannot be in the future");

        // Ensure Diagnosis is provided and not empty
        RuleFor(x => x.Diagnosis)
            .NotEmpty().WithMessage("Diagnosis is required");

        // Ensure Notes are provided and not empty
        RuleFor(x => x.Notes)
            .NotEmpty().WithMessage("Notes are required");
    }
}