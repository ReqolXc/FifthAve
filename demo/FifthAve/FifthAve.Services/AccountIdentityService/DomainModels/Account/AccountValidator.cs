using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FifthAve.Core.Constants;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace FifthAve.Services.AccountIdentityService.DomainModels.Account
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
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
                .MaximumLength(ValidatorConstants.MiddleNameLength)
                .;

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.UsernameLength);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.PostsNumber)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
        }
    }
}
