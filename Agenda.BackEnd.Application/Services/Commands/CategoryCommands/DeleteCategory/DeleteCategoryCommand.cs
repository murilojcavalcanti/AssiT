using AssiT.Application.Models;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class DeleteCategoryCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
