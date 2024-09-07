using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Update;

public class UpdateXrayCommandValidator : AbstractValidator<UpdateXrayCommand>
{
    public UpdateXrayCommandValidator()
    {
        // Ensure XrayID is provided and greater than 0
        RuleFor(x => x.XrayID)
            .GreaterThan(0).WithMessage("XrayID must be greater than 0");

        // Ensure PatientID is greater than 0 if provided
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than 0")
            .When(x => x.PatientID.HasValue);

        // Ensure DoctorID is greater than 0 if provided
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than 0")
            .When(x => x.DoctorID.HasValue);

        // Ensure DateTaken is valid if provided
        RuleFor(x => x.DateTaken)
            .NotEmpty().WithMessage("DateTaken cannot be empty")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("DateTaken cannot be in the future")
            .When(x => x.DateTaken.HasValue);

        // Ensure XrayImageURL is a valid URL if provided
        RuleFor(x => x.XrayImageURL)
            .NotEmpty().WithMessage("XrayImageURL cannot be empty")
            .Must(BeAValidUrl).WithMessage("XrayImageURL must be a valid URL")
            .When(x => !string.IsNullOrEmpty(x.XrayImageURL));

        // Ensure LabName is not empty if provided
        RuleFor(x => x.LabName)
            .NotEmpty().WithMessage("LabName cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.LabName));

        // Ensure XrayType is not empty if provided
        RuleFor(x => x.XrayType)
            .NotEmpty().WithMessage("XrayType cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.XrayType));

        // Ensure Notes are not empty if provided
        RuleFor(x => x.Notes)
            .NotEmpty().WithMessage("Notes cannot be empty")
            .When(x => !string.IsNullOrEmpty(x.Notes));
    }

    // Custom method to validate URL format
    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}