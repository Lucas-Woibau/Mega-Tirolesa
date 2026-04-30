using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Models;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Queries.AppointmentQueries.GetAllAppointmentQuery
{
    public class GetAllAppointmentsQueryHandler : IHandler<GetAllAppointmentsQuery, ResultViewModel<List<AppointmentItemViewModel>>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAllAppointmentsQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ResultViewModel<List<AppointmentItemViewModel>>> HandleAsync(GetAllAppointmentsQuery request)
        {
            var appoitments = await _appointmentRepository.GetAllAsync();

            var appointmentsViewModel = appoitments.Select(AppointmentItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<AppointmentItemViewModel>>.Success(appointmentsViewModel);
        }
    }
}
