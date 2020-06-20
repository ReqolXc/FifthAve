using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Services.AccountIdentityService
{
    public static class AccountIdentityServiceModule
    {
        public static IServiceCollection AddTo(IServiceCollection services)
        {
            services.AddTransient<AccountIdentityService>();
            services.AddTransient<ValidationService>();
            return services;
        }
    }
}