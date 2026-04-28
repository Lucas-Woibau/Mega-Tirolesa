using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommandHandler : IHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel> HandleAsync(DeleteUserCommand request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return ResultViewModel.Error("User does not exist.");
            }

            user.SetAsDeleted();
            await _userRepository.UpdateAsync(user);

            return ResultViewModel.Success();
        }
    }
}
