using AssiT.BackEnd.Application.Services.Commands.UserCommands.UpdateUser;
using FluentValidation;

namespace AssiT.Core.Validators
{
    public class CreateUserValidator   : AbstractValidator<UpdateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O ID do usuario deve ser maior que zero.");

            When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .Length(8, 100)
                        .WithMessage("O email deve ter entre 8 e 100 caracteres.")
                    .EmailAddress()
                        .WithMessage("O email deve ser um email válido.");
            });
            When(x => !string.IsNullOrWhiteSpace(x.Name), () =>
            {
                RuleFor(x => x.Name)
                .MinimumLength(3)
                    .WithMessage("O nome deve ter no minimo 3 caracteres.");
            });
        }
    }
}
