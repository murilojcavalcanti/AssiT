using AssiT.BackEnd.Application.Services.Commands.UserCommands.CreateUser;
using FluentValidation;

namespace AssiT.Application.Validators.UserValidators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("A email é obrigatório.")
                .Length(8, 16)
                    .WithMessage("O email deve ter entre 3 e 100 caracteres.")
                .EmailAddress()
                    .WithMessage("O email deve ser um email valido.");

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MinimumLength(3)
                    .WithMessage("O nome deve ter no minimo 3 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("A senha é obrigatória.")
                .Length(8, 16)
                    .WithMessage("A senha deve ter entre 8 e 16 caracteres.")
                .Matches(@"[A-Z]")
                    .WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches(@"[a-z]")
                    .WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"[0-9]")
                    .WithMessage("A senha deve conter pelo menos um número.")
                .Matches(@"[^a-zA-Z0-9]")
                    .WithMessage("A senha deve conter pelo menos um caractere especial.");
        }
    }
}
