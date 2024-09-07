using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetById;

public class GetXrayByIdValidator : AbstractValidator<GetXrayByIdQuery>
{
    public GetXrayByIdValidator()
    {
        RuleFor(x => x.XrayID)
            .GreaterThan(0).WithMessage("XrayID must be greater than zero.");
    }
}