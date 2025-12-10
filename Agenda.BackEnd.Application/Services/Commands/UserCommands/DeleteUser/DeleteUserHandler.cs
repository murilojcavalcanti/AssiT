using Agenda.BackEnd.Application.Models;
using Agenda.BackEnd.Core.Entities;
using Agenda.BackEnd.Core.Interfaces.Repository;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Commands.UserCommands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User contact = await _userRepository.Get(c=>c.Id == request.Id);
            if(contact is null)
                return ResultViewModel.Error("Contact not found.");
            await _userRepository.Delete(contact);
            return ResultViewModel.Success();
        }
    }
}
