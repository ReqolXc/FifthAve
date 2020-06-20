using FifthAve.Core.Constants;
using FluentValidation;

namespace FifthAve.Services.AccountIdentityService.Handlers.JwtToken
{
    public class JwtTokenValidator : AbstractValidator<JwtTokenRequest>
    {
        public JwtTokenValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.UsernameLength);


            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ValidatorConstants.PasswordLength);
        }
    }
}