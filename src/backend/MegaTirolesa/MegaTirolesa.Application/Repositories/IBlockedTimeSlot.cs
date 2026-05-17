using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Repositories
{
    public interface IBlockedTimeSlot
    {
        Task<List<BlockedTimeSlot>> GetAllAsync();
        Task<BlockedTimeSlot?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(BlockedTimeSlot blockedTimeSlot);
        Task UpdateAsync(BlockedTimeSlot blockedTimeSlot);
        Task DeleteAsync(Guid id);
    }
}
