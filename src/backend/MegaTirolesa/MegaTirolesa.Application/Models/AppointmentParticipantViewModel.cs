using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Models
{
    public class AppointmentParticipantViewModel
    {
        public AppointmentParticipantViewModel(Guid idAppointment, string name, string cpf, int age, double weight, bool isResponsible)
        {
            IdAppointment = idAppointment;
            Name = name;
            Cpf = cpf;
            Age = age;
            Weight = weight;
            IsResponsible = isResponsible;
        }

        public Guid IdAppointment { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public double Weight { get; private set; }
        public bool IsResponsible { get; private set; }

        public static AppointmentParticipantItemViewModel FromEntity(AppointmentParticipant entity)
            => new(entity.IdAppointment, entity.Name, entity.Cpf, entity.Age, entity.Weight, entity.IsResponsible);
    }
}


