using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using AssiT.Application.utils;
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
            var predicate = PredicateBuilder.True<Asset>()
       .AndIf(request.CategoriaId.HasValue && request.CategoriaId > 0,
           x => x.CategoryId == request.CategoriaId.Value)
       .AndIf(request.AcquisitionDate.HasValue,
           x => x.AcquisitionDate == request.AcquisitionDate.Value)
       .AndIf(request.AcquisitionValueMin.HasValue,
           x => x.AcquisitionValue >= request.AcquisitionValueMin.Value)
       .AndIf(request.AcquisitionValueMax.HasValue,
           x => x.AcquisitionValue <= request.AcquisitionValueMax.Value)
       .AndIf(request.Status.HasValue,
           x => x.AssetStatus == request.Status.Value);

            (ICollection<Asset> assets, int total) = await _assetRepository.GetAll(predicate, request.Page);

            var assetViewModels = assets
                .Select(AssetsViewModel.FromEntity)
                .ToList();

            return ResultViewModel<(List<AssetsViewModel>, int)>
                .Success((assetViewModels, total));
        }
    }
}
