using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace FifthAve.Api.StartUps.Serialization
{
    public static class JsonSerialization
    {
        public static IMvcBuilder AddJsonSerialization(this IMvcBuilder builder)
        {
            builder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            return builder;
        }
    }
}
