using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssiT.Application.Validators.AssetValidator
{
    public class UpdateAssetValidator:AbstractValidator<UpdateAssetCommand>
    {
        public UpdateAssetValidator()
        {
            When(x => !string.IsNullOrWhiteSpace(x.Name), () =>
            {
                RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome do ativo é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O nome do ativo deve ter no máximo 100 caracteres.");
            });
            
            When(x => !string.IsNullOrWhiteSpace(x.SerialNumber), () =>
            {
                RuleFor(x => x.SerialNumber)
                .MaximumLength(15)
                .WithMessage("O número de série deve ter no máximo 15 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.SerialNumber));
            });

            When(x => x.AcquisitionDate != null, () =>
            {
                RuleFor(x => x.AcquisitionDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de compra não pode ser uma data futura.");
            });

            When(x => x.AcquisitionValue != null, () =>
            {
                RuleFor(x => x.AcquisitionValue)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor de compra deve ser maior ou igual a zero.");
            });
        }
    }
}
