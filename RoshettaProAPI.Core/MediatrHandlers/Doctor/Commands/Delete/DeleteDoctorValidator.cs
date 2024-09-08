using FluentValidation;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Delete;

public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorCommand>
{
    public DeleteDoctorValidator()
    {
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");
    }
}