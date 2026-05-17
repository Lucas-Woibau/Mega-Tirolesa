using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class BlockedTimeSlotRespository : IBlockedTimeSlot
    {
        private readonly MegaTirolesaDbContext _context;

        public BlockedTimeSlotRespository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlockedTimeSlot>> GetAllAsync()
        {
            var blockedTimeSlots = await _context.BlockedTimeSlots
                .ToListAsync();

            return blockedTimeSlots;
        }

        public async Task<BlockedTimeSlot?> GetByIdAsync(Guid id)
        {
            var blockedTimeSlot = await _context.BlockedTimeSlots
                .SingleOrDefaultAsync(t => t.Id == id);

            return blockedTimeSlot;
        }

        public async Task<Guid> CreateAsync(BlockedTimeSlot blockedTimeSlot)
        {
            _context.Add(blockedTimeSlot);
            await _context.SaveChangesAsync();

            return blockedTimeSlot.Id;
        }

        public async Task UpdateAsync(BlockedTimeSlot blockedTimeSlot)
        {
            _context.Update(blockedTimeSlot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var blockedTimeSlot = await _context.BlockedTimeSlots
                .SingleOrDefaultAsync(p => p.Id == id);

            if (blockedTimeSlot == null)
            {
                return;
            }

            _context.Update(blockedTimeSlot);
            blockedTimeSlot.SetAsDeleted();

            await _context.SaveChangesAsync();
        }
    }
}
