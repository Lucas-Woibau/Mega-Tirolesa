using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;

namespace MegaTirolesa.Application.Commands.AppointmentParticipantsCommands.CreateAppointmentParticipants
{
    public class CreateAppointmentParticipantCommand
    {
    }

    public class CreateAppointmentParticipantCommandHandler : IHandler<CreateAppointmentParticipantCommand, ResultViewModel<Guid>>
    {
        public Task<ResultViewModel<Guid>> HandleAsync(CreateAppointmentParticipantCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
