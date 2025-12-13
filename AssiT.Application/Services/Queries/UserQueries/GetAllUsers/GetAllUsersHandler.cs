using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;
using System.Linq.Expressions;

namespace AssiT.BackEnd.Application.Services.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<(List<UserViewModel>, int)>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<(List<UserViewModel>,int)>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<User, bool>> predicate = null;

            (ICollection<User>users,int total) = await _userRepository.GetAll(predicate, request.Page);

            var usersViewModels = users.Select(c => UserViewModel.FromEntity(c)).ToList();

            return ResultViewModel<(List<UserViewModel>,int)>.Success((usersViewModels,total));
        }
    }
}
