using FifthAve.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Api.StartUps.Configuration
{
    public static class ConfigurationModule
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var root = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var config = root.Get<AppConfiguration>();

            services.AddSingleton<IAppConfiguration, AppConfiguration>(x => config);
            
            return services;
        }
    }
}
