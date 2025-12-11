using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAssetByIdHandler : IRequestHandler<GetAssetByIdQuery,ResultViewModel<AssetsViewModel>>
    {
        private readonly IAssetRepository _assetRepository;

        public GetAssetByIdHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<ResultViewModel<AssetsViewModel>> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
        {
            Asset? asset = await _assetRepository.Get(c=>c.Id==request.Id);

            return ResultViewModel<AssetsViewModel>.Success(AssetsViewModel.FromEntity(asset));
        }
    }
}
