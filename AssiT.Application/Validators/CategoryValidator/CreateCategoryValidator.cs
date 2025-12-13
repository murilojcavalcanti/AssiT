using AssiT.BackEnd.Application.Services.Commands.CategoryCommands.CreateCategory;
using FluentValidation;

namespace AssiT.Application.Validators.CategoryValidator
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome da categoria é obrigatório.")
                .MinimumLength(3)
                .WithMessage("O nome da categoria deve ter no mínimo 3 caracteres.")
                .MaximumLength(100)
                .WithMessage("O nome da categoria deve ter no máximo 100 caracteres.");
        }
    }
}
