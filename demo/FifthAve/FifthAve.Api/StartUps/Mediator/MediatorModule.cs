using FifthAve.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Api.StartUps.Mediator
{
    public static class MediatorModule
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(ServicesAssembly.Assembly, ApiAssembly.Assembly);
            return services;
        }
    }
}
