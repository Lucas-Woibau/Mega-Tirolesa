using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Commands.AppointmentCommands.DeleteAppointment
{
    public partial class DeleteAppointmentCommand
    {
        public class DeleteAppointmentCommandHandler : IHandler<DeleteAppointmentCommand, ResultViewModel>
        {
            private readonly IAppointmentRepository _appointmentRepository;

            public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
            {
                _appointmentRepository = appointmentRepository;
            }

            public async Task<ResultViewModel> HandleAsync(DeleteAppointmentCommand request)
            {
                var appointment = await _appointmentRepository.GetByIdAsync(request.Id);

                if (appointment == null)
                {
                    return ResultViewModel.Error("Appointment does not exist.");
                }

                appointment.SetAsDeleted();
                await _appointmentRepository.UpdateAsync(appointment);

                return ResultViewModel.Success();
            }
        }
    }
}
