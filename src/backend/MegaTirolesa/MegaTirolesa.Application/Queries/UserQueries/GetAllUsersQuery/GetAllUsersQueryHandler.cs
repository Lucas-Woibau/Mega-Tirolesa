using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Models;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Queries.UserQueries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IHandler<GetAllUsersQuery, ResultViewModel<List<UserItemViewModel>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<List<UserItemViewModel>>> HandleAsync(GetAllUsersQuery request)
        {
            var users = await _userRepository.GetAllAsync();

            var usersItemViewModel = users.Select(UserItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(usersItemViewModel);
        }
    }
}
