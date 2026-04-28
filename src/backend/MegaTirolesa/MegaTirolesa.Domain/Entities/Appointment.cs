using MegaTirolesa.Domain.Enums;

namespace MegaTirolesa.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        protected Appointment() { }
        public Appointment(Guid idUser, DateTime appointmentDate)
            : base()
        {
            IdUser = idUser;
            AppointmentDate = appointmentDate;

            Status = AppointmentStatus.Confirmed;
        }

        public Guid IdUser { get; private set; }
        public User User { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public AppointmentStatus Status { get; private set; }

        public void Update(DateTime appointmentDate)
        {
            AppointmentDate = appointmentDate;
        }
    }
}
