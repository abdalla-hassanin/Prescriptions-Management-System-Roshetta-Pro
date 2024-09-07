using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.Validator;

public class GetPatientByIdQueryValidator : AbstractValidator<GetPatientByIdQuery>
{
    public GetPatientByIdQueryValidator()
    {
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than zero.");
    }
}
