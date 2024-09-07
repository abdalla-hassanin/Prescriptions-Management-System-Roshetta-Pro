using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetById;

public class GetMedicationByIdValidator : AbstractValidator<GetMedicationByIdQuery>
{
    public GetMedicationByIdValidator()
    {
        RuleFor(x => x.MedicationID)
            .GreaterThan(0).WithMessage("MedicationID must be greater than zero.");
    }
}