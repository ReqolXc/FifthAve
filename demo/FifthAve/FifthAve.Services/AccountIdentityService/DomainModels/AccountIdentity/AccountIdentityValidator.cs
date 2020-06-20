using FifthAve.Core.Constants;
using FluentValidation;

namespace FifthAve.Services.AccountIdentityService.DomainModels.AccountIdentity
{
    public class AccountIdentityValidator : AbstractValidator<AccountIdentity>
    {
        public AccountIdentityValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.UsernameLength);

            RuleFor(x => x.HashedPassword)
                .NotNull()
                .NotEmpty();
        }
    }
}
