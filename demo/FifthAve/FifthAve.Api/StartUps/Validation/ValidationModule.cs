using FifthAve.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Api.StartUps.Validation
{
    public static class ValidationModule
    {
        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                ServicesAssembly.Assembly
            };

            services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Singleton);
            return services;
        }
    }
}
