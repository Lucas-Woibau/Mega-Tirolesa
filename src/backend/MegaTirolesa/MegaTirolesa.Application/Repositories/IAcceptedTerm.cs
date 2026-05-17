using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Repositories
{
    public interface IAcceptedTerm
    {
        Task<List<AcceptedTerm>> GetAllAsync();
        Task<AcceptedTerm?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(AcceptedTerm appointment);
        Task UpdateAsync(AcceptedTerm appointment);
        Task DeleteAsync(Guid id);
    }
}
