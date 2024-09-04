using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Validator;

public class GetClinicByIdQueryValidator : AbstractValidator<GetClinicByIdQuery>
{
    public GetClinicByIdQueryValidator()
    {
        RuleFor(x => x.ClinicID)
            .GreaterThan(0).WithMessage("ClinicID must be greater than zero.");
    }
}
