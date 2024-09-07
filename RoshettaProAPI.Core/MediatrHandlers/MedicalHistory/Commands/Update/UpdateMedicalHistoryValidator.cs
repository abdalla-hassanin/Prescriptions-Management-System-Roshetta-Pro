using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Update;

public class UpdateMedicalHistoryValidator : AbstractValidator<UpdateMedicalHistoryCommand>
{
    public UpdateMedicalHistoryValidator()
    {
        // Ensure MedicalHistoryID is provided
        RuleFor(x => x.MedicalHistoryID)
            .GreaterThan(0).WithMessage("MedicalHistoryID must be greater than 0");
        // Ensure PatientID is valid if provided
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than 0")
            .When(x => x.PatientID.HasValue);

        // Ensure DoctorID is valid if provided
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than 0")
            .When(x => x.DoctorID.HasValue);
        // Ensure that if Diagnosis is provided, it isn't empty or null
        RuleFor(x => x.Diagnosis)
            .NotEmpty().WithMessage("Diagnosis cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.Diagnosis));

        // Ensure that Notes, if provided, are not empty
        RuleFor(x => x.Notes)
            .NotEmpty().WithMessage("Notes cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.Notes));

        // Validate VisitDate if provided
        RuleFor(x => x.VisitDate)
            .NotEmpty().WithMessage("VisitDate cannot be empty")
            .When(x => x.VisitDate.HasValue);

       
    }
}
