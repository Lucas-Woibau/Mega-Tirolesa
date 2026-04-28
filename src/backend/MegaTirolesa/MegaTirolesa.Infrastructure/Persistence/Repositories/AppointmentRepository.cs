using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MegaTirolesaDbContext _context;

        public AppointmentRepository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            var appointments = await _context.Appointments
                .Include(u => u.User)
                .ToListAsync();

            return appointments;
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            var appointment = await _context.Appointments
                .Include(u => u.User)
                .SingleOrDefaultAsync(a => a.Id == id);

            return appointment;
        }

        public async Task<Guid> CreateAsync(Appointment appointment)
        {
            await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointment = await _context.Appointments.SingleOrDefaultAsync(u => u.Id == id);

            if (appointment == null)
                return;

            appointment.SetAsDeleted();

            await _context.SaveChangesAsync();
        }
    }
}
