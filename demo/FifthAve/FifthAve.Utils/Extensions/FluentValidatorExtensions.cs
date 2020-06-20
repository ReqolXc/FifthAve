using FifthAve.Utils.Validators;
using FluentValidation;
using FluentValidation.Validators;

namespace FifthAve.Utils.Extensions
{
    public static class FluentValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.SetValidator((IPropertyValidator)new PhoneNumberValidator());
    }
}
