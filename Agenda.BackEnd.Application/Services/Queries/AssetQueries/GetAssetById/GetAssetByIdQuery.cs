using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAssetByIdQuery:IRequest<ResultViewModel<AssetsViewModel>>
    {
        public int Id { get; set; }
        public GetAssetByIdQuery()
        {
            
        }
        public GetAssetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
