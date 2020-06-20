using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Utils.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidator<TValidator, TEntity>(this IServiceCollection service) where TValidator : AbstractValidator<TEntity> 
            => service.AddTransient<IValidator<TEntity>, TValidator>();
    }
}
