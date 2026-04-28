using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Commands.AppointmentCommands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IHandler<UpdateAppointmentCommand, ResultViewModel>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<ResultViewModel> HandleAsync(UpdateAppointmentCommand request)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.IdAppointment);

            if(appointment == null)
            {
                return ResultViewModel.Error("Appointment not found.");
            }

            appointment.Update(request.AppointmentDate);
            await _appointmentRepository.UpdateAsync(appointment);

            return ResultViewModel.Success();
        }
    }
}
