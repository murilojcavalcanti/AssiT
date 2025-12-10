using AssiT.Core.Entities;
using FluentValidation;

namespace AssiT.Core.Validators
{
    public class UserValidators   : AbstractValidator<User>
    {
        public UserValidators()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 16);
        }
    }
}
