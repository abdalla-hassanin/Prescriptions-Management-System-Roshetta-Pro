using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.Validator;

public class GetDoctorByIdQueryValidator : AbstractValidator<GetDoctorByIdQuery>
{
    public GetDoctorByIdQueryValidator()
    {
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than zero.");
    }
}
