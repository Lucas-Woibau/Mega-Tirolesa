using MegaTirolesa.Application.Repositories;
using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MegaTirolesaDbContext _context;

        public UserRepository(MegaTirolesaDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.Users
                .Include(u => u.Appointments)
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Appointments)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<Guid> CreateAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return;

            _context.Update(user);
            user.SetAsDeleted();

            await _context.SaveChangesAsync();
        }
    }
}
