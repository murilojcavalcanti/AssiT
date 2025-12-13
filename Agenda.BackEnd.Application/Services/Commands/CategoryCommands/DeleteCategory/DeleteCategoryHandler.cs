using AssiT.Application.Models;
using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCategory.CreateCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ResultViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.Get(c=>c.Id == request.Id);
            if(category is null)
                return ResultViewModel.Error("Category not found.");
            await _categoryRepository.Delete(category);
            return ResultViewModel.Success();
        }
    }
}
