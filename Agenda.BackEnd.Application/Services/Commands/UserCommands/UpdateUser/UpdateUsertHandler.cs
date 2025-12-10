using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces.Repository;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Commands.UserCommands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user =await _userRepository.Get(c=>c.Id==request.Id);
            User userUpdated = request.ToEntity();
            if (user == null)
                return ResultViewModel.Error("Contact not found");
            user.Update(userUpdated);
            await _userRepository.Update(user);
            return ResultViewModel.Success();
        }
    }
}
