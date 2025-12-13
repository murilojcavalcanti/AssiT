using AssiT.Application.Models;
using AssiT.Application.Models.userModels;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Queries.CategoryQueries.GetAllCategories
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, ResultViewModel<CategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultViewModel<CategoryViewModel>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.Get(c=>c.Id == request.Id);

            return ResultViewModel<CategoryViewModel>.Success(CategoryViewModel.FromEntity(category));
        }
    }
}
