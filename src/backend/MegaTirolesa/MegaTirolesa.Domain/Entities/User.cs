namespace MegaTirolesa.Domain.Entities
{
    public class User : BaseEntity
    {
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
        }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
