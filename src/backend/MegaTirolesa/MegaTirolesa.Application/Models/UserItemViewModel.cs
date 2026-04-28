using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Models
{
    public class UserItemViewModel
    {
        public UserItemViewModel(Guid id, string name, string email, string cpf, string phoneNumber,
           DateTime birthDate, double weight, string country, string state, string city)
        {
            Id = id;
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
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public static UserItemViewModel FromEntity(User entity)
            => new(entity.Id, entity.Name, entity.Email, entity.CPF, entity.PhoneNumber, entity.BirthDate,
                entity.Weight, entity.Country, entity.State, entity.City);
    }
}
