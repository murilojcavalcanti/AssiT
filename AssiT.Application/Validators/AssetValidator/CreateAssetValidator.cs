using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using FluentValidation;

namespace AssiT.Application.Validators.AssetValidator
{
    public class CreateAssetValidator : AbstractValidator<CreateAssetCommand>
    {
        public CreateAssetValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome do ativo é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O nome do ativo deve ter no máximo 100 caracteres.");

            
            RuleFor(x => x.SerialNumber)
                .MaximumLength(15)
                .WithMessage("O número de série deve ter no máximo 15 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.SerialNumber));

            RuleFor(x => x.AcquisitionDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de compra não pode ser uma data futura.");

            RuleFor(x => x.AcquisitionValue)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor de compra deve ser maior ou igual a zero.");
                
        }
    }
}
