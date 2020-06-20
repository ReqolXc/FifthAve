using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Api.StartUps.Authorization
{
    public static class AuthorizationModule
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization();
            return services;
        }
    }
}