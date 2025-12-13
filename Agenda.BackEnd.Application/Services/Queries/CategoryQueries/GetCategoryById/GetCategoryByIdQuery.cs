using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Queries.CategoryQueries.GetAllCategories
{
    public class GetCategoryByIdQuery : IRequest<ResultViewModel<CategoryViewModel>>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
        public GetCategoryByIdQuery()
        {
            
        }
    }
}
