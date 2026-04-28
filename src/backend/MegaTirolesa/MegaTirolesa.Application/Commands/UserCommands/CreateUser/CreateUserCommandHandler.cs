using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IHandler<CreateUserCommand, ResultViewModel<Guid>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<Guid>> HandleAsync(CreateUserCommand request)
        {
            var user = request.ToEntity();

            var id = await _userRepository.CreateAsync(user);

            return new ResultViewModel<Guid>(id);
        }
    }
}
