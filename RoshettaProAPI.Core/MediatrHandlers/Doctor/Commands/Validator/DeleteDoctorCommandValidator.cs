using FluentValidation;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Validator;

public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
{
    public DeleteDoctorCommandValidator()
    {
        RuleFor(x => x.DoctorID)
            .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");
    }
}