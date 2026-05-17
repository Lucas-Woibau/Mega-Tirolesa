using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class AcceptedTermRepository : IAcceptedTerm
    {
        private readonly MegaTirolesaDbContext _context;

        public AcceptedTermRepository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<AcceptedTerm>> GetAllAsync()
        {
            var acceptedTerms = await _context.AcceptedTerms
                .ToListAsync();

            return acceptedTerms;
        }

        public async Task<AcceptedTerm?> GetByIdAsync(Guid id)
        {
            var acceptedTerm = await _context.AcceptedTerms
                .SingleOrDefaultAsync(x => x.Id == id);

            return acceptedTerm;
        }

        public async Task<Guid> CreateAsync(AcceptedTerm appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task UpdateAsync(AcceptedTerm appointment)
        {
            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var acceptedTerm = await _context.Participants
                .SingleOrDefaultAsync(p => p.Id == id);

            if (acceptedTerm == null)
            {
                return;
            }

            _context.Update(acceptedTerm);
            acceptedTerm.SetAsDeleted();

            await _context.SaveChangesAsync();
        }
    }
}
