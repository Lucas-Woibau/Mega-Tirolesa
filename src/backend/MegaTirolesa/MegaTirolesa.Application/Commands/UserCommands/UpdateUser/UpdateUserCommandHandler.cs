using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler : IHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel> HandleAsync(UpdateUserCommand request)
        {
            var user = await _userRepository.GetByIdAsync(request.IdUser);

            if (user == null)
            {
                return ResultViewModel.Error("User not found.");
            }

            user.Update(request.Name, request.Email, request.CPF, request.PhoneNumber,
                request.BirthDate, request.Weight, request.Country, request.State, request.City);

            await _userRepository.UpdateAsync(user);

            return ResultViewModel.Success();

        }
    }
}
