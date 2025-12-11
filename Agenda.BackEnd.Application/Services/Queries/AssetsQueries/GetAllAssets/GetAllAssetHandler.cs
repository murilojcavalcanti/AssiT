using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;
using System.Linq.Expressions;

namespace AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAllContactsHandler : IRequestHandler<GetAllAssetQuery, ResultViewModel<List<AssetsViewModel>>>
    {
        private readonly IAssetRepository _assetRepository;

        public GetAllContactsHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<ResultViewModel<List<AssetsViewModel>>> Handle(GetAllAssetQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Asset, bool>> predicate = c =>
                (request.CategoriaId == 0 || c.CategoryId == request.CategoriaId) &&
                (string.IsNullOrEmpty(request.AcquisitionDate.ToString()) || c.AcquisitionDate == request.AcquisitionDate &&
                (string.IsNullOrEmpty(request.Alias) || c.Alias.Contains(request.Alias)) &&
                (string.IsNullOrEmpty(request.PhoneNumber) || c.PhoneNumber.Contains(request.PhoneNumber));

            var contacts = await _assetRepository.GetAll(predicate, request.Page);

            var contactViewModels = contacts.Select(c => AssetsViewModel.FromEntity(c)).ToList();
            return ResultViewModel<List<AssetsViewModel>>.Success(contactViewModels);
        }
    }
}
