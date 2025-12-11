using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using MediatR;
using System.ComponentModel;

namespace AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAllAssetQuery:IRequest<ResultViewModel<List<AssetsViewModel>>>
    {

        public int? CategoriaId { get; set; }

        public DateTime ?AcquisitionDate { get; set; }

        public decimal? AcquisitionValue { get; set; }

        [DefaultValue(1)]
        public int Page { get; set; }
        public GetAllAssetQuery()
        {
            
        }

        public GetAllAssetQuery(int page, int? categoriaId, DateTime acquisitionDate, DateTime acquisitionValue)
        {
            Page = page;
            CategoriaId = categoriaId;
            AcquisitionDate = acquisitionDate;
            AcquisitionValue = acquisitionValue;
        }
    }
}
