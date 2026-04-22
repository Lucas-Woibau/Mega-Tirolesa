using MegaTirolesa.Domain.Enums;

namespace MegaTirolesa.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        protected Appointment() { }
        public Appointment(Guid idUser, User user, DateTime appointmentDate)
            : base()
        {
            IdUser = idUser;
            User = user;
            AppointmentDate = appointmentDate;

            Status = AppointmentStatus.Confirmed;
        }

        public Guid IdUser { get; set; }
        public User User { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
