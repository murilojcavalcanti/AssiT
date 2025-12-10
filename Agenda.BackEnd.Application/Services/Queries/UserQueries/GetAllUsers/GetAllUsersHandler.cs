using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Application.Models.contactModels;
using Agenda.BackEnd.Application.Models.userModels;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces.Repository;
using MediatR;
using System.Linq.Expressions;

namespace Agenda.BackEnd.Application.Services.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            
            Expression<Func<User, bool>> predicate = null;

            var users = await _userRepository.GetAll(predicate, request.Page);

            var usersViewModels = users.Select(c => UserViewModel.FromEntity(c)).ToList();
            return ResultViewModel<List<UserViewModel>>.Success(usersViewModels);
        }
    }
}
