using AutoMapper;
using FifthAve.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FifthAve.Api.StartUps.Mapping
{
    public static class MappingModule
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(ServicesAssembly.Assembly);
            return services;
        }
    }
}
