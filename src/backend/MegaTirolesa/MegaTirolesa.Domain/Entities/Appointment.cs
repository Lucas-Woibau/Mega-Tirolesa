using MegaTirolesa.Domain.Enums;

namespace MegaTirolesa.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        protected Appointment() { }
        public Appointment(Guid idUser, DateTime appointmentDate, Guid idTimeSlot, int participantsQuantity)
            : base()
        {
            IdUser = idUser;
            IdTimeSlot = idTimeSlot;
            ParticipantsQuantity = participantsQuantity;

            Status = AppointmentStatus.Pending;
        }

        public Guid IdUser { get; private set; }
        public User User { get; private set; }
        public Guid IdTimeSlot { get; private set; }
        public TimeSlot TimeSlot { get; private set; }
        public int ParticipantsQuantity { get; private set; }
        public List<AppointmentParticipant> Participants { get; private set; } = [];
        public AppointmentStatus Status { get; private set; }

        public void Update(Guid idTimeSlot, int participantsQuantity)
        {
            IdTimeSlot = idTimeSlot;
            ParticipantsQuantity = participantsQuantity;
        }
    }
}
