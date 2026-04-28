using MegaTirolesa.Domain.Entities;

namespace MegaTirolesa.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public static UserViewModel FromEntity(User entity)
            => new(entity.Id, entity.Name, entity.Email, entity.PhoneNumber);
    }
}
