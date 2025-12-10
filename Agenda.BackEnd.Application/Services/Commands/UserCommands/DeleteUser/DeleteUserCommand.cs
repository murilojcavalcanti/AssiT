using Agenda.BackEnd.Application.Models;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand:IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
