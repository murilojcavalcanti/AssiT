using AssiT.Application.Models;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
