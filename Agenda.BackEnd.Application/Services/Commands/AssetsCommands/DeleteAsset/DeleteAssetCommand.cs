using AssiT.Application.Models;
using MediatR;

namespace Agenda.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class DeleteAssetCommand:IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteAssetCommand(int id)
        {
            Id = id;
        }
    }
}
