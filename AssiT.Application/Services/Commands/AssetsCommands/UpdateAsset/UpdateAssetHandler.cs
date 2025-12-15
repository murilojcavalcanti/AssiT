using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class UpdateAssetHandler : IRequestHandler<UpdateAssetCommand, ResultViewModel>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateAssetHandler(IAssetRepository assetRepository, ICategoryRepository categoryRepository)
        {
            _assetRepository = assetRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            Asset asset = await _assetRepository.Get(c=>c.Id==request.Id);
            Asset assetUpdated = request.ToEntity();
            
            if (asset == null)
                return ResultViewModel.Error("Asset not found");
            if (assetUpdated.CategoryId == 0 || await _categoryRepository.Get(c => c.Id == assetUpdated.Id) is null)
                return ResultViewModel.Error("Category not found");

            asset.Update(assetUpdated);

            await _assetRepository.Update(asset);
            
            return ResultViewModel.Success();
        }
    }
}
