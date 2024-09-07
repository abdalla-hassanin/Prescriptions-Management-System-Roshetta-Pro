using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Update;

public class UpdatePrescriptionCommandValidator : AbstractValidator<UpdatePrescriptionCommand>
{
    public UpdatePrescriptionCommandValidator()
    {
        // Ensure PrescriptionID is provided and greater than 0
        RuleFor(x => x.PrescriptionID)
            .GreaterThan(0).WithMessage("PrescriptionID must be greater than 0");

        // Ensure PatientID is greater than 0 if provided
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than 0")
            .When(x => x.PatientID > 0);

        // Ensure DoctorID is greater than 0 if provided
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than 0")
            .When(x => x.DoctorID > 0);

        // Ensure DateIssued is not empty and valid
        RuleFor(x => x.DateIssued)
            .NotEmpty().WithMessage("DateIssued is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("DateIssued cannot be in the future");

        // Ensure ExpirationDate is after DateIssued if provided
        RuleFor(x => x.ExpirationDate)
            .GreaterThanOrEqualTo(x => x.DateIssued)
            .When(x => x.ExpirationDate.HasValue)
            .WithMessage("Expiration Date must be after Date Issued.");

        // Ensure Notes are not empty if provided
        RuleFor(x => x.Notes)
            .NotEmpty().WithMessage("Notes cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.Notes));

        // Validate each PrescriptionMedication if provided
        RuleForEach(x => x.PrescriptionMedications)
            .SetValidator(new PrescriptionMedicationDtoValidator())
            .When(x => x.PrescriptionMedications != null && x.PrescriptionMedications.Any());
    }
}

public class PrescriptionMedicationDtoValidator : AbstractValidator<PrescriptionMedicationDto>
{
    public PrescriptionMedicationDtoValidator()
    {
        RuleFor(x => x.MedicationID)
            .GreaterThan(0).WithMessage("MedicationID must be greater than 0");

        RuleFor(x => x.Dosage)
            .GreaterThan(0).WithMessage("Dosage must be greater than 0");

        RuleFor(x => x.DosageUnit)
            .NotEmpty().WithMessage("Dosage Unit is required");

        RuleFor(x => x.Frequency)
            .NotEmpty().WithMessage("Frequency is required");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start Date is required");

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage("End Date must be after Start Date");

        RuleFor(x => x.Instructions)
            .MaximumLength(1000).WithMessage("Instructions should not exceed 1000 characters")
            .When(x => !string.IsNullOrEmpty(x.Instructions));
    }
}
