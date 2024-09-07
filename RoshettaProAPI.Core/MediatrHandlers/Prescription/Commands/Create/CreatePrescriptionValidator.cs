using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;

public class CreatePrescriptionCommandValidator : AbstractValidator<CreatePrescriptionCommand>
{
    public CreatePrescriptionCommandValidator()
    {
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");

        RuleFor(x => x.DateIssued)
            .NotEmpty().WithMessage("Date Issued is required.");

        RuleFor(x => x.ExpirationDate)
            .GreaterThanOrEqualTo(x => x.DateIssued)
            .When(x => x.ExpirationDate.HasValue)
            .WithMessage("Expiration Date must be after Date Issued.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes should not exceed 500 characters.");

        RuleForEach(x => x.PrescriptionMedications)
            .SetValidator(new PrescriptionMedicationDtoValidator());
    }
}

public class PrescriptionMedicationDtoValidator : AbstractValidator<PrescriptionMedicationDto>
{
    public PrescriptionMedicationDtoValidator()
    {
        RuleFor(x => x.MedicationID)
            .GreaterThan(0).WithMessage("Medication ID must be greater than 0.");

        RuleFor(x => x.Dosage)
            .GreaterThan(0).WithMessage("Dosage must be greater than 0.");

        RuleFor(x => x.DosageUnit)
            .NotEmpty().WithMessage("Dosage Unit is required.");

        RuleFor(x => x.Frequency)
            .NotEmpty().WithMessage("Frequency is required.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start Date is required.");

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage("End Date must be after Start Date.");

        RuleFor(x => x.Instructions)
            .MaximumLength(1000).WithMessage("Instructions should not exceed 1000 characters.");
    }
}