using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class TimeSlotRepository : ITimeSlot
    {
        private readonly MegaTirolesaDbContext _context;

        public TimeSlotRepository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<TimeSlot>> GetAllAsync()
        {
            var timeSlots = await _context.TimeSlots
                .ToListAsync();

            return timeSlots;
        }

        public async Task<TimeSlot?> GetByIdAsync(Guid id)
        {
            var timeSlot = await _context.TimeSlots
                .SingleOrDefaultAsync(t => t.Id == id);

            return timeSlot;
        }

        public async Task<Guid> CreateAsync(TimeSlot timeSlot)
        {
            await _context.AddAsync(timeSlot);
            await _context.SaveChangesAsync();

            return timeSlot.Id;
        }

        public async Task UpdateAsync(TimeSlot timeSlot)
        {
            _context.Update(timeSlot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var timeslot = await _context.TimeSlots.SingleOrDefaultAsync(t => t.Id == id);

            if (timeslot == null)
            {
                return;
            }

            _context.Update(timeslot);
            timeslot.SetAsDeleted();
            await _context.SaveChangesAsync();
        }
    }
}
