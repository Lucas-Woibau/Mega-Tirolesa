using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence
{
    public class MegaTirolesaDbContext : DbContext
    {
        public MegaTirolesaDbContext(DbContextOptions<MegaTirolesaDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // TODO: Mapear as entidades

            base.OnModelCreating(builder);
        }
    }
}
