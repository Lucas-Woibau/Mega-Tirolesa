namespace MegaTirolesa.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string name, string email, string cpf, string phoneNumber, DateTime birthDate, double weight, string country, string state, string city)
            : base()
        {
            Name = name;
            Email = email;
            CPF = cpf;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Weight = weight;
            Country = country;
            State = state;
            City = city;

            Appointments = [];
        }

        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string CPF { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public double Weight { get; private set; }
        public string Country { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;

        public List<Appointment> Appointments { get; private set; }

        public void Update(string name, string email, string cpf, string phoneNumber, DateTime birthDate, double weight, string country, string state, string city)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Weight = weight;
            Country = country;
            State = state;
            City = city;
        }
    }
}
