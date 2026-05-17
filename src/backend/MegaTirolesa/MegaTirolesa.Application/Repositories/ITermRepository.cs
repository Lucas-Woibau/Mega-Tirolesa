using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Repositories
{
    public interface ITermRepository
    {
        Task<List<Term>> GetAllAsync();
        Task<Term?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Term term);
        Task UpdateAsync(Term term);
        Task DeleteAsync(Guid id);
    }
}
