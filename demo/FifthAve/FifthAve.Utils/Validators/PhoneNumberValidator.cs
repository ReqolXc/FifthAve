using System;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace FifthAve.Utils.Validators
{
    public class PhoneNumberValidator : PropertyValidator, IRegularExpressionValidator, IPropertyValidator
    {
        public PhoneNumberValidator()
            : base((IStringSource)new LanguageStringSource(nameof(EmailValidator)))
        { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            throw new NotImplementedException();
        }


        public string? Expression { get; }
    }
}
