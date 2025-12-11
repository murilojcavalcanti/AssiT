using AssiT.Application.Models;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
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
