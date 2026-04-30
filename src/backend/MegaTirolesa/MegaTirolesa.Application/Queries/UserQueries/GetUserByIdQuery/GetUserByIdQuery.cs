using Bibliotrack.Application.Models;
using MegaTirolesa.Application.Common;
using MegaTirolesa.Application.Repositories;

namespace MegaTirolesa.Application.Queries.UserQueries.GetUserByIdQuery
{
    public class GetUserByIdQuery
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetUserByIdQueryHandler : IHandler<GetUserByIdQuery, ResultViewModel<Guid>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<Guid>> HandleAsync(GetUserByIdQuery request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return ResultViewModel<Guid>.Error("User not found");
            }

            return ResultViewModel<Guid>.Success(user.Id);
        }
    }
}
