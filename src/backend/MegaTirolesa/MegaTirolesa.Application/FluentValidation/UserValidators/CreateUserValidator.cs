using FluentValidation;
using MegaTirolesa.Application.Commands.UserCommands.CreateUser;

namespace MegaTirolesa.Application.FluentValidation.UserValidators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Digite um e-mail válido");
        }
    }
}
