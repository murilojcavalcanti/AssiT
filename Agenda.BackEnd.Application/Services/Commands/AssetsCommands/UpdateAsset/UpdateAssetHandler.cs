using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class UpdateAssetHandler : IRequestHandler<UpdateAssetCommand, ResultViewModel>
    {
        private readonly IAssetRepository _assetRepository;

        public UpdateAssetHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            Asset asset = await _assetRepository.Get(c=>c.Id==request.Id);
            Asset assetUpdated = request.ToEntity();
            
            if (asset == null)
                return ResultViewModel.Error("Contact not found");
            
            asset.Update(assetUpdated);

            await _assetRepository.Update(asset);
            
            return ResultViewModel.Success();
        }
    }
}
