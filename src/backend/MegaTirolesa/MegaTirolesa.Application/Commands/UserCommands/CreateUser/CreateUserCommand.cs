using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public User ToEntity()
            => new(Name, Email, CPF, PhoneNumber, BirthDate, Weight, Country, State, City);
    }
}
