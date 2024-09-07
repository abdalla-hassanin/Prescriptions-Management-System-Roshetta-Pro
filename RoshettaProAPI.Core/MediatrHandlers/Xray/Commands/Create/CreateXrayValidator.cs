using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Create;

public class CreateXrayCommandValidator : AbstractValidator<CreateXrayCommand>
{
    public CreateXrayCommandValidator()
    {
        // Ensure PatientID is provided and greater than 0
        RuleFor(x => x.PatientID)
            .GreaterThan(0).WithMessage("PatientID must be greater than 0");

        // Ensure DoctorID is provided and greater than 0
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("DoctorID must be greater than 0");

        // Ensure DateTaken is not empty and not in the future
        RuleFor(x => x.DateTaken)
            .NotEmpty().WithMessage("DateTaken is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("DateTaken cannot be in the future");

        // Ensure XrayImageURL is not empty and is a valid URL format
        RuleFor(x => x.XrayImageURL)
            .NotEmpty().WithMessage("XrayImageURL is required")
            .Must(BeAValidUrl).WithMessage("XrayImageURL must be a valid URL");

        // Ensure LabName is not empty
        RuleFor(x => x.LabName)
            .NotEmpty().WithMessage("LabName is required");

        // Ensure XrayType is not empty
        RuleFor(x => x.XrayType)
            .NotEmpty().WithMessage("XrayType is required");

        // Ensure Notes are not empty
        RuleFor(x => x.Notes)
            .NotEmpty().WithMessage("Notes are required");
    }

    // Custom method to validate URL format
    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}