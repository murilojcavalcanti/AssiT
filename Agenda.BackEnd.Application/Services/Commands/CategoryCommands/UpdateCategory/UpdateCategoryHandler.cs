using AssiT.Application.Models;
using AssiT.BackEnd.Application.Services.Commands.CategoryCommands.UpdateCategory;
using AssiT.Core.Entities;
using AssiT.Core.Interfaces.Repository;
using MediatR;

namespace AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ResultViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.Get(c=>c.Id==request.Id);
            Category categoryUpdated = request.ToEntity();
            
            if (category == null)
                return ResultViewModel.Error("Contact not found");
            
            category.Update(categoryUpdated);

            await _categoryRepository.Update(category);
            
            return ResultViewModel.Success();
        }
    }
}
