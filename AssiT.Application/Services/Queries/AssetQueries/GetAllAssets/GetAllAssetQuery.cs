using AssiT.Application.Models;
using AssiT.Application.Models.AssetModels;
using MediatR;
using System.ComponentModel;

namespace AssiT.BackEnd.Application.Services.Queries.ContactQueries.GetContact
{
    public class GetAllAssetQuery:IRequest<ResultViewModel<(List<AssetsViewModel>,int)>>
    {

        public int? CategoriaId { get; set; }

        public DateTime ?AcquisitionDate { get; set; }

        public decimal? AcquisitionValueMin { get; set; }
        public decimal? AcquisitionValueMax { get; set; }

        [DefaultValue(1)]
        public int Page { get; set; }
        public GetAllAssetQuery()
        {
            
        }

        public GetAllAssetQuery(int page, int? categoriaId, DateTime acquisitionDate, decimal acquisitionValueMin, decimal acquisitionValueMax)
        {
            Page = page;
            CategoriaId = categoriaId;
            AcquisitionDate = acquisitionDate;
            AcquisitionValueMin = acquisitionValueMin;
            AcquisitionValueMax = acquisitionValueMax;
        }
    }
}
