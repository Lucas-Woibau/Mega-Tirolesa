using FluentValidation;
using MegaTirolesa.Application.Commands.AppointmentCommands.CreateAppointment;

namespace MegaTirolesa.Application.FluentValidation.AppointmentValidator
{
    public class UpdateAppoitmentValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public UpdateAppoitmentValidator()
        {
            RuleFor(a => a.AppointmentDate)
                .GreaterThan(_ => DateTime.UtcNow)
                .WithMessage("A data de agendamento deve ser futura.");
        }
    }
}
