using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class DeleteAssetHandler : IRequestHandler<DeleteAssetCommand, ResultViewModel>
    {
        private readonly IAssetRepository _assetRepository;

        public DeleteAssetHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            Asset asset = await _assetRepository.Get(c=>c.Id == request.Id);
            if(asset is null)
                return ResultViewModel.Error("Contact not found.");
            await _assetRepository.Delete(asset);
            return ResultViewModel.Success();
        }
    }
}
