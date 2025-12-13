using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class CreateAssetHandler : IRequestHandler<CreateAssetCommand, ResultViewModel<int>>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateAssetHandler(IAssetRepository assetRepository, ICategoryRepository categoryRepository)
        {
            _assetRepository = assetRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            Asset asset = request.ToEntity();
            var existingCategory = await _categoryRepository.Get(u => u.Id == request.CategoryId);
            if (existingCategory == null)
            {
                return ResultViewModel<int>.Error("Não existe esta categoria cadastrada.");
            }
            await _assetRepository.Insert(asset);
            return ResultViewModel<int>.Success(asset.Id);
        }
    }
}
