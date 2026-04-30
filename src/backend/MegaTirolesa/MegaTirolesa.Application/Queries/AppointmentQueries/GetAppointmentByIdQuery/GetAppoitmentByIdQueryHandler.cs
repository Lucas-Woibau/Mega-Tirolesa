using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Queries.AppointmentQueries.GetAppointmentByIdQuery
{
    public class GetAppoitmentByIdQueryHandler : IHandler<GetAppointmentByIdQuery, ResultViewModel<Guid>>
    {
        private readonly IAppointmentRepository _repository;

        public GetAppoitmentByIdQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<Guid>> HandleAsync(GetAppointmentByIdQuery request)
        {
            var appointment = await _repository.GetByIdAsync(request.Id);

            if (appointment == null)
            {
                return ResultViewModel<Guid>.Error("Appointment not found.");
            }

            return ResultViewModel<Guid>.Success(appointment.Id);
        }
    }
}
