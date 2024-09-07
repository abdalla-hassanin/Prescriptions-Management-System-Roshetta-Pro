using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetById;

public class GetMedicalHistoryByIdValidator : AbstractValidator<GetMedicalHistoryByIdQuery>
{
    public GetMedicalHistoryByIdValidator()
    {
        RuleFor(x => x.MedicalHistoryID)
            .GreaterThan(0).WithMessage("MedicalHistoryID must be greater than zero.");
    }
}
