using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;
using System.Linq.Expressions;

namespace AssiT.BackEnd.Application.Services.Queries.CategoryQueries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ResultViewModel<(List<CategoryViewModel>,int)>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultViewModel<(List<CategoryViewModel>,int)>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            
            Expression<Func<Category, bool>> predicate = null;

            (ICollection<Category>categories,int total) = await _categoryRepository.GetAll(predicate, request.Page);

            var usersViewModels = categories.Select(c => CategoryViewModel.FromEntity(c)).ToList();
            return ResultViewModel<(List<CategoryViewModel>,int)>.Success((usersViewModels,total));
        }
    }
}
