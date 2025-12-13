using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using MediatR;
using System.ComponentModel;

namespace AssiT.BackEnd.Application.Services.Queries.CategoryQueries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<ResultViewModel<(List<CategoryViewModel>, int)>>
    {
        [DefaultValue(1)]
        public int Page { get; set; }

        public GetAllCategoriesQuery(int page)
        {
            Page = page;
        }
        public GetAllCategoriesQuery()
        {
            
        }
    }
}
