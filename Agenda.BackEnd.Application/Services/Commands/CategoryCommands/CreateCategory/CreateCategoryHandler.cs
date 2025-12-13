using AssiT.Application.Models;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ResultViewModel<int>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = request.ToEntity();
            await _categoryRepository.Insert(category);
            return ResultViewModel<int>.Success(category.Id);
        }
    }
}
