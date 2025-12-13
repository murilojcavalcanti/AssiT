using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAllContactsHandler : IRequestHandler<GetAllAssetQuery, ResultViewModel<(List<AssetsViewModel>,int)>>
    {
        private readonly IAssetRepository _assetRepository;

        public GetAllContactsHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<ResultViewModel<(List<AssetsViewModel>, int)>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Asset, bool>> predicate = c =>
                (request.CategoriaId == 0 || c.CategoryId == request.CategoriaId) &&
                (!request.AcquisitionDate.HasValue || c.AcquisitionDate == request.AcquisitionDate) &&
                (!request.AcquisitionValueMax.HasValue || c.AcquisitionValue <= request.AcquisitionValueMax.Value) &&
                (!request.AcquisitionValueMin.HasValue || c.AcquisitionValue >= request.AcquisitionValueMin.Value);

            (ICollection<Asset> assets, int total) = await _assetRepository.GetAll(predicate, request.Page);

            var assetViewModels = assets
                .Select(AssetsViewModel.FromEntity)
                .ToList();

            return ResultViewModel<(List<AssetsViewModel>, int)>
                .Success((assetViewModels, total));
        }
    }
}
