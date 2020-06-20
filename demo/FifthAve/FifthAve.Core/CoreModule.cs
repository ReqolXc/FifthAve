using FifthAve.Core.Database;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            DatabaseModule.AddTo(services);
            return services;
        }
    }
}
