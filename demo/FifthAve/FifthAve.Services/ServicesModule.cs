using FifthAve.Services.AccountIdentityService;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Services
{
    public static class ServicesModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            AccountIdentityServiceModule.AddTo(services);
            return services;
        }
    }
}