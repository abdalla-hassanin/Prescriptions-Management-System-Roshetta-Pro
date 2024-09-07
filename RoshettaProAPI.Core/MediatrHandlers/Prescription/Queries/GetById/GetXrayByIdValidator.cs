using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetById;

public class GetPrescriptionByIdValidator : AbstractValidator<GetPrescriptionByIdQuery>
{
    public GetPrescriptionByIdValidator()
    {
        RuleFor(x => x.PrescriptionID)
            .GreaterThan(0).WithMessage("PrescriptionID must be greater than zero.");
    }
}