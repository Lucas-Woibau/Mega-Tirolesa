using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class AppointmentParticipantRepository : IAppointmentParticipantRepository
    {
        private readonly MegaTirolesaDbContext _context;

        public AppointmentParticipantRepository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentParticipant>> GetAllAsync()
        {
            var appointmentsParticipants = await _context.Participants
                .ToListAsync();

            return appointmentsParticipants;
        }

        public async Task<AppointmentParticipant?> GetByIdAsync(Guid id)
        {
            var appointmentsParticipant = await _context.Participants
                .SingleOrDefaultAsync(p => p.Id == id);

            return appointmentsParticipant;
        }

        public async Task<Guid> CreateAsync(AppointmentParticipant appointmentParticipant)
        {
            await _context.AddAsync(appointmentParticipant);
            await _context.SaveChangesAsync();

            return appointmentParticipant.Id;
        }

        public async Task UpdateAsync(AppointmentParticipant appointmentParticipant)
        {
            _context.Update(appointmentParticipant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointmentParticipant = await _context.Participants
                .SingleOrDefaultAsync(p => p.Id == id);

            if (appointmentParticipant == null)
            {
                return;
            }

            _context.Update(appointmentParticipant);
            appointmentParticipant.SetAsDeleted();

            await _context.SaveChangesAsync();
        }
    }
}
