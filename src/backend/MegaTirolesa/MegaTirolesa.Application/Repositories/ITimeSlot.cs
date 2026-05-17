using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Repositories
{
    public interface ITimeSlot
    {
        Task<List<TimeSlot>> GetAllAsync();
        Task<TimeSlot?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(TimeSlot appointment);
        Task UpdateAsync(TimeSlot appointment);
        Task DeleteAsync(Guid id);
    }
}
