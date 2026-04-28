using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Commands.AppointmentCommands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IHandler<CreateAppointmentCommand, ResultViewModel<Guid>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ResultViewModel<Guid>> HandleAsync(CreateAppointmentCommand request)
        {
            var appointment = request.ToEntity();

            var id = await _appointmentRepository.CreateAsync(appointment);

            return ResultViewModel<Guid>.Success(id);
        }
    }
}
