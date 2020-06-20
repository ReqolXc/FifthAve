using FifthAve.Core.Constants;
using FluentValidation;

namespace FifthAve.Services.AccountService.Handlers.CreateAccount
{
    public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.FirstNameLength);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.LastNameLength);

            RuleFor(x => x.MiddleName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.MiddleNameLength);

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.UsernameLength);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.PasswordLength);

            RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}
