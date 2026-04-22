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
            builder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasMany(a => a.Appointments)
                    .WithOne(a => a.User)
                    .HasForeignKey(a => a.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Appointment>(a =>
            {
                a.HasKey(a => a.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}
