using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly MegaTirolesaDbContext _context;

        public TermRepository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Term>> GetAllAsync()
        {
            var terms = await _context.Terms
                .ToListAsync();

            return terms;
        }

        public async Task<Term?> GetByIdAsync(Guid id)
        {
            var term = await _context.Terms
                .SingleOrDefaultAsync(term => term.Id == id);

            return term;
        }

        public async Task<Guid> CreateAsync(Term term)
        {
            await _context.AddAsync(term);
            await _context.SaveChangesAsync();

            return term.Id;
        }

        public async Task UpdateAsync(Term term)
        {
            _context.Update(term);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var term = await _context.TimeSlots.SingleOrDefaultAsync(t => t.Id == id);

            if (term == null)
            {
                return;
            }

            _context.Update(term);
            term.SetAsDeleted();
            await _context.SaveChangesAsync();
        }
    }
}
