using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Commands.AppointmentCommands.CreateAppointment
{
    public class CreateAppointmentCommand
    {
        public Guid IdUser { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment ToEntity()
            => new(IdUser, AppointmentDate);
    }
}
