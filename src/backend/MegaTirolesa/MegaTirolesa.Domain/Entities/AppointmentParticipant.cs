namespace MegaTirolesa.Domain.Entities
{
    public class AppointmentParticipant : BaseEntity
    {
        protected AppointmentParticipant() { }
        public AppointmentParticipant(Guid idAppointment, string name, string cpf, int age, double weight, bool isResponsible)
            : base()
        {
            IdAppointment = idAppointment;
            Name = name;
            Cpf = cpf;
            Age = age;
            Weight = weight;
            IsResponsible = isResponsible;
        }

        public Guid IdAppointment { get; private set; }
        public Appointment Appointment { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public double Weight { get; private set; }
        public bool IsResponsible { get; private set; }

        public void Update(string name, string cpf, int age, double weight, bool isResponsible)
        {
            Name = name;
            Cpf = cpf;
            Age = age;
            Weight = weight;
            IsResponsible = isResponsible;
        }
    }
}
