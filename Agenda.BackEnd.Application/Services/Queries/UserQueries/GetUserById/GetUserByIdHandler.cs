using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Application.Models.userModels;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces.Repository;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Queries.UserQueries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.Get(c=>c.Id == request.Id);

            return ResultViewModel<UserViewModel>.Success(UserViewModel.FromEntity(user));
        }
    }
}
