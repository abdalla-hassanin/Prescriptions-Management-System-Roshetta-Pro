using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.GetById;

public class GetDoctorByIdValidator : AbstractValidator<GetDoctorByIdQuery>
{
    public GetDoctorByIdValidator()
    {
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than zero.");
    }
}
