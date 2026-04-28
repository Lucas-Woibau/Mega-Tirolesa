using MegaTirolesa.Domain.Entities;
using MegaTirolesa.Domain.Enums;

namespace MegaTirolesa.Application.Models
{
    public class AppointmentViewModel
    {
        public AppointmentViewModel(Guid id, Guid idUser, string userName, DateTime appointmentDate, AppointmentStatus status)
        {
            Id = id;
            IdUser = idUser;
            UserName = userName;
            AppointmentDate = appointmentDate;

            Status = status;
        }

        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string UserName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public static AppointmentViewModel FromEntity(Appointment entity)
            => new(entity.Id, entity.IdUser, entity.User.Name, entity.AppointmentDate, entity.Status);
    }
}

