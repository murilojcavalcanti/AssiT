using AssiT.BackEnd.Application.Services.Commands.CategoryCommands.UpdateCategory;
using FluentValidation;

namespace AssiT.Application.Validators.CategoryValidator
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O ID da categoria deve ser maior que zero.");

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
