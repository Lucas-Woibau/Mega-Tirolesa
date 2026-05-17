using MegaTirolesa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure.Persistence
{
    public class MegaTirolesaDbContext : DbContext
    {
        public MegaTirolesaDbContext(DbContextOptions<MegaTirolesaDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentParticipant> Participants { get; set; }
        public DbSet<AcceptedTerm> AcceptedTerms { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<BlockedTimeSlot> BlockedTimeSlots { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

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

            builder.Entity<Appointment>(e =>
            {
                e.HasKey(a => a.Id);

                e.HasOne(a => a.TimeSlot)
                    .WithMany(a => a.Appointments)
                    .HasForeignKey(a => a.IdTimeSlot)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<AppointmentParticipant>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(a => a.Appointment)
                    .WithMany()
                    .HasForeignKey(a => a.IdAppointment)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<AcceptedTerm>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(a => a.Term)
                    .WithMany()
                    .HasForeignKey(a => a.IdTerm)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Term>(e =>
            {
                e.HasKey(e => e.Id);
            });

            builder.Entity<BlockedTimeSlot>(e =>
            {
                e.HasKey(e => e.Id);

                e.HasOne(b => b.TimeSlot)
                    .WithMany()
                    .HasForeignKey(b => b.IdTimeSlot);
            });

            builder.Entity<TimeSlot>(e =>
            {
                e.HasKey(e => e.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}
