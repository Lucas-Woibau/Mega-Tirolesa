using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Repositories
{
    public interface IAppointmentParticipantRepository
    {
        Task<List<AppointmentParticipant>> GetAllAsync();
        Task<AppointmentParticipant?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(AppointmentParticipant appointmentParticipant);
        Task UpdateAsync(AppointmentParticipant appointmentParticipant);
        Task DeleteAsync(Guid id);
    }
}
