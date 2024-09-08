using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.GetById;

public class GetPatientByIdValidator : AbstractValidator<GetPatientByIdQuery>
{
    public GetPatientByIdValidator()
    {
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than zero.");
    }
}
